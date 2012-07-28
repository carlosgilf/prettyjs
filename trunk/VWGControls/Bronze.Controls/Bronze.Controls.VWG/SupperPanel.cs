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

#endregion Using

namespace Bronze.Controls.VWG
{
    /// <summary>
    /// A Panel control
    /// </summary>
    [Skin(typeof(SupperPanelSkin))]
    [Serializable()]
    public class SupperPanel : Panel
    {
        private static SerializableProperty RadiusProperty = SerializableProperty.Register("Radius", typeof(CornerRadius), typeof(SupperPanel), new SerializablePropertyMetadata());

        private static SerializableProperty BoxShadowProperty = SerializableProperty.Register("BoxShadow", typeof(BoxShadow), typeof(SupperPanel), new SerializablePropertyMetadata());


        public SupperPanel()
        {
            this.CustomStyle = "SupperPanelSkin";
        }

        public BoxShadow Padding1
        {
            get;
            set;
        }

        public virtual BoxShadow BoxShadow
        {
            get
            {
                return base.GetValue<BoxShadow>(BoxShadowProperty, this.DefaultBoxShadow);
            }
            set
            {
                if (base.SetValue<BoxShadow>(BoxShadowProperty, value, this.DefaultBoxShadow))
                {
                    this.Update();
                    base.FireObservableItemPropertyChanged("BoxShadow");
                }
            }
        }


        protected virtual BoxShadow DefaultBoxShadow
        {
            get
            {
                return BoxShadow.Empty;
            }
        }

        public virtual CornerRadius Radius
        {
            get
            {
                return base.GetValue<CornerRadius>(RadiusProperty, this.DefaultRadius);
            }
            set
            {
                if (base.SetValue<CornerRadius>(RadiusProperty, value, this.DefaultRadius))
                {
                    this.Update();
                    base.FireObservableItemPropertyChanged("Radius");
                }
            }
        }


        protected virtual CornerRadius DefaultRadius
        {
            get
            {
                return CornerRadius.Empty;
            }
        }

        private DisplayMode displayMode = DisplayMode.Normal;
        public DisplayMode DisplayMode
        {
            get { return displayMode; }
            set
            {
                displayMode = value;
                this.Update();
            }
        }


        protected override void RenderAttributes(Gizmox.WebGUI.Common.Interfaces.IContext objContext, Gizmox.WebGUI.Common.Interfaces.IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);
            if (DisplayMode != VWG.DisplayMode.Normal)
            {
                objWriter.WriteAttributeString("Hidden", (int)DisplayMode);
                if (DisplayMode == VWG.DisplayMode.Hidden)
                {
                    //通过XLST重写只能设置第二层div的样式，所以还需要通过js隐藏最外层的div
                    this.InvokeScript(string.Format("$('#VWG_{0}').css('display','none')", this.ID));
                }
                else if (DisplayMode == VWG.DisplayMode.VisibilityHidden)
                {
                    //通过XLST重写只能设置第二层div的样式，所以还需要通过js隐藏最外层的div
                    this.InvokeScript(string.Format("$('#VWG_{0}').css('visibility','hidden')", this.ID));
                }
            }

            if (Radius != CornerRadius.Empty)
            {
                CornerRadiusValue rd = this.Radius;
                string style = rd.GetStyle();
                objWriter.WriteAttributeString("Radius", style);
            }
        }


    }

    public enum DisplayMode
    {
        Normal = 0,
        Hidden = 1,
        VisibilityHidden = 2
    }

}
