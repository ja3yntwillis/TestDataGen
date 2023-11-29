using DbScript.Db;
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
            DatabaseConnection dbConnectObj = new DatabaseConnection();
            dbConnectObj.connectioncheck();
        }
    }
}
