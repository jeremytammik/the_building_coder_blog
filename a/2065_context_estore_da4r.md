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

- check api context
  ricaun 2024-03
  https://thebuildingcoder.typepad.com/blog/2024/03/api-context-aps-toolkit-and-da4r-debugging.html#2
  roman nice3point 2024-08
  https://thebuildingcoder.typepad.com/blog/2024/08/api-context-background-process-postcommand.html#4
  ricaun 2025-01
  [How to know if Revit API is in Context](https://forums.autodesk.com/t5/revit-api-forum/how-to-know-if-revit-api-is-in-context/m-p/13276039#M83476)

- ricaun handles add-in id for extensible storage in DA4R to solve
  Revit Design Automation | Extensible Storage "Writing of Entities of this Schema is not allowed to the current add-in." Error
  https://forums.autodesk.com/t5/revit-api-forum/revit-design-automation-extensible-storage-quot-writing-of/m-p/13280384#M83582

@tristan-m I found a way to make the ActiveAddInId valid in the Design Automation Ready event.

You can create a custom ExternalSevice and register in the OnStartup and make the Design Automation Ready event to execute your custom ExternalSevice, the code inside the ExternalSevice is execute in the same AddIn Context.

I created a library to make easier to use DA4R and fix this issue by default.
https://github.com/ricaun-io/ricaun.Revit.DA


This is how the sample to check if the ActiveAddInId is not null in the DA4R event. In the code below the Execute method.
public class App : DesignApplication
{
    public override void OnStartup()
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"AddInId: \t{ControlledApplication.ActiveAddInId?.GetAddInName()}");
        Console.WriteLine("----------------------------------------");
    }

    public override void OnShutdown()
    {
    }

    public bool Execute(Application application, string filePath, Document document)
    {
        Console.WriteLine("----------------------------------------");
        Console.WriteLine($"AddInId: \t{application.ActiveAddInId?.GetAddInName()}");
        Console.WriteLine("----------------------------------------");

        return application.ActiveAddInId != null;
    }
}

I update my RevitAddin.DA.Tester project to use the library.
https://github.com/ricaun-io/RevitAddin.DA.Tester


Now I just need to create a DA4R template 😊


- ricaun's bundle package builder
  RevitAddinUtility usage and redistribution permissions.
  https://forums.autodesk.com/t5/revit-api-forum/revitaddinutility-usage-and-redistribution-permissions/td-p/8182324
  I actually recreate a similar package only to create the .addin and the PackageContent.xml. That what I have been using in my build process to create .bundle files for the Revit plugins.
  https://github.com/ricaun-io/Autodesk.PackageBuilder

- we discussed two workarounds to [Determine Elements Present in Section View]
  https://thebuildingcoder.typepad.com/blog/2024/01/directcontext3d-ids-and-linked-section-elements-.html#5
  now Wallas [@wl_santanna](https://forums.autodesk.com/t5/user/viewprofilepage/user-id/9728005) Santana presented the true solution, pointing out that:
  A new overload for the FilteredElementCollector class was added in revit 2024. It allows the user to input a linked document and retrieve the visible linked elements in a host document view.
  ApiDocs.co · Revit · FilteredElementCollector Constructor (Document, ElementId, ElementId)
  https://apidocs.co/apps/revit/2024/968b52a0-de55-2f96-de40-968812bc41c7.htm
  https://www.revitapidocs.com/2024/968b52a0-de55-2f96-de40-968812bc41c7.htm
  FilteredElementCollector(Document, ElementId, ElementId)
  Constructs a new FilteredElementCollector that will search and filter the visible elements from a Revit link in a host document view.
  Constructs a new FilteredElementCollector that will search and filter the visible elements from a Revit link in a host document view.

- https://autodesk.slack.com/archives/C0SR6NAP8/p1730892247924659
  Python versus .NET
  Q: regarding Revit and its scripting capabilities.
  It seems that Revit is shifting away from Python scripting in favor of .NET scripting. Is this accurate? If so, could you provide some insight into why this change is happening? Additionally, what does this mean for the future usability of Python scripts within Revit?
  We’re currently looking to use PyRevit, which relies on Python scripts, but we’re facing some challenges on the IT side (we’re using Sentinel—see this post for reference: https://github.com/pyrevitlabs/pyRevit/issues/1055). From Autodesk’s perspective, should we (and others) be converting our Python scripts to the .NET framework?".
  A1: I'm not sure how to answer the question about Python and .NET scripting.    We've always had an API based on .NET, which can be used from a variety of languages.  Among those is Python, as is offered by PyRevit or scripting in Dynamo nodes.
  Maybe the question is about changes brought in Revit 2025 when we switched to .NET Core.  But I believe PyRevit has a 2025 version and that Dynamo continues to support scripting.
  The new Macro Manager stopped supporting Python.
  Is that the source of the question?
  Moving away isn’t true, but ‘supporting’ on this one is a bit ambiguous which makes it feel that way for many. We support the CPython engine in Revit 2022 and up, but it has some limitations around some object types (in particular interfaces) which can be limiting for some users. The Dynamo team has put some pretty significant effort to sidestep limitations of PythonNet in order to enable as much as possible, but they are limited by that Python implementation. I expect better coverage to start being introduced in 2026 (see the Dynamo Public roadmap), but it’s never been fully compatible with the API and likely never will be.
  One thing which I think is imperative to note that we do not have any control or sway over the PyRevit team, nor any other 3rd part tool (such as Sentinel). Note that PyRevit relies almost entirely on IronPython 2 for most scripts as that Python engine has the most compatibility with the .NET environment. Yes that is IronPython2 which has not had any security updates since something like 2022 and has a dependency on Python 2 which hasn’t had any security updates since something like 2020… as such good infosec likely should block it by default - I would say this should include the Dynamo package to enable IronPython 2 as well.
  All of that said, the API is .NET so the most robust and accessible version of the API is .NET, and every interpreter layer in between that and the written code will only bring lower performance, stability, and scope, and Python is generally not the best option to scale automations as a result.
  (For anyone curious about my personal ordering of scaled efficiency I rank them as APS Design Automation, then external service and Revit Add-In, then Revit Add-In, then Dynamo / Python tools)  (edited)

- how to opt out of non-essential cookies?
  not so easy, check out the Google research on
  CookieEnforcer
  https://research.google/pubs/cookieenforcer-automated-cookie-notice-analysis-and-enforcement/
  and the accompanying research paper
  on [Automated Cookie Notice Analysis and Enforcement](https://www.usenix.org/system/files/sec23fall-prepub-389-khandelwal.pdf)
  using AI with machine learning and natural language processing

twitter:

#RevitAPI @AutodeskRevit #BIM @DynamoBIM

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

### API Context and Extensible Storage in DA4R


####<a name="2"></a> Check for Valid Revit API Context

Checking that the add-in code is currently executing within a valid Revit API context keeps spawning new solutions.

Luiz Henrique [@ricaun](https://ricaun.com/) Cassettari suggested one approach in March last year
by [attempting to subscribe to the application `Idling` event and catching the exception](https://thebuildingcoder.typepad.com/blog/2024/03/api-context-aps-toolkit-and-da4r-debugging.html#2) in
case of failure.
Throwing an exception is expensive and should be avoided if possible, so that approach is suboptimal.

Next, in August 2024, Roman [@Nice3point](https://t.me/nice3point) Karpovich, aka Роман Карпович, shared a more effective approach in
his [RevitToolkit.Context method](https://thebuildingcoder.typepad.com/blog/2024/08/api-context-background-process-postcommand.html#4).

Now, in Janauary 2025, Ricaun returns with a new solution by checking the application `ActiveAddInId` property, in
the [Revit API discussion forum](http://forums.autodesk.com/t5/revit-api-forum/bd-p/160) thread
on [how to know if Revit API is in context](https://forums.autodesk.com/t5/revit-api-forum/how-to-know-if-revit-api-is-in-context/m-p/13276039#M83476):

> Revit AddIn Context is what I'm calling the Revit API Context now.
I tested in a lot of places inside the Revit API and the `ActiveAddInId` is always valid because Revit tracks what AddInId is executing the code.
Some methods require to have an AddInId like the Extensible Storage, and when registering a `IExternalCommand` in a panel the command always generates the same AddInId that was used to register the command.
This is the basic code to check if [Revit is in the AddIn Context](https://ricaun.com/revit-addin-context/):

<pre><code class="language-cs">bool InAddInContext(UIApplication application)
{
  // ActiveAddInId is null when invoked outside Revit API context.
  return application.ActiveAddInId is not null;
}</code></pre>

There is only one place that the ActiveAddInId is null and Revit API in in Context, inside the APS Design Automation for Revit event.
That is a bug/limitation and what prompted me to take a closer look at the ActiveAddInId proprerty, discussed in more depth in the thread
on [Revit Design Automation Extensible Storage "Writing of Entities of this Schema is not allowed to the current add-in" error](https://forums.autodesk.com/t5/revit-api-forum/revit-design-automation-extensible-storage-quot-writing-of/td-p/12833018).
Because now I know how the ActiveAddInId works, I can use ExternalService inside Design Automation for Revit to make the event run in a valid ActiveAddInId.
So, I created
the [ricaun.Revit.DA Design Automation for Revit utility library](https://github.com/ricaun-io/ricaun.Revit.DA) to
fix that and another issue I'm having inside DA4R.

Many thanks to ricaun for discovering and sharing this, and all his other outstanding work with the Revit API and DA4R!

####<a name="3"></a> External Service Enables Extensible Storage in DA4R

Ricaun makes use of the add-in id understanding to address
the [Revit Design Automation Extensible Storage "Writing of Entities of this Schema is not allowed to the current add-in" error](https://forums.autodesk.com/t5/revit-api-forum/revit-design-automation-extensible-storage-quot-writing-of/m-p/13280384#M83582):

> I found a way to make the `ActiveAddInId` valid in the Design Automation Ready event.
You can create a custom `ExternalService`, register it in `OnStartup` and make the Design Automation Ready event to execute your custom ExternalService; the code inside the ExternalService is executed in the same AddIn Context.
I created
the [ricaun.Revit.DA Design Automation for Revit utility library](https://github.com/ricaun-io/ricaun.Revit.DA) to
fix this issue.

This is how the sample checks if the ActiveAddInId is not null in the DA4R event, in the code below the Execute method:

<pre><code class="language-cs">public class App : DesignApplication
{
  public override void OnStartup()
  {
    Console.WriteLine("----------------------------------------");
    Console.WriteLine($"AddInId: \t{ControlledApplication.ActiveAddInId?.GetAddInName()}");
    Console.WriteLine("----------------------------------------");
  }

  public override void OnShutdown()
  {
  }

  public bool Execute(Application application, string filePath, Document document)
  {
    Console.WriteLine("----------------------------------------");
    Console.WriteLine($"AddInId: \t{application.ActiveAddInId?.GetAddInName()}");
    Console.WriteLine("----------------------------------------");

    return application.ActiveAddInId != null;
  }
}</code></pre>

I updated my [RevitAddin.DA.Tester project](https://github.com/ricaun-io/RevitAddin.DA.Tester) to use the library.
Now I just need to create a DA4R template &nbsp;  :-)

Many thanks again to ricaun for solving this!

####<a name="4"></a> ricaun's bundle package builder

ricaun's bundle package builder
RevitAddinUtility usage and redistribution permissions.
https://forums.autodesk.com/t5/revit-api-forum/revitaddinutility-usage-and-redistribution-permissions/td-p/8182324
I actually recreate a similar package only to create the .addin and the PackageContent.xml. That what I have been using in my build process to create .bundle files for the Revit plugins.
https://github.com/ricaun-io/Autodesk.PackageBuilder

####<a name="2"></a> we discussed two workarounds to [Determine Elements Present in Section View]

we discussed two workarounds to [Determine Elements Present in Section View]
https://thebuildingcoder.typepad.com/blog/2024/01/directcontext3d-ids-and-linked-section-elements-.html#5
now Wallas [@wl_santanna](https://forums.autodesk.com/t5/user/viewprofilepage/user-id/9728005) Santana presented the true solution, pointing out that:
A new overload for the FilteredElementCollector class was added in revit 2024. It allows the user to input a linked document and retrieve the visible linked elements in a host document view.
ApiDocs.co · Revit · FilteredElementCollector Constructor (Document, ElementId, ElementId)
https://apidocs.co/apps/revit/2024/968b52a0-de55-2f96-de40-968812bc41c7.htm
https://www.revitapidocs.com/2024/968b52a0-de55-2f96-de40-968812bc41c7.htm
FilteredElementCollector(Document, ElementId, ElementId)
Constructs a new FilteredElementCollector that will search and filter the visible elements from a Revit link in a host document view.
Constructs a new FilteredElementCollector that will search and filter the visible elements from a Revit link in a host document view.

####<a name="2"></a> https://autodesk.slack.com/archives/C0SR6NAP8/p1730892247924659

https://autodesk.slack.com/archives/C0SR6NAP8/p1730892247924659
Python versus .NET
Q: regarding Revit and its scripting capabilities.
It seems that Revit is shifting away from Python scripting in favor of .NET scripting. Is this accurate? If so, could you provide some insight into why this change is happening? Additionally, what does this mean for the future usability of Python scripts within Revit?
We’re currently looking to use PyRevit, which relies on Python scripts, but we’re facing some challenges on the IT side (we’re using Sentinel—see this post for reference: https://github.com/pyrevitlabs/pyRevit/issues/1055). From Autodesk’s perspective, should we (and others) be converting our Python scripts to the .NET framework?".
A1: I'm not sure how to answer the question about Python and .NET scripting.    We've always had an API based on .NET, which can be used from a variety of languages.  Among those is Python, as is offered by PyRevit or scripting in Dynamo nodes.
Maybe the question is about changes brought in Revit 2025 when we switched to .NET Core.  But I believe PyRevit has a 2025 version and that Dynamo continues to support scripting.
The new Macro Manager stopped supporting Python.
Is that the source of the question?
Moving away isn’t true, but ‘supporting’ on this one is a bit ambiguous which makes it feel that way for many. We support the CPython engine in Revit 2022 and up, but it has some limitations around some object types (in particular interfaces) which can be limiting for some users. The Dynamo team has put some pretty significant effort to sidestep limitations of PythonNet in order to enable as much as possible, but they are limited by that Python implementation. I expect better coverage to start being introduced in 2026 (see the Dynamo Public roadmap), but it’s never been fully compatible with the API and likely never will be.
One thing which I think is imperative to note that we do not have any control or sway over the PyRevit team, nor any other 3rd part tool (such as Sentinel). Note that PyRevit relies almost entirely on IronPython 2 for most scripts as that Python engine has the most compatibility with the .NET environment. Yes that is IronPython2 which has not had any security updates since something like 2022 and has a dependency on Python 2 which hasn’t had any security updates since something like 2020… as such good infosec likely should block it by default - I would say this should include the Dynamo package to enable IronPython 2 as well.
All of that said, the API is .NET so the most robust and accessible version of the API is .NET, and every interpreter layer in between that and the written code will only bring lower performance, stability, and scope, and Python is generally not the best option to scale automations as a result.
(For anyone curious about my personal ordering of scaled efficiency I rank them as APS Design Automation, then external service and Revit Add-In, then Revit Add-In, then Dynamo / Python tools)  (edited)

####<a name="2"></a> how to opt out of non-essential cookies?

how to opt out of non-essential cookies?
not so easy, check out the Google research on
CookieEnforcer
https://research.google/pubs/cookieenforcer-automated-cookie-notice-analysis-and-enforcement/
and the accompanying research paper
on [Automated Cookie Notice Analysis and Enforcement](https://www.usenix.org/system/files/sec23fall-prepub-389-khandelwal.pdf)
using AI with machine learning and natural language processing




####<a name="2"></a>

<pre><code class="language-cs"></code></pre>


Many thanks to ricaun for discovering and sharing this!



<center>
<img src="img/" alt="" title="" width="600"/>
</center>

