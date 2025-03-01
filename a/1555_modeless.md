<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<link rel="stylesheet" type="text/css" href="bc.css">
<script src="run_prettify.js" type="text/javascript"></script>
<!--
<script src="https://google-code-prettify.googlecode.com/svn/loader/run_prettify.js" type="text/javascript"></script>
-->
</head>

<!---

- 12950036 [Family API]
- 12926140 [External .NET application]

External Access to the Revit API @AutodeskForge #ForgeDevCon #RevitAPI @AutodeskRevit #adsk #aec #bim #dynamobim http://bit.ly/modeless

We are currently being flooded with questions about a topic that has already been discussed repeatedly and in depth in the past, external access to the Revit API.
Possibly, the cause is the growing interest in implementing web driven solutions to generate RFA and RVT files.
It is in fact possible to implement a web server driving Revit in the background to execute such tasks, as demonstrated by the old sample showing how
to drive Revit through a WCF service and other examples listed in the topic group on Idling and external events for modeless access and driving Revit from outside
&ndash; Revit I/O and Forge
&ndash; Question
&ndash; Answer...

-->

### External Access to the Revit API

We are currently being flooded with questions about a topic that has already been discussed repeatedly and in depth in the past, external access to the Revit API.

- [Revit I/O and Forge](#2)
- [Question](#3)
- [Answer](#4)

#### <a name="2"></a>Revit I/O and Forge

Possibly, the cause is the growing interest in implementing web driven solutions to generate RFA and RVT files.

It is in fact possible to implement a web server driving Revit in the background to execute such tasks, as demonstrated by the old sample showing how
to [drive Revit through a WCF service](http://thebuildingcoder.typepad.com/blog/2012/11/drive-revit-through-a-wcf-service.html) and
other examples listed in The Building Code topic group
on [Idling and external events for modeless access and driving Revit from outside](http://thebuildingcoder.typepad.com/blog/about-the-author.html#5.28).

However, this kind of access is currently unreliable, since Revit is designed for interactive use, not batch processing.

Furthermore, it is not supported by the Revit desktop product license.

If you are interested in official support for this kind of service, please share
your [requirements, thoughts and input on Revit I/O](http://thebuildingcoder.typepad.com/blog/about-the-author.html#5.28b) with
us.

Future support for generating `RVT` and/or `RFA` files through a web service has already been announced as part of
the [Forge](https://developer.autodesk.com/)
[Design Automation API](https://developer.autodesk.com/en/docs/design-automation/v2/overview/).

At present, the API provides the ability to run scripts on AutoCAD `DWG` files, *with plans in the works to expand to file types generated by other design software*.

Current functionalities for DWG files include

- creating new DWG files
- querying for information in existing DWG files
- purging drawings and saving them to other DWF file formats
- plotting DWG files to DWF and PDF
- translating text from one language to another

Forge also already provides support for one `RVT` specific operation in the cloud today that may be of immediate interest to you, via
the [Model Derivative API](https://developer.autodesk.com/en/docs/model-derivative/v2/overview/); check out 
the [supported translation formats](https://developer.autodesk.com/en/docs/model-derivative/v2/overview/supported-translations/) and
note that `RVT` can be converted to `DWG` and `IFC`, besides the thumbnail and Forge-specific `SVF` formats.

If your requirements to access RVT files from an external context are driven by the need to view the BIM, not modify it, Forge can probably cover all your needs right now.


#### <a name="3"></a>Question

Returning to the question of external Revit API access today, one of the latest incarnations of this kind of question is
the [Revit API discussion forum](http://forums.autodesk.com/t5/revit-api-forum/bd-p/160) thread
on [how to load Revit file in API using C#](https://forums.autodesk.com/t5/revit-api-forum/how-to-load-revit-file-in-api-using-c/m-p/7071015),
also asked on [StackOverflow](http://stackoverflow.com/questions/43849917/how-to-load-revit-file-in-api-using-c):

I want to make use of the Revit API in C# code.

I am trying to export images of specific views from a Revit project.

How can I access the `ExternalCommandData` required by the `Execute` method?

<pre class="code"> 
<span style="color:blue;">public</span>&nbsp;Autodesk.Revit.UI.<span style="color:#2b91af;">Result</span>&nbsp;Execute(
&nbsp;&nbsp;<span style="color:#2b91af;">ExternalCommandData</span>&nbsp;revit,
&nbsp;&nbsp;<span style="color:blue;">ref</span>&nbsp;<span style="color:blue;">string</span>&nbsp;message,
&nbsp;&nbsp;<span style="color:#2b91af;">ElementSet</span>&nbsp;elements&nbsp;)
{
&nbsp;&nbsp;<span style="color:#2b91af;">UIApplication</span>&nbsp;uiapp&nbsp;=&nbsp;revit.Application;
}
</pre>

I want to browse `*.rvt` files and call the above method from a Windows form.

#### <a name="4"></a>Answer

You could very well make use of the Forge translation process and APIs mentioned above to achieve what you are asking for.

Revit itself, however, can only run plugins in-process, therefore you cannot use its API from an external WinForm app.

The `Execute` method you mention is a call-back method, implemented by a Revit add-in external command in a .NET assembly DLL loaded by Revit and called by Revit in a specific context.

Revit creates and passes in the `ExternalCommandData` information.

Calling directly into the Revit API from an external context yourself is, was and always has been illegal.
 
The Revit API cannot be used at all except within a valid Revit API context.
 
Such a context is provided exclusively by Revit call-back methods.
 
You need to subscribe to a Revit event, such as an external command `Execute` method, and let Revit call it for you.
 
Within the event handler, the Revit API can be used.
 
You can also use the Revit API to set up an external event that can be raised from a non-Revit-API context, such as your standalone external application.
 
This is demonstrated by the ModelessDialog/ModelessForm_ExternalEvent Revit SDK sample.

For more information on the Revit SDK, please refer to
the [getting started with the Revit API learning material](http://thebuildingcoder.typepad.com/blog/about-the-author.html#2).
 
This specific question has been answered and discussed in depth numerous times in the past, both in the Revit API discussion forum and by The Building Coder.
 
Many examples and further explanations are provided in The Building Code topic group
on [Idling and External Events for Modeless Access and Driving Revit from Outside](http://thebuildingcoder.typepad.com/blog/about-the-author.html#5.28).
 
Here are some other recent Revit API forum discussion threads addressing similar issues:

- [Calling of Revit API from external application not working in C&#35;](https://forums.autodesk.com/t5/revit-api-forum/calling-of-revit-api-from-external-application-not-workin-in-c/m-p/6752245)
- [Issue in running API from external application](https://forums.autodesk.com/t5/revit-api-forum/issue-in-running-api-from-external-application/m-p/6420798)
- [Standalone application &ndash; not plug-in &ndash; possible?](https://forums.autodesk.com/t5/revit-api-forum/standalone-application-not-plug-in-possible/td-p/4298946)
- [Updating a form from an external event handler](https://forums.autodesk.com/t5/revit-api-forum/updating-a-form-from-an-externalevent-handler/m-p/6935614)

<center>
<img src="img/stackoverflow_external_access.png" alt="StackOverflow question" width="523">
</center>

