using System;
using System.Collections.Generic;
using System.Text;
using Common.Report;
using Microsoft.Reporting.WebForms;
using System.IO;
using Common.Report.Exporting;
using System.Data;

namespace Common.Report
{
	public class WinFormsReportExporter : IReportExporter
	{
        string extension;
        public string Extension
        {
            get { return extension; }
        }

        string encoding;
        public string Encoding
        {
            get { return encoding; }
        }

        string mimeType;
        public string MimeType
        {
            get { return mimeType; }
        }

        protected LocalReport LocalReport;
        public WinFormsReportExporter(LocalReport localReport)
        {
            LocalReport = localReport;
        }
        
		protected byte[] ProcessReport(LocalReport report, string reportRenderType, string deviceInfo)
		{
			Warning[] warnings;
			string[] streamids;
			byte[] bytes;
			try
			{
				report.EnableExternalImages = true;
				report.EnableHyperlinks = true;
				bytes = report.Render(reportRenderType, deviceInfo, out mimeType, out encoding,
					out extension, out streamids, out warnings);
			}
			finally
			{
				//
			}

			return bytes;
		}



		private MemoryStream GetExportedContent(string reportRenderType, string deviceInfo)
		{
			MemoryStream toRet;

			try
			{
                byte[] reportData = ProcessReport(LocalReport, reportRenderType, deviceInfo);
				toRet = new MemoryStream(reportData);
			}
			finally
			{
                LocalReport.Dispose();
			}

			return toRet;
		}

		#region IReportExcelExporter Members

		public MemoryStream ExportToXls()
		{
			return this.ExportToXls(null);
		}

		public MemoryStream ExportToPdf()
		{
			return this.ExportToPdf(null);
		}

		public MemoryStream ExportToXls(string deviceInfo)
		{
			return GetExportedContent(ReportRenderType.Excel, deviceInfo);
		}

		public MemoryStream ExportToPdf(string deviceInfo)
		{
			return GetExportedContent(ReportRenderType.PDF, deviceInfo);
		}

		public MemoryStream ExportToImage(string deviceInfo)
		{
			return GetExportedContent(ReportRenderType.IMAGE, deviceInfo);
		}


        public MemoryStream ExportToWord(string deviceInfo)
        {
            return GetExportedContent(ReportRenderType.WORD, deviceInfo);
        }

        #endregion
    }
}
