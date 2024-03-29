using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Bronze.Controls.VWG
{
    partial class Form2
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
            this.scheduleBox1 = new Bronze.Controls.VWG.ScheduleBoxEx();
            this.SuspendLayout();
            // 
            // scheduleBox1
            // 
            this.scheduleBox1.DisplayMonthHeader = false;
            this.scheduleBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.scheduleBox1.FirstDate = new System.DateTime(2014, 6, 10, 16, 10, 29, 827);
            this.scheduleBox1.FirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Monday;
            this.scheduleBox1.HourFormat = Gizmox.WebGUI.Forms.ScheduleBoxHourFormat.Clock12H;
            this.scheduleBox1.Location = new System.Drawing.Point(0, 0);
            this.scheduleBox1.Name = "scheduleBox1";
            this.scheduleBox1.Size = new System.Drawing.Size(835, 662);
            this.scheduleBox1.TabIndex = 0;
            this.scheduleBox1.View = Gizmox.WebGUI.Forms.ScheduleBoxView.Week;
            this.scheduleBox1.WorkEndHour = 17;
            this.scheduleBox1.WorkStartHour = 9;
            this.scheduleBox1.EventDoubleClick += new Bronze.Controls.VWG.ScheduleBoxEx.ScheduleBoxEventHandler(this.scheduleBox1_EventDoubleClick);
            // 
            // Form2
            // 
            this.Controls.Add(this.scheduleBox1);
            this.Size = new System.Drawing.Size(835, 662);
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private ScheduleBoxEx scheduleBox1;



    }
}