using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TableToRdlc.Report;

namespace TableToRdlc
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var table = WebTable.HtmlToTable(this.richTextBox1.Text);

            table.Computer();
        }
    }
}
