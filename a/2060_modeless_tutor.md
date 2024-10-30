<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<link rel="stylesheet" type="text/css" href="bc.css">
<!-- https://highlightjs.org/#usage
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/highlight.js/11.9.0/styles/default.min.css">
<script src="https://cdnjs.cloudflare.com/ajax/libs/highlight.js/11.9.0/highlight.min.js"></script>
<script>hljs.highlightAll();</script>
-->

<!-- https://prismjs.com -->
<link href="https://cdn.jsdelivr.net/npm/prismjs@1.29.0/themes/prism.min.css" rel="stylesheet" />
<script src="https://cdn.jsdelivr.net/npm/prismjs@1.29.0/components/prism-core.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/prismjs@1.29.0/plugins/autoloader/prism-autoloader.min.js"></script>
<style> code[class*=language-], pre[class*=language-] { font-size : 90%; } </style>

</head>

<!---

- modeless WPF add-in samples and tutorials
  Revit addin with modeless WPF window with XAML
  https://www.linkedin.com/pulse/revit-addin-modeless-window-sergei-nefedov-bceef/
  by Sergei Nefedov
  Extensible Application Markup Language
  https://en.wikipedia.org/wiki/Extensible_Application_Markup_Language
  came up in
  Calling IExternalCommand from WPF button
  https://forums.autodesk.com/t5/revit-api-forum/calling-iexternalcommand-from-wpf-button/m-p/13110196
  Revit crashes when exiting add-in WPF application
  https://forums.autodesk.com/t5/revit-api-forum/revit-crashes-when-exiting-add-in-wpf-application/m-p/9236332/
  Moustafa Khalil of [SharpBIM](https://hashnode.com/@SharpBIM) ([GitHub](https://github.com/mostafa901))
  [Revit_WPF_Example](https://github.com/mostafa901/Revit_WPF_Example)

- add to dismiss dialogues:
  https://adndevblog.typepad.com/aec/2013/06/dismiss-the-dialog-when-opening-a-copied-central-model-file.html
  https://archi-lab.net/dismissing-revit-pop-ups-the-easy-and-not-so-easy-ways/
  Dismiss Task Dialog Copied Central Model Revit 2023 with Visual Studio
  https://stackoverflow.com/questions/79125045/dismiss-task-dialog-copied-central-model-revit-2023-with-visual-studio

- ai llm rag &rarr; graphrag &rarr; knowledgebase
  https://duckduckgo.com/?q=ai+llm+rag+--%3E+graphrag+--%3E+knowledgebase

- The Bitter Lesson
  http://www.incompleteideas.net/IncIdeas/BitterLesson.html
  > One thing that should be learned from the bitter lesson is the great power of general purpose methods, of methods that continue to scale with increased computation even as the available computation becomes very great. The two methods that seem to scale arbitrarily in this way are search and learning.
  > The second general point to be learned from the bitter lesson is that the actual contents of minds are tremendously, irredeemably complex; we should stop trying to find simple ways to think about the contents of minds, such as simple ways to think about space, objects, multiple agents, or symmetries. All these are part of the arbitrary, intrinsically-complex, outside world. They are not what should be built in, as their complexity is endless; instead we should build in only the meta-methods that can find and capture this arbitrary complexity. Essential to these methods is that they can find good approximations, but the search for them should be by our methods, not by us. We want AI agents that can discover like we can, not which contain what we have discovered. Building in our discoveries only makes it harder to see how the discovering process can be done.

- Brain Drain: David vs Goliath
  https://stackoverflow.blog/2024/10/17/training-data-scarcity-synthetic-quality-model-genai-ai/
  > There are worries that GenAI systems may run out of fresh data as they scale. Synthetic data is an option, but using AI-generated data to train AI can degrade the model's performance. There may be a better solution. Can data quality overcome a loss of data quantity?

- https://x.com/hellokillian/status/1849248458701705334
  interpreter --os requires OpenAI API key
  interpreter --local

- MetaGPT
  https://github.com/geekan/MetaGPT

- HTML for people
  https://htmlforpeople.com/
  create and publish a web site from scratch, for anyone

twitter:

 the @AutodeskRevit #RevitAPI #BIM @DynamoBIM

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

### Modeless Add-In Sample and Tutorial



<center>
<img src="img/.png" alt="" title="" width="100"/>
</center>

####<a name="2"></a> Retirement Looming

My retirement is coming up, currently schedule for end of April 2025.

Since I have heaps of unused accrued vacation that I need to use up beforehand, and no enough working hours to do so, I am planning to take leave in November and December 2024.

So, I will presumably be less active both here in The Building Coder blog and in
the [Revit API discussion forum](http://forums.autodesk.com/t5/revit-api-forum/bd-p/160).

####<a name="2"></a> Modeless WPF Add-In Sample and Tutorial

modeless WPF add-in samples and tutorials
Revit addin with modeless WPF window with XAML
https://www.linkedin.com/pulse/revit-addin-modeless-window-sergei-nefedov-bceef/
by Sergei Nefedov
Extensible Application Markup Language
https://en.wikipedia.org/wiki/Extensible_Application_Markup_Language
came up in
Calling IExternalCommand from WPF button
https://forums.autodesk.com/t5/revit-api-forum/calling-iexternalcommand-from-wpf-button/m-p/13110196
Revit crashes when exiting add-in WPF application
https://forums.autodesk.com/t5/revit-api-forum/revit-crashes-when-exiting-add-in-wpf-application/m-p/9236332/
Moustafa Khalil of [SharpBIM](https://hashnode.com/@SharpBIM) ([GitHub](https://github.com/mostafa901))
[Revit_WPF_Example](https://github.com/mostafa901/Revit_WPF_Example)

####<a name="2"></a> add to dismiss dialogues

add to dismiss dialogues:
https://adndevblog.typepad.com/aec/2013/06/dismiss-the-dialog-when-opening-a-copied-central-model-file.html
https://archi-lab.net/dismissing-revit-pop-ups-the-easy-and-not-so-easy-ways/
Dismiss Task Dialog Copied Central Model Revit 2023 with Visual Studio
https://stackoverflow.com/questions/79125045/dismiss-task-dialog-copied-central-model-revit-2023-with-visual-studio

####<a name="2"></a> AI LLM RAG &rarr; graphrag &rarr; knowledgebase

ai llm rag &rarr; graphrag &rarr; knowledgebase
https://duckduckgo.com/?q=ai+llm+rag+--%3E+graphrag+--%3E+knowledgebase

####<a name="2"></a> The Bitter Lesson

The Bitter Lesson
http://www.incompleteideas.net/IncIdeas/BitterLesson.html
> One thing that should be learned from the bitter lesson is the great power of general purpose methods, of methods that continue to scale with increased computation even as the available computation becomes very great. The two methods that seem to scale arbitrarily in this way are search and learning.
> The second general point to be learned from the bitter lesson is that the actual contents of minds are tremendously, irredeemably complex; we should stop trying to find simple ways to think about the contents of minds, such as simple ways to think about space, objects, multiple agents, or symmetries. All these are part of the arbitrary, intrinsically-complex, outside world. They are not what should be built in, as their complexity is endless; instead we should build in only the meta-methods that can find and capture this arbitrary complexity. Essential to these methods is that they can find good approximations, but the search for them should be by our methods, not by us. We want AI agents that can discover like we can, not which contain what we have discovered. Building in our discoveries only makes it harder to see how the discovering process can be done.

####<a name="2"></a> Brain Drain: David vs Goliath

Brain Drain: David vs Goliath
https://stackoverflow.blog/2024/10/17/training-data-scarcity-synthetic-quality-model-genai-ai/
> There are worries that GenAI systems may run out of fresh data as they scale. Synthetic data is an option, but using AI-generated data to train AI can degrade the model's performance. There may be a better solution. Can data quality overcome a loss of data quantity?

####<a name="2"></a> https://x.com/hellokillian/status/1849248458701705334

https://x.com/hellokillian/status/1849248458701705334
interpreter --os requires OpenAI API key
interpreter --local

####<a name="2"></a> MetaGPT

MetaGPT
https://github.com/geekan/MetaGPT

####<a name="2"></a> HTML for people

HTML for people
https://htmlforpeople.com/
create and publish a web site from scratch, for anyone

####<a name="2"></a> UN Confirms We Are not tackling climate change

World way off target in tackling climate change - UN
https://www.bbc.com/news/articles/ce8yyle2eq2o
Greenhouse gas emissions:
Right now, when the plans are added up, they indicate that emissions will likely fall by just 2.6% by 2030 compared to 2019.
This is far short of the 43% reduction that scientists say will be needed by the end of this decade to keep the world on track for net-zero carbon by 2050.
Forest feedback loop:
So if the forests and the oceans become less able to soak up CO2, global warming could accelerate more rapidly.

