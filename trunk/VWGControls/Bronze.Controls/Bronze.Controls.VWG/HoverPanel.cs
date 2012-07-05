﻿/*
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
using Gizmox.WebGUI.Common.Resources;

#endregion Using

namespace Bronze.Controls.VWG
{
    /// <summary>
    /// A Panel control
    /// </summary>
    [Skin(typeof(HoverPanelSkin))]
    [Serializable()]
    public class HoverPanel : Panel
    {
        private static SerializableProperty HoverBackColorProperty = SerializableProperty.Register("HoverBackColor", typeof(Color), typeof(HoverPanel), new SerializablePropertyMetadata());

        ResourceHandle _overImage;

        public HoverPanel()
        {
            this.CustomStyle = "HoverPanelSkin";
        }

        private bool _overable = true;
        public bool Overable
        {
            get
            {
                return _overable;
            }
            set
            {
                _overable = value;
                this.Update();
            }
        }

        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Localizable(true)]
        [Description("Sets the image to be used when the cursor enters the label")]
        public ResourceHandle HoverImage
        {
            get { return _overImage; }
            set { _overImage = value; }
        }

        private bool hidden;


        private bool renderRunClientMouseOut = false;


        public virtual Color HoverBackColor
        {
            get
            {
                // Return backcolor
                return this.GetValue<Color>(HoverPanel.HoverBackColorProperty, this.DefaultForeColor);
            }
            set
            {
                // Set the fore color and update the control if diffrent
                if (this.SetValue<Color>(HoverPanel.HoverBackColorProperty, value, this.DefaultForeColor))
                {
                    // Update the control
                    this.Update();
                }
            }
        }

        [Description("鼠标经过的javascript脚本")]
        public string OnClientMouseOver
        {
            get;
            set;
        }

        [Description("鼠标离开时的javascript脚本")]
        public string OnClientMouseLeave
        {
            get;
            set;
        }

        private int radius = 0;
        

        public bool Hidden
        {
            get { return hidden; }
            set { 
                hidden = value;
                this.Update();
            }
        }

        public bool RenderRunClientMouseLeave
        {
            get { return renderRunClientMouseOut; }
            set { renderRunClientMouseOut = value; }
        }

        public int Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        protected override void RenderAttributes(Gizmox.WebGUI.Common.Interfaces.IContext objContext, Gizmox.WebGUI.Common.Interfaces.IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);
            objWriter.WriteAttributeString("Hidden", Hidden ? "1" : "0");
        

            if (_overImage != null)
            {
                objWriter.WriteAttributeString("HoverImage", _overImage.ToString());
            }
            else
            {
                objWriter.WriteAttributeString("HoverImage", "");
            }
            objWriter.WriteAttributeString("HoverColor", ColorTranslator.ToHtml(this.HoverBackColor));
            objWriter.WriteAttributeString("Overable", this._overable ? "1" : "0");
            if (!string.IsNullOrEmpty(OnClientMouseOver))
            {
                objWriter.WriteAttributeString("OverScript", OnClientMouseOver);
            }
            this.InvokeScript(string.Format("HoverPanel_Init('{0}')", this.ID));
            if (!string.IsNullOrEmpty(OnClientMouseLeave))
            {
                objWriter.WriteAttributeString("LeaveScript", OnClientMouseLeave);
                
                if (RenderRunClientMouseLeave)
                {
                    this.InvokeScript(OnClientMouseLeave);
                }
            }

            if (Hidden)
            {
                //通过XLST重写只能设置第二层div的样式，所以还需要通过js隐藏最外层的div
                this.InvokeScript(string.Format("$('#VWG_{0}').hide()", this.ID));
            }

            if (Radius>0)
            {
                objWriter.WriteAttributeString("Radius", "Radius");
            }


        }


    }

}

