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
    public partial class SelectorTextboxListTest : Form
    {
        public SelectorTextboxListTest()
        {
            InitializeComponent();
        }

        private void SelectorTextboxListTest_Load(object sender, EventArgs e)
        {
            
            selectorTextboxList1.SplitString = ",��;��\r;\n";
            selectorTextboxList1.VaildExpression = @"^\d+$";
            selectorTextboxList1.VaildExpressionMsg = "��ʽ����ȷ���������Ϊ����";
            selectorTextboxList1.DisplayFormat = "{Text}<span style='color: #666666'><{Value}></span>";
            selectorTextboxList1.ClientInputDisplayFormat = "{Text}<span style='color: #666666'></span>";
            selectorTextboxList1.EmptyMessage = "��ѡ���ұߵ���ϵ��";
            for (long i = 13578778700; i < 13578778720; i++)
            {
                this.selectorTextboxList1.Items.Add(new Bronze.Controls.VWG.SelectorTextBox.Selector { Text = "������", Value = i, Id = i, Tooltip = "������Ϣ" + i });
            }
        }
    }
}