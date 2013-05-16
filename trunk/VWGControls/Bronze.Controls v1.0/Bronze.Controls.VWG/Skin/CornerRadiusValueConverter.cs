using Gizmox.WebGUI.Forms;
using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;

namespace Bronze.Controls.VWG
{

    [Serializable]
    public class CornerRadiusValueConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext objContext, Type objSourceType)
        {
            return ((objSourceType == typeof(string)) || base.CanConvertFrom(objContext, objSourceType));
        }

        public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType)
        {
            return ((objDestinationType == typeof(string)) || base.CanConvertTo(objContext, objDestinationType));
        }

        public override object ConvertFrom(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue)
        {
            if (objValue is string)
            {
                string str = (string)objValue;
                if (!string.IsNullOrEmpty(str))
                {
                    string[] strArray = str.Split(new char[] { ',' });
                    if (strArray.Length == 1)
                    {
                        return new CornerRadiusValue(new CornerRadius(int.Parse(strArray[0])));
                    }
                    if (strArray.Length == 4)
                    {
                        return new CornerRadiusValue(new CornerRadius(int.Parse(strArray[0]), int.Parse(strArray[1]), int.Parse(strArray[2]), int.Parse(strArray[3])));
                    }
                }
            }




            return base.ConvertFrom(objContext, objCulture, objValue);
        }

        public override object ConvertTo(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue, Type objDestinationType)
        {
            if (objDestinationType == typeof(string))
            {
                CornerRadiusValue value2 = objValue as CornerRadiusValue;
                if (value2 != null)
                {
                    if (value2.All != -1)
                    {
                        return value2.All.ToString();
                    }
                    return string.Format("{0}, {1}, {2}, {3}", new object[] { value2.TopLeft, value2.TopRight, value2.BottomRight, value2.BottomLeft });
                }
            }
            return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
        }

        public override object CreateInstance(ITypeDescriptorContext objContext, IDictionary objPropertyValues)
        {
            CornerRadius padding;
            CornerRadiusValue value2 = (CornerRadiusValue)objContext.PropertyDescriptor.GetValue(objContext.Instance);
            int intAll = (int)objPropertyValues["All"];
            if (value2.All != intAll)
            {
                padding = new CornerRadius(intAll);
            }
            else
            {
                padding = new CornerRadius((int)objPropertyValues["TopLeft"], (int)objPropertyValues["TopRight"], (int)objPropertyValues["BottomRight"], (int)objPropertyValues["BottomLeft"]);
            }
            return Activator.CreateInstance(value2.GetType(), new object[] { padding });
        }

        public override bool GetCreateInstanceSupported(ITypeDescriptorContext objContext)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext objContext, object objValue, Attribute[] arrAttributes)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(CornerRadiusValue), arrAttributes);
            string[] names = new string[] { "All", "TopLeft", "TopRight", "BottomRight", "BottomLeft" };
            return properties.Sort(names);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext objContext)
        {
            return true;
        }
    }
}