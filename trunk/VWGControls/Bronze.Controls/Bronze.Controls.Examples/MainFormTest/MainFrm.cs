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

namespace Bronze.Controls.Examples.MainFormTest
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
            SetHtml();
        }

        private void SetHtml()
        {
            this.htmlTop.Html = "<a>menu1</a><a>menu2</a>";
        }

        
    }
}