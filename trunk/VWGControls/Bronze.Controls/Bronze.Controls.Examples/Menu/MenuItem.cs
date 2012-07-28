#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Bronze.Controls.VWG;

#endregion

namespace Bronze.Controls.Examples
{
    public partial class MenuItem : UserControl
    {
        public MenuItem()
        {
            InitializeComponent();
            this.btnMain.BringToFront();
            this.lbText.BringToFront();

            //this.hoverPopup.BoxShadow = new Bronze.Controls.VWG.BoxShadow(System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102))))), 5, 5, 6);
        }


        private string title = "";

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

        public HoverPanel GetButton(string text)
        {
            var btn = this.hoverBtn;
            if (text != null)
            {
                this.lbText.Text = text;
            }
            this.Controls.Remove(btn);
            return btn;
        }



        public string GetButtonScript(bool show)
        {
            return GetControlClientScript(show, this.btnMain);
        }



        public string GetControlClientScript(bool show, params Control[] controls)
        {
            //string action = show ? "show()" : "hide()";
            //string template = "$('#VWG_{0}').{1};";
            string action = show ? "visible" : "hidden";
            string template = "$('#VWG_{0}').children('div:first').removeClass('SupperPanel-VHidden');$('#VWG_{0}').css('visibility','{1}');";
            var sb = new StringBuilder();
            foreach (var c in controls)
            {
                sb.AppendFormat(template, c.ID, action);
            }
            return sb.ToString();
        }

        public HoverPanel GetPopup(Control menuContent)
        {
            var popup = hoverPopup;

            hoverPopup.Height = menuContent.Height + hoverPopup.Padding.Size.Height;
            hoverPopup.Width = menuContent.Width + hoverPopup.Padding.Size.Width;
            menuContent.Dock = DockStyle.Fill;
            hoverPopup.Controls.Clear();
            hoverPopup.Controls.Add(menuContent);
            this.Controls.Remove(popup);
            return popup;
        }



        public void SetClientAction()
        {

        }




    }
}