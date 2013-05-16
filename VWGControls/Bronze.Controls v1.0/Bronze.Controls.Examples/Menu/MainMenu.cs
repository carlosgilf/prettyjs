using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bronze.Controls.VWG;
using Bronze.Controls.Examples.SimpleMenu;
using System.Drawing;
using Gizmox.WebGUI.Forms;

namespace Bronze.Controls.Examples.Menu
{
    public class MainMenu : SupperPanel
    {
        public MainMenu()
        {
            InitializeComponent();
            _items = new List<MenuItemInfo>();
            _menuRelations = new List<MenuRelation>();
        }

        private void InitializeComponent()
        {
            this.Height = 40;
            //this.BackColor = ColorTranslator.FromHtml("#a1a1a1");
            this.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle("MenuBlue.bar_bg.gif");
            //this.BoxShadow = new Bronze.Controls.VWG.BoxShadow(Color.Gray, 2, 6, 11);
            //this.BoxShadow = new Bronze.Controls.VWG.BoxShadow(ColorTranslator.FromHtml("#a1a1a1"), 2, 5, 8);
            this.Radius = new Gizmox.WebGUI.Forms.CornerRadius(10);
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

            var creator = new MenuItem();
            var btn = creator.GetButton(itemInfo.ButtonText);
            var popup = creator.GetPopup(itemInfo.MenuContent);


            btn.Width = itemInfo.Width;
            btn.RenderRunClientMouseLeave = true;

            btn.Top = 5;
            if (this.Controls.Count > 0)
            {
                var lastControl = this.Controls[this.Controls.Count - 1];
                var left = lastControl.Left + lastControl.Width + 2;
                btn.Left = left;
            }
            else
            {
                btn.Left = 15;
            }
            this.Controls.Add(btn);

            string showAction = creator.GetButtonScript(true);
            string hideAction = creator.GetButtonScript(false);


            popup.DisplayMode = VWG.DisplayMode.Hidden;
            this.Form.Controls.Add(popup);
            popup.BringToFront();


            var showHide = Animate.Split(',');
            showAction = string.Format("vwg_showMenu('{0}',200,'{1}');", popup.ID, showHide[0]) + showAction;

            hideAction = string.Format("vwg_hideMenu('{0}',200,'{1}',120);", popup.ID, showHide[1]) + hideAction;
            btn.OnClientMouseOver = showAction;
            btn.OnClientMouseLeave = hideAction;


            popup.OnClientMouseOver = showAction;
            popup.OnClientMouseLeave = hideAction;
            popup.RenderRunClientMouseLeave = false;

            Items.Add(itemInfo);

            var relationItem = new MenuRelation() { Button = btn, Popup = popup };
            this._menuRelations.Add(relationItem);
            //SetPopupLocation(relationItem);

            creator.Dispose();
        }






        private void SetPopupLocation(MenuRelation menuItem)
        {
            var location = GetRealLocation(this);
            menuItem.Popup.Top = location.Y + this.Height - 1;
            menuItem.Popup.Left = location.X + menuItem.Button.Left;

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
}