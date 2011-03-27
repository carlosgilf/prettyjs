using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Reporting.WebForms;
using System.Data;
using System.Collections;
using Common.Report.Exporting;
using System.Web;
using System.Collections.Specialized;
using System.Xml;

namespace Common.Report
{
    public class DynamicReport
    {
        private DataTable m_dataSet;
        private MemoryStream m_rdl;
        public JrtReport Rdl;
        public string[] RemoveColumnNames;

        public DataTable DataSource
        {
            get
            {
                return m_dataSet;
            }
            set
            {
                m_dataSet = value;
            }
        }

        public DynamicReport()
        {
            Rdl = new JrtReport();
        }

        public void ShowReport(ReportViewer rptViewer)
        {
            GetColumns();
            //rptViewer.Reset();
            rptViewer.LocalReport.DisplayName = string.IsNullOrEmpty(Rdl.PageHeaderText) ? "Report" : Rdl.PageHeaderText;
            rptViewer.LocalReport.LoadReportDefinition(m_rdl);
            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("MyData", m_dataSet));
        }

        public void ShowReport(Microsoft.Reporting.WinForms.ReportViewer rptViewer)
        {
            GetColumns();
            rptViewer.Reset();
            rptViewer.LocalReport.DisplayName = string.IsNullOrEmpty(Rdl.PageHeaderText) ? "Report" : Rdl.PageHeaderText;
            rptViewer.LocalReport.LoadReportDefinition(m_rdl);
            rptViewer.LocalReport.DataSources.Clear();
            rptViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("MyData", m_dataSet));
            rptViewer.RefreshReport();
        }

        public void ShowReport(ReportViewer rptViewer, DataTable dataSet)
        {
            this.m_dataSet = dataSet;
            GetColumns();
            //rptViewer.Reset();
            rptViewer.LocalReport.DisplayName = string.IsNullOrEmpty(Rdl.PageHeaderText) ? "Report" : Rdl.PageHeaderText;
            rptViewer.LocalReport.LoadReportDefinition(m_rdl);
            rptViewer.LocalReport.DataSources.Add(new ReportDataSource("MyData", m_dataSet));

            //rptViewer.LocalReport.Refresh();
        }

        private MemoryStream ExportRDLC(BaseDeviceInfoSettings exportTypeSetting, string deviceInfoXml, out IReportExporter winFormsReportExporter, out LocalReport localReport)
        {
            return ExportRDLC(exportTypeSetting, deviceInfoXml, null, out winFormsReportExporter, out localReport);
        }

        private MemoryStream ExportRDLC(BaseDeviceInfoSettings exportTypeSetting, string deviceInfoXml, DataTable _dataSet, out IReportExporter winFormsReportExporter, out LocalReport localReport)
        {
            if (_dataSet != null)
            {
                this.m_dataSet = _dataSet;
            }

            GetColumns();
            DateTime startTime = DateTime.Now;
            localReport = new LocalReport();
            localReport.DisplayName = string.IsNullOrEmpty(Rdl.PageHeaderText) ? "Report" : Rdl.PageHeaderText;
            localReport.LoadReportDefinition(m_rdl);
            localReport.DataSources.Add(new ReportDataSource("MyData", m_dataSet));
            winFormsReportExporter = new WinFormsReportExporter(localReport);
            MemoryStream content;

            if (exportTypeSetting is ExcelDeviceInfoSettings)
            {
                content = winFormsReportExporter.ExportToXls(deviceInfoXml);
            }
            else if (exportTypeSetting is PdfDeviceInfoSettings)
            {
                content = winFormsReportExporter.ExportToPdf(deviceInfoXml);
            }
            else if (exportTypeSetting is ImageDeviceInfoSettings)
            {
                content = winFormsReportExporter.ExportToImage(deviceInfoXml);
            }
            else if (exportTypeSetting is WordDeviceInfoSettings)
            {
                content = winFormsReportExporter.ExportToWord(deviceInfoXml);
            }
            else
            {
                throw new ApplicationException("Unknown export type format");
            }

            TimeSpan totalTime = DateTime.Now - startTime;
            return content;
        }

        /// <summary>
        /// 导出报表内容到文件
        /// </summary>
        /// <param name="exportTypeSetting"></param>
        /// <param name="deviceInfoXml"></param>
        /// <param name="_dataSet"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public string ExportToFile(BaseDeviceInfoSettings exportTypeSetting, string deviceInfoXml, DataTable _dataSet, string path)
        {
            IReportExporter winFormsReportExporter;
            LocalReport localReport;
            MemoryStream content = ExportRDLC(exportTypeSetting, deviceInfoXml, _dataSet, out winFormsReportExporter, out localReport);
            string fileExtension = winFormsReportExporter.Extension;

            string fileFullPath = path + "\\" + localReport.DisplayName + "." + fileExtension;
            if (Directory.Exists(fileFullPath))
            {
                File.Delete(fileFullPath);
            }
            File.WriteAllBytes(fileFullPath, content.ToArray());
            return fileFullPath;

        }

        public void ExportToResponse()
        {
            ExportToResponse(new ExcelDeviceInfoSettings(), null);
        }

        public void ExportToResponse(BaseDeviceInfoSettings exportTypeSetting, DataTable _dataSet)
        {
            ExportToResponse(exportTypeSetting, null, _dataSet);
        }

        /// <summary>
        /// 导出报表内容直接在Respons输出到客户端
        /// </summary>
        /// <param name="exportTypeSetting"></param>
        /// <param name="deviceInfoXml"></param>
        /// <param name="_dataSet"></param>
        /// <param name="response"></param>
        public void ExportToResponse(BaseDeviceInfoSettings exportTypeSetting, string deviceInfoXml, DataTable _dataSet)
        {
            IReportExporter winFormsReportExporter;
            LocalReport localReport;
            MemoryStream content = ExportRDLC(exportTypeSetting, deviceInfoXml, _dataSet, out winFormsReportExporter, out localReport);
            string fileExtension = winFormsReportExporter.Extension;

            //HttpContext.Current.Response.ContentType = "application/octet-stream";
            HttpResponse response = HttpContext.Current.Response;
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            response.AppendHeader("Content-disposition", "attachment;filename=" + HttpUtility.UrlEncode(localReport.DisplayName + "." + fileExtension));
            StreamToResponse(content, winFormsReportExporter.MimeType, response);
            response.Flush();
        }



        internal static void StreamToResponse(Stream data, string mimeType, HttpResponse response)
        {
            SetStreamingHeaders(mimeType, response);
            StreamToResponse(data, response);
        }

        internal static void SetStreamingHeaders(string mimeType, HttpResponse response)
        {
            response.BufferOutput = false;
            if (!string.IsNullOrEmpty(mimeType))
            {
                response.ContentType = mimeType;
            }
            response.Expires = -1;
        }

        internal static void StreamToResponse(Stream data, HttpResponse response)
        {
            int count = 0;
            byte[] buffer = new byte[0x14000];
            int num2 = 0;
            while ((count = data.Read(buffer, 0, 0x14000)) > 0)
            {
                response.OutputStream.Write(buffer, 0, count);
                num2 += count;
                if (num2 >= 0x14000)
                {
                    response.Flush();
                    num2 = 0;
                }
            }
        }


        public static string RdlName(string sName)
        {
            sName = System.Text.RegularExpressions.Regex.Replace(sName, @"[\[\]]", "");
            sName = System.Text.RegularExpressions.Regex.Replace(sName, @"[\.\: ]", "__");
            return sName;
        }

        private static bool VaildVariableName(string name)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(name, "^[a-zA-Z\u4e00-\u9fa5_][a-zA-Z\u4e00-\u9fa50-9_]*$", System.Text.RegularExpressions.RegexOptions.Compiled);
        }

        private MemoryStream GenerateRdl(IDictionary<string, string> allFields, IDictionary<string, string> selectedFields)
        {
            MemoryStream ms = new MemoryStream();
            Rdl.AllFields = allFields;
            Rdl.SelectedFields = selectedFields;
            Rdl.WriteXml(ms);
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

        private IDictionary<string, string> GetAvailableFields()
        {
            DataTable dataTable = m_dataSet;

            IDictionary<string, string> availableFields = new Dictionary<string, string>();
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                string fieldName = dataTable.Columns[i].ColumnName;
                string correctFieldName = fieldName;
                bool isVariable = VaildVariableName(fieldName);
                if (!isVariable)
                {
                    correctFieldName = "ID__F" + i.ToString();
                }
                availableFields.Add(fieldName, correctFieldName);
            }
            return availableFields;
        }

        private bool IsExsitColumnName(string fieldName)
        {
            if (RemoveColumnNames != null)
            {
                foreach (string name in RemoveColumnNames)
                {
                    if (fieldName.ToLower() == name.ToLower())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void GetColumns()
        {
            try
            {
                IDictionary<string, string> allFields = GetAvailableFields();

                IDictionary<string, string> selectedFields = new Dictionary<string, string>();

                foreach (var item in allFields)
                {
                    if (!IsExsitColumnName(item.Key))
                    {
                        selectedFields.Add(item);
                    }
                }

                if (m_rdl != null)
                    m_rdl.Dispose();
                m_rdl = GenerateRdl(allFields, selectedFields);
                DumpRdl(m_rdl);

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Print()
        {
            HttpContext context = HttpContext.Current;
            //Warning[] warnings = null;
            //string[] streamids = null;
            //string mimeType = null;
            //string encoding = null;
            //string extension = null;
            Warning[] warningArray;
            HttpResponse response = context.Response;
            response.StatusCode = 200;
            MemoryStream lastMemoryStream = null;
            context.Response.BufferOutput = false;
            context.Response.ContentType = null;
            context.Response.Expires = -1;
            HttpContext.Current.Response.Clear();
            GetColumns();
            LocalReport localReport = new LocalReport();
            localReport.DisplayName = string.IsNullOrEmpty(Rdl.PageHeaderText) ? "Report" : Rdl.PageHeaderText;

            localReport.LoadReportDefinition(m_rdl);
            localReport.DataSources.Add(new ReportDataSource("MyData", m_dataSet));
            var winFormsReportExporter = new WinFormsReportExporter(localReport);

            StringBuilder builder = new StringBuilder("<DeviceInfo>");
            NameValueCollection requestParameters = context.Request.QueryString;
            for (int i = 0; i < requestParameters.Count; i++)
            {
                if (requestParameters.Keys[i] != null)
                {
                    if (requestParameters.Keys[i].StartsWith("rc:", StringComparison.OrdinalIgnoreCase))
                    {
                        builder.AppendFormat("<{0}>{1}</{0}>", XmlConvert.EncodeName(requestParameters.Keys[i].Substring(3)), HttpUtility.HtmlEncode(requestParameters[i]));
                    }
                }
            }
            builder.Append("</DeviceInfo>");

            localReport.Render("IMAGE", builder.ToString(), delegate(string name, string extension, Encoding encoding, string mimeType, bool willSeek)
            {
                if (!HttpContext.Current.Response.IsClientConnected)
                {
                    throw new HttpException("Client disconnected");
                }
                if (lastMemoryStream != null)
                {
                    SendPrintStream(lastMemoryStream, response);
                    lastMemoryStream.Dispose();
                    lastMemoryStream = null;
                }
                lastMemoryStream = new MemoryStream();
                return lastMemoryStream;
            }, out warningArray);
            SendPrintStream(lastMemoryStream, response);
            lastMemoryStream.Dispose();
            SendPrintStream(null, response);

            if (!response.BufferOutput)
            {
                string a = context.Request.ServerVariables["SERVER_PROTOCOL"];
                if (string.Equals(a, "HTTP/1.0", StringComparison.OrdinalIgnoreCase))
                {
                    context.Response.Close();
                }
            }

        }

        private void SendPrintStream(Stream stream, HttpResponse response)
        {
            int length = 0;
            if (stream != null)
            {
                length = (int)stream.Length;
            }
            foreach (byte num2 in BitConverter.GetBytes(length))
            {
                response.OutputStream.WriteByte(num2);
            }
            if (stream != null)
            {
                stream.Position = 0L;
                StreamToResponse(stream, response);
                response.Flush();
            }
        }





    }


}
