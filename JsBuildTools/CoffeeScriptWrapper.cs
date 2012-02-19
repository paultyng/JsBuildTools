using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace JsBuildTools
{
	public class CoffeeScriptWrapper
	{
		public string Execute(string source)
		{
			var a = Assembly.GetExecutingAssembly();
			using (var s = a.GetManifestResourceStream("JsBuildTools.coffee-script-1.2.0.js"))
			{
				return Execute(s, source);
			}
		}

		public string Execute(Stream library, string source)
		{
			var js = new StringBuilder();

			js.AppendLine("String.prototype.substr = String.prototype.substring;");
			//js.AppendLine("var window = {}, location = {}, document = {};");

			using (var sw = new StreamReader(library))
			{
				js.AppendLine(sw.ReadToEnd());
			}

			js.AppendLine("var library = window.CoffeeScript, sourceOutput, errorOutput;");
			js.AppendLine("sourceOutput = library.compile(sourceInput);");

            var host = new Jurassic.ScriptEngine();

            host.SetGlobalValue("sourceInput", source);
			host.Execute(js.ToString());

			var error = host.GetGlobalValue<string>("errorOutput");

			return host.GetGlobalValue<string>("sourceOutput");
		}
	}
}
