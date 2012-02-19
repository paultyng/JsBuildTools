using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using VSLangProj80;

namespace JsBuildTools
{
    /// <summary>
    /// This is the generator class. 
    /// When setting the 'Custom Tool' property of a C#, VB, or J# project item to "RazorGenerator", 
    /// the GenerateCode function will get called and will return the contents of the generated file 
    /// to the project system
    /// </summary>
    [ComVisible(true)]
    [Guid("CC600501-4B2A-469D-9833-2C70DACB0244")]
    [CodeGeneratorRegistration(typeof(CoffeeScriptBuildTool), "Coffee Script Generator", vsContextGuids.vsContextGuidVCSProject, GeneratesDesignTimeSource = true)]
    [ProvideObject(typeof(CoffeeScriptBuildTool))]
    public class CoffeeScriptBuildTool : JsLibraryBuildTool<CoffeeScriptWrapper>
    {
        protected override string GetDefaultExtension()
        {
            return ".coffee.js";
        }
    }
}
