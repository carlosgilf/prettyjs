using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Bronze.Controls.Examples.SimpleMenu
{
    partial class FrmMainMenu
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
            this.simpleMenu1 = new Bronze.Controls.Examples.SimpleMenu.SimpleMenu();
            this.SuspendLayout();
            // 
            // simpleMenu1
            // 
            this.simpleMenu1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.simpleMenu1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.simpleMenu1.Location = new System.Drawing.Point(9, 52);
            this.simpleMenu1.Name = "simpleMenu1";
            this.simpleMenu1.Size = new System.Drawing.Size(686, 380);
            this.simpleMenu1.TabIndex = 0;
            this.simpleMenu1.Text = "SimpleMenu";
            // 
            // FrmMainMenu
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.simpleMenu1);
            this.Size = new System.Drawing.Size(704, 466);
            this.Text = "FrmMainMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private SimpleMenu simpleMenu1;


    }
}