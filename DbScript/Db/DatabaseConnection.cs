using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using DbScript.Reusables;
using System.Xml.Linq;
using System.Collections;

namespace DbScript.Db
{
    internal class DatabaseConnection
    {
        static Dictionary<string, string> dbConfig = Config.Dbconfig();
        string databaseserver = dbConfig["dbConnectionString"];
        string dbName = dbConfig["dbName"];
        string authtype = dbConfig["authtype"];
        string user = dbConfig["user"];
        string password = dbConfig["password"];
        string DbServer = dbConfig["DbServer"];
 
        public SqlConnection getConnectionStringForSQLServer(string databaseserver, string database, string authtype, string user, string password, string Dbserver)
        {
            String CS = "";
            switch (Dbserver)
            {
                case "MSSQLSERVER":
                    switch (authtype)
                {
                    case "Windows":
                        CS = String.Format("Data Source=" + databaseserver + ";Initial Catalog=" + database + ";Integrated Security=SSPI;uid=" + user + ";");
                        break;
                    default:
                        throw new Exception("Please choose a valid authtype supported by application");

                }
                    break;
                default: throw new Exception("Please choose a valid database supported by application");

            }
            return new SqlConnection(CS);

        }
       
        public DataTable getdatafromQuery(string Query)
        {
            SqlConnection Connection = getConnectionStringForSQLServer(databaseserver, dbName, authtype, user, password, DbServer);
            SqlDataAdapter sda = new SqlDataAdapter(Query, Connection);
            DataTable dt = new DataTable();

            try
            {
                Connection.Open();
                sda.Fill(dt);
                Connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return dt;
        }
        public ConnectionState connectioncheck()
        {
            SqlConnection Connection = getConnectionStringForSQLServer(databaseserver, dbName, authtype, user, password, DbServer);
            Connection.Open();
            var state = Connection.State;
            return state;

        }
    }
}
