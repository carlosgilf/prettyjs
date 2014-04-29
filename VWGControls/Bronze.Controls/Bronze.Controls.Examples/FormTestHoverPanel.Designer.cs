using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Bronze.Controls.Examples
{
    partial class FormTestHoverPanel
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
            this.hoverPanel1 = new Bronze.Controls.VWG.SupperHoverPanel();
            this.button1 = new Gizmox.WebGUI.Forms.Button();
            this.textBox1 = new Gizmox.WebGUI.Forms.TextBox();
            this.jrtLabel1 = new Bronze.Controls.VWG.JrtLabel();
            this.SuspendLayout();
            // 
            // hoverPanel1
            // 
            this.hoverPanel1.ArrowStart = ((uint)(10u));
            this.hoverPanel1.BackColor = System.Drawing.Color.Maroon;
            this.hoverPanel1.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Navy);
            this.hoverPanel1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.hoverPanel1.BoxShadow = new Bronze.Controls.VWG.BoxShadow(System.Drawing.Color.Empty, 0, 0, 0);
            this.hoverPanel1.CustomStyle = "SupperHoverPanelSkin";
            this.hoverPanel1.DisplayMode = Bronze.Controls.VWG.DisplayMode.Normal;
            this.hoverPanel1.LinearGradient = null;
            this.hoverPanel1.Location = new System.Drawing.Point(9, 9);
            this.hoverPanel1.Name = "hoverPanel1";
            this.hoverPanel1.OnClientMouseLeave = null;
            this.hoverPanel1.OnClientMouseOver = null;
            this.hoverPanel1.Opacity = 100;
            this.hoverPanel1.Overable = true;
            this.hoverPanel1.Radius = new Gizmox.WebGUI.Forms.CornerRadius(12);
            this.hoverPanel1.RenderRunClientMouseLeave = false;
            this.hoverPanel1.Size = new System.Drawing.Size(200, 255);
            this.hoverPanel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(527, 484);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(226, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(506, 417);
            this.textBox1.TabIndex = 2;
            // 
            // jrtLabel1
            // 
            this.jrtLabel1.AutoEllipsis = false;
            this.jrtLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.jrtLabel1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.jrtLabel1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.jrtLabel1.CustomStyle = "JrtLabelSkin";
            this.jrtLabel1.HoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.jrtLabel1.HoverFont = new System.Drawing.Font("Tahoma", 8.25F);
            this.jrtLabel1.HoverForeColor = System.Drawing.Color.Black;
            this.jrtLabel1.HoverLinearGradient = null;
            this.jrtLabel1.LinearGradient = null;
            this.jrtLabel1.Location = new System.Drawing.Point(55, 412);
            this.jrtLabel1.Name = "jrtLabel1";
            this.jrtLabel1.OnClientMouseLeave = null;
            this.jrtLabel1.OnClientMouseOver = "alert(1);";
            this.jrtLabel1.Overable = true;
            this.jrtLabel1.Radius = new Gizmox.WebGUI.Forms.CornerRadius(5);
            this.jrtLabel1.RenderRunClientMouseLeave = false;
            this.jrtLabel1.Size = new System.Drawing.Size(100, 53);
            this.jrtLabel1.TabIndex = 3;
            this.jrtLabel1.Text = "jrtLabel1";
            this.jrtLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormTestHoverPanel
            // 
            this.Controls.Add(this.jrtLabel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.hoverPanel1);
            this.Size = new System.Drawing.Size(744, 654);
            this.Text = "FormTestHoverPanel";
            this.ResumeLayout(false);

        }

        #endregion

        private VWG.SupperHoverPanel hoverPanel1;
        private Button button1;
        private TextBox textBox1;
        private VWG.JrtLabel jrtLabel1;


    }
}