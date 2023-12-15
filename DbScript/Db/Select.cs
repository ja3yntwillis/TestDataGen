using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbScript.Db
{
    internal class Select
    {
        public static DataTable getDataByQuery(string Query)
        {
            DataTable dataTable = new DataTable();
            try
            {
                
                using (SqlConnection connection = DatabaseConnection.Connection)
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
