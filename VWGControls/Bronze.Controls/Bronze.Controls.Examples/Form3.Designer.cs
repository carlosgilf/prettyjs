using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Bronze.Controls.Examples
{
    partial class Form3
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
            this.pictureBox1 = new Gizmox.WebGUI.Forms.PictureBox();
            this.textBox2 = new Gizmox.WebGUI.Forms.TextBox();
            this.supperPanel1 = new Bronze.Controls.VWG.SupperPanel();
            this.supperPictureBox1 = new Bronze.Controls.VWG.SupperPictureBox();
            this.hotfixExtender1 = new Bronze.Controls.VWG.HotfixExtender();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 105);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(97, 286);
            this.textBox2.Name = "textBox2";
            this.hotfixExtender1.SetRequestTimeout(this.textBox2, 15);
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 1;
            // 
            // supperPanel1
            // 
            this.supperPanel1.ArrowStart = ((uint)(10u));
            this.supperPanel1.CustomStyle = "SupperPanelSkin";
            this.supperPanel1.DisplayMode = Bronze.Controls.VWG.DisplayMode.Normal;
            this.supperPanel1.LinearGradient = null;
            this.supperPanel1.Location = new System.Drawing.Point(97, 9);
            this.supperPanel1.Name = "supperPanel1";
            this.supperPanel1.Opacity = 100;
            this.supperPanel1.Radius = new Gizmox.WebGUI.Forms.CornerRadius(0);
            this.supperPanel1.Size = new System.Drawing.Size(200, 100);
            this.supperPanel1.TabIndex = 4;
            // 
            // supperPictureBox1
            // 
            this.supperPictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.supperPictureBox1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.supperPictureBox1.CustomStyle = "SupperPictureBox";
            this.supperPictureBox1.Location = new System.Drawing.Point(66, 126);
            this.supperPictureBox1.Name = "supperPictureBox1";
            this.supperPictureBox1.Radius = new Gizmox.WebGUI.Forms.CornerRadius(5);
            this.supperPictureBox1.Size = new System.Drawing.Size(240, 64);
            this.supperPictureBox1.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.StretchImage;
            this.supperPictureBox1.TabIndex = 0;
            this.supperPictureBox1.TabStop = false;
            // 
            // Form3
            // 
            this.Controls.Add(this.supperPanel1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.supperPictureBox1);
            this.Size = new System.Drawing.Size(419, 466);
            this.Text = "Form3";
            this.ResumeLayout(false);

        }

        #endregion

        private VWG.SupperPictureBox supperPictureBox1;
        private PictureBox pictureBox1;
        private TextBox textBox2;
        private VWG.SupperPanel supperPanel1;
        private VWG.HotfixExtender hotfixExtender1;


    }
}