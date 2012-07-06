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

namespace Bronze.Controls.Examples.SimpleMenu
{
    public partial class FrmBaseMenu : Form
    {
        public FrmBaseMenu()
        {
            InitializeComponent();
        }

        private void FrmBaseMenu_Load(object sender, EventArgs e)
        {
            Add("Home", groupBox1);
            Add("Files", this.monthCalendar1);
        }

        private string _animate;

        public string Animate
        {
            get { return _animate ?? "dropDown,dropUp"; }
            set
            {
                _animate = value;
            }
        }


        public void Add(string menuBarText, Control control)
        {
            var creator = new MenuButton();
            var btn = creator.GetButton(menuBarText);
            //btn.Margin = new Padding(0, 0, 5, 0);
            btn.RenderRunClientMouseLeave = true;

            btn.Top = 4;
            if (buttonLayout.Controls.Count > 0)
            {
                var lastControl = buttonLayout.Controls[buttonLayout.Controls.Count - 1];
                var left = lastControl.Left + lastControl.Width + 2;
                btn.Left = left;
            }
            else
            {
                btn.Left = 15;
            }
            buttonLayout.Controls.Add(btn);

            string showAction = creator.GetButtonScript(true);
            string hideAction = creator.GetButtonScript(false);

            //btn.ClientRectangle.Left

            var popup = creator.GetPopup(control);
            popup.Hidden = true;
            this.Form.Controls.Add(popup);
            popup.BringToFront();
            popup.Top = panelBar.Top + panelBar.Height-11;
            popup.Left = panelBar.Left + buttonLayout.Left + btn.Left;

            string adjustLeftScript = string.Format("$('#VWG_{0}').css('left',$('#VWG_{1}').css('left'));", popup.ID, btn.ID);
            var showHide = Animate.Split(',');
            showAction = adjustLeftScript+ string.Format("vwg_showMenu('{0}',500,'{1}');", popup.ID, showHide[0]) + showAction;
         
            hideAction = string.Format("vwg_hideMenu('{0}',250,'{1}',60);", popup.ID, showHide[1]) + hideAction;
            btn.OnClientMouseOver = showAction;
            btn.OnClientMouseLeave = hideAction;

            //this.InvokeScript(string.Format("$('#{0}').css('left',$('#{1}').css('left'))", popup.ID,btn.ID));

            popup.OnClientMouseOver = showAction;
            popup.OnClientMouseLeave = hideAction;
            creator.Dispose();
        }
    }
}