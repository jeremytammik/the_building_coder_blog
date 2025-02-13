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

- Sam Altman shared [Three Observations](https://blog.samaltman.com/three-observations) offering insights likely related to AI developments, industry trends, or human potential. The content emphasises the ongoing evolution and impact of technology.

- Eason Kang published two blog posts about exporting IFC using Revit DA:
  https://aps.autodesk.com/blog/export-ifc-rvt-using-design-automation-api-revit-part-i
  https://aps.autodesk.com/blog/export-ifc-rvt-using-design-automation-api-revit-part-ii

- Use Revit API from a web app
  https://forums.autodesk.com/t5/revit-api-forum/use-revit-api-from-a-web-app/m-p/13314320
  Q: Is it possible to create a web app that manipulates a simple object in Revit "Beam for example".
  A: The pure Revit API is a Windows .NET API that requires a running session of Revit and a valid Revit API context to execute, which is only provided within a running session of Revit.exe on a Windows desktop PC. You can however also use the Revit API in the cloud on a virtual machine directly from a web app by making use of the Autodesk Platform Services APS Design Automation for Revit API:
  https://aps.autodesk.com/en/docs/design-automation/v3/developers_guide/overview/
  Chuong Ho adds, here is another idea you can play with:
  - Build the add-in and open a listener to get data from Revit: [Revit2GraphQL](https://github.com/BIMrxLAB/Revit2GraphQL)
  The GraphQL for Revit project contains a GraphQL endpoint for Revit that can be accessed locally as well as remotely over the web.
  Check out [BIMrx.Marconi.pdf](https://github.com/gregorvilkner/Revit2GraphQL/blob/master/BIMrx.Marconi%20SinglePage%201.1.pdf) for more information.

- The Impact of Generative AI on Critical Thinking: Self-Reported Reductions in Cognitive Effort and Confidence Effects From a Survey of Knowledge Workers
  https://www.microsoft.com/en-us/research/uploads/prod/2025/01/lee_2025_ai_critical_thinking_survey.pdf
  The rise of Generative AI (GenAI) in knowledge workflows raises questions about its impact on critical thinking skills and practices. We survey 319 knowledge workers to investigate 1) when and how they perceive the enaction of critical thinking when using GenAI, and 2) when and why GenAI affects their effort to do so. Participants shared 936 first-hand examples of using GenAI in work tasks. Quantitatively, when considering both task- and user-specific factors, a user’s task-specific self-confidence and confidence in GenAI are predictive of whether critical thinking is enacted and the effort of doing so in GenAI-assisted tasks. Specifically, higher confidence in GenAI is associated with less critical thinking, while higher self-confidence is associated with more critical thinking. Qualitatively, GenAI shifts the nature of critical thinking toward information verification, response integration, and task stewardship. Our insights reveal new design challenges and opportunities for developing GenAI tools for knowledge work.

- Revit API: Retrieving Room Data for Demolished Family Instances
  https://adndevblog.typepad.com/aec/2024/10/revit-api-retrieving-room-data-for-demolished-family-instances.html

- RST Results Package Create with Api
  https://forums.autodesk.com/t5/revit-api-forum/results-package-create-with-api/m-p/13093333
  Structural Analysis Toolkit, ResultsBuilder, Reviewing Stored Results in Revit
  https://forums.autodesk.com/t5/revit-api-forum/structural-analysis-toolkit-resultsbuilder-reviewing-stored/m-p/8778306

- uv
  https://autodesk.slack.com/archives/C016D5HE66T/p1738900731261749
  If you have not tried uv as a replacement for: pip, conda, poetry, pyenv, pip-tools - please give it a try.
  If you like how blazingly fast it is, you might be interested in learning the smart engineering behind it. Very great video.
  https://www.youtube.com/watch?v=gSKTfG1GXYQ
  uv: An Extremely Fast Python Package Manager
  It also let's us enable some interesting ways to run scripts. I've switched completely to uv for all my personal projects :)
  https://youtu.be/jXWIxk2brfk?si=Px8RLFYCRwbFiCzH
  Some tricks with UV and a new Python project: uvtrick!
  Those are very interesting tricks with uv! Thanks

twitter:

 #RevitAPI @AutodeskAPS @AutodeskRevit #BIM @DynamoBIM

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

###



I’m fine, although a bit busy, a bit overwhelmed, a bit in turmoil, too many things to do and stressing myself.

My two years younger brother is dying, and that is freaking me out a lot. Cancer, no digestion, no nutrition… could be days, could be weeks…

I hope to be able to calm down a bit gradually.

I am also overwhelmed by what is happening in the world, politically, climate, war.

At the same time, I am very excited about the AI revolution. Have you read Sam Altman’s three observations?

https://blog.samaltman.com/three-observations

Very exciting optimistic outlook into the near future.

Back on the negative side, we have the limits to growth with much evidence corroborating the prediction of a crash:

https://en.wikipedia.org/wiki/The_Limits_to_Growth

Image

Maybe the AI revolution predicted by Sam can help address the catastrophe predicted by the [limits to growth](https://en.wikipedia.org/wiki/The_Limits_to_Growth?

So, that is my short answer to your first question. Sorry if it is a bit overwhelming. I feel overwhelmed too.

Yes, my retirement, and the blog.

We are recruiting a replacement for me. The replacement needs to be based in Europe. You would be a cool candidate. Chuong Ho has expressed interest already and would be a great choice. I’ll ask him if he would be willing to relocate. Would you?

My guess is the blog will just stand still. New stuff will go into the APS blogs. Just a guess, though.

Thank you very much for the in-depth explanation about the unit testing!

That is very useful.

I wish you a great week as well!


####<a name="2"></a> Sam Altman shared [Three Observations](https://blog.samaltman.com/three-observations) offering insights likely related to AI developments, industry trends, or human potential. The content emphasises the ongoing evolution and impact of technology.

Sam Altman shared [Three Observations](https://blog.samaltman.com/three-observations) offering insights likely related to AI developments, industry trends, or human potential. The content emphasises the ongoing evolution and impact of technology.

the most interesting observation, i think, is that there is an exponential development in AI, similar to Moore's law.

2x computation power every 18 months.

well, sam altmans says that the AI intelligence has a similar exponential growth, much more extreme:

10x intelligence increase every 12 months.

he says, by 2035, every human being will have more intelligence at their disposal that the entire humanity has today.

crazy prospect.

maybe that will help us handle &ndash; and solve? &ndash; the problems that we are scheduled to run into in the next couple of decades according to the limits to growth?

####<a name="2"></a> Ricaun.RevitTest Unit Testing Framework

I discussed [ricaun.RevitTest unit testing framework](https://github.com/ricaun-io/ricaun.RevitTest)
with Luiz Henrique [@ricaun](https://ricaun.com/) Cassettari to clarify some important aspects; he says:

When I started researching about unit tests inside Revit, I had a hard time setting up
the [DynamoDS/RevitTestFramework](https://github.com/DynamoDS/RevitTestFramework) inside my Revit;
the project looks abandoned, and the last updates are six years old.

In the end I started using
the [geberit/Revit.TestRunner](https://github.com/geberit/Revit.TestRunner) version
that was a little easier to install.
I submitted PRs to fix some issues, and the project is alive on Github with more recent versions of Revit.

When I start using/playing with the [Autodesk Platform Services APS](https://aps.autodesk.com/)
[Design Automation API for Revit, DA4R](https://aps.autodesk.com/design-automation-apis,
I also want to be able to use DA4R to run tests use inside a GitHub Action.

That was the main goal: be able to run tests using both Revit for Desktop and Revit for Design Automation.

Plus, I found a way to use the default Test Explorer inside Visual Studio to run tests inside Revit.

No need to manually install the plugin in the machine, the `ricaun.RevitTest.TestAdapter` does the work to install the plugin in the machine, find Revit folder based in the Revit installation, open Revit, run the tests, show the result inside Visual Studio and close Revit.

Is really easy and convenient, you can download the sample project and just run the tests directly inside Visual Studio.

- [github.com/ricaun-io/RevitTest](https://github.com/ricaun-io/RevitTest)

Knowing that the Revit 2025 API was based on .NET Core, I designed the whole project with that in mind.

Supporting Revit versions from 2019 to 2025, and also, yes, ricaun.RevitTest works with the Revit Preview.

For running tests in DA4R, I still need to share the main project,
[ricaun-io/ricaun.DA4R.NUnit](https://github.com/ricaun-io/ricaun.DA4R.NUnit)

I have a class session in DevCon Europe this year, that's gonna be fun:

- [Multi-Version RevitTest Framework: Unit Testing Revit API using Design Automation](https://events.autodesk.com/flow/autodesk/devcon25emea/mainevent/page/agenda/session/1734703627846001oL4U)

> In the class, "Multi-Version RevitTest Framework: Unit Testing Revit API using Design Automation." you'll learn the intricacies of executing unit tests for Revit add-ins both locally and remotely. Using the versatile RevitTest Framework, you'll discover how to create consistent and reliable unit tests that can be run on your local machine as well as through Design Automation for Revit. Elevate your unit testing practices with Revit API by joining us and unlock the potential of running tests for multiple Revit versions using a unique and unified RevitTest Framework.

The ricaun.RevitTest features include:

- Support multiple Revit versions (2019-2025) (Revit Preview)
- Run inside Visual Studio Test Explorer (dotnet test)
- Do not require any manual plugin installation.
- Support to run tests using Design Automation for Revit.

Have a great week!

Many thanks to ricaun for the very helpful and detailed in-depth explanation!

RevitTest.Feature.Open.Close

ricaun_revittest.gif
.Feature.Open.Close


####<a name="2"></a> Eason Kang published two blog posts about exporting IFC using Revit DA:

Eason Kang published two blog posts about exporting IFC using Revit DA:
https://aps.autodesk.com/blog/export-ifc-rvt-using-design-automation-api-revit-part-i
https://aps.autodesk.com/blog/export-ifc-rvt-using-design-automation-api-revit-part-ii

####<a name="2"></a> Use Revit API from a web app

Use Revit API from a web app
https://forums.autodesk.com/t5/revit-api-forum/use-revit-api-from-a-web-app/m-p/13314320
Q: Is it possible to create a web app that manipulates a simple object in Revit "Beam for example".
A: The pure Revit API is a Windows .NET API that requires a running session of Revit and a valid Revit API context to execute, which is only provided within a running session of Revit.exe on a Windows desktop PC. You can however also use the Revit API in the cloud on a virtual machine directly from a web app by making use of the Autodesk Platform Services APS Design Automation for Revit API:
https://aps.autodesk.com/en/docs/design-automation/v3/developers_guide/overview/
Chuong Ho adds, here is another idea you can play with:
- Build the add-in and open a listener to get data from Revit: [Revit2GraphQL](https://github.com/BIMrxLAB/Revit2GraphQL)
The GraphQL for Revit project contains a GraphQL endpoint for Revit that can be accessed locally as well as remotely over the web.
Check out [BIMrx.Marconi.pdf](https://github.com/gregorvilkner/Revit2GraphQL/blob/master/BIMrx.Marconi%20SinglePage%201.1.pdf) for more information.

####<a name="2"></a> The Impact of Generative AI on Critical Thinking: Self-Reported Reductions in Cognitive Effort and Confidence Effects From a Survey of Knowledge Workers

The Impact of Generative AI on Critical Thinking: Self-Reported Reductions in Cognitive Effort and Confidence Effects From a Survey of Knowledge Workers
https://www.microsoft.com/en-us/research/uploads/prod/2025/01/lee_2025_ai_critical_thinking_survey.pdf
The rise of Generative AI (GenAI) in knowledge workflows raises questions about its impact on critical thinking skills and practices. We survey 319 knowledge workers to investigate 1) when and how they perceive the enaction of critical thinking when using GenAI, and 2) when and why GenAI affects their effort to do so. Participants shared 936 first-hand examples of using GenAI in work tasks. Quantitatively, when considering both task- and user-specific factors, a user’s task-specific self-confidence and confidence in GenAI are predictive of whether critical thinking is enacted and the effort of doing so in GenAI-assisted tasks. Specifically, higher confidence in GenAI is associated with less critical thinking, while higher self-confidence is associated with more critical thinking. Qualitatively, GenAI shifts the nature of critical thinking toward information verification, response integration, and task stewardship. Our insights reveal new design challenges and opportunities for developing GenAI tools for knowledge work.

####<a name="2"></a> Revit API: Retrieving Room Data for Demolished Family Instances

Revit API: Retrieving Room Data for Demolished Family Instances
https://adndevblog.typepad.com/aec/2024/10/revit-api-retrieving-room-data-for-demolished-family-instances.html

####<a name="2"></a> RST Results Package Create with Api

RST Results Package Create with Api
https://forums.autodesk.com/t5/revit-api-forum/results-package-create-with-api/m-p/13093333
Structural Analysis Toolkit, ResultsBuilder, Reviewing Stored Results in Revit
https://forums.autodesk.com/t5/revit-api-forum/structural-analysis-toolkit-resultsbuilder-reviewing-stored/m-p/8778306

####<a name="2"></a> uv

uv
https://autodesk.slack.com/archives/C016D5HE66T/p1738900731261749
If you have not tried uv as a replacement for: pip, conda, poetry, pyenv, pip-tools - please give it a try.
If you like how blazingly fast it is, you might be interested in learning the smart engineering behind it. Very great video.
https://www.youtube.com/watch?v=gSKTfG1GXYQ
uv: An Extremely Fast Python Package Manager
It also let's us enable some interesting ways to run scripts. I've switched completely to uv for all my personal projects :)
https://youtu.be/jXWIxk2brfk?si=Px8RLFYCRwbFiCzH
Some tricks with UV and a new Python project: uvtrick!
Those are very interesting tricks with uv! Thanks






<pre><code class="language-cs"></code></pre>


<center>
<img src="img/redox_flow_battery.jpg" alt="Redox flow battery" title="Redox flow battery" width="300"/>
<p style="font-size: 80%; font-style:italic">By
  <a href="https://avs.scitation.org/doi/10.1116/1.4983210">Colintheone</a>
  <a href="https://commons.wikimedia.org/w/index.php?curid=59002803">CC BY-SA 4.0</a></p>
</center>

