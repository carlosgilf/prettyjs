namespace Bronze.Controls.VWG
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
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.button1 = new Gizmox.WebGUI.Forms.Button();
            this.button2 = new Gizmox.WebGUI.Forms.Button();
            this.txtColor = new Gizmox.WebGUI.Forms.TextBox();
            this.colorDialog1 = new Gizmox.WebGUI.Forms.ColorDialog();
            this.mobjImageProcessor = new Bronze.Controls.VWG.ImageProcessor();
            this.txtOpcail = new Gizmox.WebGUI.Forms.TextBox();
            this.txtAspectRatio = new Gizmox.WebGUI.Forms.TextBox();
            this.比例 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(520, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 360);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "修改参数";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 400);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "获取选区";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(243, 362);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(69, 21);
            this.txtColor.TabIndex = 4;
            this.txtColor.Click += new System.EventHandler(this.txtColor_Click);
            // 
            // mobjImageProcessor
            // 
            this.mobjImageProcessor.BgColor = System.Drawing.Color.Black;
            this.mobjImageProcessor.BgOpacity = 0.6F;
            this.mobjImageProcessor.ImagePath = null;
            this.mobjImageProcessor.Location = new System.Drawing.Point(23, 9);
            this.mobjImageProcessor.Name = "mobjImageProcessor";
            this.mobjImageProcessor.Selection = new System.Drawing.RectangleF(0, 0, 0, 0);
            this.mobjImageProcessor.Size = new System.Drawing.Size(464, 316);
            this.mobjImageProcessor.TabIndex = 0;
            // 
            // txtOpcail
            // 
            this.txtOpcail.Location = new System.Drawing.Point(142, 362);
            this.txtOpcail.Name = "txtOpcail";
            this.txtOpcail.Size = new System.Drawing.Size(53, 21);
            this.txtOpcail.TabIndex = 5;
            this.txtOpcail.Text = "0.6";
            // 
            // txtAspectRatio
            // 
            this.txtAspectRatio.Location = new System.Drawing.Point(361, 362);
            this.txtAspectRatio.Name = "txtAspectRatio";
            this.txtAspectRatio.Size = new System.Drawing.Size(47, 21);
            this.txtAspectRatio.TabIndex = 6;
            this.txtAspectRatio.Text = "0";
            // 
            // 比例
            // 
            this.比例.AutoSize = true;
            this.比例.Location = new System.Drawing.Point(328, 365);
            this.比例.Name = "比例";
            this.比例.Size = new System.Drawing.Size(35, 13);
            this.比例.TabIndex = 7;
            this.比例.Text = "比例";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 366);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "颜色";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 364);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Opacity";
            // 
            // Form1
            // 
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.比例);
            this.Controls.Add(this.txtAspectRatio);
            this.Controls.Add(this.txtOpcail);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mobjImageProcessor);
            this.Size = new System.Drawing.Size(672, 566);
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ImageProcessor mobjImageProcessor;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.Button button1;
        private Gizmox.WebGUI.Forms.Button button2;
        private Gizmox.WebGUI.Forms.TextBox txtColor;
        private Gizmox.WebGUI.Forms.ColorDialog colorDialog1;
        private Gizmox.WebGUI.Forms.TextBox txtOpcail;
        private Gizmox.WebGUI.Forms.TextBox txtAspectRatio;
        private Gizmox.WebGUI.Forms.Label 比例;
        private Gizmox.WebGUI.Forms.Label label2;
        private Gizmox.WebGUI.Forms.Label label3;
    }
}