#region Header
//
// Util.cs - The Building Coder Revit API utility methods
//
// Copyright (C) 2008-2015 by Jeremy Tammik,
// Autodesk Inc. All rights reserved.
//
#endregion // Header

#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using WinForms = System.Windows.Forms;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
#endregion // Namespaces

namespace BuildingCoder
{
  class Util
  {
    #region Geometrical Comparison
    const double _eps = 1.0e-9;

    public static double Eps
    {
      get
      {
        return _eps;
      }
    }

    public static double MinLineLength
    {
      get
      {
        return _eps;
      }
    }

    public static double TolPointOnPlane
    {
      get
      {
        return _eps;
      }
    }

    public static bool IsZero(
      double a,
      double tolerance )
    {
      return tolerance > Math.Abs( a );
    }

    public static bool IsZero( double a )
    {
      return IsZero( a, _eps );
    }

    public static bool IsEqual( double a, double b )
    {
      return IsZero( b - a );
    }

    public static int Compare( double a, double b )
    {
      return IsEqual( a, b ) ? 0 : ( a < b ? -1 : 1 );
    }

    public static int Compare( XYZ p, XYZ q )
    {
      int d = Compare( p.X, q.X );

      if( 0 == d )
      {
        d = Compare( p.Y, q.Y );

        if( 0 == d )
        {
          d = Compare( p.Z, q.Z );
        }
      }
      return d;
    }

    public static int Compare( Plane a, Plane b )
    {
      int d = Compare( a.Normal, b.Normal );

      if( 0 == d )
      {
        d = Compare( a.SignedDistanceTo( XYZ.Zero ),
          b.SignedDistanceTo( XYZ.Zero ) );

        if( 0 == d )
        {
          d = Compare( a.XVec.AngleOnPlaneTo(
            b.XVec, b.Normal ), 0 );
        }
      }
      return d;
    }

    public static bool IsEqual( XYZ p, XYZ q )
    {
      return 0 == Compare( p, q );
    }

    /// <summary>
    /// Return true if the given bounding box bb
    /// contains the given point p in its interior.
    /// </summary>
    public bool BoundingBoxXyzContains(
      BoundingBoxXYZ bb,
      XYZ p )
    {
      return 0 < Compare( bb.Min, p )
        && 0 < Compare( p, bb.Max );
    }

    /// <summary>
    /// Return true if the vectors v and w 
    /// are non-zero and perpendicular.
    /// </summary>
    bool IsPerpendicular( XYZ v, XYZ w )
    {
      double a = v.GetLength();
      double b = v.GetLength();
      double c = Math.Abs( v.DotProduct( w ) );
      return _eps < a
        && _eps < b
        && _eps > c;
      // c * c < _eps * a * b
    }

    public static bool IsParallel( XYZ p, XYZ q )
    {
      return p.CrossProduct( q ).IsZeroLength();
    }

    public static bool IsHorizontal( XYZ v )
    {
      return IsZero( v.Z );
    }

    public static bool IsVertical( XYZ v )
    {
      return IsZero( v.X ) && IsZero( v.Y );
    }

    public static bool IsVertical( XYZ v, double tolerance )
    {
      return IsZero( v.X, tolerance )
        && IsZero( v.Y, tolerance );
    }

    public static bool IsHorizontal( Edge e )
    {
      XYZ p = e.Evaluate( 0 );
      XYZ q = e.Evaluate( 1 );
      return IsHorizontal( q - p );
    }

    public static bool IsHorizontal( PlanarFace f )
    {
      return IsVertical( f.Normal );
    }

    public static bool IsVertical( PlanarFace f )
    {
      return IsHorizontal( f.Normal );
    }

    public static bool IsVertical( CylindricalFace f )
    {
      return IsVertical( f.Axis );
    }

    /// <summary>
    /// Minimum slope for a vector to be considered
    /// to be pointing upwards. Slope is simply the
    /// relationship between the vertical and
    /// horizontal components.
    /// </summary>
    const double _minimumSlope = 0.3;

    /// <summary>
    /// Return true if the Z coordinate of the
    /// given vector is positive and the slope
    /// is larger than the minimum limit.
    /// </summary>
    public static bool PointsUpwards( XYZ v )
    {
      double horizontalLength = v.X * v.X + v.Y * v.Y;
      double verticalLength = v.Z * v.Z;

      return 0 < v.Z
        && _minimumSlope
          < verticalLength / horizontalLength;

      //return _eps < v.Normalize().Z;
      //return _eps < v.Normalize().Z && IsVertical( v.Normalize(), tolerance );
    }

    /// <summary>
    /// Return the maximum value from an array of real numbers.
    /// </summary>
    public static double Max( double[] a )
    {
      Debug.Assert( 1 == a.Rank, "expected one-dimensional array" );
      Debug.Assert( 0 == a.GetLowerBound( 0 ), "expected zero-based array" );
      Debug.Assert( 0 < a.GetUpperBound( 0 ), "expected non-empty array" );
      double max = a[0];
      for( int i = 1; i <= a.GetUpperBound( 0 ); ++i )
      {
        if( max < a[i] )
        {
          max = a[i];
        }
      }
      return max;
    }
    #endregion // Geometrical Comparison

    #region Geometrical XYZ Calculation
    /// <summary>
    /// Return the midpoint between two points.
    /// </summary>
    public static XYZ Midpoint( XYZ p, XYZ q )
    {
      return p + 0.5 * ( q - p );
    }

    /// <summary>
    /// Return the midpoint of a Line.
    /// </summary>
    public static XYZ Midpoint( Line line )
    {
      return Midpoint( line.GetEndPoint( 0 ),
        line.GetEndPoint( 1 ) );
    }

    /// <summary>
    /// Return the normal of a Line in the XY plane.
    /// </summary>
    public static XYZ Normal( Line line )
    {
      XYZ p = line.GetEndPoint( 0 );
      XYZ q = line.GetEndPoint( 1 );
      XYZ v = q - p;

      //Debug.Assert( IsZero( v.Z ),
      //  "expected horizontal line" );

      return v.CrossProduct( XYZ.BasisZ ).Normalize();
    }

    /// <summary>
    /// Return the four XYZ corners of the given 
    /// bounding box in the XY plane at the minimum 
    /// Z elevation in the order lower left, lower 
    /// right, upper right, upper left:
    /// </summary>
    public static XYZ[] GetCorners( BoundingBoxXYZ b )
    {
      double z = b.Min.Z;

      return new XYZ[] {
        new XYZ( b.Min.X, b.Min.Y, z ),
        new XYZ( b.Max.X, b.Min.Y, z ),
        new XYZ( b.Max.X, b.Max.Y, z ),
        new XYZ( b.Min.X, b.Max.Y, z ) 
      };
    }
    #endregion // Geometrical XYZ Calculation

    #region Unit Handling
    /// <summary>
    /// Base units currently used internally by Revit.
    /// </summary>
    enum BaseUnit
    {
      BU_Length = 0,         // length, feet (ft)
      BU_Angle,              // angle, radian (rad)
      BU_Mass,               // mass, kilogram (kg)
      BU_Time,               // time, second (s)
      BU_Electric_Current,   // electric current, ampere (A)
      BU_Temperature,        // temperature, kelvin (K)
      BU_Luminous_Intensity, // luminous intensity, candela (cd)
      BU_Solid_Angle,        // solid angle, steradian (sr)

      NumBaseUnits
    };

    const double _convertFootToMm = 12 * 25.4;

    const double _convertFootToMeter
      = _convertFootToMm * 0.001;

    const double _convertCubicFootToCubicMeter
      = _convertFootToMeter
      * _convertFootToMeter
      * _convertFootToMeter;

    /// <summary>
    /// Convert a given length in feet to millimetres.
    /// </summary>
    public static double FootToMm( double length )
    {
      return length * _convertFootToMm;
    }

    /// <summary>
    /// Convert a given length in millimetres to feet.
    /// </summary>
    public static double MmToFoot( double length )
    {
      return length / _convertFootToMm;
    }

    /// <summary>
    /// Convert a given point or vector from millimetres to feet.
    /// </summary>
    public static XYZ MmToFoot( XYZ v )
    {
      return v.Divide( _convertFootToMm );
    }

    /// <summary>
    /// Convert a given volume in feet to cubic meters.
    /// </summary>
    public static double CubicFootToCubicMeter( double volume )
    {
      return volume * _convertCubicFootToCubicMeter;
    }

    /// <summary>
    /// Hard coded abbreviations for the first 26
    /// DisplayUnitType enumeration values.
    /// </summary>
    public static string[] DisplayUnitTypeAbbreviation
      = new string[] {
      "m", // DUT_METERS = 0,
      "cm", // DUT_CENTIMETERS = 1,
      "mm", // DUT_MILLIMETERS = 2,
      "ft", // DUT_DECIMAL_FEET = 3,
      "N/A", // DUT_FEET_FRACTIONAL_INCHES = 4,
      "N/A", // DUT_FRACTIONAL_INCHES = 5,
      "in", // DUT_DECIMAL_INCHES = 6,
      "ac", // DUT_ACRES = 7,
      "ha", // DUT_HECTARES = 8,
      "N/A", // DUT_METERS_CENTIMETERS = 9,
      "y^3", // DUT_CUBIC_YARDS = 10,
      "ft^2", // DUT_SQUARE_FEET = 11,
      "m^2", // DUT_SQUARE_METERS = 12,
      "ft^3", // DUT_CUBIC_FEET = 13,
      "m^3", // DUT_CUBIC_METERS = 14,
      "deg", // DUT_DECIMAL_DEGREES = 15,
      "N/A", // DUT_DEGREES_AND_MINUTES = 16,
      "N/A", // DUT_GENERAL = 17,
      "N/A", // DUT_FIXED = 18,
      "%", // DUT_PERCENTAGE = 19,
      "in^2", // DUT_SQUARE_INCHES = 20,
      "cm^2", // DUT_SQUARE_CENTIMETERS = 21,
      "mm^2", // DUT_SQUARE_MILLIMETERS = 22,
      "in^3", // DUT_CUBIC_INCHES = 23,
      "cm^3", // DUT_CUBIC_CENTIMETERS = 24,
      "mm^3", // DUT_CUBIC_MILLIMETERS = 25,
      "l" // DUT_LITERS = 26,
    };
    #endregion // Unit Handling

    #region Formatting
    /// <summary>
    /// Return an English plural suffix for the given
    /// number of items, i.e. 's' for zero or more
    /// than one, and nothing for exactly one.
    /// </summary>
    public static string PluralSuffix( int n )
    {
      return 1 == n ? "" : "s";
    }

    /// <summary>
    /// Return an English plural suffix 'ies' or
    /// 'y' for the given number of items.
    /// </summary>
    public static string PluralSuffixY( int n )
    {
      return 1 == n ? "y" : "ies";
    }

    /// <summary>
    /// Return a dot (full stop) for zero
    /// or a colon for more than zero.
    /// </summary>
    public static string DotOrColon( int n )
    {
      return 0 < n ? ":" : ".";
    }

    /// <summary>
    /// Return a string for a real number
    /// formatted to two decimal places.
    /// </summary>
    public static string RealString( double a )
    {
      return a.ToString( "0.##" );
    }

    /// <summary>
    /// Return a string representation in degrees
    /// for an angle given in radians.
    /// </summary>
    public static string AngleString( double angle )
    {
      return RealString( angle * 180 / Math.PI ) + " degrees";
    }

    /// <summary>
    /// Return a string for a length in millimetres
    /// formatted to two decimal places.
    /// </summary>
    public static string MmString( double length )
    {
      return RealString( FootToMm( length ) ) + " mm";
    }

    /// <summary>
    /// Return a string for a UV point
    /// or vector with its coordinates
    /// formatted to two decimal places.
    /// </summary>
    public static string PointString( UV p )
    {
      return string.Format( "({0},{1})",
        RealString( p.U ),
        RealString( p.V ) );
    }

    /// <summary>
    /// Return a string for an XYZ point
    /// or vector with its coordinates
    /// formatted to two decimal places.
    /// </summary>
    public static string PointString( XYZ p )
    {
      return string.Format( "({0},{1},{2})",
        RealString( p.X ),
        RealString( p.Y ),
        RealString( p.Z ) );
    }

    /// <summary>
    /// Return a string for this bounding box
    /// with its coordinates formatted to two
    /// decimal places.
    /// </summary>
    public static string BoundingBoxString( BoundingBoxUV bb )
    {
      return string.Format( "({0},{1})",
        PointString( bb.Min ),
        PointString( bb.Max ) );
    }

    /// <summary>
    /// Return a string for this bounding box
    /// with its coordinates formatted to two
    /// decimal places.
    /// </summary>
    public static string BoundingBoxString( BoundingBoxXYZ bb )
    {
      return string.Format( "({0},{1})",
        PointString( bb.Min ),
        PointString( bb.Max ) );
    }

    /// <summary>
    /// Return a string for this plane
    /// with its coordinates formatted to two
    /// decimal places.
    /// </summary>
    public static string PlaneString( Plane p )
    {
      return string.Format( "plane origin {0}, plane normal {1}",
        PointString( p.Origin ),
        PointString( p.Normal ) );
    }

    /// <summary>
    /// Return a string for this transformation
    /// with its coordinates formatted to two
    /// decimal places.
    /// </summary>
    public static string TransformString( Transform t )
    {
      return string.Format( "({0},{1},{2},{3})", PointString( t.Origin ),
        PointString( t.BasisX ), PointString( t.BasisY ), PointString( t.BasisZ ) );
    }

    /// <summary>
    /// Return a string for this point array
    /// with its coordinates formatted to two
    /// decimal places.
    /// </summary>
    public static string PointArrayString( IList<XYZ> pts )
    {
      string s = string.Empty;
      foreach( XYZ p in pts )
      {
        if( 0 < s.Length )
        {
          s += ", ";
        }
        s += PointString( p );
      }
      return s;
    }

    /// <summary>
    /// Return a string representing the data of a
    /// curve. Currently includes detailed data of
    /// line and arc elements only.
    /// </summary>
    public static string CurveString( Curve c )
    {
      string s = c.GetType().Name.ToLower();

      XYZ p = c.GetEndPoint( 0 );
      XYZ q = c.GetEndPoint( 1 );

      s += string.Format( " {0} --> {1}",
        PointString( p ), PointString( q ) );

      // To list intermediate points or draw an
      // approximation using straight line segments,
      // we can access the curve tesselation, cf.
      // CurveTessellateString:

      //foreach( XYZ r in lc.Curve.Tessellate() )
      //{
      //}

      // List arc data:

      Arc arc = c as Arc;

      if( null != arc )
      {
        s += string.Format( " center {0} radius {1}",
          PointString( arc.Center ), arc.Radius );
      }

      // Todo: add support for other curve types
      // besides line and arc.

      return s;
    }

    /// <summary>
    /// Return a string for this curve with its
    /// tessellated point coordinates formatted
    /// to two decimal places.
    /// </summary>
    public static string CurveTessellateString(
      Curve curve )
    {
      return "curve tessellation "
        + PointArrayString( curve.Tessellate() );
    }

    /// <summary>
    /// Convert a UnitSymbolType enumeration value
    /// to a brief human readable abbreviation string.
    /// </summary>
    public static string UnitSymbolTypeString(
      UnitSymbolType u )
    {
      string s = u.ToString();

      Debug.Assert( s.StartsWith( "UST_" ),
        "expected UnitSymbolType enumeration value "
        + "to begin with 'UST_'" );

      s = s.Substring( 4 )
        .Replace( "_SUP_", "^" )
        .ToLower();

      return s;
    }
    #endregion // Formatting

    #region Display a message
    const string _caption = "The Building Coder";

    public static void InfoMsg( string msg )
    {
      Debug.WriteLine( msg );
      WinForms.MessageBox.Show( msg,
        _caption,
        WinForms.MessageBoxButtons.OK,
        WinForms.MessageBoxIcon.Information );
    }

    public static void InfoMsg2(
      string instruction,
      string content )
    {
      Debug.WriteLine( instruction + "\r\n" + content );
      TaskDialog d = new TaskDialog( _caption );
      d.MainInstruction = instruction;
      d.MainContent = content;
      d.Show();
    }

    public static void ErrorMsg( string msg )
    {
      Debug.WriteLine( msg );
      WinForms.MessageBox.Show( msg,
        _caption,
        WinForms.MessageBoxButtons.OK,
        WinForms.MessageBoxIcon.Error );
    }

    /// <summary>
    /// Return a string describing the given element:
    /// .NET type name,
    /// category name,
    /// family and symbol name for a family instance,
    /// element id and element name.
    /// </summary>
    public static string ElementDescription(
      Element e )
    {
      if( null == e )
      {
        return "<null>";
      }

      // For a wall, the element name equals the
      // wall type name, which is equivalent to the
      // family name ...

      FamilyInstance fi = e as FamilyInstance;

      string typeName = e.GetType().Name;

      string categoryName = ( null == e.Category )
        ? string.Empty
        : e.Category.Name + " ";

      string familyName = ( null == fi )
        ? string.Empty
        : fi.Symbol.Family.Name + " ";

      string symbolName = ( null == fi
        || e.Name.Equals( fi.Symbol.Name ) )
          ? string.Empty
          : fi.Symbol.Name + " ";

      return string.Format( "{0} {1}{2}{3}<{4} {5}>",
        typeName, categoryName, familyName,
        symbolName, e.Id.IntegerValue, e.Name );
    }
    #endregion // Display a message

    #region Element Selection
    public static Element SelectSingleElement(
      UIDocument uidoc,
      string description )
    {
      if( ViewType.Internal == uidoc.ActiveView.ViewType )
      {
        TaskDialog.Show( "Error",
          "Cannot pick element in this view: "
          + uidoc.ActiveView.Name );

        return null;
      }

#if _2010
    sel.Elements.Clear();
    Element e = null;
    sel.StatusbarTip = "Please select " + description;
    if( sel.PickOne() )
    {
      ElementSetIterator elemSetItr
        = sel.Elements.ForwardIterator();
      elemSetItr.MoveNext();
      e = elemSetItr.Current as Element;
    }
    return e;
#endif // _2010

      try
      {
        Reference r = uidoc.Selection.PickObject(
          ObjectType.Element,
          "Please select " + description );

        // 'Autodesk.Revit.DB.Reference.Element' is
        // obsolete: Property will be removed. Use
        // Document.GetElement(Reference) instead.
        //return null == r ? null : r.Element; // 2011

        return uidoc.Document.GetElement( r ); // 2012
      }
      catch( Autodesk.Revit.Exceptions.OperationCanceledException )
      {
        return null;
      }
    }

    public static Element GetSingleSelectedElement(
      UIDocument uidoc )
    {
      ICollection<ElementId> ids
        = uidoc.Selection.GetElementIds();

      Element e = null;

      if( 1 == ids.Count )
      {
        foreach( ElementId id in ids )
        {
          e = uidoc.Document.GetElement( id );
        }
      }
      return e;
    }

    static bool HasRequestedType(
      Element e,
      Type t,
      bool acceptDerivedClass )
    {
      bool rc = null != e;

      if( rc )
      {
        Type t2 = e.GetType();

        rc = t2.Equals( t );

        if( !rc && acceptDerivedClass )
        {
          rc = t2.IsSubclassOf( t );
        }
      }
      return rc;
    }

    public static Element SelectSingleElementOfType(
      UIDocument uidoc,
      Type t,
      string description,
      bool acceptDerivedClass )
    {
      Element e = GetSingleSelectedElement( uidoc );

      if( !HasRequestedType( e, t, acceptDerivedClass ) )
      {
        e = Util.SelectSingleElement(
          uidoc, description );
      }
      return HasRequestedType( e, t, acceptDerivedClass )
        ? e
        : null;
    }

    /// <summary>
    /// Retrieve all pre-selected elements of the specified type,
    /// if any elements at all have been pre-selected. If not,
    /// retrieve all elements of specified type in the database.
    /// </summary>
    /// <param name="a">Return value container</param>
    /// <param name="uidoc">Active document</param>
    /// <param name="t">Specific type</param>
    /// <returns>True if some elements were retrieved</returns>
    public static bool GetSelectedElementsOrAll(
      List<Element> a,
      UIDocument uidoc,
      Type t )
    {
      Document doc = uidoc.Document;

      ICollection<ElementId> ids
        = uidoc.Selection.GetElementIds();

      if( 0 < ids.Count )
      {
        a.AddRange( ids
          .Select<ElementId, Element>(
            id => doc.GetElement( id ) )
          .Where<Element>(
            e => t.IsInstanceOfType( e ) ) );
      }
      else
      {
        a.AddRange( new FilteredElementCollector( doc )
          .OfClass( t ) );
      }
      return 0 < a.Count;
    }
    #endregion // Element Selection

    #region Element filtering
    /// <summary>
    /// Return all elements of the requested class i.e. System.Type
    /// matching the given built-in category in the given document.
    /// </summary>
    public static FilteredElementCollector GetElementsOfType(
      Document doc,
      Type type,
      BuiltInCategory bic )
    {
      FilteredElementCollector collector
        = new FilteredElementCollector( doc );

      collector.OfCategory( bic );
      collector.OfClass( type );

      return collector;
    }

    /// <summary>
    /// Return the first element of the given type and name.
    /// </summary>
    public static Element GetFirstElementOfTypeNamed(
      Document doc,
      Type type,
      string name )
    {
      FilteredElementCollector collector
        = new FilteredElementCollector( doc )
          .OfClass( type );

#if EXPLICIT_CODE

      // explicit iteration and manual checking of a property:

      Element ret = null;
      foreach( Element e in collector )
      {
        if( e.Name.Equals( name ) )
        {
          ret = e;
          break;
        }
      }
      return ret;
#endif // EXPLICIT_CODE

#if USE_LINQ

      // using LINQ:

      IEnumerable<Element> elementsByName =
        from e in collector
        where e.Name.Equals( name )
        select e;

      return elementsByName.First<Element>();
#endif // USE_LINQ

      // using an anonymous method:

      // if no matching elements exist, First<> throws an exception.

      //return collector.Any<Element>( e => e.Name.Equals( name ) )
      //  ? collector.First<Element>( e => e.Name.Equals( name ) )
      //  : null;

      // using an anonymous method to define a named method:

      Func<Element, bool> nameEquals = e => e.Name.Equals( name );

      return collector.Any<Element>( nameEquals )
        ? collector.First<Element>( nameEquals )
        : null;
    }

    /// <summary>
    /// Return the first 3D view which is not a template,
    /// useful for input to FindReferencesByDirection().
    /// In this case, one cannot use FirstElement() directly,
    /// since the first one found may be a template and
    /// unsuitable for use in this method.
    /// This demonstrates some interesting usage of
    /// a .NET anonymous method.
    /// </summary>
    public static Element GetFirstNonTemplate3dView( Document doc )
    {
      FilteredElementCollector collector
        = new FilteredElementCollector( doc );

      collector.OfClass( typeof( View3D ) );

      return collector
        .Cast<View3D>()
        .First<View3D>( v3 => !v3.IsTemplate );
    }

    /// <summary>
    /// Given a specific family and symbol name,
    /// return the appropriate family symbol.
    /// </summary>
    public static FamilySymbol FindFamilySymbol(
      Document doc,
      string familyName,
      string symbolName )
    {
      FilteredElementCollector collector
        = new FilteredElementCollector( doc )
          .OfClass( typeof( Family ) );

      foreach( Family f in collector )
      {
        if( f.Name.Equals( familyName ) )
        {
          //foreach( FamilySymbol symbol in f.Symbols ) // 2014

          ISet<ElementId> ids = f.GetFamilySymbolIds(); // 2015

          foreach( ElementId id in ids )
          {
            FamilySymbol symbol = doc.GetElement( id )
              as FamilySymbol;

            if( symbol.Name == symbolName )
            {
              return symbol;
            }
          }
        }
      }
      return null;
    }
    #endregion // Element filtering

    #region MEP utilities
    /// <summary>
    /// Return the given element's connector manager, 
    /// using either the family instance MEPModel or 
    /// directly from the MEPCurve connector manager
    /// for ducts and pipes.
    /// </summary>
    static ConnectorManager GetConnectorManager(
      Element e )
    {
      MEPCurve mc = e as MEPCurve;
      FamilyInstance fi = e as FamilyInstance;

      if( null == mc && null == fi )
      {
        throw new ArgumentException(
          "Element is neither an MEP curve nor a fitting." );
      }

      return null == mc
        ? fi.MEPModel.ConnectorManager
        : mc.ConnectorManager;
    }

    /// <summary>
    /// Return the element's connector at the given
    /// location, and its other connector as well, 
    /// in case there are exactly two of them.
    /// </summary>
    /// <param name="e">An element, e.g. duct, pipe or family instance</param>
    /// <param name="location">The location of one of its connectors</param>
    /// <param name="otherConnector">The other connector, in case there are just two of them</param>
    /// <returns>The connector at the given location</returns>
    static Connector GetConnectorAt(
      Element e,
      XYZ location,
      out Connector otherConnector )
    {
      otherConnector = null;

      Connector targetConnector = null;

      ConnectorManager cm = GetConnectorManager( e );

      bool hasTwoConnectors = 2 == cm.Connectors.Size;

      foreach( Connector c in cm.Connectors )
      {
        if( c.Origin.IsAlmostEqualTo( location ) )
        {
          targetConnector = c;

          if( !hasTwoConnectors )
          {
            break;
          }
        }
        else if( hasTwoConnectors )
        {
          otherConnector = c;
        }
      }
      return targetConnector;
    }

    /// <summary>
    /// Return the connector set element
    /// closest to the given point.
    /// </summary>
    static Connector GetConnectorClosestTo(
      ConnectorSet connectors,
      XYZ p )
    {
      Connector targetConnector = null;
      double minDist = double.MaxValue;

      foreach( Connector c in connectors )
      {
        double d = c.Origin.DistanceTo( p );

        if( d < minDist )
        {
          targetConnector = c;
          minDist = d;
        }
      }
      return targetConnector;
    }

    /// <summary>
    /// Return the connector on the element 
    /// closest to the given point.
    /// </summary>
    public static Connector GetConnectorClosestTo(
      Element e,
      XYZ p )
    {
      ConnectorManager cm = GetConnectorManager( e );

      return null == cm
        ? null
        : GetConnectorClosestTo( cm.Connectors, p );
    }

    /// <summary>
    /// Connect two MEP elements at a given point p.
    /// </summary>
    /// <exception cref="ArgumentException">Thrown if
    /// one of the given elements lacks connectors.
    /// </exception>
    public static void Connect(
      XYZ p,
      Element a,
      Element b )
    {
      ConnectorManager cm = GetConnectorManager( a );

      if( null == cm )
      {
        throw new ArgumentException(
          "Element a has no connectors." );
      }

      Connector ca = GetConnectorClosestTo(
        cm.Connectors, p );

      cm = GetConnectorManager( b );

      if( null == cm )
      {
        throw new ArgumentException(
          "Element b has no connectors." );
      }

      Connector cb = GetConnectorClosestTo(
        cm.Connectors, p );

      ca.ConnectTo( cb );
      //cb.ConnectTo( ca );
    }
    #endregion // MEP utilities
  }

  #region Extension Method Classes
  public static class JtElementExtensionMethods
  {
    /// <summary>
    /// Return the curve from a Revit database Element 
    /// location curve, if it has one.
    /// </summary>
    public static Curve GetCurve( this Element e )
    {
      Debug.Assert( null != e.Location,
        "expected an element with a valid Location" );

      LocationCurve lc = e.Location as LocationCurve;

      Debug.Assert( null != lc,
        "expected an element with a valid LocationCurve" );

      return lc.Curve;
    }
  }

  public static class JtPlaneExtensionMethods
  {
    /// <summary>
    /// Return the signed distance from 
    /// a plane to a given point.
    /// </summary>
    public static double SignedDistanceTo(
      this Plane plane,
      XYZ p )
    {
      Debug.Assert(
        Util.IsEqual( plane.Normal.GetLength(), 1 ),
        "expected normalised plane normal" );

      XYZ v = p - plane.Origin;

      return plane.Normal.DotProduct( v );
    }

    /// <summary>
    /// Project given 3D XYZ point onto plane.
    /// </summary>
    public static XYZ ProjectOnto(
      this Plane plane,
      XYZ p )
    {
      double d = plane.SignedDistanceTo( p );

      XYZ q = p + d * plane.Normal;

      Debug.Assert(
        Util.IsZero( plane.SignedDistanceTo( q ) ),
        "expected point on plane to have zero distance to plane" );

      return q;
    }

    /// <summary>
    /// Project given 3D XYZ point into plane, 
    /// returning the UV coordinates of the result 
    /// in the local 2D plane coordinate system.
    /// </summary>
    public static UV ProjectInto(
      this Plane plane,
      XYZ p )
    {
      XYZ q = plane.ProjectOnto( p );
      XYZ o = plane.Origin;
      XYZ d = q - o;
      double u = d.DotProduct( plane.XVec );
      double v = d.DotProduct( plane.YVec );
      return new UV( u, v );
    }
  }

  public static class JtEdgeArrayExtensionMethods
  {
    /// <summary>
    /// Return a polygon as a list of XYZ points from
    /// an EdgeArray. If any of the edges are curved,
    /// we retrieve the tessellated points, i.e. an
    /// approximation determined by Revit.
    /// </summary>
    public static List<XYZ> GetPolygon(
      this EdgeArray ea )
    {
      int n = ea.Size;

      List<XYZ> polygon = new List<XYZ>( n );

      foreach( Edge e in ea )
      {
        IList<XYZ> pts = e.Tessellate();

        n = polygon.Count;

        if( 0 < n )
        {
          Debug.Assert( pts[0]
            .IsAlmostEqualTo( polygon[n - 1] ),
            "expected last edge end point to "
            + "equal next edge start point" );

          polygon.RemoveAt( n - 1 );
        }
        polygon.AddRange( pts );
      }
      n = polygon.Count;

      Debug.Assert( polygon[0]
        .IsAlmostEqualTo( polygon[n - 1] ),
        "expected first edge start point to "
        + "equal last edge end point" );

      polygon.RemoveAt( n - 1 );

      return polygon;
    }
  }

  public static class JtFamilyParameterExtensionMethods
  {
    public static bool IsShared(
      this FamilyParameter familyParameter )
    {
      MethodInfo mi = familyParameter
        .GetType()
        .GetMethod( "getParameter",
          BindingFlags.Instance
          | BindingFlags.NonPublic );

      if( null == mi )
      {
        throw new InvalidOperationException(
          "Could not find getParameter method" );
      }

      var parameter = mi.Invoke( familyParameter,
        new object[] { } ) as Parameter;

      return parameter.IsShared;
    }
  }

  public static class JtFilteredElementCollectorExtensions
  {
    public static FilteredElementCollector OfClass<T>(
      this FilteredElementCollector collector )
        where T : Element
    {
      return collector.OfClass( typeof( T ) );
    }

    public static IEnumerable<T> OfType<T>(
      this FilteredElementCollector collector )
        where T : Element
    {
      return Enumerable.OfType<T>(
        collector.OfClass<T>() );
    }
  }
  #endregion // Extension Method Classes

  #region Compatibilty Methods by Magson Leone
  public static class CompatibiltyMethods
  {
    public static Element PegarElemento( this Document doc, ElementId id )
    {

      Element ele = null;
      //ele = doc.get_Element(id);
      //ele = doc.GetElement(id);
      MethodInfo met = doc.GetType().GetMethod( "get_Element", new Type[] { typeof( ElementId ) } );
      if( met == null )
        met = doc.GetType().GetMethod( "GetElement", new Type[] { typeof( ElementId ) } );
      ele = met.Invoke( doc, new object[] { id } ) as Element;
      return ele;
    }
    public static Element PegarElemento( this Document doc, Reference refe )
    {
      Element ele = null;
      ele = doc.GetElement( refe );
      return ele;
    }
    public static char PegarDecimalSymbol( this Document doc )
    {
      char valor = ',';
      MethodInfo met = doc.GetType().GetMethod( "GetUnits" );
      if( met != null )
      {
        object temp = met.Invoke( g.doc, null );
        PropertyInfo prop = temp.GetType().GetProperty( "DecimalSymbol" );
        object o = prop.GetValue( temp, null );
        if( o.ToString() == "Comma" )
          valor = ',';
        else
          valor = '.';
      }
      else
      {
        object temp = doc.GetType().GetProperty( "ProjectUnit" );
        PropertyInfo prop = temp.GetType().GetProperty( "DecimalSymbolType" );
        object o = prop.GetValue( temp, null );
        if( o.ToString() == "DST_COMMA" )
          valor = ',';
        else
          valor = '.';
      }
      return valor;
    }
    public static Element Nivel_( this Element ele )
    {
      Document doc = ele.Document;
      Element e = null;
      //e = ele.Level;
      //e = PegarElemento(doc, ele.LevelId);
      Type t = ele.GetType();
      if( t.GetProperty( "Level" ) != null )
        e = t.GetProperty( "Level" ).GetValue( ele, null ) as Element;
      else
        e = doc.PegarElemento( (ElementId) t.GetProperty( "LevelId" ).GetValue( ele, null ) );
      return e;

    }
    public static List<Material> Materiais_( this Element ele )
    {
      List<Material> mats = new List<Material>();
      //mats = ele.Materials.Cast<Material>().ToList();
      //mats = ele.GetMaterialIds(false).Select(a => PegarElemento(doc, a)).Cast<Material>().ToList();
      Type t = ele.GetType();
      if( t.GetProperty( "Materials" ) != null )
        mats = ( (IEnumerable) t.GetProperty( "Materials" ).GetValue( ele, null ) ).Cast<Material>().ToList();
      else
      {
        Document doc = ele.Document;
        MethodInfo met = t.GetMethod( "GetMaterialIds", new Type[] { typeof( bool ) } );
        mats = ( (ICollection<ElementId>) met.Invoke( ele, new object[] { false } ) ).Select( a => PegarElemento( doc, a ) ).Cast<Material>().ToList();
      }
      return mats;
    }
    public static List<Element> Elementos( this Autodesk.Revit.UI.Selection.Selection sel )
    {
      List<Element> list_elements = new List<Element>();
      //list_elements = sel.Elements.Cast<Element>().ToList();
      //list_elements = sel.PegarElementoIds().ToList().Select(a => PegarElemento(doc, a)).ToList();
      Type t = sel.GetType();
      if( t.GetProperty( "PegarElementoIds" ) != null )
      {
        MethodInfo met = t.GetMethod( "PegarElementoIds" );
        list_elements = ( (ICollection<ElementId>) met.Invoke( sel, null ) ).Select( a => PegarElemento( doc, a ) ).ToList();

      }
      else
      {
        list_elements = ( (SelElementSet) t.GetProperty( "Elements" ).GetValue( sel, null ) ).Cast<Element>().ToList();

      }
      return list_elements;
    }
    //public static void Clear(this Autodesk.Revit.UI.Selection.Selection sel)
    //{
    //    sel.Elements.Clear();



    //}
    public static Parameter PegarParametro_( this Element ele, string nome_paramentro )
    {
      Parameter pa = null;
      //pa = ele.get_Parameter(nome_paramentro);
      //pa = ele.LookupParameter(nome_paramentro);
      Type t = ele.GetType();
      MethodInfo met = t.GetMethod( "LookupParameter", new Type[] { typeof( string ) } );
      if( met == null )
        met = t.GetMethod( "get_Parameter", new Type[] { typeof( string ) } );
      pa = met.Invoke( ele, new object[] { nome_paramentro } ) as Parameter;
      return pa;
    }
    public static Parameter PegarParametro_( this Element ele, BuiltInParameter builtInParameter )
    {
      Parameter pa = null;
      //pa = ele.get_Parameter(builtInParameter);
      //pa = ele.LookupParameter(builtInParameter);
      Type t = ele.GetType();
      MethodInfo met = t.GetMethod( "LookupParameter", new Type[] { typeof( BuiltInParameter ) } );
      if( met == null )
        met = t.GetMethod( "get_Parameter", new Type[] { typeof( BuiltInParameter ) } );
      pa = met.Invoke( ele, new object[] { builtInParameter } ) as Parameter;
      return pa;
    }
    public static Definition Criar( this Definitions definitions, string nome, ParameterType tipo, bool visibilidade )
    {
      Definition def = null;
      //def = definitions.Create(nome, tipo, visibilidade);
      //ExternalDefinitonCreationOptions ed = new ExternalDefinitonCreationOptions(nome, tipo);
      //ed.Visible = visibilidade;
      //def = definitions.Create(ed);
      List<Type> ls = doc.GetType().Assembly.GetTypes().Where( a => a.IsClass && a.Name == "ExternalDefinitonCreationOptions" ).ToList();

      if( ls.Count > 0 )
      {
        Type t = ls[0];

        ConstructorInfo c = t.GetConstructor( new Type[] { typeof( string ), typeof( ParameterType ) } );

        object ed = c.Invoke( new object[] { nome, tipo } );

        ed.GetType().GetProperty( "Visible" ).SetValue( ed, visibilidade, null );

        def = definitions.GetType().GetMethod( "Create", new Type[] { t } ).Invoke( definitions, new object[] { ed } ) as Definition;
      }
      else
      {
        def = definitions.GetType().GetMethod( "Create", new Type[] { typeof( string ), typeof( ParameterType ), typeof( bool ) } ).Invoke( definitions, new object[] { nome, tipo, visibilidade } ) as Definition;
      }

      return def;
    }
    public static double PegarMaterialArea_( this Element ele, Material m )
    {
      double valor = 0;
      //valor = ele.GetMaterialArea(m);
      //valor = ele.GetMaterialArea(m.Id, false);
      Type t = ele.GetType();
      MethodInfo met = t.GetMethod( "GetMaterialArea", new Type[] { typeof( ElementId ), typeof( bool ) } );
      if( met != null )
      {
        valor = (double) met.Invoke( ele, new object[] { m.Id, false } );
      }
      else
      {
        met = t.GetMethod( "GetMaterialArea", new Type[] { typeof( Element ) } );
        valor = (double) met.Invoke( ele, new object[] { m } );
      }
      return valor;
    }
    public static XYZ PegarPonto( this Curve curva, int i )
    {
      XYZ p = null;
      //p = curva.GetEndPoint(i);
      //p = curva.PegarPonto(i);
      MethodInfo met = curva.GetType().GetMethod( "GetEndPoint", new Type[] { typeof( int ) } );
      if( met == null )
        met = curva.GetType().GetMethod( "get_EndPoint", new Type[] { typeof( int ) } );
      p = met.Invoke( curva, new object[] { i } ) as XYZ;
      return p;
    }
    public static Wall CriarParede( this Document document, Curve curve, ElementId wallTypeId, ElementId levelId, double height, double offset, bool flip, bool structural )
    {
      Wall w = null;
      //w = g.doc.Create.NewWall(curve, (WallType)g.doc.PegarElemento(wallTypeId), (Level)g.doc.PegarElemento(levelId), height, offset, flip, structural);
      //w = Wall.Create(document, curve, wallTypeId, levelId, height, offset, flip, structural);


      object[] parametros = new object[] { document, curve, wallTypeId, levelId, height, offset, flip, structural };
      Type[] tipos = parametros.Select( a => a.GetType() ).ToArray();

      MethodInfo met = typeof( Wall ).GetMethod( "Create", tipos );

      if( met != null )
      {
        w = met.Invoke( null, parametros ) as Wall;
      }
      else
      {
        parametros = new object[] { curve, (WallType) doc.PegarElemento( wallTypeId ), (Level) doc.PegarElemento( levelId ), height, offset, flip, structural };
        tipos = parametros.Select( a => a.GetType() ).ToArray();

        w = doc.Create.GetType().GetMethod( "NewWall", tipos ).Invoke( doc.Create, parametros ) as Wall;
      }

      return w;
    }
    public static Line CriarLinha( this Document document, XYZ p1, XYZ p2, bool bound = true )
    {
      Line l = null;
      //l = Line.CreateBound(p1, p2);
      //l = g.doc.Application.Create.NewLine(p1, p2, true);

      object[] parametros = new object[] { p1, p2 };
      Type[] tipos = parametros.Select( a => a.GetType() ).ToArray();
      string metodo = "CreateBound";
      if( bound == false ) metodo = "CreateUnbound";
      MethodInfo met = typeof( Line ).GetMethod( metodo, tipos );
      if( met != null )
      {
        l = met.Invoke( null, parametros ) as Line;
      }
      else
      {
        parametros = new object[] { p1, p2, bound };
        tipos = parametros.Select( a => a.GetType() ).ToArray();
        l = doc.Application.Create.GetType().GetMethod( "NewLine", tipos ).Invoke( doc.Application.Create, parametros ) as Line;
      }
      return l;
    }
    public static Arc CriarArco( this Document document, XYZ p1, XYZ p2, XYZ p3 )
    {
      Arc arc = null;
      //arc = g.doc.Application.Create.NewArc(p1, p2, p3);
      //arc = Arc.Create(p1, p2, p3);
      object[] parametros = new object[] { p1, p2, p3 };
      Type[] tipos = parametros.Select( a => a.GetType() ).ToArray();
      string metodo = "Create";
      MethodInfo met = typeof( Arc ).GetMethod( metodo, tipos );
      if( met != null )
      {
        arc = met.Invoke( null, parametros ) as Arc;
      }
      else
      {
        arc = doc.Application.Create.GetType().GetMethod( "NewArc", tipos ).Invoke( doc.Application.Create, parametros ) as Arc;
      }
      return arc;
    }
    public static void VirarParede( this Wall wall )
    {
      //wall.flip();
      //wall.Flip();
      string metodo = "Flip";
      MethodInfo met = typeof( Wall ).GetMethod( metodo );
      if( met != null )
      {
        met.Invoke( wall, null );
      }
      else
      {
        metodo = "flip";
        met = typeof( Wall ).GetMethod( metodo );
        met.Invoke( wall, null );
      }
    }
    public static void DesunirGeometria( this Document document, Element firstElement, Element secondElement )
    {
      try
      {
        //JoinGeometryUtils.UnjoinGeometry(document, firstElement, secondElement);
        List<Type> ls = doc.GetType().Assembly.GetTypes().Where( a => a.IsClass && a.Name == "JoinGeometryUtils" ).ToList();
        object[] parametros = new object[] { document, firstElement, secondElement };
        Type[] tipos = parametros.Select( a => a.GetType() ).ToArray();
        if( ls.Count > 0 )
        {
          Type t = ls[0];
          MethodInfo met = t.GetMethod( "UnjoinGeometry", tipos );
          met.Invoke( null, parametros );
        }
      }
      catch
      {

      }
    }
    public static void UnirGeometria( this Document document, Element firstElement, Element secondElement )
    {
      try
      {
        //JoinGeometryUtils.JoinGeometry(document, firstElement, secondElement);
        List<Type> ls = doc.GetType().Assembly.GetTypes().Where( a => a.IsClass && a.Name == "JoinGeometryUtils" ).ToList();
        object[] parametros = new object[] { document, firstElement, secondElement };
        Type[] tipos = parametros.Select( a => a.GetType() ).ToArray();
        if( ls.Count > 0 )
        {
          Type t = ls[0];
          MethodInfo met = t.GetMethod( "JoinGeometry", tipos );
          met.Invoke( null, parametros );
        }
      }
      catch
      {
      }
    }
    public static bool Est�Unido( this Document document, Element firstElement, Element secondElement )
    {
      bool b = false;
      //b = JoinGeometryUtils.AreElementsJoined(document, firstElement, secondElement);
      List<Type> ls = doc.GetType().Assembly.GetTypes().Where( a => a.IsClass && a.Name == "JoinGeometryUtils" ).ToList();
      object[] parametros = new object[] { document, firstElement, secondElement };
      Type[] tipos = parametros.Select( a => a.GetType() ).ToArray();
      if( ls.Count > 0 )
      {
        Type t = ls[0];
        MethodInfo met = t.GetMethod( "AreElementsJoined", tipos );
        b = (bool) met.Invoke( null, parametros );
      }
      return b;
    }
    public static ElementId PegarFonte( this Part part )
    {
      ElementId id = null;

      //id = part.GetSourceElementIds().First().HostElementId;
      //id = part.OriginalDividedElementId;

      PropertyInfo prop = part.GetType().GetProperty( "OriginalDividedElementId" );
      if( prop != null )
        id = prop.GetValue( part, null ) as ElementId;
      else
      {
        MethodInfo met = part.GetType().GetMethod( "GetSourceElementIds" );
        object temp = met.Invoke( part, null );
        met = temp.GetType().GetMethod( "First" );
        temp = met.Invoke( temp, null );
        prop = temp.GetType().GetProperty( "HostElementId" );
        id = prop.GetValue( temp, null ) as ElementId;
      }


      return id;
    }
    public static List<GeometryObject> PegarObjetosGeometricos( this Element ele )
    {
      List<GeometryObject> list = new List<GeometryObject>();

      try
      {
        //geometryElement;
        //geometryElement.Objects;
        Options op = new Options();
        object obj = ele.get_Geometry( op );
        PropertyInfo prop = obj.GetType().GetProperty( "Objects" );
        if( prop != null )
        {
          obj = prop.GetValue( obj, null );
          IEnumerable arr = obj as IEnumerable;
          foreach( GeometryObject geo in arr )
          {
            list.Add( geo );
          }
        }
        else
        {
          IEnumerable<GeometryObject> geos = obj as IEnumerable<GeometryObject>;
          foreach( var geo in geos )
          {
            list.Add( geo );
          }
        }


        //System.Windows.Forms.MessageBox.Show(list.Count.ToString());
      }
      catch
      //(Exception ex)
      {
        //System.Windows.Forms.MessageBox.Show(ex.Message + ex.StackTrace);
        //mbox.TryCatch(ex);
      }

      return list;
    }
    public static bool CalcularVolumeDeArea( this Document doc, bool b )
    {
      //doc.Settings.VolumeCalculationSetting.VolumeCalculationOptions.VolumeComputationEnable = b;
      //AreaVolumeSettings.GetAreaVolumeSettings(doc).ComputeVolumes = b;

      try
      {
        List<Type> ls = doc.GetType().Assembly.GetTypes().Where( a => a.IsClass && a.Name == "AreaVolumeSettings" ).ToList();
        if( ls.Count > 0 )
        {
          Type t = ls[0];

          object[] parametros = new object[] { doc };
          Type[] tipos = parametros.Select( a => a.GetType() ).ToArray();
          MethodInfo met = t.GetMethod( "GetAreaVolumeSettings", tipos );
          object temp = met.Invoke( null, parametros );
          temp.GetType().GetProperty( "ComputeVolumes" ).SetValue( temp, b, null );
        }
        else
        {
          PropertyInfo prop = doc.Settings.GetType().GetProperty( "VolumeCalculationSetting" );
          object temp = prop.GetValue( doc.Settings, null );
          prop = temp.GetType().GetProperty( "VolumeCalculationOptions" );
          temp = prop.GetValue( temp, null );
          prop = temp.GetType().GetProperty( "VolumeComputationEnable" );
          prop.SetValue( temp, b, null );
        }
      }
      catch( Exception ex )
      {

        System.Windows.Forms.MessageBox.Show( ex.Message + ex.StackTrace );
      }

      return b;
    }
    public static void SetarSele��o( this Selection sel, ICollection<ElementId> elementos )
    {
      //sel.Elements.Clear();

      sel.LimparSele��o();


      //uidoc.Selection.Elements.Add(g.doc.PegarElemento(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value as ElementId));

      //SelElementSet aa;
      //sel.SetElementIds();

      object[] parametros = new object[] { elementos };
      Type[] tipos = parametros.Select( a => a.GetType() ).ToArray();

      MethodInfo met = sel.GetType().GetMethod( "SetElementIds", tipos );

      if( met != null )
      {
        met.Invoke( sel, parametros );
      }
      else
      {
        PropertyInfo prop = sel.GetType().GetProperty( "Elements" );
        object temp = prop.GetValue( sel, null );

        if( elementos.Count == 0 )
        {
          met = temp.GetType().GetMethod( "Clear" );
          met.Invoke( temp, null );
        }
        else
        {
          foreach( ElementId id in elementos )
          {
            Element elemento = doc.PegarElemento( id );


            parametros = new object[] { elemento };
            tipos = parametros.Select( a => a.GetType() ).ToArray();
            met = temp.GetType().GetMethod( "Add", tipos );
            met.Invoke( temp, parametros );
          }
        }

      }




    }
    public static void LimparSele��o( this Selection sel )
    {
      //sel.Elements.Clear();
      //sel.SetElementIds(new List<ElementId>());
      PropertyInfo prop = sel.GetType().GetProperty( "Elements" );
      if( prop != null )
      {
        object obj = prop.GetValue( sel, null );
        MethodInfo met = obj.GetType().GetMethod( "Clear" );
        met.Invoke( obj, null );
      }
      else
      {
        ICollection<ElementId> ids = new List<ElementId>();
        MethodInfo met = sel.GetType().GetMethod( "", new Type[] { ids.GetType() } );
        met.Invoke( sel, new object[] { ids } );
      }
    }

    public static ICollection<ElementId> PegarSele��o( this Selection sel )
    {
      return null;

    }

    public static void Deletar( this Document doc, Element ele )
    {
      //g.doc.Delete(ele);
      //g.doc.Delete(ele.Id);

      object obj = doc;
      MethodInfo met = obj.GetType().GetMethod( "Delete", new Type[] { typeof( Element ) } );
      if( met != null )
      {
        met.Invoke( obj, new object[] { ele } );
      }
      else
      {
        met = obj.GetType().GetMethod( "Delete", new Type[] { typeof( ElementId ) } );
        met.Invoke( obj, new object[] { ele.Id } );
      }
    }

    public static ElementId Duplicar( this View v )
    {
      ElementId id = null;

      //id = v.Duplicate(ViewDuplicateOption.WithDetailing);

      try
      {

        //JoinGeometryUtils.UnjoinGeometry(document, firstElement, secondElement);
        List<Type> ls = doc.GetType().Assembly.GetTypes().Where( a => a.IsEnum && a.Name == "ViewDuplicateOption" ).ToList();

        //if (ls.Count > 0)
        //{
        //    Type t = ls[0];

        //    MemberInfo[] memberInfos = t.GetMembers(BindingFlags.Public | BindingFlags.Static);
        //    string alerta = "";
        //    for (int i = 0; i < memberInfos.Length; i++)
        //    {
        //        //WithDetailing;
        //        alerta += memberInfos[i].Name + " - ";
        //        alerta += memberInfos[i].GetType().Name + "\n";
        //    }

        //    object obj = v;
        //    MethodInfo met = v.GetType().GetMethod("Duplicate", new Type[] { typeof(ViewDuplicateOption) });
        //    if (met != null)
        //    {
        //        id = met.Invoke(obj, new object[] { ViewDuplicateOption.WithDetailing }) as ElementId;
        //    }
        //}
      }
      catch( Exception ex )
      {
        //mbox.TryCatch(ex);
      }
      return id;
    }
  }
  #endregion // Compatibilty Methods by Magson Leone
}
