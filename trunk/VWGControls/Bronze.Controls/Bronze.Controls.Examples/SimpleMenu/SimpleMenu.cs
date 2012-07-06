#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace Bronze.Controls.Examples.SimpleMenu
{
    public partial class SimpleMenu : UserControl
    {
        public SimpleMenu()
        {
            InitializeComponent();
            
        }

        private void SimpleMenu_Load(object sender, EventArgs e)
        {
            this.menuButton4.SetMenu(this.groupBox1);
            this.menuButton1.SetMenu(this.panel3);
        }
    }
}