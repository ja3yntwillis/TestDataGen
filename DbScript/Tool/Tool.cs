using DbScript.Db;
using DbScript.Reusables;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            string runner =Config.getRootFolder()+"\\"+ConfigurationManager.AppSettings["runner"];
            string runnersheet = ConfigurationManager.AppSettings["runnersheet"];   
            DataTable table = ReadExcel.ExcelDataToDataTable(runner, runnersheet,true);
            for(int i = 0; i < table.Rows.Count; i++)
            {
                var required = table.Rows[i]["Required"].ToString();

                if(required =="Yes")
                {
                    var OperationType= table.Rows[i]["OperationType"].ToString();
                    string testfilepath = Config.getRootFolder() + "\\" + ConfigurationManager.AppSettings["dbfolder"] + "\\" + table.Rows[i]["Schema"].ToString() + "\\" + table.Rows[i]["Table"].ToString() + "\\" + ConfigurationManager.AppSettings["tablefilename"];
                    string testfileSheet = ConfigurationManager.AppSettings["tablefilesheet"];
                    switch (OperationType)
                    {
                        case "Insert":
                            DataTable dataStructure= ReadExcel.ExcelDataToDataTable(testfilepath, testfileSheet, true);
                           bool result= Insert.insertion(table.Rows[i]["Count"].ToString(), dataStructure, table.Rows[i]["Schema"].ToString(), table.Rows[i]["Table"].ToString());
                            break;
                        default: break;

                    }
                }
            }


        }
    }
}
