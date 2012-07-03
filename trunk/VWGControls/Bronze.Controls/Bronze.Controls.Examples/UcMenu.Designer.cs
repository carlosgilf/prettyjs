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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcMenu));
            this.button2 = new Gizmox.WebGUI.Forms.Button();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.hoverPopup = new Bronze.Controls.VWG.HoverPanel();
            this.菜单 = new Gizmox.WebGUI.Forms.Label();
            this.hoverBtn = new Bronze.Controls.VWG.HoverPanel();
            this.hoverPopup.SuspendLayout();
            this.hoverBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 118);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
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
            // hoverPopup
            // 
            this.hoverPopup.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("hoverPopup.BackgroundImage"));
            this.hoverPopup.Controls.Add(this.button2);
            this.hoverPopup.Controls.Add(this.label6);
            this.hoverPopup.Controls.Add(this.label5);
            this.hoverPopup.CustomStyle = "HoverPanelSkin";
            this.hoverPopup.Hidden = false;
            this.hoverPopup.HoverBackColor = System.Drawing.Color.Transparent;
            this.hoverPopup.Location = new System.Drawing.Point(0, 27);
            this.hoverPopup.Name = "hoverPopup";
            this.hoverPopup.OnClientMouseLeave = null;
            this.hoverPopup.OnClientMouseOver = null;
            this.hoverPopup.Overable = true;
            this.hoverPopup.RenderRunClientMouseLeave = false;
            this.hoverPopup.Size = new System.Drawing.Size(255, 236);
            this.hoverPopup.TabIndex = 1;
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
            this.hoverBtn.Size = new System.Drawing.Size(90, 27);
            this.hoverBtn.TabIndex = 2;
            // 
            // UcMenu
            // 
            this.Controls.Add(this.hoverBtn);
            this.Controls.Add(this.hoverPopup);
            this.Size = new System.Drawing.Size(258, 265);
            this.Text = "UcMenu";
            this.hoverPopup.ResumeLayout(false);
            this.hoverBtn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button button2;
        private Label label6;
        private Label label5;
        private VWG.HoverPanel hoverPopup;
        private Label 菜单;
        private VWG.HoverPanel hoverBtn;


    }
}