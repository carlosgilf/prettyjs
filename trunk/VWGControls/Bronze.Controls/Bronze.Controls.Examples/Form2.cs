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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.supperPanel1.BackColor = ColorTranslator.FromHtml("#e5e6f0");

            
            this.supperPanel1.BoxShadow = new VWG.BoxShadow(Color.Gray,2,2,3);
            var node = new NodeF();
            this.treeView1.Nodes.Add(new NodeF());
         
        }

    }

    public class NodeF : TreeNode
    {

    }
}