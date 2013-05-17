using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Bronze.Controls.Examples
{
    partial class SelectorTextBoxFrm
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
            this.button2 = new Gizmox.WebGUI.Forms.Button();
            this.button3 = new Gizmox.WebGUI.Forms.Button();
            this.selectorTextBox1 = new Bronze.Controls.VWG.SelectorTextBox();
            this.button4 = new Gizmox.WebGUI.Forms.Button();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.htmlBox1 = new Gizmox.WebGUI.Forms.HtmlBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(106, 260);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(251, 259);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(199, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Add items by clientScript";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(251, 299);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(199, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "remove items by client script";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // selectorTextBox1
            // 
            this.selectorTextBox1.AutoScroll = true;
            this.selectorTextBox1.BackColor = System.Drawing.Color.White;
            this.selectorTextBox1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.selectorTextBox1.CustomStyle = "SelectorTextBoxSkin";
            this.selectorTextBox1.Location = new System.Drawing.Point(9, 21);
            this.selectorTextBox1.Name = "selectorTextBox1";
            this.selectorTextBox1.Size = new System.Drawing.Size(662, 214);
            this.selectorTextBox1.SplitString = ",;";
            this.selectorTextBox1.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(74, 334);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "button4";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(251, 334);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // htmlBox1
            // 
            this.htmlBox1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.htmlBox1.ContentType = "text/html";
            this.htmlBox1.Expires = -1;
            this.htmlBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.htmlBox1.Html = "<div id=\"xxt_smsTips\" class=\"smsTips\">ddddd</div>";
            this.htmlBox1.IsWindowless = true;
            this.htmlBox1.Location = new System.Drawing.Point(121, 437);
            this.htmlBox1.Name = "htmlBox1";
            this.htmlBox1.Size = new System.Drawing.Size(442, 20);
            this.htmlBox1.TabIndex = 28;
            // 
            // SelectorTextBoxFrm
            // 
            this.Controls.Add(this.htmlBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.selectorTextBox1);
            this.Size = new System.Drawing.Size(692, 466);
            this.Text = "SelectorTextBoxFrm";
            this.Load += new System.EventHandler(this.SelectorTextBoxFrm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private VWG.SelectorTextBox selectorTextBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Panel panel1;
        private Label label1;
        private HtmlBox htmlBox1;






    }
}