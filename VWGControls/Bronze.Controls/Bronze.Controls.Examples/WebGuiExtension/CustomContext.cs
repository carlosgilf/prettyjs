using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gizmox.WebGUI.Server;
using Gizmox.WebGUI.Hosting;
using System.Web;

namespace Bronze.WebGuiCommonLib.WebGuiExtension
{
    public class CustomContext : Context
    {
        public CustomContext(HostContext objHostContext)
            : base(objHostContext)
        {
        }


        protected override string GetApplicationMetadataTags()
        {
            var request = this.HttpContext.Request;

            //强制让IE10使用兼容试图
            if (IsMoreThanIE10(request))
            {
                string metaDataTags = base.GetApplicationMetadataTags();
                metaDataTags += @"<meta name=""ie10"" http-equiv=""X-UA-Compatible"" content=""IE=5"" />";
                return metaDataTags;
            }
            return base.GetApplicationMetadataTags();
        }

        private bool IsMoreThanIE10(HttpRequest request)
        {
            if (request.UserAgent.IndexOf("Windows NT") != -1
                        && request.UserAgent.IndexOf("rv:11.0") != -1)
            {
                return true;
            }
            var borwser = request.Browser;
            if (borwser.Type.ToUpper().Contains("IE") && borwser.MajorVersion >= 10)
            {
                return true;
            }
            return false;
        }
    }
}
