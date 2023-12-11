using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbScript.Reusables
{
    internal class WriteExcel
    {
        public static void WriteDataToASheet(string sheetname,DataTable table,string schema,string tablename)
        {
            string path=  Config.getRootFolder() + "\\" + ConfigurationManager.AppSettings["resultfolder"] + "\\" + schema + "\\" + tablename+"\\latest.xlsx";

            using (ExcelPackage pck = new ExcelPackage(new System.IO.FileInfo(path)))
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add(sheetname);
                ws.Cells["A1"].LoadFromDataTable(table, true);
                pck.Save();
            }
        }
    }
}
