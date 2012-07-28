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
            this.button1 = new Gizmox.WebGUI.Forms.Button();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.listBox1 = new Gizmox.WebGUI.Forms.ListBox();
            this.dateTimePicker1 = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.ItemHome.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ItemDateTime
            // 
            this.ItemDateTime.Location = new System.Drawing.Point(225, 17);
            this.ItemDateTime.Name = "ItemDateTime";
            this.ItemDateTime.SelectionEnd = new System.DateTime(2012, 7, 7, 0, 0, 0, 0);
            this.ItemDateTime.SelectionRange = new Gizmox.WebGUI.Forms.SelectionRange(new System.DateTime(2012, 7, 7, 0, 0, 0, 0), new System.DateTime(2012, 7, 7, 0, 0, 0, 0));
            this.ItemDateTime.SelectionStart = new System.DateTime(2012, 7, 7, 0, 0, 0, 0);
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
            this.ItemHome.Controls.Add(this.button1);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(85, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Silver);
            this.panel1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Location = new System.Drawing.Point(501, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 187);
            this.panel1.TabIndex = 8;
            // 
            // listBox1
            // 
            this.listBox1.Location = new System.Drawing.Point(13, 47);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = Gizmox.WebGUI.Forms.SelectionMode.One;
            this.listBox1.Size = new System.Drawing.Size(152, 121);
            this.listBox1.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dateTimePicker1.CustomFormat = "";
            this.dateTimePicker1.Location = new System.Drawing.Point(13, 15);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(152, 21);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // MenuItemCreator
            // 
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ItemHome);
            this.Controls.Add(this.ItemDateTime);
            this.Size = new System.Drawing.Size(771, 446);
            this.Text = "MenuItemCreator";
            this.ItemHome.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox textBox5;
        private TextBox textBox6;
        private Label label3;
        private Label label4;
        internal MonthCalendar ItemDateTime;
        internal GroupBox ItemHome;
        internal Panel panel1;
        private ListBox listBox1;
        private DateTimePicker dateTimePicker1;
        private Button button1;


    }
}