using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gizmox.WebGUI.Server;
using Gizmox.WebGUI.Common.Interfaces;
using System.Web.SessionState;
using System.Web.Configuration;
using System.Security;
using System.Configuration;
using System.Web;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Common.Trace;
using System.Collections.Specialized;
using System.Reflection;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI;

namespace Bronze.WebGuiCommonLib
{
    public class PreloadEx : Preload
    {
        Context context;
        public Context Context
        {
            get
            {
                return this.context;
            }
        }

        public PreloadEx(Context objContext)
            : base(objContext)
        {
            context = objContext;
        }

        static Type _argumentsProviderType;
        static Type argumentsProviderType
        {
            get
            {
                if (_argumentsProviderType == null)
                {
                    _argumentsProviderType = Type.GetType("Gizmox.WebGUI.Server.Providers.ArgumentsProvider,Gizmox.WebGUI.Server");
                }
                return _argumentsProviderType;
            }
        }

        public override void ProcessRequest(Gizmox.WebGUI.Hosting.HostContext objHostContext)
        {
            IRequestParams request = (IRequestParams)this.Context.Request;
            this.CheckValidEnvironment();
            this.CheckValidApplication(request);
            Global.Context = this.Context;

            try
            {

                if (request.IsUserPostback)
                {
                    ((IContextTerminate)this.Context).Terminate(true);
                    VerboseRecord.Write(this, "Server/Context/Arguments", "Setting", "Setting the 'Context.Arguments' property to reflect external arguments.");

                    //this.Context.Arguments = new ArgumentsProvider(objHostContext.Request);
                    this.Context.Arguments = (NameValueCollection)Activator.CreateInstance(argumentsProviderType, objHostContext.Request);

                    this.Context.Referrer = objHostContext.Request.Form["Referrer"];
                }
                else if (this.Context.IsStatelessApplication)
                {
                    NameValueCollection arguments = this.Context.Arguments;
                    string currentTheme = this.Context.CurrentTheme;
                    ((IContextTerminate)this.Context).Terminate(true);
                    this.Context.Arguments = arguments;
                    this.Context.CurrentTheme = currentTheme;
                }

                bool pageInstanceWasForced;
                Type tt = request.GetType();
                pageInstanceWasForced = (bool)tt.GetProperty("PageInstanceWasForced", BindingFlags.Instance | BindingFlags.FlattenHierarchy | BindingFlags.Public).GetValue(request, null);

                if (!request.IsUserPostback && !pageInstanceWasForced)
                {
                    objHostContext.Response.Expires = -1;
                    objHostContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    objHostContext.Response.ContentType = "text/html";
                    string strResourceName = null;
                    if (!this.IsSupportedBrowser(objHostContext))
                    {
                        if (!this.Context.RenderStaticSEOContent(objHostContext))
                        {
                            strResourceName = this.GetUnsupportedBrowserFileName();
                        }
                        else
                        {
                            return;
                        }
                    }
                    if (this.IsTimeoutRequest(request))
                    {
                        strResourceName = this.GetTimeoutFileName();
                    }
                    //else if (this.IsDebuggerRequest(objHostContext))
                    //{
                    //    strResourceName = this.GetDebugFrameFileName();
                    //}
                    if (strResourceName == null)
                    {
                        strResourceName = this.GetBrowserFileName();
                    }
                    SkinFactory.WriteSkinResource(this.Context, objHostContext.Response.OutputStream, strResourceName, objHostContext.Request.QueryString);
                }
                else
                {
                    var uri = objHostContext.Request.Url;
                    var port = HostRuntime.Config.GetFeatureValue("ForcePort", string.Empty);
                    //uri = GetRedirectionUri(objHostContext.Request.Url, port);
                    uri = GetRedirectionUri(objHostContext.Request.Url,port);

                    string leftPart = uri.GetLeftPart(UriPartial.Path);
                    int index = leftPart.IndexOf("/post.", StringComparison.InvariantCultureIgnoreCase);
                    if (index > -1)
                    {
                        leftPart = leftPart.Substring(0, index + 1) + leftPart.Substring(index + 6);
                    }
                    string pageInstance = request.PageInstance;
                    if (!string.IsNullOrEmpty(pageInstance))
                    {
                        if (leftPart.Contains("?"))
                        {
                            leftPart = string.Format("{0}&vwginstance={1}", leftPart, pageInstance);
                        }
                        else
                        {
                            leftPart = string.Format("{0}?vwginstance={1}", leftPart, pageInstance);
                        }
                    }
                    objHostContext.Response.Redirect(leftPart);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }

            //base.ProcessRequest(objHostContext);
        }


        //public Uri GetRedirectionUri(Uri url, string port)
        //{
        //    UriBuilder builder = new UriBuilder(url);

        //    string portFromUriOrConfiguration = this.GetPortFromUriOrConfiguration(builder.Uri, false, port);
        //    if (portFromUriOrConfiguration != string.Empty)
        //    {
        //        builder.Port = int.Parse(portFromUriOrConfiguration);
        //    }
        //    else
        //    {
        //        builder.Port = -1;
        //    }
        //    return builder.Uri;
        //}


        //private string GetPortFromUriOrConfiguration(Uri objRequestUri, bool blnAddColon, string port)
        //{
        //    int result = 80;
        //    if (!string.IsNullOrEmpty(port))
        //    {
        //        int.TryParse(port, out result);
        //    }
        //    else
        //    {
        //        result = objRequestUri.Port;
        //    }
        //    if (result == 80)
        //    {
        //        return string.Empty;
        //    }
        //    if (blnAddColon)
        //    {
        //        return string.Format(":{0}", result);
        //    }
        //    return result.ToString();
        //}

        public static Uri GetRedirectionUri(Uri url, string port)
        {
            UriBuilder builder = new UriBuilder(url);

            string portFromUriOrConfiguration = GetPortFromUriOrConfiguration(builder.Uri, false, port);
            if (portFromUriOrConfiguration != string.Empty)
            {
                builder.Port = int.Parse(portFromUriOrConfiguration);
            }
            else
            {
                builder.Port = -1;
            }
            return builder.Uri;
        }


        private static string GetPortFromUriOrConfiguration(Uri objRequestUri, bool blnAddColon, string port)
        {
            int result = 80;
            if (!string.IsNullOrEmpty(port))
            {
                int.TryParse(port, out result);
            }
            else
            {
                result = objRequestUri.Port;
            }
            if (result == 80)
            {
                return string.Empty;
            }
            if (blnAddColon)
            {
                return string.Format(":{0}", result);
            }
            return result.ToString();
        }


        private void CheckValidEnvironment()
        {
            if (SessionStateMode == SessionStateMode.Off)
            {
                throw new HttpException(500, "Visual WebGui server cannot operate in a session without state. Check that session state mode is not set to off <sessionState mode=\"Off\"/> within your web.config file.");
            }
        }


        internal static SessionStateMode SessionStateMode
        {
            get
            {
                SessionStateMode inProc = SessionStateMode.InProc;
                try
                {
                    SessionStateSection section = ConfigurationManager.GetSection("system.web/sessionState") as SessionStateSection;
                    if (section != null)
                    {
                        inProc = section.Mode;
                    }
                }
                catch (SecurityException)
                {
                }
                return inProc;
            }
        }


        private bool IsTimeoutRequest(IRequestParams objRequest)
        {
            string str = string.Empty;
            if (objRequest != null)
            {
                str = objRequest.Page.ToLowerInvariant();
            }
            return (str == "timeout");
        }

        protected override bool IsSupportedBrowser(HostContext objHostContext)
        {
            bool blnIsSupported = base.IsSupportedBrowser(objHostContext);
            if (!blnIsSupported)
            {
                if (!CommonUtils.IsNullOrEmpty(objHostContext.Request.UserAgent))
                {
                    // Adjust IE11 detection strings at will. This example is based on:
                    // http://blogs.msdn.com/b/ieinternals/archive/2013/09/21/internet-explorer-11-user-agent-string-ua-string-sniffing-compatibility-with-gecko-webkit.aspx
                    if (objHostContext.Request.UserAgent.IndexOf("Windows NT") != -1
                        && objHostContext.Request.UserAgent.IndexOf("rv:11.0") != -1)
                    {
                        objHostContext.Request.Info.BrowserDirectory = "ie";
                        blnIsSupported = true; // IE11
                    }
                }
            }
            return blnIsSupported;
        }

    }
}
