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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var de=LZStringCompress.Compress("ÄãºÃ°¡£¡£¡£¡this is my code");
            var src = LZStringCompress.Decompress(de);
        }
    }
}