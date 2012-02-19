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
    [Guid("61C6B7C8-9FA7-407F-BE57-31BE42A4BC32")]
    [CodeGeneratorRegistration(typeof(LessCssBuildTool), "LESS CSS Generator", vsContextGuids.vsContextGuidVCSProject, GeneratesDesignTimeSource = true)]
    [ProvideObject(typeof(LessCssBuildTool))]
    public class LessCssBuildTool : BaseCodeGenerator
    {
        protected override string GetDefaultExtension()
        {
            return ".less.css";
        }

        protected override byte[] GenerateCode(string inputFileContent)
        {
            var wrapper = new LessCssWrapper();

            return Encoding.UTF8.GetBytes(wrapper.Execute(inputFileContent));
        }
    }
}
