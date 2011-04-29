using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Reporting.WebForms;
using Common.Report;

namespace TableToRdlc.Report
{
    public class ReportRender
    {
        public BaseReportBuilder BuildReport;

        public void ShowReport(Microsoft.Reporting.WinForms.ReportViewer rptViewer)
        {
            var report=GenerateRdl();
            DumpRdl(report);
            rptViewer.Reset();
            rptViewer.LocalReport.DisplayName = string.IsNullOrEmpty(BuildReport.PageHeaderText) ? "Report" : BuildReport.PageHeaderText;
            rptViewer.LocalReport.LoadReportDefinition(report);
            rptViewer.LocalReport.DataSources.Clear();
            rptViewer.RefreshReport();
        }

        public void ShowReport(ReportViewer rptViewer)
        {
            var report = GenerateRdl();
            DumpRdl(report);
            rptViewer.LocalReport.DisplayName = string.IsNullOrEmpty(BuildReport.PageHeaderText) ? "Report" : BuildReport.PageHeaderText;
            rptViewer.LocalReport.LoadReportDefinition(report);
            rptViewer.LocalReport.Refresh();
        }

        private MemoryStream GenerateRdl()
        {
            MemoryStream ms = new MemoryStream();
            BuildReport.WriteXml(ms);
            ms.Position = 0;
            return ms;
        }

        private void DumpRdl(MemoryStream rdl)
        {
#if DEBUG
            using (FileStream fs = new FileStream(@"c:\test.rdlc", FileMode.Create))
            {
                rdl.WriteTo(fs);
            }
#endif
        }
    }


    public interface IReportBuilder
    {
        void WriteXml(Stream ms);
    }

}
