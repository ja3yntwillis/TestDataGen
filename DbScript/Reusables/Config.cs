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
        static DataTable CommonSheet = ReadExcel.ExcelDataToDataTable("C:\\Users\\jaydutt\\source\\test\\TestDataGen\\DbScript\\Config.xlsx", "Common", true);
        public static Dictionary<string,string> Dbconfig()
        {
            Dictionary <string, string> data= new Dictionary<string, string>();
            List<string> commondata = DataOps.readDataTableByRow(0, CommonSheet);

            data.Add("dbConnectionString",commondata[0]);
            data.Add("dbName", commondata[1]);
            data.Add("authtype", commondata[2]);
            data.Add("user", commondata[3]);
            data.Add("password", commondata[4]);
            return data;
        }
    }
}
