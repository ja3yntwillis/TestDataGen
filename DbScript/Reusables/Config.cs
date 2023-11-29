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
        static string fileLocation = "C:\\Piyali\\Tasks\\Short_Term_Goal\\TestdataGenerationTool\\TestDataGen\\DbScript\\Config.xlsx";
        //static string fileLocation = "C:\\Users\\jaydutt\\source\\test\\TestDataGen\\DbScript\\Config.xlsx"
        static DataTable CommonSheet = ReadExcel.ExcelDataToDataTable(fileLocation, "Common", true);
        public static Dictionary<string,string> Dbconfig()
        {
            Dictionary <string, string> data= new Dictionary<string, string>();
            List<string> commondata = DataOps.readDataTableByRow(0, CommonSheet);

            data.Add("dbConnectionString",commondata[0]);
            data.Add("dbName", commondata[1]);
            data.Add("authtype", commondata[2]);
            data.Add("user", commondata[3]);
            data.Add("password", commondata[4]);
            data.Add("DbServer", commondata[5]);
            return data;
        }
    }
}
