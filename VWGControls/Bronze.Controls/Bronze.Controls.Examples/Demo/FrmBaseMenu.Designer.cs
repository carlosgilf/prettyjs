using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Bronze.Controls.Examples.SimpleMenu
{
    partial class FrmBaseMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBaseMenu));
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panelBar = new Gizmox.WebGUI.Forms.Panel();
            this.buttonLayout = new Gizmox.WebGUI.Forms.Panel();
            this.textBox5 = new Gizmox.WebGUI.Forms.TextBox();
            this.textBox6 = new Gizmox.WebGUI.Forms.TextBox();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.monthCalendar1 = new Gizmox.WebGUI.Forms.MonthCalendar();
            this.panelBar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("panel2.BackgroundImage"));
            this.panel2.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Center;
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(741, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(7, 52);
            this.panel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("panel1.BackgroundImage"));
            this.panel1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Center;
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(9, 52);
            this.panel1.TabIndex = 0;
            // 
            // panelBar
            // 
            this.panelBar.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.panelBar.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("panelBar.BackgroundImage"));
            this.panelBar.Controls.Add(this.buttonLayout);
            this.panelBar.Controls.Add(this.panel2);
            this.panelBar.Controls.Add(this.panel1);
            this.panelBar.Location = new System.Drawing.Point(9, 67);
            this.panelBar.Name = "panelBar";
            this.panelBar.Size = new System.Drawing.Size(748, 50);
            this.panelBar.TabIndex = 0;
            // 
            // buttonLayout
            // 
            this.buttonLayout.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.buttonLayout.DockPadding.Left = 15;
            this.buttonLayout.DockPadding.Top = 4;
            this.buttonLayout.Location = new System.Drawing.Point(9, 0);
            this.buttonLayout.Name = "buttonLayout";
            this.buttonLayout.Padding = new Gizmox.WebGUI.Forms.Padding(15, 4, 0, 0);
            this.buttonLayout.Size = new System.Drawing.Size(732, 50);
            this.buttonLayout.TabIndex = 1;
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
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(96, 230);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 161);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(404, 211);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.Size = new System.Drawing.Size(220, 180);
            this.monthCalendar1.TabIndex = 7;
            this.monthCalendar1.Value = new System.DateTime(2012, 7, 7, 0, 0, 0, 0);
            // 
            // FrmBaseMenu
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelBar);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(766, 466);
            this.Text = "FrmBaseMenu";
            this.Load += new System.EventHandler(this.FrmBaseMenu_Load);
            this.panelBar.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel2;
        private Panel panel1;
        private Panel panelBar;
        private Panel buttonLayout;
        private TextBox textBox5;
        private TextBox textBox6;
        private Label label3;
        private Label label4;
        private GroupBox groupBox1;
        private MonthCalendar monthCalendar1;


    }
}