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
            this.pLeft = new Gizmox.WebGUI.Forms.PictureBox();
            this.pRight = new Gizmox.WebGUI.Forms.PictureBox();
            this.buttonLayout = new Gizmox.WebGUI.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRight)).BeginInit();
            this.SuspendLayout();
            // 
            // pLeft
            // 
            this.pLeft.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.pLeft.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("pLeft.Image"));
            this.pLeft.Location = new System.Drawing.Point(0, 0);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(9, 200);
            this.pLeft.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.AutoSize;
            this.pLeft.TabIndex = 0;
            this.pLeft.TabStop = false;
            // 
            // pRight
            // 
            this.pRight.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.pRight.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("pRight.Image"));
            this.pRight.Location = new System.Drawing.Point(691, 0);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(7, 200);
            this.pRight.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.AutoSize;
            this.pRight.TabIndex = 1;
            this.pRight.TabStop = false;
            // 
            // buttonLayout
            // 
            this.buttonLayout.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("buttonLayout.BackgroundImage"));
            this.buttonLayout.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.buttonLayout.Location = new System.Drawing.Point(9, 0);
            this.buttonLayout.Name = "buttonLayout";
            this.buttonLayout.Size = new System.Drawing.Size(682, 200);
            this.buttonLayout.TabIndex = 2;
            // 
            // SupperMenu
            // 
            this.Controls.Add(this.buttonLayout);
            this.Controls.Add(this.pRight);
            this.Controls.Add(this.pLeft);
            this.Size = new System.Drawing.Size(698, 40);
            this.Text = "SupperMenu";
            this.Load += new System.EventHandler(this.SupperMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pRight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pLeft;
        private PictureBox pRight;
        private Panel buttonLayout;



    }
}