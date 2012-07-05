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

namespace Bronze.Controls.Examples
{
    public partial class UcMenu : UserControl
    {
        

        public UcMenu()
        {
            InitializeComponent();


            this.hoverPopup.Hidden = true;
//            string show = string.Format(
//            @"
//var obj=$(Web_GetElementByDataId('{0}'));
//var delayTimer=obj.attr('delayTimer');
//window.clearInterval(delayTimer);
//if(obj.attr('showed')!='1'){{
//    obj.attr('showed',1);
//    obj.find('.HoverPanelHidden').removeClass('HoverPanelHidden');
//    obj.dropDown(600);
//}}
//            ", this.hoverPopup.ID);

//            string hide = string.Format(@"
//var obj=$(Web_GetElementByDataId('{0}'));
//var delayTimer=obj.attr('delayTimer');
//window.clearInterval(delayTimer);
//delayTimer= setInterval(function(){{
//    window.clearInterval(delayTimer);
//    obj.dropUp();
//}},200);
//obj.attr('delayTimer',delayTimer);
//", this.hoverPopup.ID);

            var show = string.Format("vwg_showMenu('{0}')", this.hoverPopup.ID);
            var hide = string.Format("vwg_hideMenu('{0}',400)", this.hoverPopup.ID);

            this.hoverBtn.OnClientMouseOver = show;
            this.hoverBtn.OnClientMouseLeave = hide;

            this.hoverPopup.OnClientMouseOver = show;
            this.hoverPopup.OnClientMouseLeave = hide;
        }

        public void SetMenu(Control menu)
        {
            if (menu != null)
            {
                this.hoverPopup.Controls.Clear();
                this.hoverPopup.Height = menu.Height;
                this.hoverPopup.Width = menu.Width;
                menu.Dock = DockStyle.Fill;
                hoverPopup.Controls.Add(menu);
                this.Width = hoverPopup.Width;
                this.Height = hoverPopup.Top + hoverPopup.Height;
            }
        }
    }
}