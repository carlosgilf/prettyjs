using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Bronze.Controls.Examples.SimpleMenu
{
    partial class MenuButton
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

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuButton));
            this.hoverPopup = new Bronze.Controls.VWG.HoverPanel();
            this.panelMenuContanier = new Gizmox.WebGUI.Forms.Panel();
            this.panelPopuBottom = new Gizmox.WebGUI.Forms.Panel();
            this.pictureBox2 = new Gizmox.WebGUI.Forms.PictureBox();
            this.pictureBox1 = new Gizmox.WebGUI.Forms.PictureBox();
            this.hoverBtn = new Bronze.Controls.VWG.HoverPanel();
            this.lbText = new Gizmox.WebGUI.Forms.Label();
            this.btnTop = new Gizmox.WebGUI.Forms.Panel();
            this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.btn_left = new Gizmox.WebGUI.Forms.Panel();
            this.btnMain = new Gizmox.WebGUI.Forms.Panel();
            this.hoverPopup.SuspendLayout();
            this.panelPopuBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.hoverBtn.SuspendLayout();
            this.btnTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // hoverPopup
            // 
            this.hoverPopup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.hoverPopup.Controls.Add(this.panelMenuContanier);
            this.hoverPopup.Controls.Add(this.panelPopuBottom);
            this.hoverPopup.CustomStyle = "HoverPanelSkin";
            this.hoverPopup.Hidden = true;
            this.hoverPopup.HoverBackColor = System.Drawing.Color.Black;
            this.hoverPopup.Location = new System.Drawing.Point(0, 34);
            this.hoverPopup.Name = "hoverPopup";
            this.hoverPopup.OnClientMouseLeave = null;
            this.hoverPopup.OnClientMouseOver = null;
            this.hoverPopup.Overable = true;
            this.hoverPopup.Radius = 0;
            this.hoverPopup.RenderRunClientMouseLeave = false;
            this.hoverPopup.Size = new System.Drawing.Size(200, 116);
            this.hoverPopup.TabIndex = 3;
            // 
            // panelMenuContanier
            // 
            this.panelMenuContanier.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panelMenuContanier.DockPadding.Left = 10;
            this.panelMenuContanier.DockPadding.Right = 10;
            this.panelMenuContanier.DockPadding.Top = 10;
            this.panelMenuContanier.Location = new System.Drawing.Point(0, 0);
            this.panelMenuContanier.Name = "panelMenuContanier";
            this.panelMenuContanier.Padding = new Gizmox.WebGUI.Forms.Padding(10, 10, 10, 0);
            this.panelMenuContanier.Size = new System.Drawing.Size(200, 94);
            this.panelMenuContanier.TabIndex = 1;
            // 
            // panelPopuBottom
            // 
            this.panelPopuBottom.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("panelPopuBottom.BackgroundImage"));
            this.panelPopuBottom.Controls.Add(this.pictureBox2);
            this.panelPopuBottom.Controls.Add(this.pictureBox1);
            this.panelPopuBottom.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.panelPopuBottom.Location = new System.Drawing.Point(0, 94);
            this.panelPopuBottom.Name = "panelPopuBottom";
            this.panelPopuBottom.Size = new System.Drawing.Size(200, 22);
            this.panelPopuBottom.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.pictureBox2.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("pictureBox2.Image"));
            this.pictureBox2.Location = new System.Drawing.Point(189, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(11, 22);
            this.pictureBox2.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.pictureBox1.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("pictureBox1.Image"));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(13, 22);
            this.pictureBox1.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // hoverBtn
            // 
            this.hoverBtn.Controls.Add(this.lbText);
            this.hoverBtn.Controls.Add(this.btnTop);
            this.hoverBtn.Controls.Add(this.btnMain);
            this.hoverBtn.CustomStyle = "HoverPanelSkin";
            this.hoverBtn.Hidden = false;
            this.hoverBtn.HoverBackColor = System.Drawing.Color.Black;
            this.hoverBtn.Location = new System.Drawing.Point(0, 0);
            this.hoverBtn.Name = "hoverBtn";
            this.hoverBtn.OnClientMouseLeave = null;
            this.hoverBtn.OnClientMouseOver = null;
            this.hoverBtn.Overable = true;
            this.hoverBtn.Radius = 0;
            this.hoverBtn.RenderRunClientMouseLeave = false;
            this.hoverBtn.Size = new System.Drawing.Size(89, 35);
            this.hoverBtn.TabIndex = 2;
            // 
            // lbText
            // 
            this.lbText.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Top;
            this.lbText.AutoSize = true;
            this.lbText.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lbText.ForeColor = System.Drawing.Color.White;
            this.lbText.Location = new System.Drawing.Point(22, 6);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(44, 17);
            this.lbText.TabIndex = 0;
            this.lbText.Text = "Home";
            // 
            // btnTop
            // 
            this.btnTop.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("btnTop.BackgroundImage"));
            this.btnTop.Controls.Add(this.panel3);
            this.btnTop.Controls.Add(this.btn_left);
            this.btnTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.btnTop.Location = new System.Drawing.Point(0, 0);
            this.btnTop.Name = "btnTop";
            this.btnTop.Size = new System.Drawing.Size(89, 8);
            this.btnTop.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("panel3.BackgroundImage"));
            this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(83, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(6, 8);
            this.panel3.TabIndex = 0;
            // 
            // btn_left
            // 
            this.btn_left.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("btn_left.BackgroundImage"));
            this.btn_left.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.btn_left.Location = new System.Drawing.Point(0, 0);
            this.btn_left.Name = "btn_left";
            this.btn_left.Size = new System.Drawing.Size(8, 8);
            this.btn_left.TabIndex = 0;
            // 
            // btnMain
            // 
            this.btnMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.btnMain.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(174))))));
            this.btnMain.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(1, 0, 1, 0);
            this.btnMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.btnMain.Location = new System.Drawing.Point(0, 0);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(89, 35);
            this.btnMain.TabIndex = 1;
            // 
            // MenuButton
            // 
            this.Controls.Add(this.hoverPopup);
            this.Controls.Add(this.hoverBtn);
            this.Size = new System.Drawing.Size(424, 292);
            this.Text = "MenuButton";
            this.hoverPopup.ResumeLayout(false);
            this.panelPopuBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.hoverBtn.ResumeLayout(false);
            this.btnTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel btnTop;
        private Panel panel3;
        private Panel btn_left;
        private Panel btnMain;
        private VWG.HoverPanel hoverBtn;
        private Label lbText;
        private VWG.HoverPanel hoverPopup;
        private Panel panelPopuBottom;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Panel panelMenuContanier;


    }
}