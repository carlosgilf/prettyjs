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
using Bronze.Controls.VWG.Common;

#endregion

namespace Bronze.Controls.VWG
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();



            var newEvent = new ScheduleBoxEvent();


            // Create absolutely new event
            newEvent = new ScheduleBoxEvent();
            newEvent.Start = DateTime.Now;
            newEvent.End = newEvent.Start.AddHours(1);
            newEvent.Subject = "This is a test Subject";
            newEvent.Tag = "This is a test tag";
            this.scheduleBox1.Events.Add(newEvent);
            this.scheduleBox1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var de=LZStringCompress.Compress("ÄãºÃ°¡£¡£¡£¡this is my code");
            var src = LZStringCompress.Decompress(de);



        }

        private void scheduleBox1_EventDoubleClick(object sender, ScheduleBoxEx.ScheduleBoxEventArgs e)
        {

        }
    }
}