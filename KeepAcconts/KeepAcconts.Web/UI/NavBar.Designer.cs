using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace KeepAcconts.Web.UI
{
    partial class NavBar
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
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.TitleItem = new Gizmox.WebGUI.Forms.Panel();
            this.TitleItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("ÀŒÃÂ", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(125)))), ((int)(((byte)(132)))));
            this.label2.Location = new System.Drawing.Point(8, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = " ’º˛œ‰";
            // 
            // TitleItem
            // 
            this.TitleItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(233)))), ((int)(((byte)(241)))));
            this.TitleItem.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207))))), System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207))))), System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207))))), System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(187)))), ((int)(((byte)(196))))));
            this.TitleItem.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.TitleItem.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0, 0, 0, 1);
            this.TitleItem.Controls.Add(this.label2);
            this.TitleItem.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.TitleItem.Location = new System.Drawing.Point(0, 0);
            this.TitleItem.Name = "TitleItem";
            this.TitleItem.Size = new System.Drawing.Size(257, 22);
            this.TitleItem.TabIndex = 0;
            // 
            // NavBar
            // 
            this.Controls.Add(this.TitleItem);
            this.Size = new System.Drawing.Size(257, 109);
            this.Text = "NavBar";
            this.Load += new System.EventHandler(this.NavBar_Load);
            this.TitleItem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Label label2;
        public Panel TitleItem;


    }
}