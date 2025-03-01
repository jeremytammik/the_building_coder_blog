<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<link rel="stylesheet" type="text/css" href="bc.css">
<script src="https://cdn.rawgit.com/google/code-prettify/master/loader/run_prettify.js" type="text/javascript"></script>
</head>

<!---


twitter:

Auto-executing an external command in the #RevitAPI @AutodeskForge @AutodeskRevit #bim #DynamoBim #ForgeDevCon http://bit.ly/autoruncmd

I had an extensive discussion on automatically driving Revit from outside to auto-execute a simple functionality with no user input, originally implemented by an external command.
Also, a big thank you to all for the numerous congratulations on The Building Coder's eleventh birthday
&ndash; Auto-executing an external command
&ndash; Eleventh birthday congratulations...


linkedin:

Auto-executing an external command in the #RevitAPI

http://bit.ly/autoruncmd

I had an extensive discussion on automatically driving Revit from outside to auto-execute a simple functionality with no user input, originally implemented by an external command.

Also, a big thank you to all for the numerous congratulations on The Building Coder's eleventh birthday:

- Auto-executing an external command
- Eleventh birthday congratulations...

#bim #DynamoBim #ForgeDevCon #Revit #API #IFC #SDK #AI #VisualStudio #Autodesk #AEC #adsk

the [Revit API discussion forum](http://forums.autodesk.com/t5/revit-api-forum/bd-p/160) thread

<p style="font-size: 80%; font-style:italic"></p>

-->

### Auto-Executing an External Command

I had an extensive discussion on automatically driving Revit from outside to auto-execute a simple functionality with no user input, originally implemented by an external command.

Also, a big thank you to all for the numerous congratulations
on [The Building Coder's eleventh birthday](https://thebuildingcoder.typepad.com/blog/2019/08/11-years-and-revit-api-docs-full-text-search.html#2):

- [Auto-executing an external command](#2)
- [Eleventh birthday congratulations](#3)

####<a name="2"></a> Autorun an External Command

**Question:** I have an external command that I would prefer to execute automatically to avoid the need to manually start up Revit, open the RVT model, and launch the command. How can this be achieved?

**Answer:** Easy to solve, various approaches possible.

I would suggest starting out by trying to use a journal file as described for
the [IFC import and conversion  script](http://thebuildingcoder.typepad.com/blog/2010/07/ifc-import-and-conversion-journal-script.html).

Another simple approach is to implement an event handler for the `DocumentOpened` event and automatically process the document immediately as soon as it is opened.

Can you provide a short description of the top-level user interaction, the top-level Revit add-in API architecture, and the top-level RVT model context of the functionality you wish to run?

- Is it a single external command?
- Does the user push one single button to run it, and nothing else?
- Does it need to be run on all RVT files in a given directory?
- Can you implement a text file listing the RVT models to process?
- Is any user input at all required?

**Response:** Currently, we just open the model and click our export button.

That launches the code, running on that specific model along with all the links, and writing everything to some external SQLite and JSON files. No user interaction is required besides opening the model and clicking the button.

It is fully synchronized (not async), so it blocks the GUI until it finishes.

The interface we implement for Revit looks like this:

<pre class="code">
  [Transaction(TransactionMode.ReadOnly)]
  class Main: IExternalCommand
  {
    public Result Execute(
      ExternalCommandData commandData,
      ref string message,
      ElementSet elements)
    {
      using (Document doc
        = commandData.Application.ActiveUIDocument.Document)
      {
        using (RevitExport exporter = new RevitExport(doc))
        {
          Stopwatch st = Stopwatch.StartNew();
          exporter.ExportEverything();
          Debug.Print($"Elapsed time: {st.Elapsed.TotalSeconds} seconds");
        }
      }
    }
  }
</pre>

**Answer:** That sounds good.
This can indeed easily be converted to autorun.
The easiest solution might be to use the manual user interface and the Revit journal file functionality like this:

- Rename your input file `X.rvt` to `input.rvt`.
- Open Revit.
- In the Revit user interface, perform the following steps:
    - Open input.rvt.
    - Click your command button.
    - Shut down Revit.
- Look at the journal file generated by this process.
For instance, my journal files are generated in the folder *C:\Users\jeremy\AppData\Local\Autodesk\Revit\Autodesk Revit 2020\Journals*, and the most recent one is named *journal.0019.txt*.
- Rename the newest journal file to `process_input.txt`

Now you have completed the system setup.

You can process a new model `Y.rvt` by executing the following:

<pre>
copy Y.rvt input.rvt
"C:\Program Files\Autodesk\Revit 2020\Revit.exe" "C:\Users\...\Journals\process_input.txt"
</pre>

These two lines can be placed into a Windows batch or command file, and the original input filename specified as an argument.

Besides the IFC conversion example mentioned above, here is another article on various aspects
of [journal file replay](https://thebuildingcoder.typepad.com/blog/2009/07/journal-file-replay.html).

You should add some logging output to your external command, so that you have reliable information on whether the processing completed successfully.

The advantage of this approach is its simplicity.

The disadvantage is that you start up and close down Revit for each file processed.

However, since you can drive this automatically for any number of times, this is probably no problem if you have a couple of dozen files to process. If you have thousands, a more efficient approach would be needed.

More efficient approaches can easily be implemented inside your add-in code. For instance, you can implement another external command that processes multiple files by reading a text file listing the files to process. It can open them one by one programmatically and launch your process on each by calling a method taking a `Document` input argument. To prepare for this approach, rewrite your `Execute` method to extract the document from the command data, and pass that into a `Process` method taking the `Document` argument. With these two external commands in place, you have the choice of processing either one single file, the current open document, or an entire list of files, with one single click. 

Since Revit is not built for processing hundreds of files in batch mode, processing will fail sooner or later when working on a large number of files. Therefore, logging your progress is important. If you want the process to be fully automatic, you can implement additional functionality to check that it is still working, kill Revit if it has stopped, and restart again to continue processing whatever remains to be done. This kind of approach is documented in several articles on batch processing:

- [Batch rendering across several projects](https://thebuildingcoder.typepad.com/blog/2014/12/au-ends-and-batch-rendering-across-several-projects.html)
- [Batch processing Revit documents](https://thebuildingcoder.typepad.com/blog/2015/08/batch-processing-dwfx-links-and-future-proofing.html#4)
- [Batch processing Revit families and documents](https://thebuildingcoder.typepad.com/blog/2019/04/batch-processing-and-aspects-of-asstringvalue.html#2)

**Response:** Sounds good, I'll go ahead with this.
A few more questions:

- Do I have any way to add conditions? E.g., verify that all linked models are loaded?
- What if the plugin was modified? In that case I usually need to manually press "load plugin" on the popup. Can this be automated as well?

**Answer:** Good questions.

The journal file is totally stupid. It will exactly reproduce what you did manually when it was recorded.

If something goes wrong, it will behave exactly as if you were sitting there manually typing and clicking in the user interface.

Therefore, the safest (and only possible) approach is to ensure that nothing does go wrong.

If anything fails to load, the process will fail.

Therefore the need to log each successful processing and check afterwards that everything worked as expected.

To answer your specific questions:

- Can I add conditions, e.g., verify that linked models are loaded?

You can add such a check to your `Process` method and terminate gracefully if something is missing. Add the check to the external command first, ensure that it works and does something sensible in manual mode.

- What if the plugin was modified? In that case I usually need to manually press "load plugin" on the popup. Can it be automated?

The warning message can be eliminated completely by digitally signing the DLL. This issue is discussed extensively in the forum thread
on [code signing of Revit add-ins](http://forums.autodesk.com/t5/revit-api/code-signing-of-revit-addins/m-p/5981560).
The solution is documented in the Revit online help section
on [digitally signing your Revit add-in](https://help.autodesk.com/view/RVT/2020/ENU/?guid=Revit_API_Revit_API_Developers_Guide_Introduction_Add_In_Integration_Digitally_Signing_Your_Revit_Add_in_html).

Alternatively, every time the DLL is modified, load it manually once and click 'Always load'. From then on, the message will not appear again, as long as the DLL is not modified.


####<a name="3"></a> Thank you for your Eleventh Birthday Congratulations

Thank you very much for the lively response and numerous congratulations on The Building Coder's eleventh birthday!

Over a hundred LinkedIn reactions and over 4500 views there, over eighteen hundred Twitter impressions, almost a hundred Twitter 'engagements', and more, via other channels:

[Matt Taylor in a comment](https://thebuildingcoder.typepad.com/blog/2019/08/11-years-and-revit-api-docs-full-text-search.html#comment-4588231441):

> Happy birthday TBC!

[Adam Sheather on Twitter](https://twitter.com/Gytaco/status/1164728843266957312?s=20):

> Congrats mate! You are still my go-to site for Revit API problems, and the wealth of knowledge and time you put into the blog has provided unimaginable benefit for the community! Thank you!

[Amedeo Papi on LinkedIn](https://www.linkedin.com/feed/update/urn:li:activity:6570246697056780288?commentUrn=urn%3Ali%3Acomment%3A%28activity%3A6570246697056780288%2C6570455407364571136%29):

> Thank you, Jeremy Tammik, for everything you do for the #Autodesk users interested in development and programming!

[Philippe Leefsma on LinkedIn](https://www.linkedin.com/feed/update/urn:li:activity:6570246697056780288?commentUrn=urn%3Ali%3Acomment%3A%28activity%3A6570246697056780288%2C6570335510227632128%29):

> It will remain useful to Revit developers across the entire galaxy for centuries &nbsp; ;)

Thank you ever so much for all the good wishes!

<center>
<img src="img/tbc_11_twitter_engagements.png" alt="Twitter engagements" width="600">
</center>

####<a name="4"></a> LinkedIn Update 2019-08-28

156 LinkedIn reactions and 7 Comments:

- Aleksandr Akunets: Happy Birthday !
- Alex Vila Ortega: Happy community to have a helper so dedicated as you are! Happy B’day!
- Guillaume Joubert: Happy Birthday !!!
- Amedeo Papi: Thank you Jeremy Tammik for everything you do for the #Autodesk users interested in development and programming!
- Philippe Leefsma: It will remain useful to Revit developers across the entire galaxy for centuries;) 
- Mehmet Polat Diker: Thank you for opening up the gates of “Revit Api Magic” to all of us!
- Hoss Zamani: Thank you for the consistent support throughout these years Jeremy.
