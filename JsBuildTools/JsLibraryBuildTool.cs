using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace JsBuildTools
{
    [Guid("42DCBCF1-6D8B-4743-A9CC-87CF4F0E93F8")]
    [ComVisible(true)]
    public abstract class JsLibraryBuildTool<T> : BaseCodeGenerator where T : JsLibraryWrapper<T>, new()
    {
        protected override byte[] GenerateCode(string inputFileContent)
        {
            var wrapper = new T();

            return Encoding.UTF8.GetBytes(wrapper.Execute(inputFileContent));
        }
    }
}
