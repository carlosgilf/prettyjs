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
using System.Threading;
using System.Web;

#endregion

namespace Bronze.Controls.Examples
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.supperPictureBox1.Radius = new CornerRadius(5);
        }

        protected override void FireEvent(Gizmox.WebGUI.Common.Interfaces.IEvent objEvent)
        {
            if (objEvent.Type == "RunServerMethod")
            {
                var paramters = objEvent["params"];

                MessageBox.Show(paramters);
            }
            base.FireEvent(objEvent);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread.Sleep(10*1000);
            MessageBox.Show("show me:"+DateTime.Now.ToLongTimeString());
            this.textBox2.Text = "i changed the text";
            //this.Context.Terminate(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = "ddd";
        }
    }
}