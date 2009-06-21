using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using JrtCoder;

namespace TestJsParser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFormat_Click(object sender, EventArgs e)
        {
            if (rbJS.Checked)
            {
                Beautifier beautifier = new Beautifier();
                CodeStyle style = (CodeStyle)Enum.Parse(typeof(CodeStyle), cbStyle.Text.ToString());
                beautifier.Style = style;
                //beautifier.IsHtmlOutput = true;
                beautifier.IdentStr = (string)cbIndent.SelectedValue ?? this.cbIndent.Text;
                try
                {
                    beautifier.activeOffset = int.Parse(txtActivePos.Text);
                }
                catch { }

                beautifier.js_beautify(this.richTextBox1.Text);

                this.richTextBox2.Text = beautifier.output + "\n" + beautifier.activeFormatedOffset.ToString();


            }
            else
            {
                //SqlBuilder.Parser i_Parser = new SqlBuilder.Parser();
                //i_Parser.Parse(this.richTextBox1.Text, true, false);
                //this.richTextBox2.Text = i_Parser.SQL;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] style = Enum.GetNames(typeof(CodeStyle));
            this.cbStyle.Items.Clear();
            this.cbStyle.Items.AddRange(style);
            this.cbStyle.SelectedIndex = 0;
            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            ht.Add("TAB缩进", "\t");
            ht.Add("4个空格", "    ");
            ht.Add("2个空格", "  ");
            DataTable dt = new DataTable();
            dt.Columns.Add("Teax");
            dt.Columns.Add("Value");
            dt.Rows.Add("TAB缩进", "\t");
            dt.Rows.Add("4个空格", "    ");
            dt.Rows.Add("2个空格", "  ");
            cbIndent.DataSource = dt;
            cbIndent.DisplayMember = "Teax";
            cbIndent.ValueMember = "Value";
            this.cbIndent.SelectedIndex = 0;
        }
    }
}
