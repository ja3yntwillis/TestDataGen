using DbScript.Reusables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDataGen.Reusables;

namespace DbScript.Tool
{
    internal class Tool
    {
      public static void StartTool()
        {
            Dictionary<string, string> dbConfig = Config.Dbconfig();
            var a= dbConfig["dbConnectionString"];
        }
    }
}
