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
            // SelectorTextBoxFrm
            // 
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.selectorTextBox1);
            this.Size = new System.Drawing.Size(692, 466);
            this.Text = "SelectorTextBoxFrm";
            this.Load += new System.EventHandler(this.SelectorTextBoxFrm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private VWG.SelectorTextBox selectorTextBox1;
        private Button button1;
        private Button button2;
        private Button button3;






    }
}