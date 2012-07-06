using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Bronze.Controls.Examples.SimpleMenu
{
    partial class SupperMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupperMenu));
            this.buttonLayout = new Gizmox.WebGUI.Forms.Panel();
            this.pRight = new Gizmox.WebGUI.Forms.Panel();
            this.pLeft = new Gizmox.WebGUI.Forms.Panel();
            this.panelBar = new Gizmox.WebGUI.Forms.Panel();
            this.panelBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLayout
            // 
            this.buttonLayout.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.buttonLayout.DockPadding.Left = 15;
            this.buttonLayout.DockPadding.Top = 4;
            this.buttonLayout.Location = new System.Drawing.Point(0, 0);
            this.buttonLayout.Name = "buttonLayout";
            this.buttonLayout.Padding = new Gizmox.WebGUI.Forms.Padding(15, 4, 0, 0);
            this.buttonLayout.Size = new System.Drawing.Size(682, 50);
            this.buttonLayout.TabIndex = 1;
            // 
            // pRight
            // 
            this.pRight.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("pRight.BackgroundImage"));
            this.pRight.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Center;
            this.pRight.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.pRight.Location = new System.Drawing.Point(691, 0);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(7, 52);
            this.pRight.TabIndex = 0;
            // 
            // pLeft
            // 
            this.pLeft.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("pLeft.BackgroundImage"));
            this.pLeft.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Center;
            this.pLeft.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.pLeft.Location = new System.Drawing.Point(0, 0);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(9, 52);
            this.pLeft.TabIndex = 0;
            // 
            // panelBar
            // 
            this.panelBar.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("panelBar.BackgroundImage"));
            this.panelBar.Controls.Add(this.buttonLayout);
            this.panelBar.Controls.Add(this.pRight);
            this.panelBar.Controls.Add(this.pLeft);
            this.panelBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panelBar.Location = new System.Drawing.Point(0, 0);
            this.panelBar.Name = "panelBar";
            this.panelBar.Size = new System.Drawing.Size(698, 50);
            this.panelBar.TabIndex = 0;
            // 
            // SupperMenu
            // 
            this.Controls.Add(this.panelBar);
            this.Size = new System.Drawing.Size(698, 50);
            this.Text = "SupperMenu";
            this.Load += new System.EventHandler(this.SupperMenu_Load);
            this.panelBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel buttonLayout;
        private Panel pRight;
        private Panel pLeft;
        private Panel panelBar;


    }
}