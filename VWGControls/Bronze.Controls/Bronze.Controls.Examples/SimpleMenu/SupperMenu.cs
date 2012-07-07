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
    public partial class SupperMenu : UserControl
    {
        public SupperMenu()
        {
            InitializeComponent();
            _items = new List<MenuItemInfo>();
        }

        private List<MenuItemInfo> _items;

        private string _animate;

        public string Animate
        {
            get { return _animate ?? "dropDown,dropUp"; }
            set
            {
                _animate = value;
            }
        }

        public List<MenuItemInfo> Items
        {
            get { return _items; }
        }

        private Point GetRealLocation(Control c)
        {
            Point point = new Point();
            int top = c.Top;
            int left = c.Left;
            var current = c.Parent;
            while (current != this.Form)
            {
                top += current.Top;
                left += current.Left;
                current = current.Parent;
            }
            return new Point(left, top);
        }


        public void Add(MenuItemInfo itemInfo)
        {

            var creator = new MenuButton();
            var btn = creator.GetButton(itemInfo.ButtonText);
            btn.Width = itemInfo.Width;
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

            var location = GetRealLocation(this);

            string showAction = creator.GetButtonScript(true);
            string hideAction = creator.GetButtonScript(false);

            var popup = creator.GetPopup(itemInfo.MenuContent);
            popup.Hidden = true;
            this.Form.Controls.Add(popup);
            popup.BringToFront();
            popup.Top = location.Y + this.Height-1;
            popup.Left = location.X + pLeft.Left + buttonLayout.Left + btn.Left;

            string adjustLeftScript = "";// string.Format("$('#VWG_{0}').css('left',$('#VWG_{1}').css('left'));", popup.ID, btn.ID);
            var showHide = Animate.Split(',');
            showAction = adjustLeftScript + string.Format("vwg_showMenu('{0}',500,'{1}');", popup.ID, showHide[0]) + showAction;

            hideAction = string.Format("vwg_hideMenu('{0}',250,'{1}',60);", popup.ID, showHide[1]) + hideAction;
            btn.OnClientMouseOver = showAction;
            btn.OnClientMouseLeave = hideAction;

            //this.InvokeScript(string.Format("$('#{0}').css('left',$('#{1}').css('left'))", popup.ID,btn.ID));

            popup.OnClientMouseOver = showAction;
            popup.OnClientMouseLeave = hideAction;
            creator.Dispose();
            Items.Add(itemInfo);
        }

        private void SupperMenu_Load(object sender, EventArgs e)
        {

        }
    }

    [Serializable]
    public class MenuItemInfo
    {
        private string _buttonText;
        private Control _menuContent;

        private int _width = 65;

        public string ButtonText
        {
            get { return _buttonText; }
            set { _buttonText = value; }
        }

        public Control MenuContent
        {
            get { return _menuContent; }
            set { _menuContent = value; }
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
    }

}