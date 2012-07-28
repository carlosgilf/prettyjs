namespace Bronze.Controls.VWG
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.InteropServices;

    [Serializable, StructLayout(LayoutKind.Sequential), TypeConverter(typeof(BoxShadowConverter))]
    public struct BoxShadow
    {
        private bool mblnAll;
        private int mintXOffset;
        private int mintColor;
        private int mintYOffset;
        private int mintBlurSize;
        public static readonly BoxShadow Empty;
        public BoxShadow(int intAll)
        {
            int num;
            this.mblnAll = true;
            this.mintBlurSize = num = intAll;
            this.mintYOffset = num;
            this.mintColor = num;
            this.mintXOffset = num;
        }

        public BoxShadow(int intColor, int intXOffset, int intYOffset, int intBlurSize)
        {
            this.mintXOffset = intXOffset;
            this.mintColor = intColor;
            this.mintYOffset = intYOffset;
            this.mintBlurSize = intBlurSize;
            this.mblnAll = ((this.mintXOffset == this.mintColor) && (this.mintXOffset == this.mintYOffset)) && (this.mintXOffset == this.mintBlurSize);
        }

        [RefreshProperties(RefreshProperties.All)]
        public int All
        {
            get
            {
                if (!this.mblnAll)
                {
                    return -1;
                }
                return this.mintXOffset;
            }
            set
            {
                if (!this.mblnAll || (this.mintXOffset != value))
                {
                    int num;
                    this.mblnAll = true;
                    this.mintBlurSize = num = value;
                    this.mintYOffset = num;
                    this.mintColor = num;
                    this.mintXOffset = num;
                }
            }
        }
        internal bool IsAll
        {
            get
            {
                return this.mblnAll;
            }
        }
        [RefreshProperties(RefreshProperties.All)]
        public int BlurSize
        {
            get
            {
                if (this.mblnAll)
                {
                    return this.mintXOffset;
                }
                return this.mintBlurSize;
            }
            set
            {
                if (this.mblnAll || (this.mintBlurSize != value))
                {
                    this.mblnAll = false;
                    this.mintBlurSize = value;
                }
            }
        }
        [RefreshProperties(RefreshProperties.All)]
        public int Color
        {
            get
            {
                if (this.mblnAll)
                {
                    return this.mintXOffset;
                }
                return this.mintColor;
            }
            set
            {
                if (this.mblnAll || (this.mintColor != value))
                {
                    this.mblnAll = false;
                    this.mintColor = value;
                }
            }
        }
        [RefreshProperties(RefreshProperties.All)]
        public int YOffset
        {
            get
            {
                if (this.mblnAll)
                {
                    return this.mintXOffset;
                }
                return this.mintYOffset;
            }
            set
            {
                if (this.mblnAll || (this.mintYOffset != value))
                {
                    this.mblnAll = false;
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
                if (this.mblnAll || (this.mintXOffset != value))
                {
                    this.mblnAll = false;
                    this.mintXOffset = value;
                }
            }
        }
        [Browsable(false)]
        public int Horizontal
        {
            get
            {
                return (this.Color + this.YOffset);
            }
        }
        [Browsable(false)]
        public int Vertical
        {
            get
            {
                return (this.XOffset + this.BlurSize);
            }
        }
        [Browsable(false)]
        public System.Drawing.Size Size
        {
            get
            {
                return new System.Drawing.Size(this.Horizontal, this.Vertical);
            }
        }
        public static BoxShadow Add(BoxShadow objPadding1, BoxShadow objPadding2)
        {
            return (objPadding1 + objPadding2);
        }

        public static BoxShadow Subtract(BoxShadow objPadding1, BoxShadow objPadding2)
        {
            return (objPadding1 - objPadding2);
        }

        public override bool Equals(object objOther)
        {
            if (objOther is BoxShadow)
            {
                BoxShadow padding = (BoxShadow) objOther;
                if (((padding.mblnAll == this.mblnAll) && (padding.mintXOffset == this.mintXOffset)) && ((padding.mintColor == this.mintColor) && (padding.mintBlurSize == this.mintBlurSize)))
                {
                    return (padding.mintYOffset == this.mintYOffset);
                }
            }
            return false;
        }

        public static BoxShadow operator +(BoxShadow objPadding1, BoxShadow objPadding2)
        {
            return new BoxShadow(objPadding1.Color + objPadding2.Color, objPadding1.XOffset + objPadding2.XOffset, objPadding1.YOffset + objPadding2.YOffset, objPadding1.BlurSize + objPadding2.BlurSize);
        }

        public static BoxShadow operator -(BoxShadow objPadding1, BoxShadow objPadding2)
        {
            return new BoxShadow(objPadding1.Color - objPadding2.Color, objPadding1.XOffset - objPadding2.XOffset, objPadding1.YOffset - objPadding2.YOffset, objPadding1.BlurSize - objPadding2.BlurSize);
        }

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
            return (((this.Color ^RotateLeft(this.XOffset, 8)) ^ RotateLeft(this.YOffset, 0x10)) ^ RotateLeft(this.BlurSize, 0x18));
        }

        public override string ToString()
        {
            return ("{Color=" + this.Color.ToString() + ",XOffset=" + this.XOffset.ToString() + ",YOffset=" + this.YOffset.ToString() + ",BlurSize=" + this.BlurSize.ToString() + "}");
        }

        private void ResetAll()
        {
            this.All = 0;
        }

        private void ResetBlurSize()
        {
            this.BlurSize = 0;
        }

        private void ResetColor()
        {
            this.Color = 0;
        }

        private void ResetYOffset()
        {
            this.YOffset = 0;
        }

        private void ResetXOffset()
        {
            this.XOffset = 0;
        }

        internal void Scale(float fltX, float fltY)
        {
            this.mintXOffset = (int) (this.mintXOffset * fltY);
            this.mintColor = (int) (this.mintColor * fltX);
            this.mintYOffset = (int) (this.mintYOffset * fltX);
            this.mintBlurSize = (int) (this.mintBlurSize * fltY);
        }

        internal bool ShouldSerializeAll()
        {
            return this.mblnAll;
        }

        static BoxShadow()
        {
            Empty = new BoxShadow(0);
        }

        public static int RotateLeft(int intValue, int intNBits)
        {
            intNBits = intNBits % 0x20;
            return ((intValue << intNBits) | (intValue >> (0x20 - intNBits)));
        }
    }
}
