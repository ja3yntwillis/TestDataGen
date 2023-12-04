using DbScript.Db;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Collections;


namespace DbScript
{
    public partial class Form1 : Form
    {
        DatabaseConnection dbConnectObj = new DatabaseConnection();
        public Form1()
        {
            InitializeComponent();
            CheckConnection.PerformClick();
        }
        private void CheckConnection_Click(object sender, EventArgs e)
        {
            // Tool.Tool.StartTool();
           //DatabaseConnection dbConnectObj = new DatabaseConnection();
            CheckConnection.FlatStyle = FlatStyle.Flat;
            CheckConnection.FlatAppearance.BorderColor = BackColor;
            CheckConnection.FlatAppearance.MouseOverBackColor = BackColor;
            CheckConnection.FlatAppearance.MouseDownBackColor = BackColor;
           
            if (dbConnectObj.connectioncheck()==true)
            {
                ConnectionStatus.Text = "Connection Successful to "+ ConfigurationManager.AppSettings["dbName"];
                ConnectionStatus.ForeColor = System.Drawing.Color.Green;

                // To check insertion is hppening or not //
               /* string databaseserver = ConfigurationManager.AppSettings["databaseserver"];
                string dbName = ConfigurationManager.AppSettings["dbName"];
                string authtype = ConfigurationManager.AppSettings["authtype"];
                string user = ConfigurationManager.AppSettings["user"];
                string password = ConfigurationManager.AppSettings["password"];
                string DbServer = ConfigurationManager.AppSettings["DbServer"];
                SqlConnection Connection = dbConnectObj.getConnectionStringForSQLServer(databaseserver, dbName, authtype, user, password, DbServer);
                String query = "INSERT INTO dbo.person (firstName,lastName) VALUES ('IMTestFirst','IMTestLast')";
                
               try
                {
                    Connection.Open();
                    SqlCommand command = new SqlCommand(query, Connection);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Query executed and data has been inserted.");
                    Connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }*/
              // piyali end //  

            }
            else
            {
                ConnectionStatus.Text = "Connection Unuccessful Check Configuration for " + ConfigurationManager.AppSettings["dbName"]+" at App.config";
                ConnectionStatus.ForeColor = System.Drawing.Color.Red;
            }
           



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckConnection.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tool.Tool.StartTool();
        }
    }
}
