using System;
using System.Collections.Generic;
using System.Configuration;
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
        public static void createResultDir(string schema,string tablename) {
            string resultfolder = Config.getRootFolder() + "\\" + ConfigurationManager.AppSettings["resultfolder"];
            string schemapath = resultfolder + "\\" + schema;
            string tablepath = schemapath + "\\" + tablename;
            System.IO.Directory.CreateDirectory(schemapath);
            System.IO.Directory.CreateDirectory(tablepath);
        }
        public static DataTable getResultDataTable(List<string> columnName) {
            DataTable resultData = new DataTable();
            for (int j = 0; j < columnName.Count; j++)
            {
                resultData.Columns.Add(columnName[j], typeof(string));
            }
            resultData.Columns.Add("Query", typeof(string));
            resultData.Columns.Add("Status", typeof(string));

            return resultData;

        }
    }
}
