using DbScript.Db;
using System;
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
                ConnectionStatus.Text = "Connection Successful";
                ConnectionStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                ConnectionStatus.Text = "Connection Unuccessful Check Configuration";
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
