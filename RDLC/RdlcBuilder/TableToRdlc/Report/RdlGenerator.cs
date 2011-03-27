using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Rdl;
using Common.Dynamic;
using System.Collections;

namespace Common.Report
{
    public delegate void RenderHandler(string fieldName,Style cellStyle,Style fontStyle,string value);
    [Serializable]
    public class RdlGenerator
    {
        public RenderHandler TableCellRenderer;
        public double A4Width = 210;
        private IDictionary<string, string> m_allFields;
        private IDictionary<string, string> m_selectedFields;

        /// <summary>
        /// 各列的宽度比例，如果是正数表示百分比，负数则为实际宽度
        /// </summary>
        public double[] Widths;

        public IDictionary<string, string> AllFields
        {
            get { return m_allFields; }
            set { m_allFields = value; }
        }

        public IDictionary<string, string> SelectedFields
        {
            get { return m_selectedFields; }
            set { m_selectedFields = value; }
        }

        double leftMargin = 19.05;
        public double LeftMargin
        {
            get { return leftMargin; }
            set { leftMargin = value; }
        }


        double topMargin = 19.05;
        public double TopMargin
        {
            get { return topMargin; }
            set { topMargin = value; }
        }

        double rightMargin = 19.05;
        public double RightMargin
        {
            get { return rightMargin; }
            set { rightMargin = value; }
        }


        double bottomMargin = 19.05;
        public double BottomMargin
        {
            get { return bottomMargin; }
            set { bottomMargin = value; }
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
        //string pageFooterText = "第 {0} / {1} 页";
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

        private bool alwaysShowHeader=true;

        /// <summary>
        /// 是否在新页面中一直显示表头
        /// </summary>
        public bool RepeatTableHeaderOnNewPage
        {
            get { return alwaysShowHeader; }
            set { alwaysShowHeader = value; }
        }

        //private DataGrouping grouping=null;
        //public DataGrouping Grouping
        //{
        //    get { return grouping; }
        //    set { grouping = value; }
        //}
    

        private Rdl.Report CreateReport()
        {
            ReportBuilder builder = new ReportBuilder();
            builder.DataSources = CreateDataSources();
            builder.Body = CreateBody();
            builder.DataSets = CreateDataSets();
            builder.Width = A4Width+"mm";

            Page p = new Page();
            p.TopMargin = TopMargin.ToString() + "mm";
            //builder.RightMargin=RightMargin.ToString()+"mm";
            p.BottomMargin = BottomMargin.ToString() + "mm";
            p.PageHeader = CreatPageHeader();
            p.PageFooter = CreatPageFooter();
            builder.Page = p.Create();

            return builder.Create();
        }

        public static ParagraphsType CreateParagraphs(string value, StyleType style)
        {
            ParagraphsType paragraphs = new ParagraphsType();
            Paragraph pgr = new Paragraph();
            TextRunsType txtRuns = new TextRunsType();
            LocIDStringWithDataTypeAttribute v = new LocIDStringWithDataTypeAttribute();
            v.Value = value;
            txtRuns.TextRun = new TextRunType[] { new TextRun() {
                Value = v, Style=style
            }.Create() };
            pgr.TextRuns = txtRuns;
            if (style != null)
            {
                pgr.Style = style;
            }
            paragraphs.Paragraph = new ParagraphType[] { pgr.Create() };
            return paragraphs;
        }

        public static ParagraphsType CreateParagraphs(string value)
        {
            return CreateParagraphs(value, null);
        }

        StyleType createStyle(string textAlign)
        {
            Style style = new Style
            {
                FontSize = "12pt",
                FontWeight = "Bold",
                TextAlign = "Center"
            };
            return style.Create();
        }


        //创建页眉
        private PageSectionType CreatPageHeader()
        {
            double height = 0.91;
            double LRHeigth = 0.0;
            double tableHeaderHeigth = 0.0;
            ArrayList Items = new ArrayList();
            
            Textbox ctb = new Textbox
            {
                Height = "0.9cm",
                Left = LeftMargin.ToString() + "mm",
                Width = (A4Width - LeftMargin - RightMargin).ToString() + "mm",
                Paragraphs = CreateParagraphs(PageHeaderText, new Style { FontFamily="宋体", FontSize = "18pt", FontWeight = "Bold", TextAlign = "Center" }.Create()),
                CanGrow = true ,
                Style = new Style { FontSize = "18pt", FontWeight = "Bold", TextAlign = "Center" }.Create()
            };

            TextboxType headerTextbox = ctb.Create("Page_HeaderText");
            Items.Add(headerTextbox);

            ctb.Width = ((A4Width - LeftMargin - RightMargin) / 2).ToString() + "mm";
            ctb.Height = "0.5cm";
            ctb.Paragraphs = CreateParagraphs(PageHeaderLeftText);
            ctb.Style = new Style { FontSize = "9pt", TextAlign = "Left" }.Create();
            ctb.Top = "0.92cm";
            TextboxType headerLeftTextbox = ctb.Create("Page_HeaderLeftText");
            if (!string.IsNullOrEmpty(this.PageHeaderLeftText))
            {
                Items.Add(headerLeftTextbox);
                LRHeigth = 0.5;
            }

            ctb.Style = new Style { FontSize = "9pt", TextAlign = "Right" }.Create();
            ctb.Left = ((A4Width) / 2).ToString() + "mm";
            ctb.Paragraphs = CreateParagraphs(PageHeaderRightText);
            
            TextboxType headerRightTextbox = ctb.Create("Page_HeaderRightText");
            if (!string.IsNullOrEmpty(this.PageHeaderRightText))
            {
                Items.Add(headerRightTextbox);
                LRHeigth = 0.5;
            }

            ReportItemsType reportItems = new ReportItemsType();
            reportItems.Items = Items.ToArray();

            PageSection header = new PageSection();
            header.ReportItems = reportItems;
            height = height+tableHeaderHeigth + LRHeigth;
            header.Height = height.ToString()+"cm";
            header.PrintOnFirstPage = true;
            header.PrintOnLastPage = true;
            return header.Create();
        }

        //创建页脚
        private PageSectionType CreatPageFooter()
        {
            Style style = new Style();
            Textbox ctb = new Textbox();

            string height = "0.65cm";
            string top = "0mm";
            ArrayList Items = new ArrayList();

            style.FontSize = "9pt";
            style.TextAlign = "Left";
            ctb.Width = ((A4Width - LeftMargin - RightMargin) / 2).ToString() + "mm";
            ctb.Height = "0.63cm";
            ctb.Paragraphs = CreateParagraphs(PageFooterLeftText,style.Create());
            ctb.Style = style.Create();
            ctb.CanGrow = true;
            ctb.Left = LeftMargin.ToString() + "mm";
            TextboxType headerLeftTextbox = ctb.Create("Page_FooterLeftText");
            if (!string.IsNullOrEmpty(this.PageFooterLeftText))
            {
                Items.Add(headerLeftTextbox);
                height = "1.1cm";
                top = "0.6cm";
            }

            style.TextAlign = "Right";
            ctb.Style = style.Create();
            ctb.Left = ((A4Width) / 2).ToString() + "mm";
            ctb.Paragraphs = CreateParagraphs(PageFooterRightText, style.Create()); 
            TextboxType headerRightTextbox = ctb.Create("Page_FooterRightText");
            if (!string.IsNullOrEmpty(this.PageFooterRightText))
            {
                Items.Add(headerRightTextbox);
                height = "1.1cm";
                top = "0.6cm";
            }

            style.TextAlign = "Center";
            ctb = new Textbox
            {
                Top = top,
                Height = "0.6cm",
                Left = LeftMargin.ToString() + "mm",
                Width = (A4Width - LeftMargin - RightMargin).ToString() + "mm",
                Paragraphs = CreateParagraphs(string.Format("=" + pageFooterText, "Globals!PageNumber", "Globals!TotalPages"), style.Create()),
                //Value = string.Format("=" + pageFooterText, "Globals!PageNumber", "Globals!TotalPages"),
                Style = style.Create()
            };
            TextboxType headerTextbox = ctb.Create("Page_FooterText");
            Items.Add(headerTextbox);

            ReportItemsType reportItems = new ReportItemsType();
            reportItems.Items = Items.ToArray();
            PageSection header = new PageSection();
            header.ReportItems = reportItems;
            header.Height = height;
            header.PrintOnFirstPage = true;
            header.PrintOnLastPage = true;
            return header.Create();
        }


        private Rdl.DataSourcesType CreateDataSources()
        {
            Rdl.DataSourcesType dataSources = new Rdl.DataSourcesType();
            dataSources.DataSource = new Rdl.DataSourceType[] { CreateDataSource() };
            return dataSources;
        }

        private Rdl.DataSourceType CreateDataSource()
        {
            DataSource source = new DataSource();
            source.ConnectionProperties = new ConnectionPropertiesType[] { CreateConnectionProperties() };
            return source.Create("DummyDataSource");

        }

        private Rdl.ConnectionPropertiesType CreateConnectionProperties()
        {
            ConnectionProperties conn = new ConnectionProperties();
            conn.ConnectString = "";
            conn.DataProvider = "SQL";
            return conn.Create();
        }

        private Rdl.BodyType CreateBody()
        {
            Body body = new Body();
            body.ReportItems = CreateReportItems();
            body.Height = "1in";
            return body.Create();
        }

        private Rdl.ReportItemsType CreateReportItems()
        {
            ReportItems reportItems = new ReportItems();

            TableRdlGenerator tableGen = new TableRdlGenerator(this,"TableContent");
            tableGen.Fields = m_selectedFields;
            reportItems.Tablix = new TablixType[] { tableGen.CreateTable() };
            return reportItems.Create();

        }

        private Rdl.DataSetsType CreateDataSets()
        {
            Rdl.DataSetsType dataSets = new Rdl.DataSetsType();
            dataSets.DataSet = new Rdl.DataSetType[] { CreateDataSet() };
            return dataSets;
        }

        private Rdl.DataSetType CreateDataSet()
        {
            DataSet ds = new DataSet();
            ds.Query = new QueryType[] { CreateQuery() };
            ds.Fields = new FieldsType[] { CreateFields() };
            return ds.Create("MyData");
        }

        private Rdl.QueryType CreateQuery()
        {
            Query query = new Query();
            query.DataSourceName = "DummyDataSource";
            query.CommandText = "";
            return query.Create();
        }



        private Rdl.FieldsType CreateFields()
        {
            Rdl.FieldsType fields = new Rdl.FieldsType();

            fields.Field = new Rdl.FieldType[m_allFields.Count];

            int i = 0;
            foreach (var f in m_allFields)
            {
                fields.Field[i] = CreateField(f.Key);
                i++;
            }
     

            return fields;
        }

        private Rdl.FieldType CreateField(String fieldName)
        {
            Field f = new Field();
            f.DataField = new string[]{ fieldName};
            Rdl.FieldType field = new Rdl.FieldType();
            return f.Create(m_allFields[fieldName]);
        }

        public void WriteXml(Stream stream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Rdl.Report));
            serializer.Serialize(stream, CreateReport());
        }
    }
}
