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

        private void FrmMenus_Load(object sender, EventArgs e)
        {
            var silde = new KeyValuePair<string, string>("slide", "slideDown,slideUp");
            var fading = new KeyValuePair<string, string>("Fading", "fadeIn,fadeOut");
            var drop = new KeyValuePair<string, string>("Drop", "dropDown,dropUp");

            var list = new List<KeyValuePair<string, string>>();
            list.Add(drop);
            list.Add(fading);
            list.Add(silde);

            this.comboBox1.DataSource = list;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var animate = this.comboBox1.SelectedValue.ToString();
            foreach (Control item in this.Controls)
            {
                if (item is UcMenu)
                {
                    ((UcMenu)item).Animate = animate;
                }
                
            }
        }
    }
}