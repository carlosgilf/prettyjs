using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace Bronze.Controls.VWG
{
    public class LinearGradient
    {

        public LinearGradient()
        {

        }


        public LinearGradient(string startPoint, string startColor, string endColor)
        {
            StartPoint = startPoint;
            stops = new List<Color>();
            stops.Add(ColorTranslator.FromHtml(startColor));
            stops.Add(ColorTranslator.FromHtml(endColor));
        }


        private List<Color> stops;

        public List<Color> ColorStops
        {
            get { return stops; }
            set { stops = value; }
        }

        private string startPostion = "top";

        public string StartPoint
        {
            get { return startPostion; }
            set { startPostion = value; }
        }

        private string endPostion;

        public string EndPoint
        {
            get { return endPostion; }
            set { endPostion = value; }
        }

        public override string ToString()
        {
            if (ColorStops != null)
            {
                string style = @"background:-moz-linear-gradient({0});background:-webkit-linear-gradient({0});background:linear-gradient({0});-pie-background: linear-gradient({0})";
                string colors = string.Empty;
                foreach (var color in ColorStops)
                {
                    var strColor = ColorTranslator.ToHtml(color);
                    if (string.IsNullOrEmpty(colors))
                    {
                        colors = strColor;
                    }
                    else
                    {
                        colors = colors + "," + strColor;
                    }
                }
                return string.Format(style, colors);
            }
            else
            {
                return string.Empty;
            }
        }

    }
}