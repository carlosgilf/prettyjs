using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace KeepAcconts.Web
{
    partial class frmFileManager
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
            this.SuspendLayout();
            // 
            // frmFileManager
            // 
            this.Size = new System.Drawing.Size(693, 521);
            this.Text = "frmFileManager";
            this.Load += new System.EventHandler(this.frmFileManager_Load);
            this.ResumeLayout(false);

        }

        #endregion


    }
}