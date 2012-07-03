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
var obj=$('#VWG_{0}');
var delayTimer=obj.attr('delayTimer');
window.clearInterval(delayTimer)
if(obj.attr('showed')!='1'){{
    obj.css('z-index', '900');
    obj.attr('showed',1)
    obj.find('.HoverPanelHidden').removeClass('HoverPanelHidden');
    obj.slideDown(300);
}}
            ", this.hoverPopup.ID);

            string hide = string.Format(@"
var obj=$('#VWG_{0}');
var delayTimer=obj.attr('delayTimer');
window.clearInterval(delayTimer);
delayTimer= setInterval(function(){{
    window.clearInterval(delayTimer);
    obj.css('z-index', '1');
    obj.slideUp(120,function(){{obj.attr('showed',0)}});
}},300);
obj.attr('delayTimer',delayTimer);
", this.hoverPopup.ID);

            this.hoverBtn.OnClientMouseOver = show;
            this.hoverBtn.OnClientMouseLeave = hide;

            this.hoverPopup.OnClientMouseOver = show;
            this.hoverPopup.OnClientMouseLeave = hide;
        }
    }
}