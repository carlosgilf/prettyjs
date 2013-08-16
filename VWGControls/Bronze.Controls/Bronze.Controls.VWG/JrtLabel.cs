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
        ResourceHandle _overBackgroundImage;

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

        private int imgWidth;
        [System.ComponentModel.DefaultValue(0)]
        public int ImageWidth
        {
            get { return imgWidth; }
            set { imgWidth = value; }
        }

        private int imgHeight;
        [System.ComponentModel.DefaultValue(0)]
        public int ImageHeight
        {
            get { return imgHeight; }
            set { imgHeight = value; }
        }


        /// <summary>
        /// Gets or sets the background image displayed in the control.
        /// </summary>
        /// <value></value>




        [System.ComponentModel.DefaultValue(null)]
        [Category("CatAppearance")]
        [System.ComponentModel.Localizable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
        public override ResourceHandle BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
                base.BackgroundImage = value;
            }
        }

        /// <summary>
        /// Gets or sets the background image layout as defined in the <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> enumeration.
        /// </summary>
        /// <value></value>
        /// <returns>One of the values of <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> (<see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Center"></see> , <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.None"></see>, <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Stretch"></see>, <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Tile"></see>, or <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Zoom"></see>). <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Tile"></see> is the default value.</returns>

        [System.ComponentModel.DefaultValue(null)]
        [Category("CatAppearance")]
        [System.ComponentModel.Localizable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), EditorBrowsable(EditorBrowsableState.Always), Browsable(true)]
        public override ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }
            set
            {
                base.BackgroundImageLayout = value;
            }
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
        [Description("Sets the background image to be used when the cursor enters the label")]
        public ResourceHandle HoverBackgroundImage
        {
            get { return _overBackgroundImage; }
            set { _overBackgroundImage = value; }
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

        private ArrowPosition imagePostionOfText = ArrowPosition.None;

        [DefaultValue(ArrowPosition.None)]
        public ArrowPosition ImagePostionOfText
        {
            get { return imagePostionOfText; }
            set { imagePostionOfText = value; }
        }

        private int labelSpaceWidth = 3;

        /// <summary>
        /// 图片和文本的间隔
        /// </summary>
        [DefaultValue(3)]
        [Description("图片和文本的间隔")]
        public int ImageLabelSpace
        {
            get { return labelSpaceWidth; }
            set { labelSpaceWidth = value; }
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
            objWriter.WriteAttributeString("Overable", this._overable ? "1" : "0");

            if (this.ImagePostionOfText != ArrowPosition.None)
            {
                objWriter.WriteAttributeString("ImgPS", this.ImagePostionOfText.ToString());
            }
            objWriter.WriteAttributeString("ImgSpace", this.ImageLabelSpace);


            if (_overBackgroundImage != null)
            {
                objWriter.WriteAttributeString("HoverBgImg", this._overBackgroundImage.ToString());
            }
            else
            {
                objWriter.WriteAttributeString("HoverBgImg", "");
            }
            if (ImageWidth>0)
            {
                objWriter.WriteAttributeString(WGAttributes.ImageWidth, ImageWidth);
            }
            if (ImageHeight > 0)
            {
                objWriter.WriteAttributeString(WGAttributes.ImageHeight, ImageHeight);
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

        /// <summary>
        /// 颜色反转
        /// </summary>
        /// <param name="ColorToInvert"></param>
        /// <returns></returns>
        Color InvertColor(Color ColorToInvert)
        {

            return Color.FromArgb((byte)~ColorToInvert.R, (byte)~ColorToInvert.G, (byte)~ColorToInvert.B);
        }

    }


}
