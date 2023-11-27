using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataGen.Reusables
{
    public class ReadExcel
    {
        public static DataTable ExcelDataToDataTable(string filePath, string sheetName, bool hasHeader = true)
        {
            var dt = new DataTable();
            var fi = new FileInfo(filePath);
            if (!fi.Exists)
                throw new Exception("File " + filePath + " Does Not Exists");

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var xlPackage = new ExcelPackage(fi);
            var worksheet = xlPackage.Workbook.Worksheets[sheetName];

            dt = worksheet.Cells[1, 1, worksheet.Dimension.End.Row, worksheet.Dimension.End.Column].ToDataTable(c =>
            {
                c.FirstRowIsColumnNames = true;
            });

            return dt;
        }
        public static void readSheet(string wb,string sheetname)
        {
            FileInfo existingFile = new FileInfo(wb);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[sheetname];
                int colCount = worksheet.Dimension.End.Column;
                int rowCount = worksheet.Dimension.End.Row;     
                for (int row = 1; row <= rowCount; row++)
                {

                    for (int col = 1; col <= colCount; col++)
                    {
                        var    a=" Row:" + row + " column:" + col + " Value:" + worksheet.Cells[row, col].Value;
                        Console.WriteLine();
                    }
                }
            }
        }


    }
}
