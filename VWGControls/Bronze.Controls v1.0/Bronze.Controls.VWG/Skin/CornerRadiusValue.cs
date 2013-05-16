namespace Bronze.Controls.VWG
{
    using Gizmox.WebGUI.Common.Interfaces;
    using Gizmox.WebGUI.Forms;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using Gizmox.WebGUI.Forms.Skins;

    [Serializable, TypeConverter(typeof(CornerRadiusValueConverter)), EditorBrowsable(EditorBrowsableState.Never)]
    public class CornerRadiusValue : SkinValue
    {
        private static CornerRadiusValue mobjEmpty = new CornerRadiusValue(CornerRadius.Empty);
        private CornerRadius mobjValue;

        public CornerRadiusValue(CornerRadius objValue)
        {
            this.mobjValue = objValue;
        }

        public override string GetValue(IContext objContext, SkinValueDefinition objValueDefinition)
        {
            string importantDeclarationValue = objValueDefinition.GetImportantDeclarationValue(objContext);
            if (this.mobjValue.All>0)
            {
                return string.Format("{0}:{1}px{2}", this.GetWebStyleName(), this.mobjValue.All, importantDeclarationValue);
            }
            return string.Format("{0}:{1}px {2}px {3}px {4}px{5}", new object[] { this.GetWebStyleName(), this.mobjValue.TopLeft, this.mobjValue.TopRight, this.mobjValue.BottomRight, this.mobjValue.BottomLeft, importantDeclarationValue });
        }

        protected virtual string GetWebStyleName()
        {
            return "border-radius";
        }

        public string GetStyle()
        {
            string style =string.Empty;
            if (this.mobjValue.All > 0)
            {
                style= string.Format("{0}:{1}px;", this.GetWebStyleName(), this.mobjValue.All);
            }
            style= string.Format("{0}:{1}px {2}px {3}px {4}px;", new object[] { this.GetWebStyleName(), this.mobjValue.TopLeft, this.mobjValue.TopRight, this.mobjValue.BottomRight, this.mobjValue.BottomLeft });

            return string.Concat(style, "-webkit-" + style, "-moz-" + style);
        }
        

        public static implicit operator CornerRadiusValue(CornerRadius objRadius)
        {
            return new CornerRadiusValue(objRadius);
        }

        public static implicit operator CornerRadius(CornerRadiusValue objRadiusValue)
        {
            if (objRadiusValue == null)
            {
                return CornerRadius.Empty;
            }
            return objRadiusValue.Value;
        }

        public static implicit operator string(CornerRadiusValue objRadiusValue)
        {
            if (objRadiusValue.Value.All>0)
            {
                return objRadiusValue.All.ToString();
            }
            return string.Format("{0},{1},{2},{3}", new object[] { objRadiusValue.TopLeft, objRadiusValue.TopRight, objRadiusValue.BottomRight, objRadiusValue.BottomLeft });
        }

        public static implicit operator CornerRadiusValue(string strRadius)
        {
            CornerRadius empty = CornerRadius.Empty;
            if (!string.IsNullOrEmpty(strRadius))
            {
                string[] strArray = strRadius.Split(new char[] { ',' });
                if (strArray.Length == 4)
                {
                    empty = new CornerRadius(int.Parse(strArray[0]), int.Parse(strArray[1]), int.Parse(strArray[2]), int.Parse(strArray[3]));
                }
                else if (strArray.Length == 1)
                {
                    empty = new CornerRadius(int.Parse(strArray[0]));
                }
            }
            return new CornerRadiusValue(empty);
        }

        public override string ToString()
        {
            return this.mobjValue.ToString();
        }

        [RefreshProperties(RefreshProperties.All)]
        public int All
        {
            get
            {
                return this.mobjValue.All;
            }
            set
            {
                this.mobjValue.All = value;
            }
        }

        [RefreshProperties(RefreshProperties.All)]
        public int BottomLeft
        {
            get
            {
                return this.mobjValue.BottomLeft;
            }
            set
            {
                this.mobjValue.BottomLeft = value;
            }
        }

        public static CornerRadiusValue Empty
        {
            get
            {
                return mobjEmpty;
            }
        }

        //[Browsable(false)]
        //public int Horizontal
        //{
        //    get
        //    {
        //        return this.mobjValue.Horizontal;
        //    }
        //}

        [RefreshProperties(RefreshProperties.All)]
        public int TopLeft
        {
            get
            {
                return this.mobjValue.TopLeft;
            }
            set
            {
                this.mobjValue.TopLeft = value;
            }
        }

        [RefreshProperties(RefreshProperties.All)]
        public int BottomRight
        {
            get
            {
                return this.mobjValue.BottomRight;
            }
            set
            {
                this.mobjValue.BottomRight = value;
            }
        }

        //[Browsable(false)]
        //public System.Drawing.Size Size
        //{
        //    get
        //    {
        //        return this.mobjValue.Size;
        //    }
        //}

        [RefreshProperties(RefreshProperties.All)]
        public int TopRight
        {
            get
            {
                return this.mobjValue.TopRight;
            }
            set
            {
                this.mobjValue.TopRight = value;
            }
        }

        [Browsable(false)]
        public CornerRadius Value
        {
            get
            {
                return this.mobjValue;
            }
        }

        //[Browsable(false)]
        //public int Vertical
        //{
        //    get
        //    {
        //        return this.mobjValue.Vertical;
        //    }
        //}
    }
}
