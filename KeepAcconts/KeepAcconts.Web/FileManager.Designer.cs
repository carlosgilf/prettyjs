using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace KeepAcconts.Web
{
    partial class FileManager
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
            this.panelPathLink = new Gizmox.WebGUI.Forms.Panel();
            this.toolBar1 = new Gizmox.WebGUI.Forms.ToolBar();
            this.tbtForword = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbtnBack = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbtRetrun = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.toolBarButton1 = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbtNewDirectory = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbtnAddFiles = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.panelMainContainer = new Gizmox.WebGUI.Forms.Panel();
            this.splitContainer1 = new Gizmox.WebGUI.Forms.SplitContainer();
            this.button1 = new Gizmox.WebGUI.Forms.Button();
            this.Filelist = new Bronze.WebGuiCommonLib.DataListView();
            this.colName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colSize = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colType = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colModifyDate = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.pathLinker1 = new KeepAcconts.Web.PathLinker();
            this.panelPathLink.SuspendLayout();
            this.panelMainContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPathLink
            // 
            this.panelPathLink.Controls.Add(this.pathLinker1);
            this.panelPathLink.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panelPathLink.Location = new System.Drawing.Point(0, 0);
            this.panelPathLink.Name = "panelPathLink";
            this.panelPathLink.Size = new System.Drawing.Size(822, 35);
            this.panelPathLink.TabIndex = 0;
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.toolBar1.Buttons.AddRange(new Gizmox.WebGUI.Forms.ToolBarButton[] {
            this.tbtForword,
            this.tbtnBack,
            this.tbtRetrun,
            this.toolBarButton1,
            this.tbtNewDirectory,
            this.tbtnAddFiles});
            this.toolBar1.DragHandle = true;
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageSize = new System.Drawing.Size(16, 16);
            this.toolBar1.Location = new System.Drawing.Point(0, 35);
            this.toolBar1.MenuHandle = true;
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(822, 42);
            this.toolBar1.TabIndex = 1;
            // 
            // tbtForword
            // 
            this.tbtForword.CustomStyle = "";
            this.tbtForword.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbtForword.Name = "tbtForword";
            this.tbtForword.Size = 24;
            this.tbtForword.Text = "前进";
            this.tbtForword.ToolTipText = "";
            // 
            // tbtnBack
            // 
            this.tbtnBack.CustomStyle = "";
            this.tbtnBack.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbtnBack.Name = "tbtnBack";
            this.tbtnBack.Size = 24;
            this.tbtnBack.Text = "后退";
            this.tbtnBack.ToolTipText = "";
            // 
            // tbtRetrun
            // 
            this.tbtRetrun.CustomStyle = "";
            this.tbtRetrun.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbtRetrun.Name = "tbtRetrun";
            this.tbtRetrun.Size = 24;
            this.tbtRetrun.Text = "向上";
            this.tbtRetrun.ToolTipText = "";
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.CustomStyle = "";
            this.toolBarButton1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Size = 24;
            this.toolBarButton1.Style = Gizmox.WebGUI.Forms.ToolBarButtonStyle.Separator;
            this.toolBarButton1.ToolTipText = "";
            // 
            // tbtNewDirectory
            // 
            this.tbtNewDirectory.CustomStyle = "";
            this.tbtNewDirectory.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbtNewDirectory.Name = "tbtNewDirectory";
            this.tbtNewDirectory.Size = 24;
            this.tbtNewDirectory.Text = "创建文件夹";
            this.tbtNewDirectory.ToolTipText = "";
            // 
            // tbtnAddFiles
            // 
            this.tbtnAddFiles.CustomStyle = "";
            this.tbtnAddFiles.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbtnAddFiles.Name = "tbtnAddFiles";
            this.tbtnAddFiles.Size = 24;
            this.tbtnAddFiles.Text = "添加文件";
            this.tbtnAddFiles.ToolTipText = "";
            // 
            // panelMainContainer
            // 
            this.panelMainContainer.Controls.Add(this.splitContainer1);
            this.panelMainContainer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panelMainContainer.Location = new System.Drawing.Point(0, 77);
            this.panelMainContainer.Name = "panelMainContainer";
            this.panelMainContainer.Size = new System.Drawing.Size(822, 466);
            this.panelMainContainer.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.splitContainer1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.splitContainer1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = Gizmox.WebGUI.Forms.FixedPanel.None;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = Gizmox.WebGUI.Forms.Orientation.Vertical;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Filelist);
            this.splitContainer1.Size = new System.Drawing.Size(822, 466);
            this.splitContainer1.SplitterDistance = 150;
            this.splitContainer1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 133);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Filelist
            // 
            this.Filelist.AutoGenerateColumns = false;
            this.Filelist.CheckBoxes = true;
            this.Filelist.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colName,
            this.colSize,
            this.colType,
            this.colModifyDate});
            this.Filelist.DataListSource = null;
            this.Filelist.DataMember = null;
            this.Filelist.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Filelist.GridLines = true;
            this.Filelist.ItemsPerPage = 20;
            this.Filelist.KeyField = null;
            this.Filelist.Location = new System.Drawing.Point(0, 0);
            this.Filelist.Name = "Filelist";
            this.Filelist.OrderBy = null;
            this.Filelist.RowHeight = 21;
            this.Filelist.ShowItemToolTips = false;
            this.Filelist.Size = new System.Drawing.Size(668, 466);
            this.Filelist.SortName = null;
            this.Filelist.TabIndex = 0;
            this.Filelist.TableName = null;
            this.Filelist.ViewControlTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Filelist.RowItemBinding += new Gizmox.WebGUI.Forms.ListViewItemBindingEventHandler(this.Filelist_RowItemBinding);
            this.Filelist.ItemBinding += new Gizmox.WebGUI.Forms.ListViewItemBindingEventHandler(this.Filelist_ItemBinding);
            this.Filelist.DoubleClick += new System.EventHandler(this.Filelist_DoubleClick);
            // 
            // colName
            // 
            this.colName.Image = null;
            this.colName.Tag = "Name";
            this.colName.Text = "名称";
            this.colName.Width = 305;
            // 
            // colSize
            // 
            this.colSize.Image = null;
            this.colSize.Tag = "Size";
            this.colSize.Text = "大小";
            this.colSize.Width = 66;
            // 
            // colType
            // 
            this.colType.Image = null;
            this.colType.Tag = "Type";
            this.colType.Text = "类型";
            this.colType.Width = 89;
            // 
            // colModifyDate
            // 
            this.colModifyDate.Image = null;
            this.colModifyDate.Tag = "ModifyDate";
            this.colModifyDate.Text = "修改日期";
            this.colModifyDate.Width = 150;
            // 
            // pathLinker1
            // 
            this.pathLinker1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.pathLinker1.Location = new System.Drawing.Point(0, 0);
            this.pathLinker1.Name = "pathLinker1";
            this.pathLinker1.Size = new System.Drawing.Size(699, 35);
            this.pathLinker1.TabIndex = 0;
            this.pathLinker1.Text = "PathLinker";
            // 
            // FileManager
            // 
            this.Controls.Add(this.panelMainContainer);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.panelPathLink);
            this.Size = new System.Drawing.Size(822, 543);
            this.Text = "FileManager";
            this.Load += new System.EventHandler(this.FileManager_Load);
            this.panelPathLink.ResumeLayout(false);
            this.panelMainContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelPathLink;
        private ToolBar toolBar1;
        private ToolBarButton tbtForword;
        private ToolBarButton tbtnBack;
        private ToolBarButton tbtRetrun;
        private ToolBarButton toolBarButton1;
        private ToolBarButton tbtNewDirectory;
        private ToolBarButton tbtnAddFiles;
        private Panel panelMainContainer;
        private SplitContainer splitContainer1;
        private Bronze.WebGuiCommonLib.DataListView Filelist;
        private ColumnHeader colName;
        private ColumnHeader colSize;
        private ColumnHeader colType;
        private ColumnHeader colModifyDate;
        private Button button1;
        private PathLinker pathLinker1;



    }
}