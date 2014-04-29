using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Bronze.Controls.Examples
{
    partial class testFuck
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
            this.jrtLabel1 = new Bronze.Controls.VWG.JrtLabel();
            this.supperPanel1 = new Bronze.Controls.VWG.SupperPanel();
            this.SuspendLayout();
            // 
            // jrtLabel1
            // 
            this.jrtLabel1.AutoEllipsis = false;
            this.jrtLabel1.BackColor = System.Drawing.Color.Maroon;
            this.jrtLabel1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.jrtLabel1.CustomStyle = "JrtLabelSkin";
            this.jrtLabel1.HoverBackColor = System.Drawing.Color.Transparent;
            this.jrtLabel1.HoverFont = new System.Drawing.Font("Tahoma", 8.25F);
            this.jrtLabel1.HoverForeColor = System.Drawing.Color.Black;
            this.jrtLabel1.HoverLinearGradient = null;
            this.jrtLabel1.LinearGradient = null;
            this.jrtLabel1.Location = new System.Drawing.Point(75, 129);
            this.jrtLabel1.Name = "jrtLabel1";
            this.jrtLabel1.OnClientMouseLeave = null;
            this.jrtLabel1.OnClientMouseOver = null;
            this.jrtLabel1.Overable = true;
            this.jrtLabel1.Radius = new Gizmox.WebGUI.Forms.CornerRadius(8);
            this.jrtLabel1.RenderRunClientMouseLeave = false;
            this.jrtLabel1.Size = new System.Drawing.Size(100, 80);
            this.jrtLabel1.TabIndex = 0;
            this.jrtLabel1.Text = "jrtLabel1";
            // 
            // supperPanel1
            // 
            this.supperPanel1.ArrowStart = ((uint)(10u));
            this.supperPanel1.BackColor = System.Drawing.Color.Aqua;
            this.supperPanel1.BoxShadow = new Bronze.Controls.VWG.BoxShadow(System.Drawing.Color.Empty, 0, 0, 0);
            this.supperPanel1.CustomStyle = "SupperPanelSkin";
            this.supperPanel1.DisplayMode = Bronze.Controls.VWG.DisplayMode.Normal;
            this.supperPanel1.LinearGradient = null;
            this.supperPanel1.Location = new System.Drawing.Point(205, 66);
            this.supperPanel1.Name = "supperPanel1";
            this.supperPanel1.Opacity = 100;
            this.supperPanel1.Radius = new Gizmox.WebGUI.Forms.CornerRadius(5);
            this.supperPanel1.Size = new System.Drawing.Size(200, 100);
            this.supperPanel1.TabIndex = 1;
            // 
            // testFuck
            // 
            this.Controls.Add(this.supperPanel1);
            this.Controls.Add(this.jrtLabel1);
            this.Size = new System.Drawing.Size(419, 466);
            this.Text = "testFuck";
            this.ResumeLayout(false);

        }

        #endregion

        private VWG.JrtLabel jrtLabel1;
        private VWG.SupperPanel supperPanel1;


    }
}