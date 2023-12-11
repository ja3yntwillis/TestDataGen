using DbScript.Reusables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbScript.DataGeneration
{
    internal class CaptureSheetData
    {

        public static string readDatafromSheet(string columnname,DataTable dt,int count)
        {
            return DataOps.readDataTableByColumn(columnname, dt)[count];
        }
    }
}
