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
    public partial class MenuButton : UserControl
    {
        public MenuButton()
        {
            InitializeComponent();
        }

        private string animate;

        public string Animate
        {
            get { return animate ?? "dropDown,dropUp"; }
            set
            {
                animate = value;
                SetClientAction();
            }
        }

        public void SetMenu(Control menu)
        {
            if (menu != null)
            {
                this.hoverPopup.Height = menu.Height + panelPopuBottom.Height;
                this.hoverPopup.Width = menu.Width;
                menu.Dock = DockStyle.Fill;
                panelMenuContanier.Controls.Clear();
                panelMenuContanier.Controls.Add(menu);
                this.Width = hoverPopup.Width;
                this.Height = hoverPopup.Top + hoverPopup.Height ;
            }
        }

        public void SetClientAction()
        {

            this.hoverPopup.Hidden = true;
            var showHide = Animate.Split(',');
            var show = string.Format("vwg_showMenu('{0}',400,'{1}'); $('#VWG_{2}').show();$('#VWG_{3}').show();", 
                this.hoverPopup.ID, showHide[0],this.btnTop.ID,this.btnMain.ID);
            var hide = string.Format("vwg_hideMenu('{0}',300,'{1}',150);$('#VWG_{2}').hide();$('#VWG_{3}').hide();",
                this.hoverPopup.ID, showHide[1], this.btnTop.ID, this.btnMain.ID);

            this.hoverBtn.OnClientMouseOver = show;
            this.hoverBtn.OnClientMouseLeave = hide;

            this.hoverPopup.OnClientMouseOver = show;
            this.hoverPopup.OnClientMouseLeave = hide;
            this.Update();
        }

    }
}