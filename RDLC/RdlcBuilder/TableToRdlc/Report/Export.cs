using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Common.Report;
using Microsoft.Reporting.WebForms;
using Common.Report.Exporting;
using System.Reflection;
using System.Collections;
using System.Data;
using System.Xml;
using System.Collections.Specialized;
using System.Text;

namespace Bronze.DEPSP.Report
{
    public class ReportHelper
    {
        public static string Export(string reportPath, string dataSourceName, DataTable dt, string FileName)
        {
            ReportDataSource rds = new ReportDataSource(dataSourceName, dt);

            // Variables  
            Warning[] warnings = null;
            string[] streamids = null;
            string mimeType = null;
            string encoding = null;
            string extension = null;

            try
            {
                // Setup the report viewer object and get the array of bytes  
                ReportViewer viewer = new ReportViewer();
                
                //EnableFormat(viewer, "HTML4.0");
                viewer.ProcessingMode = ProcessingMode.Local;
                viewer.LocalReport.ReportPath = reportPath;
                viewer.LocalReport.DataSources.Add(rds);
                byte[] bytes = viewer.LocalReport.Render("DOC", null, out mimeType, out encoding, out extension, out streamids, out warnings);
                //byte[] bytes = viewer.LocalReport.Render("HTML4.0", @"<DeviceInfo><ExpandContent>True</ExpandContent></DeviceInfo>", out mimeType, out encoding, out extension, out streamids, out warnings);
                
                /*
                // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.  
                HttpContext.Current.Response.Buffer = true;
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = mimeType;

                HttpContext.Current.Response.AddHeader("content-disposition", ("attachment; filename=" + HttpUtility.UrlEncode(FileName) + ".") + extension);
                HttpContext.Current.Response.BinaryWrite(bytes);
                // create the file  
                // send it to the client to download  
                HttpContext.Current.Response.Flush();
                */

                //HttpContext.Current.Response.Buffer = false;
                //HttpContext.Current.Response.ClearHeaders();
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "application/octet-stream";
                HttpContext.Current.Response.AddHeader("content-disposition", ("attachment; filename=" + HttpUtility.UrlEncode(FileName) + ".") + extension);
                HttpContext.Current.Response.BinaryWrite(bytes);
                HttpContext.Current.Response.Flush();
            }
            catch (Exception ex)
            {
                throw new Exception("Error Creating PDF File: " + ex.InnerException.Message);
            }

            return FileName;
        }



        public static void EnableFormat(ReportViewer viewer, string formatName)
        {
            const BindingFlags Flags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
            FieldInfo m_previewService = viewer.LocalReport.GetType().GetField("m_previewService", Flags);
            MethodInfo ListRenderingExtensions = m_previewService.FieldType.GetMethod("ListRenderingExtensions", Flags);
            object previewServiceInstance = m_previewService.GetValue(viewer.LocalReport);
            IList extensions = ListRenderingExtensions.Invoke(previewServiceInstance, null) as IList;
            PropertyInfo name = extensions[0].GetType().GetProperty("Name", Flags);
            foreach (object extension in extensions)
            {
                if (string.Compare(name.GetValue(extension, null).ToString(), formatName, true) == 0)
                {
                    FieldInfo m_isVisible = extension.GetType().GetField("m_isVisible", BindingFlags.NonPublic | BindingFlags.Instance);
                    FieldInfo m_isExposedExternally = extension.GetType().GetField("m_isExposedExternally", BindingFlags.NonPublic | BindingFlags.Instance);
                    m_isVisible.SetValue(extension, true);
                    m_isExposedExternally.SetValue(extension, true);
                    break;
                }
            }
        }
    }


    public class ReportHandler 
    {

        public static void Print(string reportPath, string dataSourceName, DataTable dt)
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

            ReportDataSource rds = new ReportDataSource(dataSourceName, dt);
            ReportViewer viewer = new ReportViewer();
            viewer.ProcessingMode = ProcessingMode.Local;
            viewer.LocalReport.ReportPath = reportPath;
            viewer.LocalReport.DataSources.Add(rds);
            //byte[] bytes = viewer.LocalReport.Render("Excel", null, out mimeType, out encoding, out extension, out streamids, out warnings);
            //HttpContext.Current.Response.BinaryWrite(bytes);
            //if (!response.BufferOutput)
            //{
            //    string a = context.Request.ServerVariables["SERVER_PROTOCOL"];
            //    if (string.Equals(a, "HTTP/1.0", StringComparison.OrdinalIgnoreCase))
            //    {
            //        context.Response.Close();
            //    }
            //}


            LocalReport localReport = viewer.LocalReport;
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

        private static void SendPrintStream(Stream stream, HttpResponse response)
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

        internal static void StreamToResponse(Stream data, HttpResponse response)
        {
            int count = 0;
            byte[] buffer = new byte[0x14000];
            while ((count = data.Read(buffer, 0, 0x14000)) > 0)
            {
                response.OutputStream.Write(buffer, 0, count);
            }
        }




    }


}
