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
                ConnectionStatus.Text = "Connection Successful to "+ DatabaseConnection.dbName;
                ConnectionStatus.ForeColor = System.Drawing.Color.Green;

               // Insert.insertData("INSERT INTO dbo.person (firstName,lastName) VALUES ('IMTestFirst','IMTestLast')");

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

        private void button2_Click(object sender, EventArgs e)
        {
            Tool.Tool.CreateStructure();
        }
    }
}
