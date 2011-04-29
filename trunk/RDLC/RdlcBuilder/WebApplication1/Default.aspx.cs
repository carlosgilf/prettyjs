using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Report;
using System.Data;
using Common.Report;
using System.IO;
using System.Text;
using TableToRdlc.Report;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GridView1.Visible = false;
        }


        public string RenderControls(Control control)
        {
            control.Visible = true;
            control.EnableViewState = false;
            StringWriter output = new StringWriter();
            Page m_pageHolder = new Page();
            var form = new System.Web.UI.HtmlControls.HtmlForm();
            form.Controls.Add(control);
            m_pageHolder.Controls.Add(form);
            HttpContext.Current.Server.Execute(m_pageHolder, output, false);
            return output.ToString();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            //DynamicReport bind = new DynamicReport();
            //bind.Rdl.PageHeaderText = "成绩";
            //bind.Rdl.LeftMargin = 8;
            //bind.Rdl.RightMargin = 5;
            //bind.Rdl.TopMargin = 8;
            //bind.Rdl.BottomMargin = 10;
            //bind.Rdl.PageFooterText = "\"第 \" & {0} & \" 页.共 \" & {1} & \" 页\"";
            //bind.ShowReport(this.ReportViewer1, this.GridView1);



            ReportRender render = new ReportRender();
            render.BuildReport = new SimpleTableReportBuilder()
            {
                PageHeaderText = "成绩",
                PageFooterText = "\"第 \" & {0} & \" 页.共 \" & {1} & \" 页\"",
                Table = WebTable.HtmlToTable(this.GridView1)
            };
            render.ShowReport(this.ReportViewer1);

        }
    }
}