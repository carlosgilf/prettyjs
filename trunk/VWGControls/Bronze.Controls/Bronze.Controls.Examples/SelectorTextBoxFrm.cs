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
            for (int i = 0; i < 500; i++)
            {
                this.selectorTextBox1.Items.Add(new Bronze.Controls.VWG.SelectorTextBox.Selector { Text = "张三"+i, Value = i, Id = i, Tooltip="描述信息"+i });
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.selectorTextBox1.Items.Add(new Bronze.Controls.VWG.SelectorTextBox.Selector { Text = "小李", Value ="", Id = Guid.NewGuid().ToString(), Tooltip = "描述信息11"  });
            this.selectorTextBox1.Update();
        }
    }
}