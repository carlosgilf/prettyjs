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
using Gizmox.WebGUI.Common.Resources;

#endregion

namespace Bronze.WebGui.Skin
{
    public partial class ListViewTest1 : Form
    {
        public ListViewTest1()
        {
            InitializeComponent();
            this.listViewItem1.Text = GetIcon("bulb_green.png");
            //this.testListView1.Items.Add(
        }

        private string GetIcon(string strName)
        {
            return (new IconResourceHandle(strName)).ToString();
        }

    }
}