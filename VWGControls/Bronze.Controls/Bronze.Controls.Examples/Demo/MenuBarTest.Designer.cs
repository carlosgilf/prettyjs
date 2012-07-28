using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Bronze.Controls.Examples.Demo
{
    partial class MenuBarTest
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
            this.hoverPanel1 = new Bronze.Controls.VWG.HoverPanel();
            this.supperMenu1 = new Bronze.Controls.Examples.MenuBar();
            this.SuspendLayout();
            // 
            // hoverPanel1
            // 
            this.hoverPanel1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.hoverPanel1.CustomStyle = "HoverPanelSkin";
            this.hoverPanel1.Hidden = false;
            this.hoverPanel1.HoverBackColor = System.Drawing.Color.Black;
            this.hoverPanel1.Location = new System.Drawing.Point(34, 205);
            this.hoverPanel1.Name = "hoverPanel1";
            this.hoverPanel1.OnClientMouseLeave = null;
            this.hoverPanel1.OnClientMouseOver = null;
            this.hoverPanel1.Overable = true;
            this.hoverPanel1.Radius = new Gizmox.WebGUI.Forms.CornerRadius(20);
            this.hoverPanel1.RenderRunClientMouseLeave = false;
            this.hoverPanel1.Size = new System.Drawing.Size(192, 192);
            this.hoverPanel1.TabIndex = 1;
            // 
            // supperMenu1
            // 
            this.supperMenu1.Animate = "dropDown,dropUp";
            this.supperMenu1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.supperMenu1.Location = new System.Drawing.Point(34, 27);
            this.supperMenu1.Name = "supperMenu1";
            this.supperMenu1.Size = new System.Drawing.Size(698, 40);
            this.supperMenu1.TabIndex = 2;
            this.supperMenu1.Text = "SupperMenu";
            // 
            // MenuBarTest
            // 
            this.Controls.Add(this.supperMenu1);
            this.Controls.Add(this.hoverPanel1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(852, 466);
            this.Text = "MenuBarTest";
            this.Load += new System.EventHandler(this.MenuBarTest_Load_1);
            this.ResumeLayout(false);

        }

        #endregion

        private VWG.HoverPanel hoverPanel1;
        private MenuBar supperMenu1;


    }
}