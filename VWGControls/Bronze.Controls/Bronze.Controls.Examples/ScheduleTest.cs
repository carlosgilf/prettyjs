#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace Bronze.Controls.Examples
{
    public partial class ScheduleTest : Form
    {
        public ScheduleTest()
        {
            InitializeComponent();
            this.scheduleBox1.RowItemClick += new VWG.ScheduleBoxEx.ScheduleBoxRowHandler(scheduleBox1_RowItemClick);
        }

        void scheduleBox1_RowItemClick(object sender, VWG.ScheduleBoxEx.ScheduleBoxRowItemEventArgs e)
        {
            var newEvent = new VWG.ScheduleBoxEvent();
            // Create absolutely new event
            newEvent.Start = e.Time;
            newEvent.End = e.Time.AddMinutes(30);
            newEvent.Subject = "时间" + e.Time;
            newEvent.Tag = "This is a test 时间";
            this.scheduleBox1.Events.Add(newEvent);
            this.scheduleBox1.Show();
        }

        private void ScheduleTest_Load(object sender, EventArgs e)
        {
            this.scheduleBox1.DisplayMonthHeader = true;
            var names=Enum.GetNames(typeof(ScheduleBoxView));
            this.comboBox1.DataSource=names;

            var newEvent = new VWG.ScheduleBoxEvent();
            // Create absolutely new event
            newEvent.Start = DateTime.Now;
            newEvent.End = newEvent.Start.AddHours(1);
            newEvent.Subject = "This is a test Subject";
            newEvent.Tag = "This is a test tag";
            this.scheduleBox1.Events.Add(newEvent);
            this.scheduleBox1.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.scheduleBox1.View = (ScheduleBoxView)Enum.Parse(typeof(ScheduleBoxView), comboBox1.SelectedValue.ToString());
        }
    }
}