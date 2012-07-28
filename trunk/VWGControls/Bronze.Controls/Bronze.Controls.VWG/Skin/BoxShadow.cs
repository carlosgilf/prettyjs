namespace Bronze.Controls.VWG
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential), TypeConverter(typeof(BoxShadowConverter))]
    public struct BoxShadow
    {
        //private bool mblnAll;
        private int mintXOffset;
        private Color mintColor;
        private int mintYOffset;
        private int mintBlurSize;
        public static readonly BoxShadow Empty;

        public BoxShadow(Color intColor, int intXOffset, int intYOffset, int intBlurSize)
        {
            this.mintXOffset = intXOffset;
            this.mintColor = intColor;
            this.mintYOffset = intYOffset;
            this.mintBlurSize = intBlurSize;
        }


        [RefreshProperties(RefreshProperties.All)]
        public int BlurSize
        {
            get
            {
                return this.mintBlurSize;
            }
            set
            {
                if (
                    (this.mintBlurSize != value))
                {
                    this.mintBlurSize = value;
                }
            }
        }
        [RefreshProperties(RefreshProperties.All)]
        public Color Color
        {
            get
            {
                return this.mintColor;
            }
            set
            {
                if (this.mintColor != value)
                {
                    this.mintColor = value;
                }
            }
        }
        [RefreshProperties(RefreshProperties.All)]
        public int YOffset
        {
            get
            {
                return this.mintYOffset;
            }
            set
            {
                if (this.mintYOffset != value)
                {
                    this.mintYOffset = value;
                }
            }
        }
        [RefreshProperties(RefreshProperties.All)]
        public int XOffset
        {
            get
            {
                return this.mintXOffset;
            }
            set
            {
                if (this.mintXOffset != value)
                {
                    this.mintXOffset = value;
                }
            }
        }


        //public static BoxShadow Add(BoxShadow objPadding1, BoxShadow objPadding2)
        //{
        //    return (objPadding1 + objPadding2);
        //}

        //public static BoxShadow Subtract(BoxShadow objPadding1, BoxShadow objPadding2)
        //{
        //    return (objPadding1 - objPadding2);
        //}

        public override bool Equals(object objOther)
        {
            if (objOther is BoxShadow)
            {
                BoxShadow padding = (BoxShadow) objOther;
                if ((
                    (padding.mintXOffset == this.mintXOffset)) && ((padding.mintColor == this.mintColor) && (padding.mintBlurSize == this.mintBlurSize)))
                {
                    return (padding.mintYOffset == this.mintYOffset);
                }
            }
            return false;
        }

        //public static BoxShadow operator +(BoxShadow objPadding1, BoxShadow objPadding2)
        //{
        //    return new BoxShadow(objPadding1.Color + objPadding2.Color, objPadding1.XOffset + objPadding2.XOffset, objPadding1.YOffset + objPadding2.YOffset, objPadding1.BlurSize + objPadding2.BlurSize);
        //}

        //public static BoxShadow operator -(BoxShadow objPadding1, BoxShadow objPadding2)
        //{
        //    return new BoxShadow(objPadding1.Color - objPadding2.Color, objPadding1.XOffset - objPadding2.XOffset, objPadding1.YOffset - objPadding2.YOffset, objPadding1.BlurSize - objPadding2.BlurSize);
        //}

        public static bool operator ==(BoxShadow objPadding1, BoxShadow objPadding2)
        {
            return ((((objPadding1.Color == objPadding2.Color) && (objPadding1.XOffset == objPadding2.XOffset)) && (objPadding1.YOffset == objPadding2.YOffset)) && (objPadding1.BlurSize == objPadding2.BlurSize));
        }

        public static bool operator !=(BoxShadow objPadding1, BoxShadow objPadding2)
        {
            return !(objPadding1 == objPadding2);
        }

        public override int GetHashCode()
        {
            return (((this.Color.GetHashCode() ^RotateLeft(this.XOffset, 8)) ^ RotateLeft(this.YOffset, 0x10)) ^ RotateLeft(this.BlurSize, 0x18));
        }

        public override string ToString()
        {
            return ("{Color=" + this.Color.ToString() + ",XOffset=" + this.XOffset.ToString() + ",YOffset=" + this.YOffset.ToString() + ",BlurSize=" + this.BlurSize.ToString() + "}");
        }


        private void ResetBlurSize()
        {
            this.BlurSize = 0;
        }

        private void ResetColor()
        {
            this.Color = Color.Empty;
        }

        private void ResetYOffset()
        {
            this.YOffset = 0;
        }

        private void ResetXOffset()
        {
            this.XOffset = 0;
        }

        //internal void Scale(float fltX, float fltY)
        //{
        //    this.mintXOffset = (int) (this.mintXOffset * fltY);
        //    this.mintColor = (int) (this.mintColor * fltX);
        //    this.mintYOffset = (int) (this.mintYOffset * fltX);
        //    this.mintBlurSize = (int) (this.mintBlurSize * fltY);
        //}


        static BoxShadow()
        {
            Empty = new BoxShadow(Color.Empty,0,0,0);
        }

        public static int RotateLeft(int intValue, int intNBits)
        {
            intNBits = intNBits % 0x20;
            return ((intValue << intNBits) | (intValue >> (0x20 - intNBits)));
        }
    }
}
