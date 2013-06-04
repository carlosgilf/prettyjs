#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace Bronze.Controls.Examples
{
    public partial class SelectorTest : Form
    {
        public SelectorTest()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = !this.panel1.Visible;
        }

        private void SelectorTest_Load(object sender, EventArgs e)
        {
            selectorTextBox1.SplitString = ",，;；\r;\n";
            selectorTextBox1.VaildExpression = @"^\d+$";
            selectorTextBox1.VaildExpressionMsg = "格式不正确，号码必须为数字";
            selectorTextBox1.DisplayFormat = "{Text}<span style='color: #666666'><{Value}></span>";
            selectorTextBox1.ClientInputDisplayFormat = "{Text}<span style='color: #666666'></span>";


            selectorTextBox1.OnClientChanagedScript = "alert(this.Items.length);";
            selectorTextBox1.OnClientRemoveScript = "alert(this.Text+','+this.Value);";


            for (long i = 13578778700; i < 13578778720; i++)
            {
                this.selectorTextBox1.Items.Add(new Bronze.Controls.VWG.SelectorTextBox.Selector { Text = "张三枫", Value = i, Id = i, Tooltip = "描述信息" + i });
            }
        }

      
    }
}