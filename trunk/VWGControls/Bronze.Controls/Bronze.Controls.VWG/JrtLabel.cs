/*
' Visual WebGui - http://www.visualwebgui.com
' Copyright (c) 2005
' by Gizmox Inc. ( http://www.gizmox.com )
'
' This program is free software; you can redistribute it and/or modify it 
' under the terms of the GNU General Public License as published by the Free 
' Software Foundation; either version 2 of the License, or (at your option) 
' any later version.
'
' THIS PROGRAM IS DISTRIBUTED IN THE HOPE THAT IT WILL BE USEFUL, 
' BUT WITHOUT ANY WARRANTY; WITHOUT EVEN THE IMPLIED WARRANTY OF MERCHANTABILITY 
' OR FITNESS FOR A PARTICULAR PURPOSE. SEE THE GNU GENERAL PUBLIC LICENSE FOR MORE DETAILS.
' YOU SHOULD HAVE RECEIVED A COPY OF THE GNU GENERAL PUBLIC LICENSE ALONG WITH THIS PROGRAM; if not, 
' write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
'
' contact: opensource@visualwebgui.com
*/

#region Using

using System;
using System.Xml;
using System.Drawing;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI;

#endregion Using

namespace Bronze.Controls.VWG
{
    /// <summary>
    /// A Label control
    /// </summary>
    [Skin(typeof(JrtLabelSkin))]
    [Serializable()]
    public class JrtLabel : Label
    {
        public JrtLabel()
        {
            this.CustomStyle = "JrtLabelSkin";
        }

        bool autoEllipsis = false;
        public bool AutoEllipsis
        {
            get
            {
                return autoEllipsis;
            }
            set
            {
                autoEllipsis = value;
                this.Update();
            }
        }

        protected override void RenderAttributes(Gizmox.WebGUI.Common.Interfaces.IContext objContext, Gizmox.WebGUI.Common.Interfaces.IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);
            if (AutoEllipsis)
            {
                objWriter.WriteAttributeString(WGAttributes.AutoEllipsis, AutoEllipsis ? "1" : "0");
            }

            //if (AutoEllipsis)
            //{
            //    this.InvokeScript(string.Format("var $span=$('#VWG_{0} .Common-Unselectable');debugger;$span.wrapEllipsis($('#VWG_{0}').height())", this.ID));
            //}
        }
    }

}
