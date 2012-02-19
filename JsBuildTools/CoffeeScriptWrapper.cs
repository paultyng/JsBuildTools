using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using Jurassic;

namespace JsBuildTools
{
    public class CoffeeScriptWrapper : JsLibraryWrapper<CoffeeScriptWrapper>
	{
        public CoffeeScriptWrapper()
            : base("JsBuildTools.coffee-script-1.2.0.js")
        {

        }

        protected override void PostExecuteLibrary(ScriptEngine engine)
        {
            engine.Execute("var " + ProcessFunctionName + " = function(src) { return CoffeeScript.compile(src, { bare: true }); };");
        }
	}
}
