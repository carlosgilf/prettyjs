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

namespace KeepAcconts.Web.UI
{
    [Serializable]
    public partial class NavBar : UserControl
    {
        public NavBar()
        {
            InitializeComponent();
            _items = new NavBarItemCollection(this);
        }


        private NavBarItemCollection _items = null;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public NavBarItemCollection Items 
        { get { return _items; }
        }



        private void NavBar_Load(object sender, EventArgs e)
        {
            //ToolBarItemCollection
            if (this.DesignMode)
            {
                return;
            }
            foreach (NavItemButton item in Items)
            {
                item.ItemClick += new EventHandler(item_Click);
                item.Dock = DockStyle.Top;
                this.Controls.Insert(0,item);
            }
        }

        void item_Click(object sender, EventArgs e)
        {
            var btn = sender as NavItemButton;
            foreach (NavItemButton item in Items)
            {
                if (item == btn)
                {
                    item.Selected = true;
                }
                else
                {
                    item.Selected = false;
                }
            }
        }
    }
}