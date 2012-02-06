using JsBuildTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JsBuildTools.Tests
{
   
    [TestClass()]
    public class LessCssWrapperTest
    {


        [TestMethod()]
        public void ExecuteTest()
        {
            var target = new LessCssWrapper();
            string css = ".class { width: 1 + 1 }";
            string expected = ".class {\n  width: 2;\n}\n"; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.Execute(css);
            Assert.AreEqual(expected, actual);
        }
    }
}
