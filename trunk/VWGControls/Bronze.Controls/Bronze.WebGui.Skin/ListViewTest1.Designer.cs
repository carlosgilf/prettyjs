using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Bronze.WebGui.Skin
{
    partial class ListViewTest1
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
            Gizmox.WebGUI.Forms.ListViewGroup listViewGroup1 = new Gizmox.WebGUI.Forms.ListViewGroup("ListViewGroup1", Gizmox.WebGUI.Forms.HorizontalAlignment.Left);
            Gizmox.WebGUI.Forms.ListViewGroup listViewGroup2 = new Gizmox.WebGUI.Forms.ListViewGroup("ListViewGroup2", Gizmox.WebGUI.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListViewTest1));
            this.testListView1 = new Bronze.WebGui.Skin.TestListView();
            this.columnHeader1 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnHeader2 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.columnHeader3 = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.listViewItem1 = new Gizmox.WebGUI.Forms.ListViewItem("ww");
            this.listViewItem2 = new Gizmox.WebGUI.Forms.ListViewItem("");
            this.SuspendLayout();
            // 
            // testListView1
            // 
            this.testListView1.AllowListItemDisplayHtml = false;
            this.testListView1.AutoGenerateColumns = true;
            this.testListView1.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.testListView1.DataMember = null;
            listViewGroup1.Header = "ListViewGroup1";
            listViewGroup1.HeaderAlignment = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            listViewGroup1.Name = "group1";
            listViewGroup2.Header = "ListViewGroup2";
            listViewGroup2.HeaderAlignment = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            listViewGroup2.Name = "group2";
            this.testListView1.Groups.AddRange(new Gizmox.WebGUI.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.testListView1.Items.AddRange(new Gizmox.WebGUI.Forms.ListViewItem[] {
            this.listViewItem1,
            this.listViewItem2});
            this.testListView1.ItemsPerPage = 20;
            this.testListView1.Location = new System.Drawing.Point(29, 24);
            this.testListView1.Name = "testListView1";
            this.testListView1.ShowItemToolTips = false;
            this.testListView1.Size = new System.Drawing.Size(602, 441);
            this.testListView1.TabIndex = 0;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Image = null;
            this.columnHeader1.Text = "qqq";
            this.columnHeader1.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Icon;
            this.columnHeader1.Width = 125;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Image = null;
            this.columnHeader2.Text = "ttt";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Image = null;
            this.columnHeader3.Text = "yyy";
            this.columnHeader3.Width = 150;
            // 
            // listViewItem1
            // 
            this.listViewItem1.BackColor = System.Drawing.Color.White;
            this.listViewItem1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.listViewItem1.ForeColor = System.Drawing.Color.Black;
            this.listViewItem1.SmallImage = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("listViewItem1.SmallImage"));
            this.listViewItem1.Text = "ww";
            // 
            // listViewItem2
            // 
            this.listViewItem2.BackColor = System.Drawing.Color.White;
            this.listViewItem2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.listViewItem2.ForeColor = System.Drawing.Color.Black;
            this.listViewItem2.SmallImage = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("listViewItem2.SmallImage"));
            // 
            // ListViewTest1
            // 
            this.Controls.Add(this.testListView1);
            this.Size = new System.Drawing.Size(662, 495);
            this.Text = "ListViewTest1";
            this.ResumeLayout(false);

        }

        #endregion

        private TestListView testListView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ListViewItem listViewItem1;
        private ListViewItem listViewItem2;


    }
}