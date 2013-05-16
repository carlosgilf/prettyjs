

namespace Bronze.Controls.VWG
{
    using Gizmox.WebGUI.Common.Interfaces;
    using Gizmox.WebGUI.Forms;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using Gizmox.WebGUI.Forms.Skins;
    using System.Globalization;

    //[Serializable, TypeConverter(typeof(BoxShadowValueConverter)), EditorBrowsable(EditorBrowsableState.Never)]

    [Serializable, EditorBrowsable(EditorBrowsableState.Never)]
    public class BoxShadowValue : SkinValue
    {
        private static BoxShadowValue mobjEmpty = new BoxShadowValue(BoxShadow.Empty);
        private BoxShadow mobjValue;

        public BoxShadowValue(BoxShadow objValue)
        {
            this.mobjValue = objValue;
        }

        public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition)
        {
            string importantDeclarationValue = objValueDefinition.GetImportantDeclarationValue(objContext);
            return string.Format("{0}:{1} {2}px {3}px {4}px{5};", new object[] { this.GetWebStyleName(), 
                ColorTranslator.ToHtml(this.mobjValue.Color), 
                this.mobjValue.XOffset, this.mobjValue.YOffset, this.mobjValue.BlurSize, importantDeclarationValue });
        }

        protected virtual string GetWebStyleName()
        {
            return "box-shadow";
        }

        public string GetStyle()
        {
            string style = string.Empty;
            style = string.Format("{0}:{1} {2}px {3}px {4}px;", new object[] { this.GetWebStyleName(),
                ColorTranslator.ToHtml(this.mobjValue.Color), 
                this.mobjValue.XOffset, this.mobjValue.YOffset, this.mobjValue.BlurSize });
            return string.Concat(style, "-webkit-" + style, "-moz-" + style);
        }


        public static implicit operator BoxShadowValue(BoxShadow objRadius)
        {
            return new BoxShadowValue(objRadius);
        }

        public static implicit operator BoxShadow(BoxShadowValue objRadiusValue)
        {
            if (objRadiusValue == null)
            {
                return BoxShadow.Empty;
            }
            return objRadiusValue.Value;
        }

        public static implicit operator string(BoxShadowValue objRadiusValue)
        {
            var color = GetColorString(objRadiusValue.Color);
            return string.Format("{0},{1},{2}{3,}", new object[] {
               color,
                 objRadiusValue.XOffset, objRadiusValue.YOffset, objRadiusValue.BlurSize });
        }

        public static implicit operator BoxShadowValue(string strRadius)
        {
            BoxShadow empty = BoxShadow.Empty;
            if (!string.IsNullOrEmpty(strRadius))
            {
                string[] strArray = strRadius.Split(new char[] { ',' });
                if (strArray.Length == 4)
                {
                    var color = ConvertColor(strArray[0]);
                    empty = new BoxShadow(color, int.Parse(strArray[1]), int.Parse(strArray[2]), int.Parse(strArray[3]));
                }
            }
            return new BoxShadowValue(empty);
        }

        public override string ToString()
        {
            return this.mobjValue.ToString();
        }

        [RefreshProperties(RefreshProperties.All)]
        public int XOffset
        {
            get
            {
                return this.mobjValue.XOffset;
            }
            set
            {
                this.mobjValue.XOffset = value;
            }
        }

        public static BoxShadowValue Empty
        {
            get
            {
                return mobjEmpty;
            }
        }



        [RefreshProperties(RefreshProperties.All)]
        public int YOffset
        {
            get
            {
                return this.mobjValue.YOffset;
            }
            set
            {
                this.mobjValue.YOffset = value;
            }
        }


        [RefreshProperties(RefreshProperties.All)]
        public Color Color
        {
            get
            {
                return this.mobjValue.Color;
            }
            set
            {
                this.mobjValue.Color = value;
            }
        }


        [RefreshProperties(RefreshProperties.All)]
        public int BlurSize
        {
            get
            {
                return this.mobjValue.BlurSize;
            }
            set
            {
                this.mobjValue.BlurSize = value;
            }
        }

        [Browsable(false)]
        public BoxShadow Value
        {
            get
            {
                return this.mobjValue;
            }
        }

        private static object GetColorString(Color objColor)
        {
            return TypeDescriptor.GetConverter(typeof(Color)).ConvertToString(objColor);
        }

        private static Color ConvertColor(string strColor)
        {
            return (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(strColor);
        }
    }
}
