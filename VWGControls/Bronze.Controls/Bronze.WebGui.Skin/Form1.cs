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

#endregion

namespace Bronze.WebGui.Skin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.SetLoadingMessage("撒旦解放开绿灯撒看见法律监督所");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Thread.Sleep(25 * 1000);

            //button1.SetLoadingMessage("撒旦解放开绿灯撒看见法律监督所");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}