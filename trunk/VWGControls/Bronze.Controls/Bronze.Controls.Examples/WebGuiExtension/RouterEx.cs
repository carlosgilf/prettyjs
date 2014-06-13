using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gizmox.WebGUI.Server;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI;
using Gizmox.WebGUI.Hosting;

namespace Bronze.WebGuiCommonLib
{
    public class Router : Gizmox.WebGUI.Server.Router 
    {
        public static bool Enable = true;

        protected override Gizmox.WebGUI.Hosting.HostHttpHandler GetHttpHandler(Gizmox.WebGUI.Hosting.HostContext objHostContext, Context objContext)
        {
            if (Enable)
            {
                RequestType enmRequestType = ((IRequestParams)objContext.Request).Type;
                if (CommonUtils.IsMono)
                {
                    objHostContext.Response.Buffer = false;
                }
                ApplyContentDispositionIfNeeded(objHostContext, enmRequestType);
                if (enmRequestType == RequestType.Preload)
                {
                    return new PreloadEx(objContext);
                }
            }
            return base.GetHttpHandler(objHostContext, objContext);
        }


        private static void ApplyContentDispositionIfNeeded(HostContext objHttpContext, RequestType enmRequestType)
        {
            switch (enmRequestType)
            {
                case RequestType.Unknown:
                case RequestType.Content:
                case RequestType.Statistics:
                case RequestType.Preload:
                case RequestType.Capture:
                case RequestType.Replay:
                case RequestType.Mashup:
                case RequestType.Manifest:
                    return;
            }
            string str = objHttpContext.Request.QueryString["content-disposition"];
            if (!string.IsNullOrEmpty(str))
            {
                objHttpContext.Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", str));
            }
        }

        protected override Context CreateContext(HostContext objHostContext)
        {
            return new Bronze.WebGuiCommonLib.WebGuiExtension.CustomContext(objHostContext);
        } 

 

 

    }
}
