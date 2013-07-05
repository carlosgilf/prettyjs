using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Bronze.Controls.Examples
{
    partial class SupperPanelTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupperPanelTest));
            this.pictureBox1 = new Gizmox.WebGUI.Forms.PictureBox();
            this.supperPanel2 = new Bronze.Controls.VWG.SupperPanel();
            this.supperPanel1 = new Bronze.Controls.VWG.SupperPanel();
            this.supperPictureBox1 = new Bronze.Controls.VWG.SupperPictureBox();
            this.supperPanel3 = new Bronze.Controls.VWG.SupperPanel();
            this.supperPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("pictureBox1.Image"));
            this.pictureBox1.Location = new System.Drawing.Point(320, 284);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(108, 107);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // supperPanel2
            // 
            this.supperPanel2.ArrowStart = ((uint)(10u));
            this.supperPanel2.BackColor = System.Drawing.Color.Silver;
            this.supperPanel2.Controls.Add(this.supperPanel1);
            this.supperPanel2.CustomStyle = "SupperPanelSkin";
            this.supperPanel2.DisplayMode = Bronze.Controls.VWG.DisplayMode.Normal;
            this.supperPanel2.DockPadding.All = 4;
            this.supperPanel2.Location = new System.Drawing.Point(176, 92);
            this.supperPanel2.Name = "supperPanel2";
            this.supperPanel2.Opacity = 100;
            this.supperPanel2.Padding = new Gizmox.WebGUI.Forms.Padding(4);
            this.supperPanel2.Radius = new Gizmox.WebGUI.Forms.CornerRadius(8);
            this.supperPanel2.Size = new System.Drawing.Size(116, 115);
            this.supperPanel2.TabIndex = 0;
            // 
            // supperPanel1
            // 
            this.supperPanel1.ArrowStart = ((uint)(10u));
            this.supperPanel1.BackColor = System.Drawing.Color.White;
            this.supperPanel1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
            this.supperPanel1.CustomStyle = "SupperPanelSkin";
            this.supperPanel1.DisplayMode = Bronze.Controls.VWG.DisplayMode.Normal;
            this.supperPanel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.supperPanel1.Location = new System.Drawing.Point(4, 4);
            this.supperPanel1.Name = "supperPanel1";
            this.supperPanel1.Opacity = 100;
            this.supperPanel1.Radius = new Gizmox.WebGUI.Forms.CornerRadius(6);
            this.supperPanel1.Size = new System.Drawing.Size(108, 107);
            this.supperPanel1.TabIndex = 0;
            // 
            // supperPictureBox1
            // 
            this.supperPictureBox1.CustomStyle = "SupperPictureBox";
            this.supperPictureBox1.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("supperPictureBox1.Image"));
            this.supperPictureBox1.Location = new System.Drawing.Point(425, 92);
            this.supperPictureBox1.Name = "supperPictureBox1";
            this.supperPictureBox1.Radius = new Gizmox.WebGUI.Forms.CornerRadius(0);
            this.supperPictureBox1.Size = new System.Drawing.Size(100, 115);
            this.supperPictureBox1.TabIndex = 1;
            this.supperPictureBox1.TabStop = false;
            // 
            // supperPanel3
            // 
            this.supperPanel3.ArrowStart = ((uint)(10u));
            this.supperPanel3.BackColor = System.Drawing.Color.Silver;
            this.supperPanel3.CustomStyle = "SupperPanelSkin";
            this.supperPanel3.DisplayMode = Bronze.Controls.VWG.DisplayMode.Normal;
            this.supperPanel3.DockPadding.All = 4;
            this.supperPanel3.Location = new System.Drawing.Point(176, 92);
            this.supperPanel3.Name = "supperPanel2";
            this.supperPanel3.Opacity = 100;
            this.supperPanel3.Padding = new Gizmox.WebGUI.Forms.Padding(4);
            this.supperPanel3.Radius = new Gizmox.WebGUI.Forms.CornerRadius(8);
            this.supperPanel3.Size = new System.Drawing.Size(116, 115);
            this.supperPanel3.TabIndex = 0;
            // 
            // SupperPanelTest
            // 
            this.Controls.Add(this.supperPictureBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.supperPanel3);
            this.Size = new System.Drawing.Size(624, 553);
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.supperPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private VWG.SupperPanel supperPanel1;
        private VWG.SupperPanel supperPanel2;
        private PictureBox pictureBox1;
        private VWG.SupperPictureBox supperPictureBox1;
        private VWG.SupperPanel supperPanel3;


    }
}