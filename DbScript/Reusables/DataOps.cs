using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbScript.Reusables
{
    internal class DataOps
    {
        public static List<string> readDataTableByRow(int rowid, DataTable input)
        {
            var list = new List<string>();
            for (int i = 0;i<input.Columns.Count;i++)
            {
                list.Add(input.Rows[rowid][i]+"");
            }
            return list;
        }
        public static List<string> readDataTableByColumn(string columnname, DataTable input)
        {
            var list = new List<string>();
            for (int i = 0; i < input.Rows.Count; i++)
            {
                list.Add(input.Rows[i][columnname] + "");
            }
            return list;
        }
    }
}
