using JsBuildTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JsBuildTools.Tests
{
    [TestClass]
    public class LessCssWrapperTest
    {
        [TestMethod]
        public void ColorVariableTest()
        {
            var target = new LessCssWrapper();
            string css = "@color: #009DAB;\nbody {\n  color: @color;\n}";
            string expected = "body {\n  color: #009dab;\n}\n";
            string actual;
            actual = target.Execute(css);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SimpleExecuteTest()
        {
            var target = new LessCssWrapper();
            string css = ".class { width: 1 + 1 }";
            string expected = ".class {\n  width: 2;\n}\n";
            string actual;
            actual = target.Execute(css);
            Assert.AreEqual(expected, actual);
        }
    }
}
