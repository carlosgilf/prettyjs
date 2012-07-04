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
            string show = string.Format(
            @"
var obj=$(Web_GetElementByDataId('{0}'));

obj.parent().parent().parent().css('z-index', '900');
var delayTimer=obj.attr('delayTimer');
window.clearInterval(delayTimer);
if(obj.attr('showed')!='1'){{
    obj.attr('showed',1);
    obj.find('.HoverPanelHidden').removeClass('HoverPanelHidden');
    obj.slideDown(500);
}}
            ", this.hoverPopup.ID);

            string hide = string.Format(@"
var obj=$(Web_GetElementByDataId('{0}'));
var delayTimer=obj.attr('delayTimer');
window.clearInterval(delayTimer);

delayTimer= setInterval(function(){{
    window.clearInterval(delayTimer);
    obj.slideUp(200,function(){{obj.attr('showed',0)}});
}},100);
obj.attr('delayTimer',delayTimer);
", this.hoverPopup.ID);

            this.hoverBtn.OnClientMouseOver = show;
            this.hoverBtn.OnClientMouseLeave = hide;

            this.hoverPopup.OnClientMouseOver = show;
            this.hoverPopup.OnClientMouseLeave = hide;
        }
    }
}