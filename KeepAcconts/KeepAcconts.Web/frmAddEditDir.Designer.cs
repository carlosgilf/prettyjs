using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace KeepAcconts.Web
{
    partial class frmAddEditDir
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
            this.btnSure = new Gizmox.WebGUI.Forms.Button();
            this.btnCancel = new Gizmox.WebGUI.Forms.Button();
            this.txtName = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSure
            // 
            this.btnSure.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Bottom | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.btnSure.Location = new System.Drawing.Point(231, 64);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(75, 23);
            this.btnSure.TabIndex = 0;
            this.btnSure.Text = "确定";
            this.btnSure.UseVisualStyleBackColor = true;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Bottom | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(316, 64);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(59, 18);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(332, 21);
            this.txtName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "文件名";
            // 
            // frmAddEditDir
            // 
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSure);
            this.Size = new System.Drawing.Size(413, 110);
            this.Text = "frmAddEditDir";
            this.Load += new System.EventHandler(this.frmAddEditDir_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnSure;
        private Button btnCancel;
        private TextBox txtName;
        private Label label1;


    }
}