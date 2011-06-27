using System;
using System.Collections;
using System.ComponentModel;

namespace Bronze.WebGuiCommonLib
{
    public static class ObjectExtension
    {
        public static object ConvertType(this object value, Type conversionType)
        {
            // Note: This if block was taken from Convert.ChangeType as is, and is needed here since we're
            // checking properties on conversionType below.
            if (conversionType == null)
            {
                throw new ArgumentNullException("conversionType");
            } // end if

            // If it's not a nullable type, just pass through the parameters to Convert.ChangeType

            if (conversionType.IsGenericType &&
              conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                {
                    return null;
                } // end if

                // It's a nullable type, and not null, so that means it can be converted to its underlying type,
                // so overwrite the passed-in conversion type with this underlying type
                NullableConverter nullableConverter = new NullableConverter(conversionType);
                conversionType = nullableConverter.UnderlyingType;
            } // end if
            if (value is string && conversionType == typeof(Guid))
            {
                return new Guid(value.ToString());
            }

            if (conversionType.IsEnum)
            {
                return Enum.Parse(conversionType, value.ToString());
            }

            // Now that we've guaranteed conversionType is something Convert.ChangeType can handle (i.e. not a
            // nullable type), pass the call on to Convert.ChangeType
            return Convert.ChangeType(value, conversionType);
        }

        public static bool IsNull(this object o)
        {
            if (o == null)
            {
                return true;
            }

            if (o is string)
            {
                return string.IsNullOrEmpty((string)o);
            }
            else if (o is Guid || o is Guid?)
            {
                if (o.ToString() == Guid.Empty.ToString())
                {
                    return true;
                }
            }
            return false;

        }

        #region 连接字符串
        /// <summary>
        /// 连接字符串
        /// </summary>
        /// <param name="separator">分隔符</param>
        /// <param name="args">多个字符串</param>
        /// <returns></returns>
        public static string Join(this string separator, params object[] args)
        {
            if (string.IsNullOrEmpty(separator))
            {
                return string.Concat(args);
            }
            else
            {
                string str = "";
                foreach (object o in args)
                {
                    if (o == null)
                    {
                        str += separator;
                    }
                    else
                    {
                        str += separator + o.ToString();
                    }
                }

                if (str != "")
                {
                    str = str.Substring(separator.Length);
                }

                return str;
            }
        }


        /// <summary>
        /// 转换数组对象为用逗号(,)分隔的字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Join(this IEnumerable s)
        {
            return Join(s, ",", null);
        }

        /// <summary>
        /// 转换数组对象为用Delimeter分隔的字符串
        /// </summary>
        /// <param name="s">要转换的数组对象</param>
        /// <param name="vDelimeter">分割符</param>
        /// <returns></returns>
        public static string Join(this IEnumerable s, string vDelimeter)
        {
            return Join(s, vDelimeter, null);
        }

        /// <summary>
        /// 转换数组对象为用逗号(,)分隔的字符串
        /// </summary>
        /// <param name="s">要转换的数组对象</param>
        /// <param name="Quotation">每个数组成员之间用引号括起来(如果是'则结果'11','22','33')，该处一般为“"” 或 “'”</param>
        /// <returns></returns>
        public static string JoinQuot(this IEnumerable s, string Quotation)
        {
            return Join(s, ",", Quotation);
        }

        /// <summary>
        /// 转换数组对象为用Delimeter分隔的字符串
        /// </summary>
        /// <param name="s">要转换的数组对象</param>
        /// <param name="Delimeter">分割符</param>
        /// <param name="Quotation">每个数组成员之间用括号括起来，该处一般为" 或 '</param>
        /// <returns></returns>
        public static string Join(this IEnumerable s, string Delimeter, string Quotation)
        {
            string result = string.Empty;
            string vDelim = string.Empty;

            foreach (object el in s)
            {
                if (!string.IsNullOrEmpty(Quotation))
                {
                    result += vDelim + Quotation + el.ToString() + Quotation;
                }
                else
                {
                    result += vDelim + el.ToString();
                }
                vDelim = Delimeter;
            }
            return result;
        }

        #endregion

        public static string FormatWith(this string format, params object[] args)
        {
            if (format == null)
                throw new ArgumentNullException("format");

            return string.Format(format, args);
        }

        public static string FormatWith(this string format, IFormatProvider provider, params object[] args)
        {
            if (format == null)
                throw new ArgumentNullException("format");

            return string.Format(provider, format, args);
        }

        /// <summary>
        /// 转换为Guid?
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Nullable<Guid> ToNGuid(this string obj)
        {
            Nullable<Guid> g = null;

            if (!obj.IsNull())
            {
                try
                {
                    g = new Guid(obj);
                }
                catch { }
            }

            return g;
        }

        public static int ToInt(this string obj)
        {
            return Convert.ToInt32(obj);
        }

        public static bool ToBool(this string obj)
        {
            return Convert.ToBoolean(obj);
        }

    }

    public static class TextBoxExtension
    {
        public static void AddEmptyTextValidate(this Gizmox.WebGUI.Forms.TextBox tbObj, string emptyText)
        {
            tbObj.Text = emptyText;
            tbObj.ForeColor = System.Drawing.Color.DarkGray;

            tbObj.GotFocus += new EventHandler((object sender, EventArgs e) =>
            {
                var obj = sender as Gizmox.WebGUI.Forms.TextBox;

                if (obj.Text == emptyText) obj.Text = string.Empty;
                obj.Focus();
                obj.ForeColor = System.Drawing.Color.Black;
            });

            tbObj.LostFocus += new EventHandler((object sender, EventArgs e) =>
            {
                var obj = sender as Gizmox.WebGUI.Forms.TextBox;

                if (obj.Text == string.Empty)
                {
                    obj.Text = emptyText;
                    obj.ForeColor = System.Drawing.Color.DarkGray;
                }
            });
        }
    }
}
