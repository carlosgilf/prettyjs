using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TableToRdlc.Report
{
    public class ReportRender
    {
        public IBuildReport BuildReport;

        public void ShowReport(Microsoft.Reporting.WinForms.ReportViewer rptViewer)
        {
            var report=GenerateRdl();
            DumpRdl(report);
            rptViewer.Reset();
            rptViewer.LocalReport.DisplayName = "rrr";
            rptViewer.LocalReport.LoadReportDefinition(report);
            rptViewer.LocalReport.DataSources.Clear();
            rptViewer.RefreshReport();
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


    public interface IBuildReport
    {
        void WriteXml(Stream ms);
    }

}
