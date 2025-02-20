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

- intro personal
  My two years younger brother is dying, and that is freaking me out a lot. Cancer, no digestion, no nutrition… could be days, could be weeks…
  I hope to be able to calm down a bit gradually.
  I am also overwhelmed by what is happening in the world, politically, climate, war.
  At the same time, I am very excited about the AI revolution. Have you read Sam Altman’s three observations?
  Back on the negative side, we have the limits to growth with much evidence corroborating the prediction of a crash:
  https://en.wikipedia.org/wiki/The_Limits_to_Growth
  Image
  Maybe the AI revolution predicted by Sam can help address the catastrophe predicted by the [limits to growth](https://en.wikipedia.org/wiki/The_Limits_to_Growth?
  So, that is my short answer to your first question. Sorry if it is a bit overwhelming. I feel overwhelmed too.

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


####<a name="2"></a> Life, Death, Turmoil

I am somewhat in turmoil.
My daughter is imminently expecting a baby.
My brother is imminently dying.
The entire world seems to be in upheaval, politically, technologically, in polarisation between continents and socially.
I’m fine myself, physically.

The largest global upheaval that I see looming is the projection by
the [1972 study on the limits to growth](https://thebuildingcoder.typepad.com/blog/2024/01/valid-revit-api-context-llm-and-ltg.html#7) that
I pointed out in January.

One sliver of hope on possibly handling the collapse that it predicts in the coming decades is offered
by [Sam Altman's Three Observations](https://blog.samaltman.com/three-observations) on the rapid and accelerating AI evolution we are observing,
providing a very exciting optimistic outlook into the near future.
He compares the development of AI
with [Moore's law](https://en.wikipedia.org/wiki/Moore%27s_law),
which notes that computing power increased expobnentially by a factor of 2 every 18 months.
In AI development, Altman notes that the cost to use a given level of AI falls about 10x every 12 months, and lower prices lead to much more use, cf.,
[Jevons Paradox](https://thebuildingcoder.typepad.com/blog/2024/10/determine-rvt-version-and-add-data-from-exe.html#10).
He concludes:

> Anyone in 2035 should be able to marshall the intellectual capacity equivalent to everyone in 2025; everyone should have access to unlimited genius to direct however they can imagine. There is a great deal of talent right now without the resources to fully express itself, and if we change that, the resulting creative output of the world will lead to tremendous benefits for us all.

Let's hope that really comes true.



Yes, my retirement, and the blog.

We are recruiting a replacement for me. The replacement needs to be based in Europe. You would be a cool candidate. Chuong Ho has expressed interest already and would be a great choice. I’ll ask him if he would be willing to relocate. Would you?

My guess is the blog will just stand still. New stuff will go into the APS blogs. Just a guess, though.

Thank you very much for the in-depth explanation about the unit testing!

That is very useful.

I wish you a great week as well!


Today, only 199 human programmers are better than `o3`, and `r1` can produce the best kernel code: [Reasoning Models are Near-Superhuman Coders (OpenAI IOI, Nvidia Kernels)](https://buttondown.com/ainews/archive/ainews-reasoning-models-are-near-superhuman/):

* RL is all you need
* o3 achieves a gold medal at the 2024 IOI and obtains a Codeforces rating on par with elite human competitors - in particular, the Codeforces score is at the 99.8-tile
* In Automating GPU Kernel Generation with DeepSeek-R1 and Inference Time Scaling, Nvidia found that DeepSeek r1 could write custom kernels that "turned out to be better than the optimized kernels developed by skilled engineers in some cases"; In the Nvidia case, the solution was also extremely simple, causing much consternation.

Lots of comments from people reacting to an initial post saying [I'm in my 50's and I just had ChatGPT write me a javascript/html calculator for my website. I'm shook.](https://www.reddit.com/r/ChatGPT/comments/1iosoyp/im_in_my_50s_and_i_just_had_chatgpt_write_me_a/?rdt=52104).

####<a name="2"></a> Retirement, Recruiting, Job Offer

Here is the public job posting, specifying a location in Europe, specifically Spain, Czechia or Ireland:

https://autodesk.wd1.myworkdayjobs.com/en-US/Ext/job/Senior-Developer-Advocate-Engineer_25WD85215-2

If you are interested in this opportunity, I suggest you do not apply directly through the link above.

Instead, send me a message by email to my Autodesk address and let me know your contact details.

Then, I can submit a referral for you, and the recruiters will contact you directly.

Good luck!


Let’s keep in touch. Let me know if you hear from the recruiting guys based on my referral. I hope it works out.


####<a name="2"></a> Sam Altman shared [Three Observations](https://blog.samaltman.com/three-observations) offering insights likely related to AI developments, industry trends, or human potential. The content emphasises the ongoing evolution and impact of technology.

Sam Altman shared [Three Observations](https://blog.samaltman.com/three-observations) offering insights likely related to AI developments, industry trends, or human potential. The content emphasises the ongoing evolution and impact of technology.

the most interesting observation, i think, is that there is an exponential development in AI, similar to Moore's law.

2x computation power every 18 months.

well, sam altmans says that the AI intelligence has a similar exponential growth, much more extreme:

10x intelligence increase every 12 months.

he says, by 2035, every human being will have more intelligence at their disposal that the entire humanity has today.

crazy prospect.

maybe that will help us handle &ndash; and solve? &ndash; the problems that we are scheduled to run into in the next couple of decades according to the limits to growth?

####<a name="2"></a> New Rev API Docs

[Rev API Docs](https://revapidocs.com/)
new online Revit API documentation, seeing as revitapidocs.com has not yet been brought up to date for Revit 2025.
I like it. free of advertising. fast. good search functionality with immediate feedback. super cool.
i just discovered a new online version of the Revit API documentation,  [Rev API docs](https://revapidocs.com/) -- [revapidocs.com](https://revapidocs.com/). this is a new member of the family, created by a Revit API consulting company [nonica.io](https://nonica.io/). it includes coverage for Revit 2025 API, which was (and still is) lacking in [revitapidocs.com](https://www.revitapidocs.com/). so, nonica have either decompiled the CHM, like i did, or discovered my sharing of the resulting HTML snippets on github. i presume they did it themselves, though.

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

####<a name="2"></a> New AI AGI Test Suites

Humanity's Last Exam
https://lastexam.ai/


ENIGMAEVAL: A Benchmark of Long Multimodal Reasoning Challenges
https://scale.com/research/enigma_eval



####<a name="2"></a> uv Python Package and Project Manager

Do you do any work with Python at all?

If so, the following tool may be of interest:

[uv](https://docs.astral.sh/uv/), an extremely fast Python package and project manager, written in Rust, sporting the following impressive features:

- A single tool to replace pip, pip-tools, pipx, poetry, pyenv, twine, virtualenv, and more.
- 10-100x faster than pip.
- Provides comprehensive project management, with a universal lockfile.
- Runs scripts, with support for inline dependency metadata.
- Installs and manages Python versions.
- Runs and installs tools published as Python packages.
- Includes a pip-compatible interface for a performance boost with a familiar CLI.
- Supports Cargo-style workspaces for scalable projects.
- Disk-space efficient, with a global cache for dependency deduplication.
- Installable without Rust or Python via curl or pip.
- Supports macOS, Linux, and Windows.

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
<img src="img/" alt="" title="" width="100"/>
<p style="font-size: 80%; font-style:italic"></p>
</center>


