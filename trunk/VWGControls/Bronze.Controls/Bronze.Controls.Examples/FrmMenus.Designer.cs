using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Bronze.Controls.Examples
{
    partial class FrmMenus
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
            this.ucMenu1 = new Bronze.Controls.Examples.UcMenu();
            this.ucMenu2 = new Bronze.Controls.Examples.UcMenu();
            this.ucMenu3 = new Bronze.Controls.Examples.UcMenu();
            this.SuspendLayout();
            // 
            // ucMenu1
            // 
            this.ucMenu1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucMenu1.Location = new System.Drawing.Point(23, 13);
            this.ucMenu1.Name = "ucMenu1";
            this.ucMenu1.Size = new System.Drawing.Size(258, 265);
            this.ucMenu1.TabIndex = 0;
            this.ucMenu1.Text = "UcMenu";
            // 
            // ucMenu2
            // 
            this.ucMenu2.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucMenu2.Location = new System.Drawing.Point(116, 13);
            this.ucMenu2.Name = "ucMenu2";
            this.ucMenu2.Size = new System.Drawing.Size(258, 265);
            this.ucMenu2.TabIndex = 1;
            this.ucMenu2.Text = "UcMenu";
            // 
            // ucMenu3
            // 
            this.ucMenu3.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.ucMenu3.Location = new System.Drawing.Point(211, 13);
            this.ucMenu3.Name = "ucMenu3";
            this.ucMenu3.Size = new System.Drawing.Size(258, 265);
            this.ucMenu3.TabIndex = 2;
            this.ucMenu3.Text = "UcMenu";
            // 
            // FrmMenus
            // 
            this.Controls.Add(this.ucMenu3);
            this.Controls.Add(this.ucMenu2);
            this.Controls.Add(this.ucMenu1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(592, 466);
            this.Text = "FrmMenus";
            this.ResumeLayout(false);

        }

        #endregion

        private UcMenu ucMenu1;
        private UcMenu ucMenu2;
        private UcMenu ucMenu3;


    }
}