using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Common.Dynamic;
using Rdl;
using TableToRdlc.Report;


namespace Common.Report
{
    public class TextBoxTable : IBuildReport
    {
        public double A4Width = 210;
        public double A4Height = 297;

        double _leftMargin = 19.05;
        public double LeftMargin
        {
            get { return _leftMargin; }
            set { _leftMargin = value; }
        }

        double _topMargin = 19.05;
        public double TopMargin
        {
            get { return _topMargin; }
            set { _topMargin = value; }
        }

        double _rightMargin = 19.05;
        public double RightMargin
        {
            get { return _rightMargin; }
            set { _rightMargin = value; }
        }


        double _bottomMargin = 19.05;
        public double BottomMargin
        {
            get { return _bottomMargin; }
            set { _bottomMargin = value; }
        }

        public WebTable Table;

        public Rdl.Report CreateReport()
        {
            var builder = new ReportBuilder
            {
                Body = CreateBody(),
                Width = A4Width + "mm"
            };
            var p = new Page
            {
                TopMargin = TopMargin + "mm",
                BottomMargin = BottomMargin + "mm"
            };
            builder.Page = p.Create();
            return builder.Create();
        }

        private BodyType CreateBody()
        {
            var body = new Body {  ReportItems = CreateReportItems(), Height = "285mm" };

            return body.Create();
        }

        private ReportItemsType CreateReportItems()
        {
            var reportItems = new ReportItemsEx{};
            if (Table!=null)
            {
                reportItems.Textboxs=Table.ToReport();
            }
            //reportItems.Textboxs.Add();
            return reportItems.Create();
        }

        public void WriteXml(Stream stream)
        {
            var serializer = new XmlSerializer(typeof(Rdl.Report));
            serializer.Serialize(stream, CreateReport());
        }




      
    }
}
