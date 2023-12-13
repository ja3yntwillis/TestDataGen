using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbScript.Db
{
    internal class Select
    {
        public static void  executeSelectQuery(string Query)
        {
           //string status = "not Executed";
           // try
           // {
           //     DatabaseConnection.Connection.Open();
           //     SqlCommand command = new SqlCommand(Query, DatabaseConnection.Connection);
           //     command.ExecuteNonQuery();
           //     status = "Success";

           // }
           // catch (Exception ex)
           // {
           //     status = "Failure \r\n" + ex.Message;
           //     Console.WriteLine(ex.Message);
           // }
           // finally
           // {
           //     DatabaseConnection.Connection.Close();
           // }
           // return status;
        }

    }
}
