using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace JsBuildTools
{
    public class LessCssWrapper : JsLibraryWrapper<LessCssWrapper>
    {
        public LessCssWrapper() : base("JsBuildTools.less-1.2.2.js")
        {

        }

        protected override void PreExecuteLibrary(Jurassic.ScriptEngine engine)
        {
            engine.Execute("var window = {}, location = {}, document = {}; location.port = ''; document.getElementsByTagName = function(tagName) { return []; };");            
        }

        protected override void PostExecuteLibrary(Jurassic.ScriptEngine engine)
        {
            engine.Execute("var " + ProcessFunctionName + " = function(src) { var parseOutput, errorOutput, parser = new window.less.Parser; parser.parse(src, function(err, tree) { errorOutput = err; parseOutput = tree.toCSS(); }); return parseOutput; };");
        }
    }
}
