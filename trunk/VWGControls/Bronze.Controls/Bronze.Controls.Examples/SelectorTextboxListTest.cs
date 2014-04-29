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
            
            selectorTextboxList1.SplitString = ",，;；\r;\n";
            selectorTextboxList1.VaildExpression = @"^\d+$";
            selectorTextboxList1.VaildExpressionMsg = "格式不正确，号码必须为数字";
            selectorTextboxList1.DisplayFormat = "{Text}<span style='color: #666666'><{Value}></span>";
            selectorTextboxList1.ClientInputDisplayFormat = "{Text}<span style='color: #666666'></span>";
            selectorTextboxList1.EmptyMessage = "请选择右边的联系人";
            for (long i = 13578778700; i < 13578778720; i++)
            {
                this.selectorTextboxList1.Items.Add(new Bronze.Controls.VWG.SelectorTextBox.Selector { Text = "张三枫", Value = i, Id = i, Tooltip = "描述信息" + i });
            }
        }
    }
}