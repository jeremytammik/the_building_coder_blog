<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<link rel="stylesheet" type="text/css" href="bc.css">

<!--
https://prismjs.com
<pre><code class="language-cs">
-->
<link href="https://cdn.jsdelivr.net/npm/prismjs@1.29.0/themes/prism.min.css" rel="stylesheet" />
<script src="https://cdn.jsdelivr.net/npm/prismjs@1.29.0/components/prism-core.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/prismjs@1.29.0/plugins/autoloader/prism-autoloader.min.js"></script>
<style> code[class*=language-], pre[class*=language-] { font-size : 90%; } </style>

</head>

<!--

####<a name="14"></a> Create dimension to wall centerline, center of core, faces of core
  Create dimension to wall centerline, center of core, faces of core
  https://forums.autodesk.com/t5/revit-api-forum/create-dimension-to-wall-centerline-center-of-core-faces-of-core/m-p/13226893#M83096
  Code to create alignment to wall core center axis: (works as described above)

- i installed and tested promptimal
  /Users/jta/a/doc/revit/tbc/git/a/img/promptimal.png
  you are a wise and helpful BIM expert, experienced Revit application engineer and proficient .NET, Revit API add-in and BIM programmer. Can you please help with this Revit API question, maybe discussed in the Revit API discussion forum, by The Building Coder blog, or other Revit API resources: {original question}
  Score on iterations 0 (original) to 5: 58 63 67 67 68 70
  You are a knowledgeable and resourceful BIM expert, Revit application engineer, and skilled .NET and Revit API programmer. Your task is to address new questions raised in the Revit API discussion forum. Use insights from The Building Coder blog and other respected Revit API resources to provide clear, innovative solutions: {original question}

- generate 3D mesh model from a single photo
  https://huggingface.co/spaces/stabilityai/stable-point-aware-3d

twitter:

for #RevitAPI @AutodeskRevit
#BIM @DynamoBIM

&ndash; ...

linkedin:



#BIM #DynamoBIM #AutodeskAPS #Revit #API #IFC #SDK #Autodesk #AEC #adsk

the [Revit API discussion forum](http://forums.autodesk.com/t5/revit-api-forum/bd-p/160) thread

<center>
<img src="img/" alt="" title="" width="600"/>
<p style="font-size: 80%; font-style:italic"></p>
<a href="img/.gif"><p style="font-size: 80%; font-style:italic">Click for animation</p></a>
</center>

-->

### Wall Layer Voodoo and Prompt Optimisation



####<a name="2"></a> Dimension Wall Centre, Core and Faces

Andrzej [andrzej_m](https://forums.autodesk.com/t5/user/viewprofilepage/user-id/5857784) Matuszek proposes
a new solution to the long-standing issue on how
to [create dimension to wall centerline, center of core, faces of core](https://forums.autodesk.com/t5/revit-api-forum/create-dimension-to-wall-centerline-center-of-core-faces-of-core/m-p/13226893#M83096),
saying:

As far as I investigated, there is a rule that determines how indexed references that can be used for stable representation voodoo to create alignments are ordered.

For a multi-layer wall, I think the order is:

<pre>
  1: Center axis
  2: 1-2 layers face
  3: 2-3 layers face
  4: 3-4 layers face
  . . .
  N: Core Center axis
  N+1: Last face
  N+2: First face
</pre>

Here, N is the count of wall layers.

In the [long-standing discussion](https://forums.autodesk.com/t5/revit-api-forum/create-dimension-to-wall-centerline-center-of-core-faces-of-core/m-p/13226893),
I would like to add that when we change the wall instance type, already created references have to remain unchanged and probably new references are appended.

In the end, we have no guarantee that we will reference to proper face using manually created stable representations, unless we've just created the wall ourselves.

Here is Andrzej's code using stable representation voodoo to create alignment to wall core center axis:

<pre><code class="language-cs">  void CreateWallCoreAxisToGridAlignment(
    Grid newGrid,
    Wall wall)
  {
    var layersCount = wall.WallType.GetCompoundStructure()
      .GetLayers().Count();

    try
    {
      var stableRep = CreateStableRepresentation(wall, layersCount);

      var ref0 = Reference.ParseFromStableRepresentation(Doc, stableRep);

      Doc.Create.NewAlignment(View, newGrid.Curve.Reference, ref0);

      Debug.WriteLine("NewAlignment to standard stable representation created!");
    }
    catch (Exception ex)
    {
      var stableRefs = GetStableRepresentations(wall, layersCount + 7);

      foreach (var stRefStr in stableRefs)
      {
        try
        {
          var stRef = Reference.ParseFromStableRepresentation(Doc, stRefStr);

          if (stRef != null)
          {
            Doc.Create.NewAlignment(View, newGrid.Curve.Reference, stRef);
            Debug.WriteLine("NewAlignment to random stable representation created!!!");
            break;
          }
        }
        catch (Exception) { }
      }
    }
  }

  internal static string CreateStableRepresentation(
    Element element,
    int stRefIndex)
  {
    string uniqueID = element.UniqueId;

    return $"{uniqueID}:{stRefIndex}:SURFACE";
  }

  internal static List&lt;string&gt; GetStableRepresentations(
    Element element,
    int count)
  {
    var result = new List&lt;string&gt;();

    string uniqueID = element.UniqueId;

    for (int i = 0; i < count; i++)
    {
      result.Add($"{uniqueID}:{i}:SURFACE");
    }

    return result;
  }</code></pre>

Many thanks to Andrzej for sharing this.

####<a name="3"></a> Promptimal Revit API Prompt

Personally, I continue my quest of making good use of LLMs to help
answer [Revit API discussion forum](http://forums.autodesk.com/t5/revit-api-forum/bd-p/160) threads.
I recently mentioned
my [impending retirement](https://thebuildingcoder.typepad.com/blog/2025/01/back-again-to-unit-test-icons-viewports-and-more.html#3),
my [Revit API support prompt](https://thebuildingcoder.typepad.com/blog/2025/01/llm-prompting-rag-ingestion-and-new-projects.html#5), and
the [Promptimal prompt optimiser](https://thebuildingcoder.typepad.com/blog/2025/01/llm-prompting-rag-ingestion-and-new-projects.html#7).

I installed and tested Promptimal locally and asked it to improve the prompt I was using previously.
This is the prompt I started out with:

- you are a wise and helpful BIM expert, experienced Revit application engineer and proficient .NET, Revit API add-in and BIM programmer. Can you please help with this Revit API question, maybe discussed in the Revit API discussion forum, by The Building Coder blog, or other Revit API resources: {original question}

Promptimal reads the original prompt and asks you in which way you would like it improved.
As an improvement, I requested something like "ensure that a Revit API question in the discussion forum is correctly andswered and explained to a newbie".
Promptimal generates the improvement in an iterative process, in five steps, and calculates a score for the quality in each step.
In my first run, the scores on iterations 0 (original) to 5 were: 58 63 67 67 68 70, with the following end result:

- You are a knowledgeable and resourceful BIM expert, Revit application engineer, and skilled .NET and Revit API programmer. Your task is to address new questions raised in the Revit API discussion forum. Use insights from The Building Coder blog and other respected Revit API resources to provide clear, innovative solutions: {original question}

Small changes, but apparently significant.
Let's try one more runs, starting with the improved prompt above and requestion the improvement "Please improve this prompt to generate an answer to a highly specificult and difficult question raised by an experianced Revit add-in programmer."
Here are the times spent and the scores calculated on the initial processing and the five iteration steps: 0:28 68 0:17 70 0:36 70.4 0:33 72 0:27 74.4 0:25 74.4.

The improved prompt in this case is:

- You are a respected BIM expert and adept Revit application engineer with deep specialization in .NET and Revit API programming. Your task is to solve complex and challenging questions from experienced Revit add-in programmers in the Revit API discussion forum. Formulate clear, innovative, and comprehensive solutions utilizing insights from The Building Coder blog and other esteemed Revit API resources: {original question}

<center>
<img src="img/promptimal.png" alt="Promptimal" title="Promptimal" width="500"/>
</center>

Please try it out yourself in your own questions and let us know how you fare.

####<a name="4"></a>

Another surprising utility that might even come in handy populating your BIM with 3D objects is the functionality to generate 3D mesh model from a single photo provided by
the [SPAR3D stable point-aware reconstruction of 3D objects from single images](https://huggingface.co/spaces/stabilityai/stable-point-aware-3d).
I tried it out myself by simply creating a snapshot of a simple bookshelf and pasting that it.
For such a simple task, the result was perfect.

