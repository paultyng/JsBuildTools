# JsBuildTools

Provides [LESS](http://lesscss.org/) CSS support in Visual Studio at design time.  

The package contains a custom build tool, just set the **Custom Tool** to **LessCssBuildTool** in your file properties on a .less file, and the tool will generate the output .css file for you.

For example if you create a **site.less** with this build tool, in Visual Studio you will get a **site.less.css**.

## Coming Soon

* Coffee Script support

## Known Issues

* Support for `@import`