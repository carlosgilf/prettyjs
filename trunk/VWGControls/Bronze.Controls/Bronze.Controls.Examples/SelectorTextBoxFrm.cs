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
    public partial class SelectorTextBoxFrm : Form
    {
        public SelectorTextBoxFrm()
        {
            InitializeComponent();
        }

        private void SelectorTextBoxFrm_Load(object sender, EventArgs e)
        {
            selectorTextBox1.SplitString = ",\r;\n";
            selectorTextBox1.VaildExpression = @"^\d+$";
            selectorTextBox1.VaildExpressionMsg = "��ʽ����ȷ���������Ϊ����";
            selectorTextBox1.DisplayFormat = "{Text}<span style='color: #666666'>{Value};</span>";
            for (int i = 0; i < 20; i++)
            {
                this.selectorTextBox1.Items.Add(new Bronze.Controls.VWG.SelectorTextBox.Selector { Text = "������" , Value = i, Id = i, Tooltip = "������Ϣ" + i });
            }

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.selectorTextBox1.Items.Add(new Bronze.Controls.VWG.SelectorTextBox.Selector { Text = "С��", Value ="", Id = Guid.NewGuid().ToString(), Tooltip = "������Ϣ11"  });
            //this.selectorTextBox1.Update();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}