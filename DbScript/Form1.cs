using DbScript.Db;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace DbScript
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckConnection.PerformClick();
        }
        private void CheckConnection_Click(object sender, EventArgs e)
        {
            // Tool.Tool.StartTool();
            DatabaseConnection dbConnectObj = new DatabaseConnection();
            CheckConnection.FlatStyle = FlatStyle.Flat;
            CheckConnection.FlatAppearance.BorderColor = BackColor;
            CheckConnection.FlatAppearance.MouseOverBackColor = BackColor;
            CheckConnection.FlatAppearance.MouseDownBackColor = BackColor;
           
            if (dbConnectObj.connectioncheck()==true)
            {
                ConnectionStatus.Text = "Connection Successful to "+ ConfigurationManager.AppSettings["dbName"];
                ConnectionStatus.ForeColor = System.Drawing.Color.Green;
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
