using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Bronze.Controls.Examples.MainFormTest
{
    partial class MainFrm
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
            this.htmlTop = new Gizmox.WebGUI.Forms.HtmlBox();
            this.panelBottom = new Gizmox.WebGUI.Forms.Panel();
            this.htmlBottom = new Gizmox.WebGUI.Forms.HtmlBox();
            this.panelMain = new Gizmox.WebGUI.Forms.Panel();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // htmlTop
            // 
            this.htmlTop.ContentType = "text/html";
            this.htmlTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.htmlTop.Expires = -1;
            this.htmlTop.Html = "<a>Test111 Top</a>";
            this.htmlTop.IsWindowless = true;
            this.htmlTop.Location = new System.Drawing.Point(0, 0);
            this.htmlTop.Name = "htmlTop";
            this.htmlTop.Size = new System.Drawing.Size(691, 100);
            this.htmlTop.TabIndex = 0;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.htmlBottom);
            this.panelBottom.Controls.Add(this.panelMain);
            this.panelBottom.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panelBottom.Location = new System.Drawing.Point(0, 100);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(691, 474);
            this.panelBottom.TabIndex = 1;
            // 
            // htmlBottom
            // 
            this.htmlBottom.ContentType = "text/html";
            this.htmlBottom.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.htmlBottom.Expires = -1;
            this.htmlBottom.Html = "<div style=\"widht:100%;height:100%;background-color:whitesmoke\"><a>Test111 Top</a" +
    "></div>";
            this.htmlBottom.IsWindowless = true;
            this.htmlBottom.Location = new System.Drawing.Point(0, 0);
            this.htmlBottom.Name = "htmlBottom";
            this.htmlBottom.Size = new System.Drawing.Size(304, 474);
            this.htmlBottom.TabIndex = 0;
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.panelMain.Location = new System.Drawing.Point(339, 26);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(200, 208);
            this.panelMain.TabIndex = 0;
            // 
            // MainFrm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.htmlTop);
            this.Size = new System.Drawing.Size(691, 574);
            this.Text = "MainFrm";
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private HtmlBox htmlTop;
        private Panel panelBottom;
        private HtmlBox htmlBottom;
        private Panel panelMain;


    }
}