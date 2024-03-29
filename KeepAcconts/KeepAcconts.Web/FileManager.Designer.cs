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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileManager));
            this.panelPathLink = new Gizmox.WebGUI.Forms.Panel();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.pictureBox1 = new Gizmox.WebGUI.Forms.PictureBox();
            this.watermarkTextBox1 = new Gizmox.WebGUI.Forms.WatermarkTextBox();
            this.pAddrBarContainer = new Gizmox.WebGUI.Forms.Panel();
            this.pAddrbarRefresh = new Gizmox.WebGUI.Forms.Panel();
            this.picAddrbarRefresh = new Gizmox.WebGUI.Forms.PictureBox();
            this.pathLinker1 = new KeepAcconts.Web.PathLinker();
            this.panelDirects = new Gizmox.WebGUI.Forms.Panel();
            this.picForward = new Gizmox.WebGUI.Forms.PictureBox();
            this.picBack = new Gizmox.WebGUI.Forms.PictureBox();
            this.button1 = new Gizmox.WebGUI.Forms.Button();
            this.button2 = new Gizmox.WebGUI.Forms.Button();
            this.toolBar1 = new Gizmox.WebGUI.Forms.ToolBar();
            this.tbtNewDirectory = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbtnAddFiles = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.tbtnDelete = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.panelMainContainer = new Gizmox.WebGUI.Forms.Panel();
            this.txtAddr = new Gizmox.WebGUI.Forms.TextBox();
            this.Filelist = new Bronze.WebGuiCommonLib.DataListView();
            this.colName = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.contextMenu1 = new Gizmox.WebGUI.Forms.ContextMenu();
            this.meunDelete = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuRename = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem4 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuCopyUrl = new Gizmox.WebGUI.Forms.MenuItem();
            this.colSize = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colType = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colModifyDate = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.fileDlg = new Gizmox.WebGUI.Forms.OpenFileDialog();
            this.panelPathLink.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pAddrBarContainer.SuspendLayout();
            this.pAddrbarRefresh.SuspendLayout();
            this.panelDirects.SuspendLayout();
            this.panelMainContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPathLink
            // 
            this.panelPathLink.Controls.Add(this.panel1);
            this.panelPathLink.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panelPathLink.Location = new System.Drawing.Point(0, 0);
            this.panelPathLink.Name = "panelPathLink";
            this.panelPathLink.Size = new System.Drawing.Size(822, 38);
            this.panelPathLink.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(210)))), ((int)(((byte)(236)))));
            this.panel1.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(211)))), ((int)(((byte)(216))))), System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(211)))), ((int)(((byte)(216))))), System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(211)))), ((int)(((byte)(216))))), System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(191)))), ((int)(((byte)(214))))));
            this.panel1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.panel1.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0, 0, 0, 1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.watermarkTextBox1);
            this.panel1.Controls.Add(this.pAddrBarContainer);
            this.panel1.Controls.Add(this.panelDirects);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(822, 37);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("pictureBox1.Image"));
            this.pictureBox1.Location = new System.Drawing.Point(798, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(15, 19);
            this.pictureBox1.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // watermarkTextBox1
            // 
            this.watermarkTextBox1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.watermarkTextBox1.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(180)))), ((int)(((byte)(191))))));
            this.watermarkTextBox1.CustomStyle = "Watermark";
            this.watermarkTextBox1.Location = new System.Drawing.Point(590, 6);
            this.watermarkTextBox1.Message = "输入关键字搜索...";
            this.watermarkTextBox1.Name = "watermarkTextBox1";
            this.watermarkTextBox1.Size = new System.Drawing.Size(225, 23);
            this.watermarkTextBox1.TabIndex = 2;
            // 
            // pAddrBarContainer
            // 
            this.pAddrBarContainer.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.pAddrBarContainer.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(229)))), ((int)(((byte)(243))))), System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(223)))), ((int)(((byte)(241))))), System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(229)))), ((int)(((byte)(243))))), System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(229)))), ((int)(((byte)(243))))));
            this.pAddrBarContainer.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.pAddrBarContainer.Controls.Add(this.pAddrbarRefresh);
            this.pAddrBarContainer.Controls.Add(this.pathLinker1);
            this.pAddrBarContainer.Location = new System.Drawing.Point(69, 5);
            this.pAddrBarContainer.Name = "pAddrBarContainer";
            this.pAddrBarContainer.Size = new System.Drawing.Size(512, 25);
            this.pAddrBarContainer.TabIndex = 1;
            // 
            // pAddrbarRefresh
            // 
            this.pAddrbarRefresh.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.pAddrbarRefresh.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(102)))), ((int)(((byte)(105))))), System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207))))), System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207))))), System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207))))));
            this.pAddrbarRefresh.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.pAddrbarRefresh.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(1, 0, 0, 0);
            this.pAddrbarRefresh.Controls.Add(this.picAddrbarRefresh);
            this.pAddrbarRefresh.Location = new System.Drawing.Point(489, 0);
            this.pAddrbarRefresh.Name = "pAddrbarRefresh";
            this.pAddrbarRefresh.Size = new System.Drawing.Size(22, 23);
            this.pAddrbarRefresh.TabIndex = 4;
            // 
            // picAddrbarRefresh
            // 
            this.picAddrbarRefresh.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("picAddrbarRefresh.Image"));
            this.picAddrbarRefresh.Location = new System.Drawing.Point(1, 2);
            this.picAddrbarRefresh.Name = "picAddrbarRefresh";
            this.picAddrbarRefresh.Size = new System.Drawing.Size(20, 19);
            this.picAddrbarRefresh.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.AutoSize;
            this.picAddrbarRefresh.TabIndex = 3;
            this.picAddrbarRefresh.TabStop = false;
            // 
            // pathLinker1
            // 
            this.pathLinker1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.pathLinker1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.pathLinker1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(249)))));
            this.pathLinker1.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(180)))), ((int)(((byte)(191))))));
            this.pathLinker1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.pathLinker1.CurrentPath = "";
            this.pathLinker1.Location = new System.Drawing.Point(0, 0);
            this.pathLinker1.Name = "pathLinker1";
            this.pathLinker1.RootPath = "";
            this.pathLinker1.Size = new System.Drawing.Size(512, 23);
            this.pathLinker1.TabIndex = 0;
            this.pathLinker1.Text = "PathLinker";
            this.pathLinker1.Leave += new System.EventHandler(this.pathLinker1_Leave);
            this.pathLinker1.Load += new System.EventHandler(this.pathLinker1_Load);
            this.pathLinker1.Click += new System.EventHandler(this.pathLinker1_Click);
            // 
            // panelDirects
            // 
            this.panelDirects.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("panelDirects.BackgroundImage"));
            this.panelDirects.Controls.Add(this.picForward);
            this.panelDirects.Controls.Add(this.picBack);
            this.panelDirects.Location = new System.Drawing.Point(0, 0);
            this.panelDirects.Name = "panelDirects";
            this.panelDirects.Size = new System.Drawing.Size(69, 38);
            this.panelDirects.TabIndex = 0;
            // 
            // picForward
            // 
            this.picForward.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.picForward.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("picForward.Image"));
            this.picForward.Location = new System.Drawing.Point(33, 0);
            this.picForward.Name = "picForward";
            this.picForward.Size = new System.Drawing.Size(28, 34);
            this.picForward.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.AutoSize;
            this.picForward.TabIndex = 0;
            this.picForward.TabStop = false;
            this.picForward.Click += new System.EventHandler(this.picForward_Click);
            // 
            // picBack
            // 
            this.picBack.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.picBack.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("picBack.Image"));
            this.picBack.Location = new System.Drawing.Point(2, 0);
            this.picBack.Name = "picBack";
            this.picBack.Size = new System.Drawing.Size(30, 34);
            this.picBack.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.AutoSize;
            this.picBack.TabIndex = 0;
            this.picBack.TabStop = false;
            this.picBack.Click += new System.EventHandler(this.picBack_Click);
            // 
            // button1
            // 
            this.button1.CustomStyle = "F";
            this.button1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.button1.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("button1.Image"));
            this.button1.Location = new System.Drawing.Point(1, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(13, 22);
            this.button1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.CustomStyle = "F";
            this.button2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("宋体", 9F);
            this.button2.Location = new System.Drawing.Point(14, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(41, 22);
            this.button2.TabIndex = 0;
            this.button2.Text = "根目录";
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Flat;
            this.toolBar1.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(1, 1, 1, 0);
            this.toolBar1.Buttons.AddRange(new Gizmox.WebGUI.Forms.ToolBarButton[] {
            this.tbtNewDirectory,
            this.tbtnAddFiles,
            this.tbtnDelete});
            this.toolBar1.DragHandle = true;
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.Font = new System.Drawing.Font("宋体", 9F);
            this.toolBar1.ImageSize = new System.Drawing.Size(16, 16);
            this.toolBar1.Location = new System.Drawing.Point(0, 82);
            this.toolBar1.MenuHandle = true;
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(822, 42);
            this.toolBar1.TabIndex = 1;
            this.toolBar1.ButtonClick += new Gizmox.WebGUI.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // tbtNewDirectory
            // 
            this.tbtNewDirectory.CustomStyle = "";
            this.tbtNewDirectory.Font = new System.Drawing.Font("Tahoma", 9F);
            this.tbtNewDirectory.Name = "tbtNewDirectory";
            this.tbtNewDirectory.Size = 24;
            this.tbtNewDirectory.Text = "创建文件夹";
            this.tbtNewDirectory.ToolTipText = "";
            // 
            // tbtnAddFiles
            // 
            this.tbtnAddFiles.CustomStyle = "";
            this.tbtnAddFiles.Font = new System.Drawing.Font("Tahoma", 9F);
            this.tbtnAddFiles.Name = "tbtnAddFiles";
            this.tbtnAddFiles.Size = 24;
            this.tbtnAddFiles.Text = "添加文件";
            this.tbtnAddFiles.ToolTipText = "";
            // 
            // tbtnDelete
            // 
            this.tbtnDelete.CustomStyle = "";
            this.tbtnDelete.Font = new System.Drawing.Font("Tahoma", 9F);
            this.tbtnDelete.Name = "tbtnDelete";
            this.tbtnDelete.Size = 24;
            this.tbtnDelete.Text = "删除";
            this.tbtnDelete.ToolTipText = "";
            // 
            // panelMainContainer
            // 
            this.panelMainContainer.Controls.Add(this.txtAddr);
            this.panelMainContainer.Controls.Add(this.Filelist);
            this.panelMainContainer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panelMainContainer.Location = new System.Drawing.Point(0, 82);
            this.panelMainContainer.Name = "panelMainContainer";
            this.panelMainContainer.Size = new System.Drawing.Size(822, 461);
            this.panelMainContainer.TabIndex = 2;
            // 
            // txtAddr
            // 
            this.txtAddr.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.txtAddr.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtAddr.Location = new System.Drawing.Point(71, 141);
            this.txtAddr.Name = "txtAddr";
            this.txtAddr.Size = new System.Drawing.Size(512, 23);
            this.txtAddr.TabIndex = 5;
            this.txtAddr.Visible = false;
            this.txtAddr.Leave += new System.EventHandler(this.txtAddr_Leave);
            // 
            // Filelist
            // 
            this.Filelist.AutoGenerateColumns = false;
            this.Filelist.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(1, 0, 1, 1);
            this.Filelist.CheckBoxes = true;
            this.Filelist.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colName,
            this.colSize,
            this.colType,
            this.colModifyDate});
            this.Filelist.ContextMenu = this.contextMenu1;
            this.Filelist.DataListSource = null;
            this.Filelist.DataMember = null;
            this.Filelist.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Filelist.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Filelist.GridLines = true;
            this.Filelist.ItemsPerPage = 20;
            this.Filelist.KeyField = null;
            this.Filelist.Location = new System.Drawing.Point(0, 0);
            this.Filelist.Name = "Filelist";
            this.Filelist.OrderBy = null;
            this.Filelist.RowHeight = 21;
            this.Filelist.SelectOnRightClick = true;
            this.Filelist.ShowItemToolTips = false;
            this.Filelist.Size = new System.Drawing.Size(822, 461);
            this.Filelist.SortName = null;
            this.Filelist.TabIndex = 0;
            this.Filelist.TableName = null;
            this.Filelist.ViewControlTextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Filelist.RowItemBinding += new Gizmox.WebGUI.Forms.ListViewItemBindingEventHandler(this.Filelist_RowItemBinding);
            this.Filelist.DoubleClick += new System.EventHandler(this.Filelist_DoubleClick);
            // 
            // colName
            // 
            this.colName.ContextMenu = this.contextMenu1;
            this.colName.Image = null;
            this.colName.Tag = "Name";
            this.colName.Text = "名称";
            this.colName.Width = 305;
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.meunDelete,
            this.menuRename,
            this.menuItem4,
            this.menuCopyUrl});
            // 
            // meunDelete
            // 
            this.meunDelete.Index = 0;
            this.meunDelete.Text = "删除";
            this.meunDelete.Click += new System.EventHandler(this.meunDelete_Click);
            // 
            // menuRename
            // 
            this.menuRename.Index = 1;
            this.menuRename.Text = "重命名";
            this.menuRename.Click += new System.EventHandler(this.menuRename_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 2;
            this.menuItem4.Text = "-";
            // 
            // menuCopyUrl
            // 
            this.menuCopyUrl.Index = 3;
            this.menuCopyUrl.Text = "复制地址";
            this.menuCopyUrl.Click += new System.EventHandler(this.menuCopyUrl_Click);
            // 
            // colSize
            // 
            this.colSize.ContextMenu = this.contextMenu1;
            this.colSize.Image = null;
            this.colSize.Tag = "Size";
            this.colSize.Text = "大小";
            this.colSize.Width = 66;
            // 
            // colType
            // 
            this.colType.ContextMenu = this.contextMenu1;
            this.colType.Image = null;
            this.colType.Tag = "Type";
            this.colType.Text = "类型";
            this.colType.Width = 89;
            // 
            // colModifyDate
            // 
            this.colModifyDate.ContextMenu = this.contextMenu1;
            this.colModifyDate.Image = null;
            this.colModifyDate.Tag = "ModifyDate";
            this.colModifyDate.Text = "修改日期";
            this.colModifyDate.Width = 150;
            // 
            // fileDlg
            // 
            this.fileDlg.MaxFileSize = 400000;
            this.fileDlg.Multiselect = true;
            this.fileDlg.FileOk += new System.ComponentModel.CancelEventHandler(this.fileDlg_FileOk);
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
            this.panel1.ResumeLayout(false);
            this.pAddrBarContainer.ResumeLayout(false);
            this.pAddrbarRefresh.ResumeLayout(false);
            this.panelDirects.ResumeLayout(false);
            this.panelMainContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelPathLink;
        private ToolBar toolBar1;
        private ToolBarButton tbtNewDirectory;
        private ToolBarButton tbtnAddFiles;
        private Panel panelMainContainer;
        private Bronze.WebGuiCommonLib.DataListView Filelist;
        private ColumnHeader colName;
        private ColumnHeader colSize;
        private ColumnHeader colType;
        private ColumnHeader colModifyDate;
        private PathLinker pathLinker1;
        private OpenFileDialog fileDlg;
        private ContextMenu contextMenu1;
        private MenuItem meunDelete;
        private MenuItem menuRename;
        private MenuItem menuItem4;
        private MenuItem menuCopyUrl;
        private ToolBarButton tbtnDelete;
        private Panel panel1;
        private Panel panelDirects;
        private Panel pAddrBarContainer;
        private PictureBox picBack;
        private PictureBox picForward;
        private WatermarkTextBox watermarkTextBox1;
        private PictureBox pictureBox1;
        private PictureBox picAddrbarRefresh;
        private Button button1;
        private Button button2;
        private Panel pAddrbarRefresh;
        private TextBox txtAddr;



    }
}