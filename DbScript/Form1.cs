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
        }

        private void CheckConnection_Click(object sender, EventArgs e)
        {
            // Tool.Tool.StartTool();
            DatabaseConnection dbConnectObj = new DatabaseConnection();
            ConnectionStatus.Text= dbConnectObj.connectioncheck()+"";
        }
    }
}
