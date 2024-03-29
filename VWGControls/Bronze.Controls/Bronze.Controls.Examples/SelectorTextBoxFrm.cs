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
            //selectorTextBox1.OnClientRemoveScript = "alert(this.Id+','+this.Text);";
            selectorTextBox1.SplitString = ",，;；\r;\n";
            selectorTextBox1.VaildExpression = @"^\d+$";
            selectorTextBox1.VaildExpressionMsg = "格式不正确，号码必须为数字";
            selectorTextBox1.DisplayFormat = "{Text}<span style='color: #666666'><{Value}></span>";
            selectorTextBox1.ClientInputDisplayFormat = "{Text}<span style='color: #666666'></span>";
            selectorTextBox1.EmptyMessage = "请选择右边的联系人";
            for (long i = 13578778700; i < 13578778720; i++)
            {
                this.selectorTextBox1.Items.Add(new Bronze.Controls.VWG.SelectorTextBox.Selector { Text = "张三枫", Value = i, Id = i, Tooltip = "描述信息" + i });
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.selectorTextBox1.Items.Add(new Bronze.Controls.VWG.SelectorTextBox.Selector { Text = "小李", Value ="", Id = Guid.NewGuid().ToString(), Tooltip = "描述信息11"  });
            //this.selectorTextBox1.Update();
            this.selectorTextBox1.Editable = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.selectorTextBox1.Editable = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.InvokeScript(@"
            var items=[];
            for(var i=0;i<1000;i++){
                items.push({Id:i,Text:'jrtjrt'+i,Value:i});
            }
            selector_addTexts(" + this.selectorTextBox1.ID + ",items,false);"
           );



        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.InvokeScript(@"
            var items=[];
            for(var i=0;i<1000;i++){
                items.push(i);
            }
            selector_clean(" + this.selectorTextBox1.ID + @");
            selector_removeTexts(" + this.selectorTextBox1.ID + ",items,false);"
                 );
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = !this.panel1.Visible;
        }
    }
}