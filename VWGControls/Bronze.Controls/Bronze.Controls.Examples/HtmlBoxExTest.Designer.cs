using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Bronze.Controls.Examples
{
    partial class HtmlBoxExTest
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
            this.htmlBoxEx1 = new Bronze.Controls.VWG.HtmlBoxEx();
            this.htmlBox1 = new Gizmox.WebGUI.Forms.HtmlBox();
            this.SuspendLayout();
            // 
            // htmlBoxEx1
            // 
            this.htmlBoxEx1.ContentType = "text/html";
            this.htmlBoxEx1.CustomStyle = "HtmlBoxEx";
            this.htmlBoxEx1.Expires = -1;
            this.htmlBoxEx1.Html = "<a>ddfdfdfsdfsdf</a>";
            this.htmlBoxEx1.IsWindowless = true;
            this.htmlBoxEx1.Location = new System.Drawing.Point(9, 9);
            this.htmlBoxEx1.Name = "htmlBoxEx1";
            this.htmlBoxEx1.Selectable = true;
            this.htmlBoxEx1.Size = new System.Drawing.Size(575, 268);
            this.htmlBoxEx1.TabIndex = 0;
            // 
            // htmlBox1
            // 
            this.htmlBox1.ContentType = "text/html";
            this.htmlBox1.Expires = -1;
            this.htmlBox1.Html = "<HTML>No content.</HTML>";
            this.htmlBox1.IsWindowless = true;
            this.htmlBox1.Location = new System.Drawing.Point(57, 334);
            this.htmlBox1.Name = "htmlBox1";
            this.htmlBox1.Size = new System.Drawing.Size(250, 250);
            this.htmlBox1.TabIndex = 1;
            // 
            // HtmlBoxExTest
            // 
            this.Controls.Add(this.htmlBox1);
            this.Controls.Add(this.htmlBoxEx1);
            this.Size = new System.Drawing.Size(817, 725);
            this.Text = "HtmlBoxExTest";
            this.ResumeLayout(false);

        }

        #endregion

        private VWG.HtmlBoxEx htmlBoxEx1;
        private HtmlBox htmlBox1;


    }
}