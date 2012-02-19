using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JsBuildTools.Tests
{
	[TestClass]
	public class CoffeeScriptWrapperTest
	{


		[TestMethod]
		public void ExecuteTest()
		{
			var target = new CoffeeScriptWrapper();
			string source = "\nnumber = 42\n";
			string expected = "var number;\n\nnumber = 42;\n"; // TODO: Initialize to an appropriate value
			string actual;
			actual = target.Execute(source);
			Assert.AreEqual(expected, actual);
		}
	}
}
