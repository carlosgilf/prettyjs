namespace Bronze.Controls.VWG
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design.Serialization;
    using System.Globalization;
    using System.Drawing;

    [Serializable]
    public class BoxShadowConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext objContext, Type objSourceType)
        {
            return ((objSourceType == typeof(string)) || base.CanConvertFrom(objContext, objSourceType));
        }

        public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType)
        {
            return ((objDestinationType == typeof(InstanceDescriptor)) || ((objDestinationType == typeof(string)) || base.CanConvertTo(objContext, objDestinationType)));
        }

        public override object ConvertFrom(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue)
        {
            if (objValue is string)
            {
                string str = (string) objValue;
                if (!string.IsNullOrEmpty(str))
                {
                    string[] strArray = str.Split(new char[] { ',' });
                    //if (strArray.Length == 1)
                    //{
                    //    return new BoxShadow(int.Parse(strArray[0]));
                    //}
                    if (strArray.Length == 4)
                    {
                        //return new BoxShadow(int.Parse(strArray[0]), int.Parse(strArray[1]), int.Parse(strArray[2]), int.Parse(strArray[3]));
                        var color=this.ConvertColor(strArray[0].ToString(),objCulture);
                        return new BoxShadow(color, int.Parse(strArray[1]), int.Parse(strArray[2]), int.Parse(strArray[3]));
                    }
                }
            }
            return base.ConvertFrom(objContext, objCulture, objValue);
        }

        public override object ConvertTo(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue, Type objDestinationType)
        {
            if (objDestinationType == null)
            {
                throw new ArgumentNullException("destinationType");
            }
            bool flag = false;
            flag |= (objDestinationType == typeof(InstanceDescriptor)) && (objValue is BoxShadow);
            if (flag | ((objDestinationType == typeof(string)) && (objValue is BoxShadow)))
            {
                BoxShadow objPadding = (BoxShadow) objValue;
                if (objDestinationType == typeof(string))
                {
                    //if (objPadding.IsAll)
                    //{
                    //    return objPadding.All.ToString();
                    //}

                    var color = GetColorString(objPadding.Color,objCulture);
                    return string.Format("{0}, {1}, {2}, {3}", new object[] { color, objPadding.XOffset, objPadding.YOffset, objPadding.BlurSize });
                }
                if (objDestinationType == typeof(InstanceDescriptor))
                {
                    return this.ConvertToInstanceDescriptor(objContext, objPadding);
                }
            }
            return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
        }

        private object ConvertToInstanceDescriptor(ITypeDescriptorContext objContext, BoxShadow objPadding)
        {
            Type[] typeArray;
            //if (objPadding.ShouldSerializeAll())
            //{
            //    typeArray = new Type[] { typeof(int) };
            //    return new InstanceDescriptor(typeof(BoxShadow).GetConstructor(typeArray), new object[] { objPadding.All });
            //}
            typeArray = new Type[] { typeof(Color), typeof(int), typeof(int), typeof(int) };
            return new InstanceDescriptor(typeof(BoxShadow).GetConstructor(typeArray), new object[] { objPadding.Color, objPadding.XOffset, objPadding.YOffset, objPadding.BlurSize });
        }

        public override object CreateInstance(ITypeDescriptorContext objContext, IDictionary objPropertyValues)
        {
            BoxShadow padding = (BoxShadow) objContext.PropertyDescriptor.GetValue(objContext.Instance);
            //int intAll = (int) objPropertyValues["All"];
            //if (padding.All != intAll)
            //{
            //    return new BoxShadow(intAll);
            //}
            var color = (Color)objPropertyValues["Color"];
            return new BoxShadow(color, (int)objPropertyValues["XOffset"], (int)objPropertyValues["YOffset"], (int)objPropertyValues["BlurSize"]);
        }

        public override bool GetCreateInstanceSupported(ITypeDescriptorContext objContext)
        {
            return true;
        }

        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext objContext, object objValue, Attribute[] arrAttributes)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(BoxShadow), arrAttributes);
            string[] names = new string[] {
                //"All", 
                "Color", "XOffset", "YOffset", "BlurSize" };
            return properties.Sort(names);
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext objContext)
        {
            return true;
        }

        private object GetColorString(Color objColor, CultureInfo objCulture)
        {
            return TypeDescriptor.GetConverter(typeof(Color)).ConvertToString(null, objCulture, objColor);
        }

           private Color ConvertColor(string strColor, CultureInfo objCulture)
        {
            return (Color) TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(null, objCulture, strColor);
        }
    }
}
