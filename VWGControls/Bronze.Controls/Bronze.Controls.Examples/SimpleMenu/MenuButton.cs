#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Bronze.Controls.VWG;
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
            this.lbText.BringToFront();
        }

        private string title="";

        public string Title
        {
            get { return title; }
            set 
            { 
                title = value;
                this.lbText.Text = value;
                this.lbText.Update();
            }
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

        public  HoverPanel GetButton(string text)
        {
            var btn = this.hoverBtn;
            if (text!=null)
            {
                this.lbText.Text = text;
            }
            this.Controls.Remove(btn);
            return btn;
        }

        public string GetButtonScript(bool show)
        {
            return GetControlClientScript(show, this.btnTop, this.btnMain);
        }


        public string GetPopupScript(bool show)
        {
            return GetControlClientScript(show, this.hoverPopup);
        }

        public string GetGroupActionScript(bool show)
        {
            return GetControlClientScript(show, this.btnTop, this.btnMain, this.hoverPopup);
        }

        public string GetControlClientScript(bool show, params Control[] controls)
        {
            string action = show ? "show()" : "hide()";
            var sb = new StringBuilder();
            string template = "$('#VWG_{0}').{1};";
            foreach (var c in controls)
            {
                sb.AppendFormat(template, c.ID, action);
            }
            return sb.ToString();
        }

        public HoverPanel GetPopup(Control menuContent)
        {
            var btn = hoverPopup;
            
            hoverPopup.Height = menuContent.Height + panelPopuBottom.Height;
            hoverPopup.Width = menuContent.Width;
            menuContent.Dock = DockStyle.Fill;
            panelMenuContanier.Controls.Clear();
            panelMenuContanier.Controls.Add(menuContent);
            this.Controls.Remove(btn);
            return btn;
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