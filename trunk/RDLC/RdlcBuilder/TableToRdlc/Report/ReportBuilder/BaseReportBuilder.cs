using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Common.Dynamic;
using Rdl;
using TableToRdlc.Report;
using System.Collections;


namespace Common.Report
{
    public abstract class BaseReportBuilder : IReportBuilder
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


        string pageHeaderText;
        public string PageHeaderText
        {
            get { return pageHeaderText; }
            set { pageHeaderText = value; }
        }

        string pageHeaderLeftText;
        public string PageHeaderLeftText
        {
            get { return pageHeaderLeftText; }
            set { pageHeaderLeftText = value; }
        }

        string pageHeaderRightText;
        public string PageHeaderRightText
        {
            get { return pageHeaderRightText; }
            set { pageHeaderRightText = value; }
        }

        string pageFooterText = "\"第\" & {0} & \"/\" & {1} & \"页\"";
        public string PageFooterText
        {
            get
            {
                return pageFooterText;
            }
            set
            {
                pageFooterText = value;
            }
        }

        public string PageFooterLeftText
        {
            get;
            set;
        }

        public string PageFooterRightText
        {
            get;
            set;
        }

        private bool alwaysShowHeader = true;

        /// <summary>
        /// 是否在新页面中一直显示表头
        /// </summary>
        public bool RepeatTableHeaderOnNewPage
        {
            get { return alwaysShowHeader; }
            set { alwaysShowHeader = value; }
        }



       

        public Rdl.Report CreateReport()
        {
            var builder = new ReportBuilder
            {
                Body = CreateBody().Create(),
                Width = A4Width + "mm"
            };
            var p = new Page
            {
                TopMargin = TopMargin + "mm",
                BottomMargin = BottomMargin + "mm"
            };
           

            p.PageHeader = CreatPageHeader();
            p.PageFooter = CreatPageFooter();
            builder.Page = p.Create();
            return builder.Create();
        }

        public virtual Body CreateBody()
        {
            var body = new Body {  ReportItems = CreateReportItems().Create(), 
                //Height = "1in"
                Height = "278mm" 
            };
            return body;
        }

        public virtual ReportItemsEx CreateReportItems()
        {
            var reportItems = new ReportItemsEx();
            return reportItems;
        }

        public void WriteXml(Stream stream)
        {
            var serializer = new XmlSerializer(typeof(Rdl.Report));
            serializer.Serialize(stream, CreateReport());
        }


        //创建页眉
        private PageSectionType CreatPageHeader()
        {
            double height = 0.91;
            double LRHeigth = 0.0;
            double tableHeaderHeigth = 0.0;
            ArrayList Items = new ArrayList();
            TextBoxBuilder builder = new TextBoxBuilder();

            var ctb = builder.CreateTextboxEx(PageHeaderText, false);
            ctb.Height = "0.9cm";
            ctb.Width = (A4Width - LeftMargin - RightMargin).ToString() + "mm";
            ctb.Style = new StyleEx { FontSize = "18pt", FontWeight = "Bold", TextAlign = "Center",FontFamily = "宋体"  };
            ctb.Paragraph.TextRun.Style = ctb.Style;
            ctb.Paragraph.Style = ctb.Style;
            ctb.Left = LeftMargin.ToString() + "mm";
            Items.Add(ctb.Create("Page_HeaderText"));


            if (!string.IsNullOrEmpty(this.PageHeaderLeftText))
            {
                ctb.Width = ((A4Width - LeftMargin - RightMargin) / 2).ToString() + "mm";
                ctb.Height = "0.5cm";
                ctb.Paragraph.TextRun.Value.Value = PageHeaderLeftText;
                ctb.Paragraph.TextRun.Style = ctb.Style;
                ctb.Paragraph.Style = ctb.Style;
                ctb.Style = new StyleEx { FontSize = "9pt", TextAlign = "Left" };
                ctb.Top = "0.92cm";
                Items.Add(ctb.Create("Page_HeaderLeftText"));
                LRHeigth = 0.5;
            }


            if (!string.IsNullOrEmpty(this.PageHeaderRightText))
            {
                ctb.Style = new StyleEx { FontSize = "9pt", TextAlign = "Right" };
                ctb.Left = ((A4Width) / 2).ToString() + "mm";
                ctb.Paragraph.TextRun.Value.Value = PageHeaderRightText;
                ctb.Paragraph.TextRun.Style = ctb.Style;
                ctb.Paragraph.Style = ctb.Style;
                Items.Add(ctb.Create("Page_HeaderRightText"));
                LRHeigth = 0.5;
            }

            ReportItemsType reportItems = new ReportItemsType();
            reportItems.Items = Items.ToArray();

            PageSection header = new PageSection();
            header.ReportItems = reportItems;
            height = height + tableHeaderHeigth + LRHeigth;
            header.Height = height.ToString() + "cm";
            header.PrintOnFirstPage = true;
            header.PrintOnLastPage = true;
            return header.Create();
        }

        //创建页脚
        private PageSectionType CreatPageFooter()
        {
            string height = "0.65cm";
            string top = "0mm";
            ArrayList Items = new ArrayList();
            var style = new StyleEx() { FontSize = "9pt", TextAlign = "Left", FontFamily = "宋体" };

            TextBoxBuilder builder = new TextBoxBuilder();
            var ctb = builder.CreateTextboxEx(PageFooterLeftText, false);
            ctb.Width = ((A4Width - LeftMargin - RightMargin) / 2).ToString() + "mm";
            ctb.Height = "0.63cm";
            ctb.Style = style;
            ctb.Paragraph.TextRun.Style = ctb.Style;
            ctb.Paragraph.Style = ctb.Style;
            ctb.CanGrow = true;
            ctb.Left = LeftMargin.ToString() + "mm";

            if (!string.IsNullOrEmpty(this.PageFooterLeftText))
            {
                Items.Add(ctb.Create("Page_FooterLeftText"));
                height = "1.1cm";
                top = "0.6cm";
            }

            if (!string.IsNullOrEmpty(this.PageFooterRightText))
            {
                style.TextAlign = "Right";
                ctb.Style = style;
                ctb.Left = ((A4Width) / 2).ToString() + "mm";
                ctb.Paragraph.TextRun.Value.Value = PageFooterRightText;
                ctb.Paragraph.TextRun.Style = ctb.Style;
                ctb.Paragraph.Style = ctb.Style;
                Items.Add(ctb.Create("Page_FooterRightText"));
                height = "1.1cm";
                top = "0.6cm";
            }

            style.TextAlign = "Center";
            ctb.Style = style;
            ctb.Height = "0.6cm";
            ctb.Top = top;
            ctb.Left = LeftMargin.ToString() + "mm";
            ctb.Width = (A4Width - LeftMargin - RightMargin).ToString() + "mm";
            ctb.Paragraph.TextRun.Value.Value = string.Format("=" + pageFooterText, "Globals!PageNumber", "Globals!TotalPages");
            ctb.Paragraph.TextRun.Style = ctb.Style;
            ctb.Paragraph.Style = ctb.Style;
            Items.Add(ctb.Create("Page_FooterText"));

            ReportItemsType reportItems = new ReportItemsType();
            reportItems.Items = Items.ToArray();
            PageSection header = new PageSection();
            header.ReportItems = reportItems;
            header.Height = height;
            header.PrintOnFirstPage = true;
            header.PrintOnLastPage = true;
            return header.Create();
        }

      
    }
}
