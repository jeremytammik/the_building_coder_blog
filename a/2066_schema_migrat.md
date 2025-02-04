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

- SchemaMigrations &ndash; make your Revit Extensible Storage API experience comfortable
  https://github.com/atomatiq/SchemaMigrations
  https://www.linkedin.com/pulse/revit-extensible-storage-schema-migration-atomatiq-a1yaf/?trackingId=RCpg3ZD4SYSHzxAgzWXP1g%3D%3D
  The [atomatiq](https://www.linkedin.com/company/atomatiq/) team including Ilia Ivanov
  Roman Karpovich and Sergei Nefedov

- openai chatgpt deep research
  It keeps coming: [20-minute youtube presentation on OpenAI deep research](https://youtu.be/YkCDVn3_wiw) using agents and internet access for long-lasting unsupervised tasks ... launching in ChatGPT pro today.
  However, responses say: Seems like the quality of this agent is still very very early days. Similar notice about their cheat sheets behind the cups.
  It is probably stressful to be in Google's position for OpenAI right now, but it seems like Deepseek made them dance for their money.
  New benchmarks are quite vague and impossible for anyone else to reproduce, so you can safely ignore that.

- Using OAuth Auth0 in a Revit add-in
  WebView2 throws System.Runtime.InteropServices.COMException: 'The requested resource is in use. (0x800700AA)'
  https://forums.autodesk.com/t5/revit-api-forum/webview2-throws-system-runtime-interopservices-comexception-the/td-p/13291882
  in case you wonder What the difference is between OAuth 2.0 and Auth0, check out the StackOverflow explanantion
  [OAuth 2.0 vs Auth0](https://stackoverflow.com/questions/46782725/oauth-2-0-vs-auth0)

- Docling
  https://ds4sd.github.io/docling/
  Docling simplifies document processing, parsing diverse formats — including advanced PDF understanding — and providing seamless integrations with the gen AI ecosystem.
  Features
  - Parsing of multiple document formats incl. PDF, DOCX, XLSX, HTML, images, and more
  - Advanced PDF understanding incl. page layout, reading order, table structure, code, formulas, image classification, and more
  - Unified, expressive DoclingDocument representation format
  - Various export formats and options, including Markdown, HTML, and lossless JSON
  - Local execution capabilities for sensitive data and air-gapped environments
  - Plug-and-play integrations incl. LangChain, LlamaIndex, Crew AI & Haystack for agentic AI
  - Extensive OCR support for scanned PDFs and images
  - Simple and convenient CLI
  i tested docling on an archiv scientific paper listed in the installation instructions, and it works perfectly with very impressive results:
  installation:
  pip install docling
  testing:
  docling https://arxiv.org/pdf/2206.01062
  the result is markdown:
  1626109 bytes -- 2206.01062v1.md
  includes images, tables, text, headings, the whole shebang perfectly formatted.

twitter:

 #RevitAPI  @AutodeskAPS  @AutodeskRevit #BIM @DynamoBIM

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

### Tools for Extensible Storage and OAuth Auth0

- [SchemaMigrations extensible storage lib](#2)
- [OpenAI ChatGPT deep research](#3)
- [OAuth Auth0 in a Revit add-in](#4)
- [Docling markdown generator](#5)

####<a name="2"></a> SchemaMigrations Extensible Storage Lib

The [atomatiq](https://www.linkedin.com/company/atomatiq/) team including Ilia Ivanov, Roman Karpovich and Sergei Nefedov presents
the [SchemaMigrations library](https://github.com/atomatiq/SchemaMigrations) of comfortable tools for the Revit Extensible Storage API to make its usage similar to
the [.NET Entity Framework](https://en.wikipedia.org/wiki/Entity_Framework):

- Define your models, add them to `SchemaContext`.
- Run `Schema Migration Generator` to create migration.
- Save your models in ES and load them from ES as instances of your `Models` class, instead of only primitive objects.

For further details, check out
the [SchemaMigrations GitHub repository documentation](https://github.com/atomatiq/SchemaMigrations).

####<a name="3"></a> OpenAI ChatGPT Deep Research

Daily exciting news on AI keeps on coming and continues accelerating.
OpenAI published
a [20-minute YouTube presentation on Deep Research](https://youtu.be/YkCDVn3_wiw), allowing the LLM to use agents, Internet access and other tools for longer-lasting partially unsupervised tasks.
This functionality is launching in ChatGPT pro today.

Similar functionality was already added to other LLMs, e.g., [Claude computer use](https://thebuildingcoder.typepad.com/blog/2024/10/au-api-wishes-and-revit-20253.html#5).
Things are certainly moving fast, baundaries pushed and new functionality publisdhed daily, with strong competition from many sides.

####<a name="4"></a> OAuth Auth0 in a Revit Add-In

Using OAuth Auth0 in a Revit add-in
WebView2 throws System.Runtime.InteropServices.COMException: 'The requested resource is in use. (0x800700AA)'
https://forums.autodesk.com/t5/revit-api-forum/webview2-throws-system-runtime-interopservices-comexception-the/td-p/13291882
in case you wonder What the difference is between OAuth 2.0 and Auth0, check out the StackOverflow explanantion
[OAuth 2.0 vs Auth0](https://stackoverflow.com/questions/46782725/oauth-2-0-vs-auth0)

####<a name="5"></a> Docling Markdown Generator

[Docling](https://ds4sd.github.io/docling/) by IBM simplifies document processing, parsing diverse formats &ndash; including advanced PDF understanding &ndash; and providing seamless integrations with the gen AI ecosystem, featuring:

- Parsing of multiple document formats incl. PDF, DOCX, XLSX, HTML, images, and more
- Advanced PDF understanding incl. page layout, reading order, table structure, code, formulas, image classification, and more
- Unified, expressive DoclingDocument representation format
- Various export formats and options, including Markdown, HTML, and lossless JSON
- Local execution capabilities for sensitive data and air-gapped environments
- Plug-and-play integrations incl. LangChain, LlamaIndex, Crew AI & Haystack for agentic AI
- Extensive OCR support for scanned PDFs and images
- Simple and convenient CLI

I tested docling on an arxiv scientific paper listed in the installation instructions, and it works perfectly right out of the box with very impressive results:

- Installation: `pip install docling`
- Testing: `docling [https://arxiv.org/pdf/2206.01062](https://arxiv.org/pdf/2206.01062)`

The result is a 1.6 MB markdown file `2206.01062v1.md` complete with images, tables, text, headings, the whole shebang, perfectly formatted.


<pre><code class="language-cs"> </code></pre>

<center>
<img src="img/.png" alt="" title="" width="100"/>
</center>


