using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
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
        public static void createStructureDir(string schema, string tablename)
        {
            string dbfolder = Config.getRootFolder() + "\\" + ConfigurationManager.AppSettings["dbfolder"];
            string schemapath = dbfolder + "\\" + schema;
            string tablepath = schemapath + "\\" + tablename;
            System.IO.Directory.CreateDirectory(schemapath);
            System.IO.Directory.CreateDirectory(tablepath);
        }
        public static DataTable createHeaders(DataTable dataTable) {

            dataTable.Columns.Add("columnname", typeof(string));
            dataTable.Columns.Add("isIdentity", typeof(string));
            dataTable.Columns.Add("type", typeof(string));
            dataTable.Columns.Add("size", typeof(string));
            dataTable.Columns.Add("format", typeof(string));
            dataTable.Columns.Add("requiredforinsert", typeof(string));
            dataTable.Columns.Add("generationtechniqueinsert", typeof(string));
            dataTable.Columns.Add("requiredforupdate", typeof(string));
            dataTable.Columns.Add("updatebasedon", typeof(string));
            dataTable.Columns.Add("generationtechniqueUpdate", typeof(string));
            dataTable.Columns.Add("requiredfordelete", typeof(string));

            return dataTable;
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
        public static bool RenameFile(string filePath, string newFileName)
        {
            bool status= false;
            if (File.Exists(filePath))
            {
                try
                {
                    string newFilePath = Path.Combine(Path.GetDirectoryName(filePath), newFileName);
                    File.Move(filePath, newFilePath);
                    status= true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    status= false;
                }
            }
            return status;
        }
    }
}
