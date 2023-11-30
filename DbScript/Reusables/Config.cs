using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataGen.Reusables;

namespace DbScript.Reusables
{
    internal class Config
    {
        public static string getRootFolder()
        {
            String currpath = System.IO.Directory.GetCurrentDirectory();
            return currpath.Split(new string[] { "\\bin" }, StringSplitOptions.None)[0];
        }
    }
}
