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
using Gizmox.WebGUI.Common.Interfaces;

#endregion

namespace Bronze.Controls.Examples
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.supperPanel1.BackColor = ColorTranslator.FromHtml("#e5e6f0");
            this.supperPanel1.ArrowPosition = VWG.ArrowPosition.Top;
            this.supperPanel1.ArrowStart = (uint)(this.supperPanel1.Width / 2)-4;
            this.supperPanel1.BoxShadow = new VWG.BoxShadow(ColorTranslator.FromHtml("#666"), 3, 3, 10);
            this.supperPanel1.Radius = new CornerRadius(10);
            var node = new NodeF();
            this.treeView1.Nodes.Add(new NodeF());
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new Form2();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var invoker = this.Context as IContextMethodInvoker;
            //invoker.InvokeMethod(this, InvokationUniqueness.Global, "Forms_CloseInlineWindow", this.ID);
            //this.InvokeMethod("Forms_CloseInlineWindow", this.ID);
            //string name = invoker.GetMethodName(this,"Forms_CloseInlineWindow");
            //this.InvokeScript(string.Format("{0}({1},event,window)", name,this.ID));

            //this.supperPanel1.ArrowPosition = VWG.ArrowPosition.Right;
            this.supperPanel1.Visible = !this.supperPanel1.Visible;
            this.supperPanel1.Top = this.button2.Top + this.button2.Height + 1;
            this.supperPanel1.Left = this.button2.Left + this.button2.Width/2 + 1 - this.supperPanel1.Width/2;
        }

    }

    public class NodeF : TreeNode
    {

    }
}