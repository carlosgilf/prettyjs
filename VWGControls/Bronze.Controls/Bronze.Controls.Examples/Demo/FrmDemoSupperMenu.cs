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
using Bronze.Controls.Examples.SimpleMenu;

#endregion

namespace Bronze.Controls.Examples
{
    public partial class FrmDemoSupperMenu : Form
    {
        public FrmDemoSupperMenu()
        {
            InitializeComponent();
        }

        private void FrmDemoSupperMenu_Load(object sender, EventArgs e)
        {
            var creactor = new MenuItemCreator();
            this.supperMenu1.Add(new MenuItemInfo() { ButtonText = "Home", MenuContent = creactor.ItemHome });
            this.supperMenu1.Add(new MenuItemInfo() { ButtonText = "DateTime Control", MenuContent = creactor.ItemDateTime,Width = 120});
            this.supperMenu1.Add(new MenuItemInfo() { ButtonText = "Data Controls", MenuContent = creactor.panel1, Width = 95 });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.supperMenu1.Top += 20;

            this.supperMenu1.Left += 20;

            this.supperMenu1.Update();
        }
    }
}