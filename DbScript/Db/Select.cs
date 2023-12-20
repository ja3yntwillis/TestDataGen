using DbScript.Reusables;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DbScript.Db
{
    internal class Select
    {
        static string databaseserver = ConfigurationManager.AppSettings["databaseserver"];
        public static string dbName = ConfigurationManager.AppSettings["dbName"];
        static string authtype = ConfigurationManager.AppSettings["authtype"];
        static string user = ConfigurationManager.AppSettings["user"];
        static string password = ConfigurationManager.AppSettings["password"];
        static string DbServer = ConfigurationManager.AppSettings["DbServer"];
        public static DataTable getDataByQuery(string Query)
        {
            DataTable dataTable = new DataTable();
            try
            {
                 SqlConnection Connection = DatabaseConnection.getConnectionStringForSQLServer(databaseserver, dbName, authtype, user, password, DbServer);
                using (SqlConnection connection = Connection)
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(Query, connection))
                    {


                        // Fill the DataTable with the results of the query
                        adapter.Fill(dataTable);

                        // Process the DataTable as needed
                        foreach (DataRow row in dataTable.Rows)
                        {
                            foreach (DataColumn col in dataTable.Columns)
                            {
                                Console.Write($"{col.ColumnName}: {row[col]} | ");
                            }
                            Console.WriteLine();
                        }
                        SqlCommand command = new SqlCommand(Query, DatabaseConnection.Connection);
                        command.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DatabaseConnection.Connection.Close();
            }
            return dataTable;
        }

    }
}
