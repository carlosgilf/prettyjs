using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
using Rdl;
using Common.Dynamic;
using System.Collections;

namespace Common.Report
{
    //public delegate void RenderHandler(string fieldName, Style cellStyle, Style fontStyle, string value);
    [Serializable]
    public class JrtReport
    {
        public RenderHandler TableCellRenderer;
        public double A4Width = 210;
        public double A4Height = 297;
        private IDictionary<string, string> _mAllFields;
        private IDictionary<string, string> _mSelectedFields;

        /// <summary>
        /// 各列的宽度比例，如果是正数表示百分比，负数则为实际宽度
        /// </summary>
        public double[] Widths;

        public IDictionary<string, string> AllFields
        {
            get { return _mAllFields; }
            set { _mAllFields = value; }
        }

        public IDictionary<string, string> SelectedFields
        {
            get { return _mSelectedFields; }
            set { _mSelectedFields = value; }
        }

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


        string _pageHeaderText;
        public string PageHeaderText
        {
            get { return _pageHeaderText; }
            set { _pageHeaderText = value; }
        }

        string _pageHeaderLeftText;
        public string PageHeaderLeftText
        {
            get { return _pageHeaderLeftText; }
            set { _pageHeaderLeftText = value; }
        }

        string _pageHeaderRightText;
        public string PageHeaderRightText
        {
            get { return _pageHeaderRightText; }
            set { _pageHeaderRightText = value; }
        }

        string _pageFooterText = "\"第\" & {0} & \"/\" & {1} & \"页\"";
        //string pageFooterText = "第 {0} / {1} 页";
        public string PageFooterText
        {
            get
            {
                return _pageFooterText;
            }
            set
            {
                _pageFooterText = value;
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

        private bool _alwaysShowHeader = true;

        /// <summary>
        /// 是否在新页面中一直显示表头
        /// </summary>
        public bool RepeatTableHeaderOnNewPage
        {
            get { return _alwaysShowHeader; }
            set { _alwaysShowHeader = value; }
        }

        public List<NewTablix> Tables = new List<NewTablix>();

        private Rdl.Report CreateReport()
        {
            var builder = new ReportBuilder
                              {
                                  DataSources = CreateDataSources(),
                                  Body = CreateBody(),
                                  DataSets = CreateDataSets(),
                                  Width = A4Width + "mm"
                              };

            var p = new Page
                         {
                             TopMargin = TopMargin + "mm",
                             BottomMargin = BottomMargin + "mm",
                             PageHeader = CreatPageHeader(),
                             PageFooter = CreatPageFooter()
                         };
            builder.Page = p.Create();

            return builder.Create();
        }

        public static ParagraphsType CreateParagraphs(string value, StyleType style)
        {
            var paragraphs = new ParagraphsType();
            var pgr = new Paragraph();
            var txtRuns = new TextRunsType();
            var v = new LocIDStringWithDataTypeAttribute {Value = value};
            txtRuns.TextRun = new[] { new TextRun{Value = v, Style=style}.Create() };
            pgr.TextRuns = txtRuns;
            if (style != null)
            {
                pgr.Style = style;
            }
            paragraphs.Paragraph = new[] { pgr.Create() };
            return paragraphs;
        }

        public static ParagraphsType CreateParagraphs(string value)
        {
            return CreateParagraphs(value, null);
        }


        //创建页眉
        private PageSectionType CreatPageHeader()
        {
            var height = 0.91;
            var lrHeigth = 0.0;
            const double tableHeaderHeigth = 0.0;
            var items = new ArrayList();

            var ctb = new Textbox
            {
                Height = "0.9cm",
                Left = LeftMargin + "mm",
                Width = (A4Width - LeftMargin - RightMargin) + "mm",
                Paragraphs = CreateParagraphs(PageHeaderText, new Style { FontFamily = "宋体", FontSize = "18pt", FontWeight = "Bold", TextAlign = "Center" }.Create()),
                CanGrow = true,
                Style = new Style { FontSize = "18pt", FontWeight = "Bold", TextAlign = "Center" }.Create()
            };

            TextboxType headerTextbox = ctb.Create("Page_HeaderText");
            items.Add(headerTextbox);

            ctb.Width = ((A4Width - LeftMargin - RightMargin) / 2) + "mm";
            ctb.Height = "0.5cm";
            ctb.Paragraphs = CreateParagraphs(PageHeaderLeftText);
            ctb.Style = new Style { FontSize = "9pt", TextAlign = "Left" }.Create();
            ctb.Top = "0.92cm";
            TextboxType headerLeftTextbox = ctb.Create("Page_HeaderLeftText");
            if (!string.IsNullOrEmpty(PageHeaderLeftText))
            {
                items.Add(headerLeftTextbox);
                lrHeigth = 0.5;
            }

            ctb.Style = new Style { FontSize = "9pt", TextAlign = "Right" }.Create();
            ctb.Left = ((A4Width) / 2) + "mm";
            ctb.Paragraphs = CreateParagraphs(PageHeaderRightText);

            TextboxType headerRightTextbox = ctb.Create("Page_HeaderRightText");
            if (!string.IsNullOrEmpty(PageHeaderRightText))
            {
                items.Add(headerRightTextbox);
                lrHeigth = 0.5;
            }

            var reportItems = new ReportItemsType {Items = items.ToArray()};

            var header = new PageSection {ReportItems = reportItems};
            height = height + tableHeaderHeigth + lrHeigth;
            header.Height = height + "cm";
            header.PrintOnFirstPage = true;
            header.PrintOnLastPage = true;
            return header.Create();
        }

        //创建页脚
        private PageSectionType CreatPageFooter()
        {
            string height = "0.65cm";
            string top = "0mm";
            var items = new ArrayList();

            var style = new Style {FontSize = "9pt", TextAlign = "Left"};
            var ctb = new Textbox
                          {
                              Width = ((A4Width - LeftMargin - RightMargin)/2) + "mm",
                              Height = "0.63cm",
                              Paragraphs = CreateParagraphs(PageFooterLeftText, style.Create()),
                              Style = style.Create(),
                              CanGrow = true,
                              Left = LeftMargin + "mm"
                          };
            TextboxType headerLeftTextbox = ctb.Create("Page_FooterLeftText");
            if (!string.IsNullOrEmpty(PageFooterLeftText))
            {
                items.Add(headerLeftTextbox);
                height = "1.1cm";
                top = "0.6cm";
            }

            style.TextAlign = "Right";
            ctb.Style = style.Create();
            ctb.Left = ((A4Width) / 2) + "mm";
            ctb.Paragraphs = CreateParagraphs(PageFooterRightText, style.Create());
            TextboxType headerRightTextbox = ctb.Create("Page_FooterRightText");
            if (!string.IsNullOrEmpty(PageFooterRightText))
            {
                items.Add(headerRightTextbox);
                height = "1.1cm";
                top = "0.6cm";
            }

            style.TextAlign = "Center";
            ctb = new Textbox
            {
                Top = top,
                Height = "0.6cm",
                //Left = LeftMargin + "mm",
                Width = (A4Width - LeftMargin - RightMargin) + "mm",
                Paragraphs = CreateParagraphs(string.Format("=" + _pageFooterText, "Globals!PageNumber", "Globals!TotalPages"), style.Create()),
                //Value = string.Format("=" + pageFooterText, "Globals!PageNumber", "Globals!TotalPages"),
                Style = style.Create()
            };
            TextboxType headerTextbox = ctb.Create("Page_FooterText");
            items.Add(headerTextbox);

            var reportItems = new ReportItemsType { Items = items.ToArray() };
            var header = new PageSection
                             {
                                 ReportItems = reportItems,
                                 Height = height,
                                 PrintOnFirstPage = true,
                                 PrintOnLastPage = true
                             };
            return header.Create();
        }


        private static DataSourcesType CreateDataSources()
        {
            var dataSources = new DataSourcesType();
            var source = new DataSource();
            var conn = new ConnectionProperties { ConnectString = "", DataProvider = "SQL" };
            source.ConnectionProperties = new[] { conn.Create() };

            dataSources.DataSource = new[] { source.Create("DummyDataSource") };
            return dataSources;
        }

        private BodyType CreateBody()
        {
            var body = new Body { ReportItems = CreateReportItems(), Height = "285mm" };
            
            return body.Create();
        }

        private ReportItemsType CreateReportItems()
        {
            foreach (var tb in Tables)
            {
                var left = (A4Width - tb.TotalWidht)/2;
                if (left>0)
                {
                    tb.Left = left+"mm";
                }
            }
            var reportItems = new ReportItemsEx { Tablixs = Tables };
            return reportItems.Create();
        }

        private DataSetsType CreateDataSets()
        {
            var query = new Query { DataSourceName = "DummyDataSource", CommandText = "" };
            var ds = new DataSet
                         {
                             Query = new[] { query.Create() },
                             Fields = new[] { CreateFields() }
                         };
            var dataSets = new DataSetsType
                               {
                                   DataSet = new[] { ds.Create("MyData") }
                               };
            return dataSets;
        }


        private FieldsType CreateFields()
        {
            var fields = new FieldsType { Field = new FieldType[_mAllFields.Count] };

            var i = 0;
            foreach (var f in _mAllFields)
            {
                fields.Field[i] = CreateField(f.Key);
                i++;
            }

            return fields;
        }

        private FieldType CreateField(String fieldName)
        {
            var f = new Field { DataField = new[] { fieldName } };
            return f.Create(_mAllFields[fieldName]);
        }

        public void WriteXml(Stream stream)
        {
            var serializer = new XmlSerializer(typeof(Rdl.Report));
            serializer.Serialize(stream, CreateReport());
        }
    }
}
