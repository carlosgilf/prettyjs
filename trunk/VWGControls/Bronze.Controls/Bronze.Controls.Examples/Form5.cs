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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            this.popup.DisplayMode = VWG.DisplayMode.Hidden;


            lbClose.RegisterClientAction(string.Format("$('#VWG_{0}').hide();null;", popup.ID));
        }

     



        private void button1_Click(object sender, EventArgs e)
        {
            var script = string.Format("vwg_showMenu('{0}',{{ duration: 500,showManyTimes:true }},'{1}');", popup.ID, "bubbleUp");
            this.InvokeScript(script);
        }
    }
}