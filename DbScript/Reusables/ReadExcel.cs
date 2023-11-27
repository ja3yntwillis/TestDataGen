using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataGen.Reusables
{
    public class ReadExcel
    {
        public static void readDataByRow(string wb,string sheetname)
        {
            FileInfo existingFile = new FileInfo(wb);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                //get the first worksheet in the workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets[sheetname];
                int colCount = worksheet.Dimension.End.Column;  //get Column Count
                int rowCount = worksheet.Dimension.End.Row;     //get row count
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
