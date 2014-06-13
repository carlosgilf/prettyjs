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
            this.treeViewEx1.AllowNodeTextAsHtml = true;
            this.treeViewEx1.AllowSelectFullLine = true;
            this.treeViewEx1.NodeHeight = 26;
            this.treeViewEx1.NodeExtClick += new VWG.TreeViewEx.NodeExtHandler(treeViewEx1_NodeExtClick);

            var addImgSrc = new ImageResourceHandle("tree.calendar.gif").ToString();
            //this.treeNode1.Text = "<div style='padding:0'><b vwgtype='label'>张山你三季度看风景</b><font color='red' vwgtype='label'>12</font></div>";
            this.treeNode1.Text = string.Format("<a>我的日程分类</a><a title='添加日程分类' name='11' vwgtype='ext' class='TreeView-RightIcon' style='background-image:url({0});'>添加</a>", addImgSrc);
            this.treeNode1.StateImage = new ImageResourceHandle("tree.calendar.gif");
            this.treeNode1.Expand();
            //this.treeNode1.NodeFont = new Font("宋体", 11, FontStyle.Bold);
            var node2 = new TreeNode() { Text = string.Format("<font vwgtype='label'>test11</font><a title='添加日程分类' name='22' vwgtype='ext1' class='TreeView-RightIconHide' style='background-image:url({0});'>&nbsp;</a>", addImgSrc)};
            node2.StateImage = new ImageResourceHandle("tree.calendar.gif");
            this.treeNode1.Nodes.Add(node2);

            var node3 = new TreeNode() { Text = string.Format("<font vwgtype='label'>test22</font><a title='添加日程分类' name='22' vwgtype='ext1' class='TreeView-RightIconHide' style='background-image:url({0});'>&nbsp;</a>", addImgSrc) };
            node3.StateImage = new ImageResourceHandle("tree.calendar.gif");
            this.treeNode1.Nodes.Add(node3);

            var node4 = new TreeNode() { Text = string.Format("<font vwgtype='label'>test33</font><a title='添加日程分类' name='22' vwgtype='ext1' class='TreeView-RightIconHide' style='background-image:url({0});'>&nbsp;</a>", addImgSrc) };
            node4.StateImage = new ImageResourceHandle("tree.calendar.gif");
            this.treeNode1.Nodes.Add(node4);


            



            //this.treeNode2.Text = "<div style='font-size:15px;padding:3 0'><b vwgtype='label'>张山你三季度看风景</b><font color='red' vwgtype='label'>12</font></div>";
            //this.treeNode3.Text = "<div style='font-size:15px;padding:3 0'><b>张山你三季度看风景</b><font color='red' vwgtype='label'>12</font></div>";
            //this.treeNode4.Text = "<div style='font-size:15px;padding:3 0'><b vwgtype='label'>张山你三季度看风景</b><font color='red' vwgtype='label'>12</font></div>";


            this.treeViewEx2.ShowPlusMinus = true;
            this.treeViewEx2.ShowLines = false;
            this.treeViewEx2.AllowSelectFullLine = false;
            this.treeNode5.Nodes.Add("ddfdfdf");
        }

        void treeViewEx1_NodeExtClick(object sender, VWG.TreeViewEx.TreeNodeExtEventArgs e)
        {
            MessageBox.Show(e.Node.Text, e.SourceName);
        }
    }
}