﻿namespace Bronze.Controls.Examples
{
    partial class FrmHoverPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHoverPanel));
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.hoverPanel1 = new Bronze.Controls.VWG.HoverPanel();
            this.hoverPanel2 = new Bronze.Controls.VWG.HoverPanel();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.hoverPopup = new Bronze.Controls.VWG.HoverPanel();
            this.hoverBtn = new Bronze.Controls.VWG.HoverPanel();
            this.菜单 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.button1 = new Gizmox.WebGUI.Forms.Button();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.button2 = new Gizmox.WebGUI.Forms.Button();
            this.hoverPanel1.SuspendLayout();
            this.hoverPanel2.SuspendLayout();
            this.hoverPopup.SuspendLayout();
            this.hoverBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "下拉";
            // 
            // hoverPanel1
            // 
            this.hoverPanel1.Controls.Add(this.hoverPanel2);
            this.hoverPanel1.CustomStyle = "HoverPanelSkin";
            this.hoverPanel1.Hidden = false;
            this.hoverPanel1.HoverBackColor = System.Drawing.Color.Black;
            this.hoverPanel1.Location = new System.Drawing.Point(365, 31);
            this.hoverPanel1.Name = "hoverPanel1";
            this.hoverPanel1.OnClientMouseLeave = null;
            this.hoverPanel1.OnClientMouseOver = null;
            this.hoverPanel1.Overable = true;
            this.hoverPanel1.RenderRunClientMouseLeave = false;
            this.hoverPanel1.Size = new System.Drawing.Size(94, 272);
            this.hoverPanel1.TabIndex = 3;
            // 
            // hoverPanel2
            // 
            this.hoverPanel2.Controls.Add(this.label2);
            this.hoverPanel2.CustomStyle = "HoverPanelSkin";
            this.hoverPanel2.Hidden = false;
            this.hoverPanel2.HoverBackColor = System.Drawing.Color.Black;
            this.hoverPanel2.Location = new System.Drawing.Point(3, 2);
            this.hoverPanel2.Name = "hoverPanel2";
            this.hoverPanel2.OnClientMouseLeave = null;
            this.hoverPanel2.OnClientMouseOver = null;
            this.hoverPanel2.Overable = true;
            this.hoverPanel2.RenderRunClientMouseLeave = false;
            this.hoverPanel2.Size = new System.Drawing.Size(84, 26);
            this.hoverPanel2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
            // 
            // hoverPopup
            // 
            this.hoverPopup.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("hoverPopup.BackgroundImage"));
            this.hoverPopup.Controls.Add(this.button2);
            this.hoverPopup.Controls.Add(this.label6);
            this.hoverPopup.Controls.Add(this.label5);
            this.hoverPopup.CustomStyle = "HoverPanelSkin";
            this.hoverPopup.Hidden = false;
            this.hoverPopup.HoverBackColor = System.Drawing.Color.Transparent;
            this.hoverPopup.Location = new System.Drawing.Point(39, 57);
            this.hoverPopup.Name = "hoverPopup";
            this.hoverPopup.OnClientMouseLeave = null;
            this.hoverPopup.OnClientMouseOver = null;
            this.hoverPopup.Overable = true;
            this.hoverPopup.RenderRunClientMouseLeave = false;
            this.hoverPopup.Size = new System.Drawing.Size(255, 236);
            this.hoverPopup.TabIndex = 1;
            // 
            // hoverBtn
            // 
            this.hoverBtn.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.hoverBtn.Controls.Add(this.菜单);
            this.hoverBtn.CustomStyle = "HoverPanelSkin";
            this.hoverBtn.Hidden = false;
            this.hoverBtn.HoverBackColor = System.Drawing.Color.Gainsboro;
            this.hoverBtn.Location = new System.Drawing.Point(39, 21);
            this.hoverBtn.Name = "hoverBtn";
            this.hoverBtn.OnClientMouseLeave = null;
            this.hoverBtn.OnClientMouseOver = null;
            this.hoverBtn.Overable = true;
            this.hoverBtn.RenderRunClientMouseLeave = false;
            this.hoverBtn.Size = new System.Drawing.Size(90, 35);
            this.hoverBtn.TabIndex = 2;
            // 
            // 菜单
            // 
            this.菜单.AutoSize = true;
            this.菜单.Location = new System.Drawing.Point(14, 5);
            this.菜单.Name = "菜单";
            this.菜单.Size = new System.Drawing.Size(35, 13);
            this.菜单.TabIndex = 0;
            this.菜单.Text = "菜单";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(43, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "看电视剧风口浪尖第";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Location = new System.Drawing.Point(43, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "看电视剧风口浪尖第";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(43, 142);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(10, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "送到房间看电视剧法律手";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(15, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "送到房间看电视剧法律手";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 118);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            // 
            // FrmHoverPanel
            // 
            this.Controls.Add(this.hoverPanel1);
            this.Controls.Add(this.hoverPopup);
            this.Controls.Add(this.hoverBtn);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(699, 462);
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmHoverPanel_Load);
            this.hoverPanel1.ResumeLayout(false);
            this.hoverPanel2.ResumeLayout(false);
            this.hoverPopup.ResumeLayout(false);
            this.hoverBtn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private VWG.HoverPanel hoverPopup;
        private Gizmox.WebGUI.Forms.Label label1;
        private VWG.HoverPanel hoverBtn;
        private Gizmox.WebGUI.Forms.Label 菜单;
        private VWG.HoverPanel hoverPanel1;
        private VWG.HoverPanel hoverPanel2;
        private Gizmox.WebGUI.Forms.Label label2;
        private Gizmox.WebGUI.Forms.Label label3;
        private Gizmox.WebGUI.Forms.Label label4;
        private Gizmox.WebGUI.Forms.Button button1;
        private Gizmox.WebGUI.Forms.Button button2;
        private Gizmox.WebGUI.Forms.Label label6;
        private Gizmox.WebGUI.Forms.Label label5;
    }
}