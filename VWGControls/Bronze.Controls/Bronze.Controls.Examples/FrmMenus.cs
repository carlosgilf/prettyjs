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
    public partial class FrmMenus : Form
    {
        public FrmMenus()
        {
            InitializeComponent();
            this.ucMenu1.SetMenu(this.panel1);
            this.ucMenu2.SetMenu(this.panel2);
            this.ucMenu3.SetMenu(this.panel3);
        }
    }
}