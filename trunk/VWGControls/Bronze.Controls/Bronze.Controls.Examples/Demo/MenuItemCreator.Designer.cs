using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Bronze.Controls.Examples
{
    partial class MenuItemCreator
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
            this.ItemDateTime = new Gizmox.WebGUI.Forms.MonthCalendar();
            this.textBox5 = new Gizmox.WebGUI.Forms.TextBox();
            this.textBox6 = new Gizmox.WebGUI.Forms.TextBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.ItemHome = new Gizmox.WebGUI.Forms.GroupBox();
            this.ItemHome.SuspendLayout();
            this.SuspendLayout();
            // 
            // ItemDateTime
            // 
            this.ItemDateTime.Location = new System.Drawing.Point(225, 17);
            this.ItemDateTime.Name = "ItemDateTime";
            this.ItemDateTime.Size = new System.Drawing.Size(220, 180);
            this.ItemDateTime.TabIndex = 7;
            this.ItemDateTime.Value = new System.DateTime(2012, 7, 7, 0, 0, 0, 0);
            this.ItemDateTime.DateChanged += new System.EventHandler(this.ItemDateTime_DateChanged);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(56, 69);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 21);
            this.textBox5.TabIndex = 3;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(53, 38);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 21);
            this.textBox6.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "label1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "label2";
            // 
            // ItemHome
            // 
            this.ItemHome.BackColor = System.Drawing.Color.White;
            this.ItemHome.Controls.Add(this.textBox5);
            this.ItemHome.Controls.Add(this.textBox6);
            this.ItemHome.Controls.Add(this.label3);
            this.ItemHome.Controls.Add(this.label4);
            this.ItemHome.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.ItemHome.Location = new System.Drawing.Point(13, 17);
            this.ItemHome.Name = "ItemHome";
            this.ItemHome.Size = new System.Drawing.Size(200, 161);
            this.ItemHome.TabIndex = 6;
            this.ItemHome.TabStop = false;
            // 
            // MenuItemCreator
            // 
            this.Controls.Add(this.ItemHome);
            this.Controls.Add(this.ItemDateTime);
            this.Size = new System.Drawing.Size(549, 446);
            this.Text = "MenuItemCreator";
            this.ItemHome.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox textBox5;
        private TextBox textBox6;
        private Label label3;
        private Label label4;
        internal MonthCalendar ItemDateTime;
        internal GroupBox ItemHome;


    }
}