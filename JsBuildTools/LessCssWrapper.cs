using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace JsBuildTools
{
    public class LessCssWrapper
    {
        public string Execute(string source)
        {
            var a = Assembly.GetExecutingAssembly();
            using (var s = a.GetManifestResourceStream("JsBuildTools.less-1.2.1.js"))
            {
                return Execute(s, source);
            }
        }

        public string Execute(Stream library, string source)
        {
            var js = new StringBuilder();

            js.AppendLine("String.prototype.substr = String.prototype.substring;");
            js.AppendLine("var window = {}, location = {}, document = {}; location.port = ''; document.getElementsByTagName = function(tagName) { return []; };");
   
            using (var sw = new StreamReader(library))
            {
                js.AppendLine(sw.ReadToEnd());
            }

            js.AppendLine("var parser = new window.less.Parser, parseOutput, errorOutput;");
            js.AppendLine("parser.parse(toParse, function (err, tree) { errorOutput = err; parseOutput = tree.toCSS(); });");

            var host = new Jurassic.ScriptEngine();

            host.SetGlobalValue("toParse", source);

            host.Execute(js.ToString());

            var error = host.GetGlobalValue<string>("errorOutput");

            return host.GetGlobalValue<string>("parseOutput");
        }
    }
}
