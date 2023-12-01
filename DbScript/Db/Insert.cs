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
        public static string insertionBase( string count, DataTable table,string schema,string tablename)
        {
            int dataCount=Convert.ToInt32(count);
            string statement = "Insert into " + tablename + " ( ";
            List<string> columns = DataOps.readDataTableByColumn("columnname", table);
            List<string> requiredforinsert = DataOps.readDataTableByColumn("requiredforinsert", table);
            for (int i=0;i< columns.Count;i++)
            {
                if (requiredforinsert[i].ToUpper().Trim() == "YES")
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
            }
            statement = statement + " ) values ({{data}})";

            return statement;
        }
        //public static string insertScripts(DataTable table, string schema, string tablename ,string baseScript)
        //{
        //    string scripts = "";
        //    List<string> requiredforinsert = DataOps.readDataTableByColumn("requiredforinsert", table);
        //    List<string> type = DataOps.readDataTableByColumn("type", table);
        //    List<string> size = DataOps.readDataTableByColumn("size", table);
        //    List<string> format = DataOps.readDataTableByColumn("format", table);

        //        string dataset = "";
        //        for (int i = 0; i < type.Count; i++)
        //        {
        //            if (requiredforinsert[i].ToUpper().Trim() == "YES")
        //            {
        //                if (i != table.Rows.Count - 1)
        //                {
        //                    if (type[i].ToUpper().Trim() == "INT" || type[i].ToUpper().Trim() == "BOOL" || type[i]=="BIT")
        //                    {
        //                        dataset = dataset + CallingRandomDataGeneration.RandomDataGenerationCalling      (type[i], size[i], format[i])+",";
        //                    }
        //                    else
        //                    {
        //                       dataset = dataset+"'" + CallingRandomDataGeneration.RandomDataGenerationCalling(type[i], size[i], format[i])+"',";
        //                    }
        //                }
        //                else
        //                {
        //                    if (type[i].ToUpper().Trim() == "INT" || type[i].ToUpper().Trim() == "BOOL" || type[i] == "BIT")
        //                    {
        //                        dataset = dataset + CallingRandomDataGeneration.RandomDataGenerationCalling(type[i], size[i], format[i]);
        //                    }
        //                    else
        //                    {
        //                        dataset = dataset + "'" + CallingRandomDataGeneration.RandomDataGenerationCalling(type[i], size[i], format[i]) "'";
        //                    }
        //                }
        //            }
        //        scripts = baseScript.Replace("{{data}}", dataset);
        //        }
            

        //    return scripts;

        //}
    }
}
