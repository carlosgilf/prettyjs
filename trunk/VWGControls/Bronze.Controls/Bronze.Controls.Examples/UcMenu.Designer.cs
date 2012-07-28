using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Bronze.Controls.Examples
{
    partial class UcMenu
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
            this.hoverPopup = new Bronze.Controls.VWG.HoverPanel();
            this.hoverBtn = new Bronze.Controls.VWG.HoverPanel();
            this.菜单 = new Gizmox.WebGUI.Forms.Label();
            this.hoverBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // hoverPopup
            // 
            this.hoverPopup.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.hoverPopup.CustomStyle = "HoverPanelSkin";
            this.hoverPopup.Hidden = false;
            this.hoverPopup.HoverBackColor = System.Drawing.Color.Transparent;
            this.hoverPopup.Location = new System.Drawing.Point(0, 26);
            this.hoverPopup.Name = "hoverPopup";
            this.hoverPopup.OnClientMouseLeave = null;
            this.hoverPopup.OnClientMouseOver = null;
            this.hoverPopup.Overable = true;
            this.hoverPopup.RenderRunClientMouseLeave = false;
            this.hoverPopup.Size = new System.Drawing.Size(138, 14);
            this.hoverPopup.TabIndex = 1;
            // 
            // hoverBtn
            // 
            this.hoverBtn.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.hoverBtn.Controls.Add(this.菜单);
            this.hoverBtn.CustomStyle = "HoverPanelSkin";
            this.hoverBtn.Hidden = false;
            this.hoverBtn.HoverBackColor = System.Drawing.Color.Gainsboro;
            this.hoverBtn.Location = new System.Drawing.Point(0, 0);
            this.hoverBtn.Name = "hoverBtn";
            this.hoverBtn.OnClientMouseLeave = null;
            this.hoverBtn.OnClientMouseOver = null;
            this.hoverBtn.Overable = true;
            this.hoverBtn.RenderRunClientMouseLeave = false;
            this.hoverBtn.Size = new System.Drawing.Size(138, 27);
            this.hoverBtn.TabIndex = 2;
            // 
            // 菜单
            // 
            this.菜单.AutoSize = true;
            this.菜单.Location = new System.Drawing.Point(48, 5);
            this.菜单.Name = "菜单";
            this.菜单.Size = new System.Drawing.Size(35, 13);
            this.菜单.TabIndex = 0;
            this.菜单.Text = "菜单";
            // 
            // UcMenu
            // 
            this.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0);
            this.Controls.Add(this.hoverPopup);
            this.Controls.Add(this.hoverBtn);
            this.Size = new System.Drawing.Size(142, 45);
            this.Text = "UcMenu";
            this.hoverBtn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private VWG.HoverPanel hoverPopup;
        private Label 菜单;
        private VWG.HoverPanel hoverBtn;


    }
}