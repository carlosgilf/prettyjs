using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Bronze.WebGui.Skin
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Visual WebGui Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new Gizmox.WebGUI.Forms.Button();
            this.button2 = new Gizmox.WebGUI.Forms.Button();
            this.listView1 = new Bronze.WebGui.Skin.TestListView();
            this.columnHeader1 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.listViewItem1 = new Gizmox.WebGUI.Forms.ListViewItem("<div><a class=\'ListView-Node ListView-Expend\'></a>ddddd0</div>");
            this.listViewItem2 = new Gizmox.WebGUI.Forms.ListViewItem("<div style=\'padding-left:16px;\'><a class=\'ListView-Node ListView-Empty\'></a>ddddd" +
                    "1</div>");
            this.listViewItem3 = new Gizmox.WebGUI.Forms.ListViewItem("<div style=\'padding-left:16px;\'><a class=\'ListView-Node ListView-EmptyLast\'></a>d" +
                    "dddd2</div>");
            this.listViewItem4 = new Gizmox.WebGUI.Forms.ListViewItem("<div><a class=\'ListView-Node ListView-Expend\'></a>ddddd4</div>");
            this.listViewItem5 = new Gizmox.WebGUI.Forms.ListViewItem("<div><a class=\'ListView-Node ListView-Expend\'></a>ddddd5</div>");
            this.listViewItem6 = new Gizmox.WebGUI.Forms.ListViewItem("<div><a class=\'ListView-Node ListView-Collapse\'></a>ddddd6</div>");
            this.listViewItem7 = new Gizmox.WebGUI.Forms.ListViewItem("<div><a class=\'ListView-Node ListView-Expend\'></a>ddddd7</div>");
            this.treeView1 = new Gizmox.WebGUI.Forms.TreeView();
            this.treeNode1 = new Gizmox.WebGUI.Forms.TreeNode();
            this.treeNode5 = new Gizmox.WebGUI.Forms.TreeNode();
            this.treeNode6 = new Gizmox.WebGUI.Forms.TreeNode();
            this.treeNode7 = new Gizmox.WebGUI.Forms.TreeNode();
            this.treeNode2 = new Gizmox.WebGUI.Forms.TreeNode();
            this.treeNode8 = new Gizmox.WebGUI.Forms.TreeNode();
            this.treeNode9 = new Gizmox.WebGUI.Forms.TreeNode();
            this.treeNode10 = new Gizmox.WebGUI.Forms.TreeNode();
            this.treeNode3 = new Gizmox.WebGUI.Forms.TreeNode();
            this.treeNode4 = new Gizmox.WebGUI.Forms.TreeNode();
            this.treeNode11 = new Gizmox.WebGUI.Forms.TreeNode();
            this.treeNode12 = new Gizmox.WebGUI.Forms.TreeNode();
            this.treeNode13 = new Gizmox.WebGUI.Forms.TreeNode();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(31, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(121, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listView1
            // 
            this.listView1.AllowListItemDisplayHtml = false;
            this.listView1.AutoGenerateColumns = true;
            this.listView1.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.DataMember = null;
            this.listView1.FullRowSelect = false;
            this.listView1.Items.AddRange(new Gizmox.WebGUI.Forms.ListViewItem[] {
            this.listViewItem1,
            this.listViewItem2,
            this.listViewItem3,
            this.listViewItem4,
            this.listViewItem5,
            this.listViewItem6,
            this.listViewItem7});
            this.listView1.ItemsPerPage = 20;
            this.listView1.Location = new System.Drawing.Point(19, 53);
            this.listView1.Name = "listView1";
            this.listView1.ShowItemToolTips = false;
            this.listView1.Size = new System.Drawing.Size(528, 404);
            this.listView1.TabIndex = 4;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Image = null;
            this.columnHeader1.Text = "col1";
            this.columnHeader1.Width = 470;
            // 
            // listViewItem1
            // 
            this.listViewItem1.BackColor = System.Drawing.SystemColors.Window;
            this.listViewItem1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.listViewItem1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listViewItem1.Text = "<div><a class=\'ListView-Node ListView-Expend\'></a>ddddd0</div>";
            // 
            // listViewItem2
            // 
            this.listViewItem2.BackColor = System.Drawing.SystemColors.Window;
            this.listViewItem2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.listViewItem2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listViewItem2.Text = "<div style=\'padding-left:16px;\'><a class=\'ListView-Node ListView-Empty\'></a>ddddd" +
                "1</div>";
            // 
            // listViewItem3
            // 
            this.listViewItem3.BackColor = System.Drawing.SystemColors.Window;
            this.listViewItem3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.listViewItem3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listViewItem3.Text = "<div style=\'padding-left:16px;\'><a class=\'ListView-Node ListView-EmptyLast\'></a>d" +
                "dddd2</div>";
            // 
            // listViewItem4
            // 
            this.listViewItem4.BackColor = System.Drawing.SystemColors.Window;
            this.listViewItem4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.listViewItem4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listViewItem4.Text = "<div><a class=\'ListView-Node ListView-Expend\'></a>ddddd4</div>";
            // 
            // listViewItem5
            // 
            this.listViewItem5.BackColor = System.Drawing.SystemColors.Window;
            this.listViewItem5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.listViewItem5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listViewItem5.Text = "<div><a class=\'ListView-Node ListView-Expend\'></a>ddddd5</div>";
            // 
            // listViewItem6
            // 
            this.listViewItem6.BackColor = System.Drawing.SystemColors.Window;
            this.listViewItem6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.listViewItem6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listViewItem6.Text = "<div><a class=\'ListView-Node ListView-Collapse\'></a>ddddd6</div>";
            // 
            // listViewItem7
            // 
            this.listViewItem7.BackColor = System.Drawing.SystemColors.Window;
            this.listViewItem7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.listViewItem7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listViewItem7.Text = "<div><a class=\'ListView-Node ListView-Expend\'></a>ddddd7</div>";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(583, 53);
            this.treeView1.Name = "treeView1";
            this.treeView1.Nodes.AddRange(new Gizmox.WebGUI.Forms.TreeNode[] {
            this.treeNode1,
            this.treeNode2,
            this.treeNode3,
            this.treeNode4});
            this.treeView1.ShowLines = false;
            this.treeView1.Size = new System.Drawing.Size(292, 404);
            this.treeView1.TabIndex = 5;
            // 
            // treeNode1
            // 
            this.treeNode1.CheckBox = Gizmox.WebGUI.Forms.CheckBoxVisibility.Inherited;
            this.treeNode1.Name = "treeNode1";
            this.treeNode1.Nodes.AddRange(new Gizmox.WebGUI.Forms.TreeNode[] {
            this.treeNode5,
            this.treeNode6,
            this.treeNode7});
            this.treeNode1.Text = "treeNode1";
            this.treeNode1.ToolTipText = "";
            // 
            // treeNode5
            // 
            this.treeNode5.CheckBox = Gizmox.WebGUI.Forms.CheckBoxVisibility.Inherited;
            this.treeNode5.Name = "treeNode5";
            this.treeNode5.Text = "treeNode5";
            this.treeNode5.ToolTipText = "";
            // 
            // treeNode6
            // 
            this.treeNode6.CheckBox = Gizmox.WebGUI.Forms.CheckBoxVisibility.Inherited;
            this.treeNode6.Name = "treeNode6";
            this.treeNode6.Text = "treeNode6";
            this.treeNode6.ToolTipText = "";
            // 
            // treeNode7
            // 
            this.treeNode7.CheckBox = Gizmox.WebGUI.Forms.CheckBoxVisibility.Inherited;
            this.treeNode7.Name = "treeNode7";
            this.treeNode7.Text = "treeNode7";
            this.treeNode7.ToolTipText = "";
            // 
            // treeNode2
            // 
            this.treeNode2.CheckBox = Gizmox.WebGUI.Forms.CheckBoxVisibility.Inherited;
            this.treeNode2.Name = "treeNode2";
            this.treeNode2.Nodes.AddRange(new Gizmox.WebGUI.Forms.TreeNode[] {
            this.treeNode8,
            this.treeNode9,
            this.treeNode10});
            this.treeNode2.Text = "treeNode2";
            this.treeNode2.ToolTipText = "";
            // 
            // treeNode8
            // 
            this.treeNode8.CheckBox = Gizmox.WebGUI.Forms.CheckBoxVisibility.Inherited;
            this.treeNode8.Name = "treeNode8";
            this.treeNode8.Text = "treeNode8";
            this.treeNode8.ToolTipText = "";
            // 
            // treeNode9
            // 
            this.treeNode9.CheckBox = Gizmox.WebGUI.Forms.CheckBoxVisibility.Inherited;
            this.treeNode9.Name = "treeNode9";
            this.treeNode9.Text = "treeNode9";
            this.treeNode9.ToolTipText = "";
            // 
            // treeNode10
            // 
            this.treeNode10.CheckBox = Gizmox.WebGUI.Forms.CheckBoxVisibility.Inherited;
            this.treeNode10.Name = "treeNode10";
            this.treeNode10.Text = "treeNode10";
            this.treeNode10.ToolTipText = "";
            // 
            // treeNode3
            // 
            this.treeNode3.CheckBox = Gizmox.WebGUI.Forms.CheckBoxVisibility.Inherited;
            this.treeNode3.Name = "treeNode3";
            this.treeNode3.Text = "treeNode3";
            this.treeNode3.ToolTipText = "";
            // 
            // treeNode4
            // 
            this.treeNode4.CheckBox = Gizmox.WebGUI.Forms.CheckBoxVisibility.Inherited;
            this.treeNode4.Name = "treeNode4";
            this.treeNode4.Nodes.AddRange(new Gizmox.WebGUI.Forms.TreeNode[] {
            this.treeNode11,
            this.treeNode12,
            this.treeNode13});
            this.treeNode4.Text = "treeNode4";
            this.treeNode4.ToolTipText = "";
            // 
            // treeNode11
            // 
            this.treeNode11.CheckBox = Gizmox.WebGUI.Forms.CheckBoxVisibility.Inherited;
            this.treeNode11.Name = "treeNode11";
            this.treeNode11.Text = "treeNode11";
            this.treeNode11.ToolTipText = "";
            // 
            // treeNode12
            // 
            this.treeNode12.CheckBox = Gizmox.WebGUI.Forms.CheckBoxVisibility.Inherited;
            this.treeNode12.Name = "treeNode12";
            this.treeNode12.Text = "treeNode12";
            this.treeNode12.ToolTipText = "";
            // 
            // treeNode13
            // 
            this.treeNode13.CheckBox = Gizmox.WebGUI.Forms.CheckBoxVisibility.Inherited;
            this.treeNode13.Name = "treeNode13";
            this.treeNode13.Text = "treeNode13";
            this.treeNode13.ToolTipText = "";
            // 
            // Form1
            // 
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(898, 545);
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private Button button2;
        private TestListView listView1;
        private ColumnHeader columnHeader1;
        private ListViewItem listViewItem1;
        private ListViewItem listViewItem2;
        private ListViewItem listViewItem3;
        private TreeView treeView1;
        private TreeNode treeNode1;
        private TreeNode treeNode5;
        private TreeNode treeNode6;
        private TreeNode treeNode7;
        private TreeNode treeNode2;
        private TreeNode treeNode8;
        private TreeNode treeNode9;
        private TreeNode treeNode10;
        private TreeNode treeNode3;
        private TreeNode treeNode4;
        private TreeNode treeNode11;
        private TreeNode treeNode12;
        private TreeNode treeNode13;
        private ListViewItem listViewItem4;
        private ListViewItem listViewItem5;
        private ListViewItem listViewItem6;
        private ListViewItem listViewItem7;


    }
}