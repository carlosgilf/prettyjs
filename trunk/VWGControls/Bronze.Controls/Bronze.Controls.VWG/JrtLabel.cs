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
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Serialization;
using System.Globalization;

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
        private static SerializableProperty RadiusProperty = SerializableProperty.Register("Radius", typeof(CornerRadius), typeof(JrtLabel), new SerializablePropertyMetadata());

        private static SerializableProperty HoverFontProperty = SerializableProperty.Register("HoverFont", typeof(Font), typeof(JrtLabel), typeof(SerializableFont), new SerializablePropertyMetadata());
        private static SerializableProperty HoverForeColorProperty = SerializableProperty.Register("HoverForeColor", typeof(Color), typeof(JrtLabel), new SerializablePropertyMetadata());
        private static SerializableProperty HoverBackColorProperty = SerializableProperty.Register("HoverBackColor", typeof(Color), typeof(JrtLabel), new SerializablePropertyMetadata());
        ResourceHandle _overImage;

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


        [Browsable(false)]
        public LinearGradient LinearGradient
        {
            get;
            set;
        }


        [Category("Hover")]
        [Browsable(false)]
        public LinearGradient HoverLinearGradient
        {
            get;
            set;
        }


        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <value></value>
        [Category("Hover")]
        public virtual Font HoverFont
        {
            get
            {
                return this.GetValue<Font>(HoverFontProperty, this.DefaultControlFont);
            }
            set
            {
                // Set the current font value and if value cahnged raise events and update control
                if (this.SetValue<Font>(HoverFontProperty, value, this.DefaultControlFont))
                {
                    // Update control
                    this.Update();
                }
            }
        }

        [Category("Hover")]
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Localizable(true)]
        [Description("Sets the image to be used when the cursor enters the label")]
        public ResourceHandle HoverImage
        {
            get { return _overImage; }
            set { _overImage = value; }
        }

        [Category("Hover")]
        public virtual Color HoverForeColor
        {
            get
            {
                // Return backcolor
                return this.GetValue<Color>(HoverForeColorProperty, this.DefaultForeColor);
            }
            set
            {
                // Set the fore color and update the control if diffrent
                if (this.SetValue<Color>(HoverForeColorProperty, value, this.DefaultForeColor))
                {
                    // Update the control
                    this.Update();
                }
            }
        }

        [Category("Hover")]
        public virtual Color HoverBackColor
        {
            get
            {
                
                // Return backcolor
                return this.GetValue<Color>(HoverBackColorProperty, this.DefaultBackColor);
            }
            set
            {
                // Set the fore color and update the control if diffrent
                if (this.SetValue<Color>(HoverBackColorProperty, value, this.DefaultBackColor))
                {
                    // Update the control
                    this.Update();
                }
            }
        }


        protected override void RenderAttributes(Gizmox.WebGUI.Common.Interfaces.IContext objContext, Gizmox.WebGUI.Common.Interfaces.IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);
            if (AutoEllipsis)
            {
                objWriter.WriteAttributeString(WGAttributes.AutoEllipsis, AutoEllipsis ? "1" : "0");
            }

            if (Radius != CornerRadius.Empty)
            {
                CornerRadiusValue rd = this.Radius;
                string style = rd.GetStyle();
                objWriter.WriteAttributeString("Radius", style);
            }

            if (this.HoverFont != null)
            {
                objWriter.WriteAttributeString("HoverFont", GetWebFont(this.HoverFont));
            }

            if (_overImage != null)
            {
                objWriter.WriteAttributeString("HoverImage", _overImage.ToString());
            }
            else
            {
                objWriter.WriteAttributeString("HoverImage", "");
            }
            objWriter.WriteAttributeString("HoverFore", ColorTranslator.ToHtml(this.HoverForeColor));
            objWriter.WriteAttributeString("HoverBgColor", ColorTranslator.ToHtml(this.HoverBackColor));

            if (LinearGradient != null)
            {
                objWriter.WriteAttributeString("Linear", LinearGradient.ToString());
            }
            if (HoverLinearGradient != null)
            {
                objWriter.WriteAttributeString("HoverLinear", HoverLinearGradient.ToString());
            }
        }


        public static string GetWebFont(Font objFont)
        {
            string strFont = "";
            if (objFont.Italic) strFont += "italic ";
            else strFont += "normal ";
            strFont += "normal ";
            if (objFont.Bold) strFont += "bold ";
            else strFont += "normal ";
            switch (objFont.Unit)
            {
                case GraphicsUnit.Pixel:
                    strFont += objFont.Size.ToString(CultureInfo.InvariantCulture) + "px ";
                    break;
                case GraphicsUnit.Point:
                    strFont += objFont.Size.ToString(CultureInfo.InvariantCulture) + "pt ";
                    break;
                case GraphicsUnit.Inch:
                    strFont += objFont.Size.ToString(CultureInfo.InvariantCulture) + "in ";
                    break;
                case GraphicsUnit.Millimeter:
                    strFont += objFont.Size.ToString(CultureInfo.InvariantCulture) + "mm ";
                    break;
            }

            strFont += objFont.FontFamily.Name + " ";

            if (objFont.Underline)
            {
                strFont += ";text-decoration:underline";
                if (objFont.Strikeout)
                {
                    strFont += " line-through";
                }
            }
            else if (objFont.Strikeout)
            {
                strFont += ";text-decoration:line-through";
            }
            return strFont;
        }

    }

}
