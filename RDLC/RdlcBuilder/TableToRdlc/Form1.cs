using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Common.Report;
using Common.Report;
using Microsoft.Reporting.WinForms;
using TableToRdlc.Report;

namespace Common
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            return;
            var m_dataSet = new DataTable();
            m_dataSet.Columns.Add("ttt");
            m_dataSet.Rows.Add("dd");

            reportViewer1.Reset();
            reportViewer1.LocalReport.DisplayName = "dfdf";
            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.ReportPath =   "c:\\test.rdlc";
            //reportViewer1.LocalReport.ReportPath =  @"C:\Users\jrt\Documents\1.rdl";
            reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("MyData", m_dataSet));
            //reportViewer1.Refresh();
            //reportViewer1.Show();
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DynamicReport bind = new DynamicReport();
            //DataTable dt = new DataTable();
            //dt.Columns.Add("tttt");
            //bind.DataSource = dt;

            //bind.Rdl.PageHeaderText = "成绩";
            //bind.Rdl.LeftMargin = 8;
            //bind.Rdl.RightMargin = 5;
            //bind.Rdl.TopMargin = 8;
            //bind.Rdl.BottomMargin = 10;
            //bind.Rdl.PageFooterText = "\"第 \" & {0} & \" 页.共 \" & {1} & \" 页\"";

            //HtmlTable table = new HtmlTable();
            //table.TableHtml = this.richTextBox1.Text;
            //table.Create();
            //bind.Rdl.Tables.Add(table.Table);

            //bind.ShowReport(this.reportViewer1);

            var table1 = WebTable.HtmlToTable(this.richTextBox1.Text);
            TextBoxTable tableBuilder=new TextBoxTable();
            tableBuilder.Table = table1;

            ReportRender render=new ReportRender();
            render.BuildReport = tableBuilder;
            render.ShowReport(this.reportViewer1);
        }
    }
}
