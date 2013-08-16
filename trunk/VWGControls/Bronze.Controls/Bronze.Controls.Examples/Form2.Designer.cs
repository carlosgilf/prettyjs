using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Bronze.Controls.Examples
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.supperPanel1 = new Bronze.Controls.VWG.SupperPanel();
            this.treeView1 = new Gizmox.WebGUI.Forms.TreeView();
            this.treeNode1 = new Gizmox.WebGUI.Forms.TreeNode();
            this.treeNode4 = new Gizmox.WebGUI.Forms.TreeNode();
            this.treeNode5 = new Gizmox.WebGUI.Forms.TreeNode();
            this.treeNode6 = new Gizmox.WebGUI.Forms.TreeNode();
            this.treeNode2 = new Gizmox.WebGUI.Forms.TreeNode();
            this.treeNode3 = new Gizmox.WebGUI.Forms.TreeNode();
            this.supperPanel2 = new Bronze.Controls.VWG.SupperPanel();
            this.supperPanel3 = new Bronze.Controls.VWG.SupperPanel();
            this.mainMenu1 = new Gizmox.WebGUI.Forms.MainMenu();
            this.menuItem1 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem2 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem3 = new Gizmox.WebGUI.Forms.MenuItem();
            this.menuItem4 = new Gizmox.WebGUI.Forms.MenuItem();
            this.supperPanel4 = new Bronze.Controls.VWG.SupperPanel();
            this.button1 = new Gizmox.WebGUI.Forms.Button();
            this.button2 = new Gizmox.WebGUI.Forms.Button();
            this.jrtLabel1 = new Bronze.Controls.VWG.JrtLabel();
            this.jrtLabel2 = new Bronze.Controls.VWG.JrtLabel();
            this.label1 = new Bronze.Controls.VWG.JrtLabel();
            this.supperPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // supperPanel1
            // 
            this.supperPanel1.ArrowStart = ((uint)(10u));
            this.supperPanel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.supperPanel1.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Gray);
            this.supperPanel1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.supperPanel1.Controls.Add(this.treeView1);
            this.supperPanel1.CustomStyle = "SupperPanelSkin";
            this.supperPanel1.DisplayMode = Bronze.Controls.VWG.DisplayMode.Normal;
            this.supperPanel1.LinearGradient = null;
            this.supperPanel1.Location = new System.Drawing.Point(27, 20);
            this.supperPanel1.Name = "supperPanel1";
            this.supperPanel1.Opacity = 100;
            this.supperPanel1.Radius = new Gizmox.WebGUI.Forms.CornerRadius(3);
            this.supperPanel1.Size = new System.Drawing.Size(294, 448);
            this.supperPanel1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(13, 20);
            this.treeView1.Name = "treeView1";
            this.treeView1.Nodes.AddRange(new Gizmox.WebGUI.Forms.TreeNode[] {
            this.treeNode1,
            this.treeNode2,
            this.treeNode3});
            this.treeView1.ShowLines = false;
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.Size = new System.Drawing.Size(266, 409);
            this.treeView1.TabIndex = 0;
            // 
            // treeNode1
            // 
            this.treeNode1.CheckBox = Gizmox.WebGUI.Forms.CheckBoxVisibility.Inherited;
            this.treeNode1.Name = "treeNode1";
            this.treeNode1.Nodes.AddRange(new Gizmox.WebGUI.Forms.TreeNode[] {
            this.treeNode4,
            this.treeNode5,
            this.treeNode6});
            this.treeNode1.Text = "treeNode1";
            this.treeNode1.ToolTipText = "";
            // 
            // treeNode4
            // 
            this.treeNode4.CheckBox = Gizmox.WebGUI.Forms.CheckBoxVisibility.Inherited;
            this.treeNode4.Name = "treeNode4";
            this.treeNode4.Text = "treeNode4";
            this.treeNode4.ToolTipText = "";
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
            // treeNode2
            // 
            this.treeNode2.CheckBox = Gizmox.WebGUI.Forms.CheckBoxVisibility.Inherited;
            this.treeNode2.Name = "treeNode2";
            this.treeNode2.Text = "treeNode2";
            this.treeNode2.ToolTipText = "";
            // 
            // treeNode3
            // 
            this.treeNode3.CheckBox = Gizmox.WebGUI.Forms.CheckBoxVisibility.Inherited;
            this.treeNode3.Name = "treeNode3";
            this.treeNode3.Text = "treeNode3";
            this.treeNode3.ToolTipText = "";
            // 
            // supperPanel2
            // 
            this.supperPanel2.ArrowStart = ((uint)(10u));
            this.supperPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.supperPanel2.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.supperPanel2.CustomStyle = "SupperPanelSkin";
            this.supperPanel2.DisplayMode = Bronze.Controls.VWG.DisplayMode.Normal;
            this.supperPanel2.LinearGradient = null;
            this.supperPanel2.Location = new System.Drawing.Point(344, 141);
            this.supperPanel2.Name = "supperPanel2";
            this.supperPanel2.Opacity = 100;
            this.supperPanel2.Radius = new Gizmox.WebGUI.Forms.CornerRadius(5);
            this.supperPanel2.Size = new System.Drawing.Size(200, 100);
            this.supperPanel2.TabIndex = 1;
            // 
            // supperPanel3
            // 
            this.supperPanel3.ArrowStart = ((uint)(10u));
            this.supperPanel3.BackColor = System.Drawing.Color.Silver;
            this.supperPanel3.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213))))));
            this.supperPanel3.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.supperPanel3.CustomStyle = "SupperPanelSkin";
            this.supperPanel3.DisplayMode = Bronze.Controls.VWG.DisplayMode.Normal;
            this.supperPanel3.LinearGradient = null;
            this.supperPanel3.Location = new System.Drawing.Point(387, 262);
            this.supperPanel3.Name = "supperPanel3";
            this.supperPanel3.Opacity = 100;
            this.supperPanel3.Radius = new Gizmox.WebGUI.Forms.CornerRadius(4);
            this.supperPanel3.Size = new System.Drawing.Size(200, 41);
            this.supperPanel3.TabIndex = 2;
            // 
            // mainMenu1
            // 
            this.mainMenu1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mainMenu1.Location = new System.Drawing.Point(0, 0);
            this.mainMenu1.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.menuItem1});
            this.mainMenu1.Name = "mainMenu1";
            this.mainMenu1.Size = new System.Drawing.Size(100, 100);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            this.menuItem2,
            this.menuItem3,
            this.menuItem4});
            this.menuItem1.Text = "dsf";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Text = "fdfd";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "dfdf";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 2;
            this.menuItem4.Text = "dfd";
            // 
            // supperPanel4
            // 
            this.supperPanel4.ArrowStart = ((uint)(10u));
            this.supperPanel4.BackColor = System.Drawing.Color.DimGray;
            this.supperPanel4.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.supperPanel4.CustomStyle = "SupperPanelSkin";
            this.supperPanel4.DisplayMode = Bronze.Controls.VWG.DisplayMode.Normal;
            this.supperPanel4.LinearGradient = null;
            this.supperPanel4.Location = new System.Drawing.Point(344, 9);
            this.supperPanel4.Name = "supperPanel4";
            this.supperPanel4.Opacity = 100;
            this.supperPanel4.Radius = new Gizmox.WebGUI.Forms.CornerRadius(0);
            this.supperPanel4.Size = new System.Drawing.Size(200, 100);
            this.supperPanel4.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(567, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(567, 127);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // jrtLabel1
            // 
            this.jrtLabel1.AutoEllipsis = true;
            this.jrtLabel1.BackColor = System.Drawing.Color.Red;
            this.jrtLabel1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.jrtLabel1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Dashed;
            this.jrtLabel1.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.jrtLabel1.CustomStyle = "JrtLabelSkin";
            this.jrtLabel1.Font = new System.Drawing.Font("΢���ź�", 12F, System.Drawing.FontStyle.Bold);
            this.jrtLabel1.ForeColor = System.Drawing.Color.White;
            this.jrtLabel1.HoverBackColor = System.Drawing.Color.DarkCyan;
            this.jrtLabel1.HoverFont = new System.Drawing.Font("΢���ź�", 12F, System.Drawing.FontStyle.Bold);
            this.jrtLabel1.HoverForeColor = System.Drawing.Color.White;
            this.jrtLabel1.HoverLinearGradient = null;
            this.jrtLabel1.LinearGradient = null;
            this.jrtLabel1.Location = new System.Drawing.Point(400, 369);
            this.jrtLabel1.Name = "jrtLabel1";
            this.jrtLabel1.Overable = true;
            this.jrtLabel1.Padding = new Gizmox.WebGUI.Forms.Padding(2, 2, 2, 3);
            this.jrtLabel1.Radius = new Gizmox.WebGUI.Forms.CornerRadius(5);
            this.jrtLabel1.Size = new System.Drawing.Size(123, 50);
            this.jrtLabel1.TabIndex = 7;
            this.jrtLabel1.Text = "��ã���ͬѧ";
            this.jrtLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // jrtLabel2
            // 
            this.jrtLabel2.AutoEllipsis = true;
            this.jrtLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.jrtLabel2.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.jrtLabel2.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Green);
            this.jrtLabel2.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.jrtLabel2.CustomStyle = "JrtLabelSkin";
            this.jrtLabel2.Font = new System.Drawing.Font("΢���ź�", 12F, System.Drawing.FontStyle.Bold);
            this.jrtLabel2.ForeColor = System.Drawing.Color.White;
            this.jrtLabel2.HoverBackColor = System.Drawing.Color.DarkCyan;
            this.jrtLabel2.HoverFont = new System.Drawing.Font("΢���ź�", 12F, System.Drawing.FontStyle.Bold);
            this.jrtLabel2.HoverForeColor = System.Drawing.Color.White;
            this.jrtLabel2.HoverLinearGradient = null;
            this.jrtLabel2.LinearGradient = null;
            this.jrtLabel2.Location = new System.Drawing.Point(567, 369);
            this.jrtLabel2.Name = "jrtLabel2";
            this.jrtLabel2.Overable = true;
            this.jrtLabel2.Padding = new Gizmox.WebGUI.Forms.Padding(2, 2, 2, 3);
            this.jrtLabel2.Radius = new Gizmox.WebGUI.Forms.CornerRadius(5);
            this.jrtLabel2.Size = new System.Drawing.Size(123, 50);
            this.jrtLabel2.TabIndex = 7;
            this.jrtLabel2.Text = "��ã���ͬѧ";
            this.jrtLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = false;
            this.label1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.label1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.label1.CustomStyle = "JrtLabelSkin";
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label1.HoverBackColor = System.Drawing.Color.Transparent;
            this.label1.HoverFont = new System.Drawing.Font("Tahoma", 9F);
            this.label1.HoverForeColor = System.Drawing.Color.Lime;
            this.label1.HoverImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("label1.HoverImage"));
            this.label1.HoverLinearGradient = null;
            this.label1.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("label1.Image"));
            this.label1.ImageLabelSpace = 0;
            this.label1.ImagePostionOfText = Bronze.Controls.VWG.ArrowPosition.Top;
            this.label1.LinearGradient = null;
            this.label1.Location = new System.Drawing.Point(307, 449);
            this.label1.Name = "label1";
            this.label1.Overable = true;
            this.label1.Radius = new Gizmox.WebGUI.Forms.CornerRadius(5);
            this.label1.Size = new System.Drawing.Size(395, 94);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form2
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.jrtLabel2);
            this.Controls.Add(this.jrtLabel1);
            this.Controls.Add(this.supperPanel1);
            this.Controls.Add(this.supperPanel3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.supperPanel2);
            this.Controls.Add(this.supperPanel4);
            this.Menu = this.mainMenu1;
            this.Size = new System.Drawing.Size(771, 567);
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.supperPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private VWG.SupperPanel supperPanel1;
        private TreeView treeView1;
        private TreeNode treeNode1;
        private TreeNode treeNode4;
        private TreeNode treeNode5;
        private TreeNode treeNode6;
        private TreeNode treeNode2;
        private TreeNode treeNode3;
        private VWG.SupperPanel supperPanel2;
        private VWG.SupperPanel supperPanel3;
        private MainMenu mainMenu1;
        private Gizmox.WebGUI.Forms.MenuItem menuItem1;
        private Gizmox.WebGUI.Forms.MenuItem menuItem2;
        private Gizmox.WebGUI.Forms.MenuItem menuItem3;
        private Gizmox.WebGUI.Forms.MenuItem menuItem4;
        private VWG.SupperPanel supperPanel4;
        private Button button1;
        private Button button2;
        private VWG.JrtLabel jrtLabel1;
        private VWG.JrtLabel jrtLabel2;
        private VWG.JrtLabel label1;


    }
}