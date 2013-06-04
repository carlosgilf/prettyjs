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
using Gizmox.WebGUI.Common.Resources;

#endregion

namespace Bronze.Controls.Examples
{
    public partial class TreeTest : Form
    {
        public TreeTest()
        {
            InitializeComponent();

            this.treeViewEx1.ShowPlusMinus = true;
            this.treeViewEx1.ShowLines = false;


            this.treeViewEx2.ShowPlusMinus = true;
            this.treeViewEx2.ShowLines = false;
            this.treeViewEx1.AllowNodeTextAsHtml = true;
            this.treeViewEx1.AllowSelectFullLine = true;
            this.treeViewEx1.NodeHeight = 36;
            this.treeNode1.Text = "<div style='padding:3 0'><b vwgtype='label'>张山你三季度看风景</b><font color='red' vwgtype='label'>12</font></div>";
            this.treeNode1.Expand();
            this.treeNode1.NodeFont = new Font("宋体", 11, FontStyle.Bold);
            var node2=new TreeNode() { Text = "<font color='red' vwgtype='label'>12</font>" };
            this.treeNode1.Nodes.Add(node2);
            this.treeViewEx1.SelectedNode = node2;

            treeNode1.StateImage = new ImageResourceHandle("tree.calendar.gif");
           


            //this.treeNode2.Text = "<div style='font-size:15px;padding:3 0'><b vwgtype='label'>张山你三季度看风景</b><font color='red' vwgtype='label'>12</font></div>";
            //this.treeNode3.Text = "<div style='font-size:15px;padding:3 0'><b>张山你三季度看风景</b><font color='red' vwgtype='label'>12</font></div>";
            //this.treeNode4.Text = "<div style='font-size:15px;padding:3 0'><b vwgtype='label'>张山你三季度看风景</b><font color='red' vwgtype='label'>12</font></div>";
        }
    }
}