using DbScript.Db;
using DbScript.Reusables;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TestDataGen.Reusables;

namespace DbScript.Tool
{
    internal class Tool
    {
        public static void CreateStructure()
        {
            string runner = Config.getRootFolder() + "\\" + ConfigurationManager.AppSettings["runner"];
            string runnersheet = ConfigurationManager.AppSettings["runnersheet"];
            DataTable table = ReadExcel.ExcelDataToDataTable(runner, runnersheet, true);
            DataTable structure=new DataTable();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                var required = table.Rows[i]["Required"].ToString();

                if (required.ToUpper().Trim() == "YES")
                {
                    Config.createStructureDir(table.Rows[i]["Schema"].ToString(), table.Rows[i]["Table"].ToString());
                    string query = "SELECT COLUMN_NAME as columnname, CASE WHEN COLUMNPROPERTY(OBJECT_ID(TABLE_SCHEMA + '.' + TABLE_NAME), COLUMN_NAME, 'IsIdentity') = 1 THEN 'YES' ELSE 'NO' END AS isidentity,DATA_TYPE as type, '' as size,'' as format ,CASE WHEN IS_NULLABLE = 'NO' THEN 'YES' WHEN IS_NULLABLE = 'YES' THEN 'NO' ELSE IS_NULLABLE END AS requiredforinsert,'Random' as generationtechniqueinsert, 'No' as requiredforupdate,'' as updatebasedon,'Random' as generationtechniqueupdate,'No' as requiredfordelete FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA ='" + table.Rows[i]["Schema"].ToString() + "' AND TABLE_NAME = '"+ table.Rows[i]["Table"].ToString()+ "' order by requiredforinsert desc";
                    structure=Select.getDataByQuery(query);
                    WriteExcel.WriteStructureToASheet(ConfigurationManager.AppSettings["tablefilesheet"], structure, table.Rows[i]["Schema"].ToString(), table.Rows[i]["Table"].ToString());


                }
            }
        }
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
                    switch (OperationType.ToUpper().Trim())
                    {
                        case "INSERT":
                            DataTable dataStructure= ReadExcel.ExcelDataToDataTable(testfilepath, testfileSheet, true);
                            DataTable dataOfInsert=Insert.performInsertion(dataStructure, table.Rows[i]["Schema"].ToString(), table.Rows[i]["Table"].ToString(), table.Rows[i]["Count"].ToString());
                            WriteExcel.WriteResultDataToASheet("Insert", dataOfInsert, table.Rows[i]["Schema"].ToString(), table.Rows[i]["Table"].ToString());
                            break;
                        default: break;

                    }
                }
            }

       
        }
    }
}
