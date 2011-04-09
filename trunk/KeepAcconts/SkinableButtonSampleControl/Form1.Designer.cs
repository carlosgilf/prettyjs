using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace IssueAppVS2008_CSharp
{
    partial class Form1
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
            this.button1 = new Gizmox.WebGUI.Forms.Button();
            this.tButton1 = new IssueAppVS2008_CSharp.TButton();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(228, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tButton1
            // 
            this.tButton1.CustomStyle = "TButtonSkin";
            this.tButton1.Location = new System.Drawing.Point(228, 87);
            this.tButton1.Name = "tButton1";
            this.tButton1.Size = new System.Drawing.Size(75, 23);
            this.tButton1.TabIndex = 1;
            this.tButton1.Text = "tButton1";
            this.tButton1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.Controls.Add(this.tButton1);
            this.Controls.Add(this.button1);
            this.Size = new System.Drawing.Size(727, 466);
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private TButton tButton1;


    }
}