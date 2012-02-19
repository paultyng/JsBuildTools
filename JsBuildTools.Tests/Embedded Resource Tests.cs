using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace JsBuildTools.Tests
{
    [TestClass]
    public class Embedded_Resource_Tests
    {
        [TestMethod]
        public void File_Tests()
        {
            foreach (var f in typeof(Embedded_Resource_Tests).Assembly.GetManifestResourceNames())
            {
                if (Path.GetExtension(f) == ".less")
                {
                    var source = ReadResource(f);
                    var expected = ReadResource(f + ".css");
                    var target = new LessCssWrapper();
                    var actual = target.Execute(source);
                    AssertTextEqual(expected, actual, f);
                }
            }
        }

        static void AssertTextEqual(string expected, string actual, string message, StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries)
        {
            var eLines = expected.Split(new char[] { '\n', '\r' }, options);
            var aLines = actual.Split(new char[] { '\n', '\r' }, options);

            for (var i = 0; i < Math.Min(eLines.Length, aLines.Length); i++)
            {
                Assert.AreEqual(eLines[i], aLines[i], message);
            }

            Assert.AreEqual(eLines.Length, aLines.Length, message);
        }

        static string ReadResource(string name)
        {
            using (var s = typeof(Embedded_Resource_Tests).Assembly.GetManifestResourceStream(name))
            {
                using (var sw = new StreamReader(s))
                {
                    return sw.ReadToEnd();
                }
            }                        
        }
    }
}
