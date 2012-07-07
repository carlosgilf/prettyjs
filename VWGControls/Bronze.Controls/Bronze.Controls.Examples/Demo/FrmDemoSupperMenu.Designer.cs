using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Bronze.Controls.Examples
{
    partial class FrmDemoSupperMenu
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
            this.supperMenu1 = new Bronze.Controls.Examples.SimpleMenu.SupperMenu();
            this.SuspendLayout();
            // 
            // supperMenu1
            // 
            this.supperMenu1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.supperMenu1.Animate = "dropDown,dropUp";
            this.supperMenu1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.supperMenu1.Location = new System.Drawing.Point(9, 54);
            this.supperMenu1.Name = "supperMenu1";
            this.supperMenu1.Size = new System.Drawing.Size(820, 40);
            this.supperMenu1.TabIndex = 0;
            this.supperMenu1.Text = "SupperMenu";
            // 
            // FrmDemoSupperMenu
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.supperMenu1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(838, 466);
            this.Text = "FrmDemoSupperMenu";
            this.Load += new System.EventHandler(this.FrmDemoSupperMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Bronze.Controls.Examples.SimpleMenu.SupperMenu supperMenu1;


    }
}