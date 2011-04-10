#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using KeepAcconts.Web.UI;

#endregion

namespace KeepAcconts.Web
{
    public partial class MainAppleUI : Form
    {
        public MainAppleUI()
        {
            InitializeComponent();
            for (int i = 0; i < 5; i++)
            {
                var navBtn = new NavItemButton();
                navBtn.Text = "TestNav" + i;
                this.navBar.Items.Add(navBtn);
            }
        }

        private void MainAppleUI_Load(object sender, EventArgs e)
        {
            
            
        }
    }
}