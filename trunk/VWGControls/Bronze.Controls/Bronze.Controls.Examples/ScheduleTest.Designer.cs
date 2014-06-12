using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Bronze.Controls.Examples
{
    partial class ScheduleTest
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
            this.comboBox1 = new Gizmox.WebGUI.Forms.ComboBox();
            this.scheduleBox1 = new Bronze.Controls.VWG.ScheduleBoxEx();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(9, 9);
            this.comboBox1.MaxDropDownItems = 8;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // scheduleBox1
            // 
            this.scheduleBox1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Left) 
            | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.scheduleBox1.DisplayMonthHeader = false;
            this.scheduleBox1.FirstDate = new System.DateTime(2014, 6, 10, 17, 8, 56, 784);
            this.scheduleBox1.FirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Monday;
            this.scheduleBox1.HourFormat = Gizmox.WebGUI.Forms.ScheduleBoxHourFormat.Clock12H;
            this.scheduleBox1.Location = new System.Drawing.Point(9, 55);
            this.scheduleBox1.Name = "scheduleBox1";
            this.scheduleBox1.Size = new System.Drawing.Size(757, 573);
            this.scheduleBox1.TabIndex = 1;
            this.scheduleBox1.View = Gizmox.WebGUI.Forms.ScheduleBoxView.Week;
            this.scheduleBox1.WorkEndHour = 17;
            this.scheduleBox1.WorkStartHour = 9;
            // 
            // ScheduleTest
            // 
            this.Controls.Add(this.scheduleBox1);
            this.Controls.Add(this.comboBox1);
            this.Size = new System.Drawing.Size(799, 637);
            this.Text = "ScheduleTest";
            this.Load += new System.EventHandler(this.ScheduleTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox comboBox1;
        private VWG.ScheduleBoxEx scheduleBox1;


    }
}