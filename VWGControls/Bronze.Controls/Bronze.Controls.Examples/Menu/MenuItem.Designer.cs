using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Bronze.Controls.Examples
{
    partial class MenuItem
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
            this.lbText = new Gizmox.WebGUI.Forms.Label();
            this.hoverBtn = new Bronze.Controls.VWG.SupperHoverPanel();
            this.btnMain = new Bronze.Controls.VWG.SupperPanel();
            this.hoverPopup = new Bronze.Controls.VWG.SupperHoverPanel();
            this.popupMain = new Bronze.Controls.VWG.SupperPanel();
            this.hoverBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbText
            // 
            this.lbText.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.lbText.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lbText.ForeColor = System.Drawing.Color.White;
            this.lbText.Location = new System.Drawing.Point(0, 0);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(65, 35);
            this.lbText.TabIndex = 0;
            this.lbText.Text = "Home";
            this.lbText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hoverBtn
            // 
            this.hoverBtn.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(174))))));
            this.hoverBtn.BoxShadow = new Bronze.Controls.VWG.BoxShadow(System.Drawing.Color.Empty, 0, 0, 0);
            this.hoverBtn.Controls.Add(this.lbText);
            this.hoverBtn.Controls.Add(this.btnMain);
            this.hoverBtn.CustomStyle = "SupperHoverPanelSkin";
            this.hoverBtn.DisplayMode = Bronze.Controls.VWG.DisplayMode.Normal;
            this.hoverBtn.Location = new System.Drawing.Point(162, 45);
            this.hoverBtn.Name = "hoverBtn";
            this.hoverBtn.OnClientMouseLeave = null;
            this.hoverBtn.OnClientMouseOver = null;
            this.hoverBtn.Overable = true;
            this.hoverBtn.Radius = new Gizmox.WebGUI.Forms.CornerRadius(0);
            this.hoverBtn.RenderRunClientMouseLeave = false;
            this.hoverBtn.Size = new System.Drawing.Size(65, 35);
            this.hoverBtn.TabIndex = 2;
            // 
            // btnMain
            // 
            this.btnMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.btnMain.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(174))))));
            this.btnMain.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.btnMain.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(1, 1, 1, 0);
            this.btnMain.BoxShadow = new Bronze.Controls.VWG.BoxShadow(System.Drawing.Color.Empty, 0, 0, 0);
            this.btnMain.CustomStyle = "SupperPanelSkin";
            this.btnMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.btnMain.DockPadding.Left = 1;
            this.btnMain.DockPadding.Right = 1;
            this.btnMain.DockPadding.Top = 1;
            this.btnMain.Location = new System.Drawing.Point(0, 0);
            this.btnMain.Name = "btnMain";
            this.btnMain.Padding = new Gizmox.WebGUI.Forms.Padding(1, 1, 1, 0);
            this.btnMain.Radius = new Gizmox.WebGUI.Forms.CornerRadius(8, 8, 0, 0);
            this.btnMain.Size = new System.Drawing.Size(65, 35);
            this.btnMain.TabIndex = 5;
            // 
            // hoverPopup
            // 
            this.hoverPopup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.hoverPopup.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(174))))));
            this.hoverPopup.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.hoverPopup.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(1, 0, 1, 1);
            this.hoverPopup.BoxShadow = new Bronze.Controls.VWG.BoxShadow(System.Drawing.Color.Empty, 0, 0, 0);
            this.hoverPopup.CustomStyle = "SupperHoverPanelSkin";
            this.hoverPopup.DisplayMode = Bronze.Controls.VWG.DisplayMode.Normal;
            this.hoverPopup.DockPadding.Bottom = 8;
            this.hoverPopup.DockPadding.Left = 8;
            this.hoverPopup.DockPadding.Right = 8;
            this.hoverPopup.DockPadding.Top = 5;
            this.hoverPopup.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.hoverPopup.Location = new System.Drawing.Point(58, 102);
            this.hoverPopup.Name = "hoverPopup";
            this.hoverPopup.OnClientMouseLeave = null;
            this.hoverPopup.OnClientMouseOver = null;
            this.hoverPopup.Overable = true;
            this.hoverPopup.Padding = new Gizmox.WebGUI.Forms.Padding(8, 5, 8, 8);
            this.hoverPopup.Radius = new Gizmox.WebGUI.Forms.CornerRadius(0, 15, 15, 15);
            this.hoverPopup.RenderRunClientMouseLeave = false;
            this.hoverPopup.Size = new System.Drawing.Size(200, 116);
            this.hoverPopup.TabIndex = 3;
            // 
            // popupMain
            // 
            this.popupMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.popupMain.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(174))))));
            this.popupMain.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.popupMain.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(1, 0, 1, 1);
            this.popupMain.BoxShadow = new Bronze.Controls.VWG.BoxShadow(System.Drawing.Color.Empty, 0, 0, 0);
            this.popupMain.CustomStyle = "SupperPanelSkin";
            this.popupMain.DisplayMode = Bronze.Controls.VWG.DisplayMode.Normal;
            this.popupMain.DockPadding.Bottom = 8;
            this.popupMain.DockPadding.Left = 8;
            this.popupMain.DockPadding.Right = 8;
            this.popupMain.DockPadding.Top = 5;
            this.popupMain.Location = new System.Drawing.Point(322, 146);
            this.popupMain.Name = "popupMain";
            this.popupMain.Padding = new Gizmox.WebGUI.Forms.Padding(8, 5, 8, 8);
            this.popupMain.Radius = new Gizmox.WebGUI.Forms.CornerRadius(0, 0, 15, 15);
            this.popupMain.Size = new System.Drawing.Size(200, 116);
            this.popupMain.TabIndex = 0;
            // 
            // MenuItem
            // 
            this.Controls.Add(this.popupMain);
            this.Controls.Add(this.hoverPopup);
            this.Controls.Add(this.hoverBtn);
            this.Size = new System.Drawing.Size(565, 463);
            this.Text = "MenuItem";
            this.hoverBtn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label lbText;
        private VWG.SupperHoverPanel hoverBtn;
        private VWG.SupperHoverPanel hoverPopup;
        private VWG.SupperPanel btnMain;
        private VWG.SupperPanel popupMain;


    }
}