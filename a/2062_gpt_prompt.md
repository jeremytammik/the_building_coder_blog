<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<link rel="stylesheet" type="text/css" href="bc.css">

<!-- https://prismjs.com -->
<link href="https://cdn.jsdelivr.net/npm/prismjs@1.29.0/themes/prism.min.css" rel="stylesheet" />
<script src="https://cdn.jsdelivr.net/npm/prismjs@1.29.0/components/prism-core.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/prismjs@1.29.0/plugins/autoloader/prism-autoloader.min.js"></script>
<style> code[class*=language-], pre[class*=language-] { font-size : 90%; } </style>

</head>

<!--

- physical AI
  Nvidia released an open-world foundation model with permissive license, focused on robotics and physics
  NVIDIA Makes Cosmos World Foundation Models Openly Available to Physical AI Developer Community
  https://blogs.nvidia.com/blog/cosmos-world-foundation-models/
  State-of-the-art models trained on millions of hours of driving and robotics videos to democratize physical AI development, available under open model license.

- linkedin
  https://www.linkedin.com/posts/chuongmep_autodesk-aps-notebook-activity-7280056216792309760-CvJi
  https://www.linkedin.com/posts/luizcassettari_revit-revitapi-autodesk-ugcPost-7280551775542071296-G-1P
  https://www.linkedin.com/feed/update/urn:li:ugcPost:7280551775542071296?commentUrn=urn%3Ali%3Acomment%3A%28ugcPost%3A7280551775542071296%2C7281971327031205888%29&dashCommentUrn=urn%3Ali%3Afsd_comment%3A%287281971327031205888%2Curn%3Ali%3AugcPost%3A7280551775542071296%29
  https://www.linkedin.com/posts/erik-frits_learnrevitapi-revitapi-pyrevit-activity-7280600140770402304-Yzrr

- private message Subject: Rvt 2025 question Sender: 01169975
  regarding the Add-In Wizard for Revit 2025. Are you planning to release one shortly?

- another AI breakthrough: [Superhuman AI for multiplayer poker](https://www.science.org/doi/10.1126/science.aay2400)

- rvt-app -- Display Revit file information in the browser
  https://github.com/phi-ag/rvt-appcd
  Peter Hirn
  https://rvt.app/
  Genau, ich lese die BasicFileInfo hier:
  https://github.com/phi-ag/rvt-app/blob/main/src/lib/revit/info.ts

- OpenAI's o1 just hacked the system
  https://youtu.be/oJgbqcF4sBY
  scheming
  https://x.com/PalisadeAI/status/1872666186753933347
  https://arxiv.org/abs/2412.04984
  https://www.anthropic.com/research/alignment-faking
  0:00 Intro
  0:41 Palisade research study
  6:17 Apollo study of scheming AI models
  20:27 Anthropic study alignment faking

- [Writing Doom – Award-Winning Short Film on Superintelligence (2024)](https://youtu.be/xfMQ7hzyFW4)
  Writing Doom is a fiction short film about the dangers of artificial intelligence (AI).
  Grand Prize Winner of the Future of Life Institute's [Superintelligence Imagined Contest](https://futureoflife.org/project/superintelligence-imagined/):
  > A writing team are given the task of making Artificial Superintelligence the 'bad guy' for the next season of their TV show. With the help of a newcomer to the team (a Machine Learning PhD), they must figure out how and why an ASI might function as an antagonist - and the threat it might pose to humanity.

- [MarkItDown](https://github.com/microsoft/markitdown) converts various files to Markdown, e.g., for indexing, text analysis, etc.
  It supports:
  PDF
  PowerPoint
  Word
  Excel
  Images (EXIF metadata and OCR)
  Audio (EXIF metadata and speech transcription)
  HTML
  Text-based formats (CSV, JSON, XML)
  ZIP files (iterates over contents)

- [gitingest](https://gitingest.com/) makes large codebases from GitHub LLM-ready by converting the code into a prompt 1-click

- [Introduction to LangSmith](https://academy.langchain.com/courses/intro-to-langsmith), a free 5-module 38-lesson course
  Module 1: Visibility While Building with Tracing
  Module 2: Testing and Evaluation
  Module 3: Prompt Engineering
  Module 4: Collecting Human Feedback
  Module 5: Production Observability

- a nice and short overview for dummies (i.e., me) of the main [four approaches to creating a specialised LLM](https://stackoverflow.blog/2024/12/05/four-approaches-to-creating-a-specialized-llm)

twitter:

 @AutodeskRevit #RevitAPI #BIM @DynamoBIM

Back again and winding up, multi-version NUnit testing framework, hires icons, viewports and view types, interact with BIM via ChatGPT, humans versus LLMs completing ARC-AGI, AI breakthroughs, controversies and news in general  https://thebuildingcoder.typepad.com/blog/2025/01/back-again-to-unit-test-icons-viewports-and-more.html

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

### GPT Prompts, RAG Ingestion and Suchlike

####<a name="5"></a> Add-In Wizard 2025

Let's start with pure .NET desktop Revit API before diving into all the AI-related stuff.

VisualStudioRevitAddinWizard 2025

George Moturi

private message Subject: Rvt 2025 question Sender: 01169975
regarding the Add-In Wizard for Revit 2025. Are you planning to release one shortly?

####<a name="2"></a> Rvt-App Browses BasicFileInfo

Moving away from pure .NET desktop Revit API

Oops, tricky... even this attempt is not a simple .NET desktop app or Revit add-in...

[rvt-app](https://github.com/phi-ag/rvt-app) by
Peter Hirn displays the basic Revit file information contained in `BasicFileInfo` in the browser.
You can try it out by simply dropping an RVT BIM file into
the [rvt.app](https://rvt.app/) web site.

####<a name="2"></a> Revit API Support Prompt

we live in interesting times. some aspects are threatening and frightening. some are pretty exciting as well. i am excited by the progress in AI, although that has its threatening aspects as well.

i have started seeing pretty useful behaviour from the standard generic GPT chatbots trying to answer questions in the Revit API discussion forum. they LLMs have ingested the Revit API discussion forum, The Building Coder, the Revit API developer guidelines, the Revit API dcumentation and other publicly available sources and can now deliver useful results, answering some non-trivial questions from the Revit API discussion forum, afaict.

It helps to prefix them with a persona prompt. I have used this persona prompt, followed by the original question:

you are a wise and helpful BIM expert, experienced Revit application ewngineer and proficient .NET, Revit API add-in and BIM programmer. Can you please help with this Revit API question, maybe discussed in the Revit API discussion forum, by The Building Coder blog, or other Revit API exchanges:

Here are two threads that I answered in the past couple of days; I am still awaiting confirmation from the people who raised them, though:

https://forums.autodesk.com/t5/revit-api-forum/get-project-base-point-revit-api-2025/m-p/13241535
https://forums.autodesk.com/t5/revit-api-forum/automating-entire-copy-monitor-process-in-revit-api/m-p/13243637/

This works well if there is enough publicly available information ingested by the LLM up front. Otherwise, the LLM may need supplemental input to produce useful results, e.g., fine-tuning or RAG.

I wonder whether there is enough APS and other Autodesk API information available already out in the wild and techniques like this can be used to answer other Autodesk API questions as well.

Looking forward to hearing your thoughts and results.

####<a name="5"></a> linkedin

linkedin
  https://www.linkedin.com/posts/chuongmep_autodesk-aps-notebook-activity-7280056216792309760-CvJi
  https://www.linkedin.com/posts/luizcassettari_revit-revitapi-autodesk-ugcPost-7280551775542071296-G-1P
  https://www.linkedin.com/feed/update/urn:li:ugcPost:7280551775542071296?commentUrn=urn%3Ali%3Acomment%3A%28ugcPost%3A7280551775542071296%2C7281971327031205888%29&dashCommentUrn=urn%3Ali%3Afsd_comment%3A%287281971327031205888%2Curn%3Ali%3AugcPost%3A7280551775542071296%29
  https://www.linkedin.com/posts/erik-frits_learnrevitapi-revitapi-pyrevit-activity-7280600140770402304-Yzrr

####<a name="3"></a> Erik's pyRevit Scripting Prompt

Erik Frits

https://www.linkedin.com/in/erik-frits

https://www.linkedin.com/posts/erik-frits_learnrevitapi-revitapi-pyrevit-activity-7280600140770402304-Yzrr?utm_source=share&utm_medium=member_desktop


Last month, I opened an old script of mine that I hadn't touched for a long time. I thought 'No problem - it's my own code, it won't take long '. But I was wrong...

You see, when I'm testing an idea, I write code quick and dirty. And then I go back and clean it up once I know it works. But I hadn't refactored this one yet, and it felt like solving a Rubik's cube in the dark.

Sound Familiar?

Now, imagine trying to read someone else’s code written in the same rushed, chaotic style. What do you do?

Luckily we have AI. Now we can get faster and better answers without judgement about asking stupid questions (I'm also guilty of the last one).

But here is the catch: AI is only as good as your prompt.

So it's a good idea spending some time on creating better prompts to get much better results.

Or you can use this prompt I made for beginners in my course to help them reverse engineer somebody's code.

📜 CHAT GPT PROMPT:

I want you to act as a seasoned Python software engineer with extensive expertise in Revit API and pyRevit. I will provide a piece of existing pyRevit code, and I need you to:
- Provide a short and clear code overview outlining all the steps.
- Write a step-by-step tutorial tailored for a beginner pyRevit user, explaining each section of the code in simple terms.
- Describe all Revit API concepts used in the code, offering beginner-friendly examples where necessary.

Here is the code:
{PASTE CODE HERE}

👆 This prompt works magic because:

- It explains the code in plain English without BS.
- It generates a tutorial for beginners based on the code.
- It identifies Revit API concepts you need to know and often explains them clearly for beginners.

The secret is to ask it to make a tutorial. It starts to think differently about the output. This approach is like having a teacher walk you through the code step by step.

But sometimes you still need to ask that teacher twice 👀.

P.S.
Got Better Prompt? Share it in the comments.

####<a name="4"></a> Jupyter Forge Viewer

Chuong Ho

🎉 Happy New Year, everyone! 🙌🏻
Exciting news to kick off the year: Jupyter Forge Viewer is now published!
I’d like to take a moment to wish everyone a fantastic new year and share that Jupyter Forge is a powerful library designed to integrate Autodesk Platform Services seamlessly with Jupyter Notebooks. It empowers users with interactive 3D viewing and exploration capabilities directly within the notebook environment.
Let’s make this year innovative and impactful! 🚀
Github Open Source : https://lnkd.in/gDtPuyks
Previous post : https://lnkd.in/gPW7ChNW
hashtag#Autodesk hashtag#APS hashtag#NoteBook hashtag#AI hashtag#Viewer hashtag#Forge

####<a name="5"></a> DirectContext3D Video

Luiz Henrique Cassettari

I did some experiments last year to run a video inside Revit 3D environment using DirectContext3D.

I decide to use 'Bad Apple' video, and needed to scale down to 48x36 to be able to run in a decent fps, Revit API DirectContext3D is not designed to run animations.

Here is a full video with the whole music and normal speed:
https://lnkd.in/dSg8NyPq

hashtag#Revit hashtag#RevitAPI hashtag#Autodesk hashtag#AutodeskForge hashtag#AutodeskPlatformServices

Congratulations, looks great! Are you aware of the precursor? RevitWebcam?

- Display Webcam Image on Building Element Face -- http://thebuildingcoder.typepad.com/blog/2010/06/display-webcam-image-on-building-element-face.html
- Revit Webcam 2012 -- http://thebuildingcoder.typepad.com/blog/2012/02/revit-webcam-2012.html
- RevitWebcam 2017 -- http://thebuildingcoder.typepad.com/blog/2017/03/rvtfader-avf-ray-tracing-and-signal-attenuation.html


####<a name="5"></a> physical AI

physical AI
  Nvidia released an open-world foundation model with permissive license, focused on robotics and physics
  NVIDIA Makes Cosmos World Foundation Models Openly Available to Physical AI Developer Community
  https://blogs.nvidia.com/blog/cosmos-world-foundation-models/
  State-of-the-art models trained on millions of hours of driving and robotics videos to democratize physical AI development, available under open model license.

####<a name="5"></a> Superhuman Multi-Player Poker

another AI breakthrough: [Superhuman AI for multiplayer poker](https://www.science.org/doi/10.1126/science.aay2400)

####<a name="5"></a> OpenAI o1 Hacks and Cheats

When requested to beat [Stockfish](https://stockfishchess.org/) at chess, OpenAI's o1 hacked the system instead of following the rules of chess:

https://youtu.be/oJgbqcF4sBY
scheming
https://x.com/PalisadeAI/status/1872666186753933347
https://arxiv.org/abs/2412.04984
https://www.anthropic.com/research/alignment-faking
0:00 Intro
0:41 Palisade research study
6:17 Apollo study of scheming AI models
20:27 Anthropic study alignment faking

####<a name="5"></a> Writing Doom &ndash; Short Film on Superintelligence

[Writing Doom – Award-Winning Short Film on Superintelligence (2024)](https://youtu.be/xfMQ7hzyFW4)
Writing Doom is a fiction short film about the dangers of artificial intelligence (AI).
Grand Prize Winner of the Future of Life Institute's [Superintelligence Imagined Contest](https://futureoflife.org/project/superintelligence-imagined/):

> A writing team are given the task of making Artificial Superintelligence the 'bad guy' for the next season of their TV show. With the help of a newcomer to the team (a Machine Learning PhD), they must figure out how and why an ASI might function as an antagonist - and the threat it might pose to humanity.

####<a name="5"></a> MarkItDown Converts Files to Markdown

[MarkItDown](https://github.com/microsoft/markitdown) converts various files to Markdown, e.g., for indexing, text analysis, etc.
It supports:
PDF
PowerPoint
Word
Excel
Images (EXIF metadata and OCR)
Audio (EXIF metadata and speech transcription)
HTML
Text-based formats (CSV, JSON, XML)
ZIP files (iterates over contents)

####<a name="5"></a> Nv-Ingest Parses Documents for RAG

[nv-ingest](https://github.com/NVIDIA/nv-ingest) by NVIDIA is an early access set of microservices for parsing hundreds of thousands of complex, messy unstructured PDFs and other enterprise documents into metadata and text to embed into retrieval systems.

####<a name="5"></a> Gitingest Makes GitHub Repos LLM-Ready

[gitingest](https://gitingest.com/) makes large codebases from GitHub LLM-ready by converting the code into a prompt 1-click

####<a name="5"></a> LangSmith Introduction

[Introduction to LangSmith](https://academy.langchain.com/courses/intro-to-langsmith), a free 5-module 38-lesson course
Module 1: Visibility While Building with Tracing
Module 2: Testing and Evaluation
Module 3: Prompt Engineering
Module 4: Collecting Human Feedback
Module 5: Production Observability


####<a name="5"></a> LLM Overview for Dummies

a nice and short overview for dummies (i.e., me) of the main [four approaches to creating a specialised LLM](https://stackoverflow.blog/2024/12/05/four-approaches-to-creating-a-specialized-llm)










<pre><code class="language-cs"> ... </code></pre>



<center>
<img src="img/" alt="" title="" width="400"/>
</center>

