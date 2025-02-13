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


####<a name="2"></a> Sam Altman shared [Three Observations](https://blog.samaltman.com/three-observations) offering insights likely related to AI developments, industry trends, or human potential. The content emphasises the ongoing evolution and impact of technology.

Sam Altman shared [Three Observations](https://blog.samaltman.com/three-observations) offering insights likely related to AI developments, industry trends, or human potential. The content emphasises the ongoing evolution and impact of technology.

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

