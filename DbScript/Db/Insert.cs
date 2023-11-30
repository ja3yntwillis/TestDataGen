using DbScript.Reusables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbScript.Db
{
    internal class Insert
    {
        public static bool insertion( string count, DataTable table,string schema,string tablename)
        {
            int dataCount=Convert.ToInt32(count);
            string statement = "Insert into " + tablename + " (";
            List<string> columns = DataOps.readDataTableByColumn("columnname", table);
            for (int i=0;i< columns.Count;i++)
            {
                if (i != table.Rows.Count - 1)
                {
                    statement = statement + columns[i] + ",";
                }
                else
                {
                    statement = statement + columns[i];
                }
            }
            statement = statement + " ) values (";
            return true;
        }
    }
}
