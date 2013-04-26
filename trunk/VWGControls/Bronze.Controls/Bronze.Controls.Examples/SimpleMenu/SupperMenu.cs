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
    public partial class SupperMenu : UserControl
    {
        public SupperMenu()
        {
            InitializeComponent();
            _items = new List<MenuItemInfo>();
            _menuRelations = new List<MenuRelation>();
        }

        private List<MenuRelation> _menuRelations;

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
            var point = new Point();
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
            var popup = creator.GetPopup(itemInfo.MenuContent);



            btn.Width = itemInfo.Width;
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


            popup.DisplayMode = VWG.DisplayMode.Hidden;
            this.Form.Controls.Add(popup);
            popup.BringToFront();

            string adjustLeftScript = "";// string.Format("$('#VWG_{0}').css('left',$('#VWG_{1}').css('left'));", popup.ID, btn.ID);
            var showHide = Animate.Split(',');
            showAction = adjustLeftScript + string.Format("vwg_showMenu('{0}',300,'{1}');", popup.ID, showHide[0]) + showAction;

            hideAction = string.Format("vwg_hideMenu('{0}',120,'{1}',60);", popup.ID, showHide[1]) + hideAction;
            btn.OnClientMouseOver = showAction;
            btn.OnClientMouseLeave = hideAction;


            popup.OnClientMouseOver = showAction;
            popup.OnClientMouseLeave = hideAction;

            Items.Add(itemInfo);

            var relationItem = new MenuRelation() { Button = btn, Popup = popup };
            this._menuRelations.Add(relationItem);
            //SetPopupLocation(relationItem);

            creator.Dispose();
        }

        private void SupperMenu_Load(object sender, EventArgs e)
        {

        }

        private void SetPopupLocation(MenuRelation menuItem)
        {
            var location = GetRealLocation(this);
            menuItem.Popup.Top = location.Y + this.Height - 1;
            menuItem.Popup.Left = location.X + pLeft.Left + buttonLayout.Left + menuItem.Button.Left;

            //popup和Menu的Anchor属性一致，当调整浏览器大小时重新布局，不影响Popup弹出的位置
            menuItem.Popup.Anchor = this.Anchor;
        }

        public void UpdateMenu()
        {
            if (_menuRelations == null)
            {
                return;
            }
            foreach (var ctl in this._menuRelations)
            {
                ctl.Button.Update();
                ctl.Popup.Update();

                SetPopupLocation(ctl);
            }
        }

        protected override void Render(Gizmox.WebGUI.Common.Interfaces.IContext objContext, Gizmox.WebGUI.Common.Interfaces.IResponseWriter objWriter, long lngRequestID)
        {
            base.Render(objContext, objWriter, lngRequestID);
            UpdateMenu();
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


    [Serializable]
    public class MenuRelation
    {
        public SupperHoverPanel Button;
        public SupperHoverPanel Popup;
    }

}