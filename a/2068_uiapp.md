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

- three horizons
  https://www.h3uni.org/tutorial/three-horizons/


- XOR
  https://www.chiark.greenend.org.uk/~sgtatham/quasiblog/xor/
  Simon Tatham made a good stab at summarising everything one might possibly want to know about XOR.

- a nice little essay on the topic of using AI for speedy coding and/or in-depth learning: [New Junior Developers Can’t Actually Code](https://nmn.gl/blog/ai-and-learning).

- still feeling with nick:
  Reading the news today, I explored further an item on Chinese calligraphy and stumbled over a poem from the year (ca.) 350 AD, the [Lantingji Xu, Preface to the Poems Collected from the Orchid Pavilion](https://en.wikipedia.org/wiki/Lantingji_Xu). I found it touching and fitting to be shared here, and maybe you will enjoy it too:
  In the ninth year of Yonghe, at the onset of late spring,
  we have gathered at the Orchid Pavilion in the North of Kuaiji Mountain for the purification ritual.
  All the literati, the young and the aged, have congregated.
  This location has high mountains and steep hills, dense woods, and tall bamboo,
  as well as a clear, limpid stream reflecting the surroundings.
  We sit by a redirected stream, allowing the wine goblets to float beside us on its winding course.
  Although without the accompaniment of music,
  the wine and poem reciting are sufficient for us to exchange our feelings.
  On this day, the sky is clear, the air is fresh, and a gentle breeze is blowing.
  Looking up, we admire the vastness of the universe;
  looking down, we see the myriad works of poetry.
  Letting the gaze wander and the mind roam, one can fully enjoy the pleasures of sight and sound, truly a delight.
  People's interactions with each other quickly pass through a lifetime.
  Some would share their ambitions in a chamber;
  others may freely indulge in diverse interests and pursuits.
  The choices are plenty and our temperaments vary.
  We enjoy the momentary satisfaction of pleasures that regale us,
  yet we hardly realize how swiftly we age.
  As desires fade and circumstances change, grief arises.
  What previously gratified us will soon be a relic,
  we cannot help but mourn.
  Whether life is long or short, there is always an end.
  As the ancients said,
  "Death and birth are momentous."
  How agonizing!
  Reading the past compositions reveals a consistent melancholy from the ancients.
  One may find themselves lamenting in response to their words, unable to articulate their feelings.
  It is absurd to equate life with death,
  and it is equally foolish to think that longevity is the same as the short-lived.
  The future generations will look upon us,
  just like we look upon our past.
  How sad!
  Hence, we record the people presented here today and their works;
  Even though time and circumstances will be different,
  the feelings expressed will remain unchanged.
  Future readers shall find the same empathy through this collection of poems.

- get bounding box of element on sheet
  Chuong Ho shared a more reliable method GetBboxElementOnSheet
  Getting element coordiantes on sheet
  https://forums.autodesk.com/t5/revit-api-forum/getting-element-coordiantes-on-sheet/td-p/9785396

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

### UIApplication and Bounding Box on Sheet


####<a name="2"></a> Access UIApplication Anywhere

Luiz Henrique [@ricaun](https://ricaun.com/) Cassettari shares yet another new discovery,
how to [get `UIApplication` anywhere](https://forums.autodesk.com/t5/revit-api-forum/get-uiapplication-anywhere/td-p/13341551):

`UIApplication` is the most useful class inside Revit API, providing access to all events, documents and to know whether your code is in the AddInContext (Revit API Context).

It would be really handy is there was way to have access to `UIApplication` any time you need.

There is a way, a native way in the RevitAPIUI.dll, to retrieve the `UIApplication` without any reflection or internal code.
I figured that out that a long time ago (~3 years) when I was messing with events.

The class `RibbonItemEventArgs` provides a direct reference for a new `UIApplication` class:

<pre><code class="language-cs">UIApplication uiapp = new Autodesk.Revit.UI.Events.RibbonItemEventArgs().Application;</code></pre>

I created a class `RevitApplication` in
my [ricaun.Revit.UI](https://github.com/ricaun-io/ricaun.Revit.UI) library
just to have a base standard:

https://github.com/ricaun-io/ricaun.Revit.UI/blob/master/ricaun.Revit.UI/RevitApplication.cs

<pre><code class="language-cs">UIApplication uiapp = RevitApplication.UIApplication;
UIControlledApplication application = RevitApplication.UIControlledApplication;
bool inAddInContext = RevitApplication.IsInAddInContext;</code></pre>

Better still if Autodesk creates a static class like RevitApplication in RevitAPIUI.dll.

That concludes my post, I hope you like it.

See yaa!


<center>
<img src="img/.png" alt="" title="" width="100"/> <!-- Pixel Height: 655 Pixel Width: 800 -->
/center>




