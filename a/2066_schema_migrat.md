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
- [MacOS copy paste sans formatting](#6)
- [DIY open source redox flow battery](#7)

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
Things are certainly moving fast, boundaries pushed and new functionality published daily, with strong competition from many sides.

####<a name="4"></a> OAuth Auth0 in a Revit Add-In

Daniel [christev7HTEL](https://forums.autodesk.com/t5/user/viewprofilepage/user-id/15843072) Christev kindly
shared a fix to enable using `OAuth` `Auth0` in a Revit add-in in
the [Revit API discussion forum](http://forums.autodesk.com/t5/revit-api-forum/bd-p/160) thread
on [WebView2 throws System.Runtime.InteropServices.COMException: 'The requested resource is in use. (0x800700AA)'](https://forums.autodesk.com/t5/revit-api-forum/webview2-throws-system-runtime-interopservices-comexception-the/td-p/13291882).
in case &ndash;; like me &ndash;; you wonder what the difference is between OAuth 2.0 and Auth0, check out the StackOverflow explanation
on [OAuth 2.0 vs Auth0](https://stackoverflow.com/questions/46782725/oauth-2-0-vs-auth0).
Daniel says:

Just wanted to post some info on a bug I came across + fix.
Maybe no one will run into this problem, but it took me a while to get to the bottom of it.

It started with trying to use `Auth0` in a Revit application; the default implementation throws the exception and Revit crashes:

- System.Runtime.InteropServices.COMException: 'The requested resource is in use. (0x800700AA)'

It is possible to fix this by instantiating your client with a `WebBrowserBrowser`:

<pre><code class="language-cs">IBrowser browser = new WebBrowserBrowser();

client = new Auth0Client(new Auth0ClientOptions
{
Domain = domain,
ClientId = clientId,
RedirectUri = "http://localhost:3003",
PostLogoutRedirectUri = "http://localhost:3003",
Browser = browser
});</code></pre>

or even creating an implementation to try to use the default `SystemBrowser`
but I still wanted `WebView2` here.
It turns out the prickly bit of code boils down to the default environment that is created.
Generally, when you are generating a WebView2 within an application, you should call the following code:

<pre><code class="language-cs">string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
System.IO.Directory.CreateDirectory(appDataFolder);
var env = await CoreWebView2Environment.CreateAsync(null, appDataFolderACAD);
await webView.EnsureCoreWebView2Async(env);</code></pre>

It's important to create the environment, or else the default implementation will register a data folder running out of a secured folder that can't write like Program Files..
And this was what happened to me. WebView2 in Revit was trying to create a directory at:

- C:\Program Files\Autodesk\Revit 2025\Revit.exe.WebView2\`

which aside from being an absolute eye-sore, requires admin privileges to write to, and thus the resource cannot be used.

As someone new to WebView2, this really tripped me up, so here's to hoping it will help someone else at some point too.

So I created a custom `UserEnvironmentWebViewBrowser` where the `UserDataFolder` can be set, and defaults to appdata.
(This is by and large identical to the `WebViewBrowser` implementation, with the addition of the aforementioned):

<pre><code class="language-cs">public class UserEnvironmentWebViewBrowser : IBrowser
{
private readonly Func&lt;Window&gt; _windowFactory;

private readonly bool _shouldCloseWindow;

public UserEnvironmentWebViewBrowser(Func&lt;Window&gt; windowFactory, bool shouldCloseWindow = true)
{
_windowFactory = windowFactory;
_shouldCloseWindow = shouldCloseWindow;
}

public UserEnvironmentWebViewBrowser(
  string title = "Authenticating...",
  string? userDataFolder = null,
  int width = 1024,
  int height = 768)
:
  this(() =&gt; new Window
{
  Name = "WebAuthentication",
  Title = title,
  Width = width,
  Height = height
})
{
  if (userDataFolder != null && Directory.Exists(userDataFolder))
  {
    UserDataFolder = userDataFolder;
  }
}

public string UserDataFolder { get; set; }
  = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

public async Task&lt;BrowserResult&gt; InvokeAsync(
  BrowserOptions options,
  CancellationToken cancellationToken = default(CancellationToken))
{
  TaskCompletionSource&lt;BrowserResult&gt; tcs
    = new TaskCompletionSource&lt;BrowserResult&gt;();
  Window window = _windowFactory();
  WebView2 webView = new WebView2();
  window.Content = webView;
  webView.NavigationStarting += delegate (object? sender,
    CoreWebView2NavigationStartingEventArgs e)
  {
    if (e.Uri.StartsWith(options.EndUrl))
    {
      tcs.SetResult(new BrowserResult
      {
        ResultType = BrowserResultType.Success,
        Response = e.Uri.ToString()
      });
      if (_shouldCloseWindow)
      {
        window.Close();
      }
      else
      {
        window.Content = null;
      }
    }
  };
  window.Closing += delegate
  {
    webView.Dispose();
    if (!tcs.Task.IsCompleted)
    {
      tcs.SetResult(new BrowserResult
      {
        ResultType = BrowserResultType.UserCancel
      });
    }
  };
  window.Show();

  var webView2Environment = await CoreWebView2Environment.CreateAsync(null, UserDataFolder);
  await webView.EnsureCoreWebView2Async(webView2Environment);
  webView.CoreWebView2.Navigate(options.StartUrl);
  return await tcs.Task;
}
}</code></pre>

You can also check out the solution in
my [RevitWebView2Bug GitHub repo](https://github.com/bulgos/RevitWebView2Bug).

Shoutout to [@grahamcook](https://forums.autodesk.com/t5/user/viewprofilepage/user-id/1070920) as
I found the answer within his [post](https://forums.autodesk.com/t5/net/using-the-webviewer2-package-version-issues/m-p/12941602.

Many thanks, Daniel and Graham, for sharing this.

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

####<a name="6"></a> MacOS Copy Paste Sans Formatting

After thousands of unthinking repetitions, I finally searched and found a note
on [how to copy and paste text excluding formatting on Mac](https://www.macrumors.com/how-to/copy-paste-text-no-formatting-mac/):

> In Windows, the Copy and Paste key combinations are Control-C and Control-V, respectively.
On the Mac, it's similar using the Command (⌘) key instead of Control.
You can also paste text without its original formatting.
Not knowing that this is possible on a Mac, many users paste text into a plain-format text editor to strip it of any styling before copying and pasting it again to its intended destination (that's me).
But you don't have to do that.
To directly paste the copied text elsewhere as purely plain text, use the key combination Command-Option-Shift-V and it will be automatically stripped of any formatting.

Wow.
I should have thought of checking that out years ago.

####<a name="7"></a> DIY Open Source Redox Flow Battery

Now to round off with a non-digital topic:
I was previously not aware of any DIY efforts to create battery storage and therefore excited to discover
the [Flow Battery Research Collective](https://fbrc.dev) open source project targeted at
creating a simple DIY [redox flow battery](https://en.wikipedia.org/wiki/Flow_battery).

This [20-minute video](https://spectra.video/w/6BddEiwBqRMHSbC9qBLBz9) discusses progress so far and current status.
The [roadmap](https://fbrc.dev/posts/roadmap-faq-forum/) posits a research kit in the middle of this year to help discover optimal liquid chemical components, and hopes to be able to provide a kit for creating your own working 48V battery sufficient for powering a small home by the end of the year.

<center>
<img src="img/redox_flow_battery.jpg" alt="Redox flow battery" title="Redox flow battery" width="300"/>
<p style="font-size: 80%; font-style:italic">By
  <a href="https://avs.scitation.org/doi/10.1116/1.4983210">Colintheone</a>
  <a href="https://commons.wikimedia.org/w/index.php?curid=59002803">CC BY-SA 4.0</a></p>
</center>

By the way, there are a number of non-DIY effort underway as well, with significant interest, support, and funding, e.g.,
the [Long-term energy storage challenge](https://www.sprind.org/en/impulses/challenges/energystorage)
by [SPRIN-D](https://www.sprind.org/en/we).
One example is the Swiss startup [Unbound Potential](https://youtu.be/e_3Yd8mKvmw?feature=shared).

