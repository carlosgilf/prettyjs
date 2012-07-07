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
            var popup = hoverPopup;
            
            hoverPopup.Height = menuContent.Height + panelPopuBottom.Height;
            hoverPopup.Width = menuContent.Width;
            menuContent.Dock = DockStyle.Fill;
            panelMenuContanier.Controls.Clear();
            panelMenuContanier.Controls.Add(menuContent);
            this.Controls.Remove(popup);
            return popup;
        }

        

        public void SetClientAction()
        {

            
        }

    }

    public class ComponentSuit
    {
        public string Script { get; set; }
        public HoverPanel Panel { get; set; }
    }
}