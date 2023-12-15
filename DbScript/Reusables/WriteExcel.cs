using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbScript.Reusables
{
    internal class WriteExcel
    {
        public static void WriteResultDataToASheet(string sheetname,DataTable table,string schema,string tablename)
        {
            string path=  Config.getRootFolder() + "\\" + ConfigurationManager.AppSettings["resultfolder"] + "\\" + schema + "\\" + tablename+"\\"+tablename+"_latest.xlsx";
            DateTime currentDateTime = DateTime.Now;
            string timestamp = currentDateTime.ToString("yyyyMMddHHmmss");
            Config.RenameFile(path, tablename + "_Archive_"+ timestamp+".xlsx");

            using (ExcelPackage pck = new ExcelPackage(new System.IO.FileInfo(path)))
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add(sheetname);
                ws.Cells["A1"].LoadFromDataTable(table, true);
                pck.Save();
            }
        }
        public static void WriteStructureToASheet(string sheetname, DataTable table, string schema, string tablename)
        {
            string path = Config.getRootFolder() + "\\" + ConfigurationManager.AppSettings["dbfolder"] + "\\" + schema + "\\" + tablename + "\\" + ConfigurationManager.AppSettings["tablefilename"];
            if (!File.Exists(path))
            {
                using (ExcelPackage pck = new ExcelPackage(new System.IO.FileInfo(path)))
                {
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add(sheetname);
                    ws.Cells["A1"].LoadFromDataTable(table, true);
                    pck.Save();
                }
            }
        }
    }
}
