using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Dynamic;
using Common.Report.Rdlc.Enums;

namespace TableToRdlc.Report
{
    public static class RdlUtils
    {


        public static double ConvertUnit(string length)
        {
            if (string.IsNullOrEmpty(length))
            {
                return 0;
            }
            length = length.Trim();
            double result = 0;
            if (length.EndsWith("px", StringComparison.CurrentCultureIgnoreCase))
            {
                length = length.Remove(length.Length - 2, 2);
            }
            var value = double.TryParse(length, out result) ? result : 0;

            var unit = new System.Web.UI.WebControls.Unit(value, System.Web.UI.WebControls.UnitType.Pixel);
            return MeasureTools.UnitToMillimeters(unit);
        }

        public static string ToMM(string length)
        {
            var unit = ConvertUnit(length);
            return unit + "mm";
        }

        public static string ToCasl(string val)
        {
            if (string.IsNullOrWhiteSpace(val))
            {
                return val;
            }
            return val.Substring(0, 1).ToUpper() + val.Substring(1, val.Length - 1).ToLower();
        }

        public static Dictionary<string, string> StyleParser(string style)
        {
            var result = new Dictionary<string, string>();
            if (!string.IsNullOrWhiteSpace(style))
            {
                var parts = style.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach (var part in parts)
                {
                    var nameValues = part.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    if (nameValues.Length == 2)
                    {
                        var key = nameValues[0].Trim().ToLower();
                        var value = nameValues[1].Trim().ToLower();
                        result[key] = value;

                        if (key == "padding")
                        {
                            StylePosParser(key, value, new[] { "top", "right", "bottom", "left" }, result);
                        }
                        else if (key == "border")
                        {
                            StylePosParser(key, value, new[] { "width", "style", "color" }, result);
                        }
                    }
                }
            }

            return result;
        }

        public static void StylePosParser(string key, string value,string[] pos, Dictionary<string, string> result)
        {
            var paddings = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var len = (paddings.Length > pos.Length ? pos.Length : paddings.Length);
            for (int i = 0; i < len; i++)
            {
                result[key + "-" + pos[i]] = paddings[i];
            }
        }


    }
}
