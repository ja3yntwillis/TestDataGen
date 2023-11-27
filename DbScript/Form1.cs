using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestDataGen.Reusables;

namespace DbScript
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var table=ReadExcel.ExcelDataToDataTable("C:\\Users\\jaydutt\\source\\test\\TestDataGen\\DbScript\\dbConfig\\Enrollment\\PersonNameActual\\structure.xlsx", "structure",true);
            Console.Write(table);
        }
    }
}
