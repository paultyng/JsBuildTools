using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jurassic;
using System.Reflection;
using System.IO;

namespace JsBuildTools
{
    /// <remarks>Generic simply to break out the statics</remarks>
    public abstract class JsLibraryWrapper<T> where T : JsLibraryWrapper<T>
    {
        static object _lock = new object();
        static ScriptEngine _host;
        static int _lastSourceHashCode;

        string _defaultLibrary;

        protected JsLibraryWrapper(string defaultLibrary)
        {
            _defaultLibrary = defaultLibrary;
        }

        public string Execute(string source)
        {
            var a = Assembly.GetExecutingAssembly();
            using (var s = a.GetManifestResourceStream(_defaultLibrary))
            {
                using (var sw = new StreamReader(s))
                {
                    return Execute(sw.ReadToEnd(), source);
                }
            }
        }

        protected virtual void PreExecuteLibrary(ScriptEngine engine) { }
        protected virtual void PostExecuteLibrary(ScriptEngine engine) { }

        protected virtual string ProcessFunctionName { get { return "process"; } }
        protected virtual string ErrorOutputName { get { return "errorOut"; } }

        public string Execute(string library, string source)
        {
            if (_host == null || _lastSourceHashCode != library.GetHashCode())
            {
                lock (_lock)
                {
                    if (_host == null || _lastSourceHashCode != library.GetHashCode())
                    {
                        var engine = new ScriptEngine();

                        PreExecuteLibrary(engine);
                        engine.Execute(library);
                        PostExecuteLibrary(engine);

                        _lastSourceHashCode = library.GetHashCode();
                        _host = engine;
                    }
                }
            }

            lock (_lock)
            {
                _host.SetGlobalValue(ErrorOutputName, string.Empty);
                var result = _host.CallGlobalFunction<string>(ProcessFunctionName, source);
                var error = _host.GetGlobalValue<string>(ErrorOutputName);

                if (!string.IsNullOrWhiteSpace(error))
                {
                    throw new InvalidOperationException(error);
                }

                return result;
            }
        }
    }
}
