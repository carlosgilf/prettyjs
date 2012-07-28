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

namespace Bronze.Controls.Examples.Demo
{
    public partial class MainMenuTest : Form
    {
        public MainMenuTest()
        {
            InitializeComponent();
        }

        private void MainMenuTest_Load(object sender, EventArgs e)
        {
           // mainMenu1.Animate = "slideDown,slideUp";
             var creactor = new MenuItemCreator();
            this.mainMenu1.Add(new MenuItemInfo() { ButtonText = "Home", MenuContent = creactor.ItemHome });
            this.mainMenu1.Add(new MenuItemInfo() { ButtonText = "DateTime Control", MenuContent = creactor.ItemDateTime, Width = 120 });
            this.mainMenu1.Add(new MenuItemInfo() { ButtonText = "Data Controls", MenuContent = creactor.panel1, Width = 95 });
            this.mainMenu1.Add(new MenuItemInfo() { ButtonText = "Test1", MenuContent = creactor.supperPanel1, Width = 65 });
        
        }
    }
}