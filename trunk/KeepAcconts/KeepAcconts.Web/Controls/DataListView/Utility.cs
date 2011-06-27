using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;


namespace Bronze.WebGuiCommonLib
{
    public class Utility
    {
     

        public static object ChangeType(object value, Type conversionType)
        {
            if (conversionType == null)
            {
                throw new ArgumentNullException("conversionType");
            }

            if (conversionType.IsGenericType &&
              conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                {
                    return null;
                }
                NullableConverter nullableConverter = new NullableConverter(conversionType);
                conversionType = nullableConverter.UnderlyingType;
            }
            if (value is string && conversionType == typeof(Guid))
            {
                return new Guid(value.ToString());
            }
            return Convert.ChangeType(value, conversionType);
        }

        /// <summary>
        /// 通过文本测量宽度
        /// </summary>
        /// <param name="text">文本内容</param>
        /// <param name="font">字体</param>
        /// <returns></returns>
        public static float GetWidthByText(string text, Font font)
        {
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            g.PageUnit = GraphicsUnit.Pixel;

            SizeF stringSize = new SizeF();
            stringSize = g.MeasureString(text, font);
            return stringSize.Width;
        }

        /// <summary>
        /// 通过宽度测量文本高度
        /// </summary>
        /// <param name="text">文本</param>
        /// <param name="Textwidth">文本高度</param>
        /// <returns></returns>
        public static float GetHeightByText(string text, int textWidth, Font font)
        {
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            g.PageUnit = GraphicsUnit.Pixel;
            StringFormat stringFormat = new StringFormat();
            stringFormat.FormatFlags = StringFormatFlags.LineLimit;

            SizeF stringSize = new SizeF();
            stringSize = g.MeasureString(text, font, textWidth, stringFormat);
            return stringSize.Height;
        }
    }
}
