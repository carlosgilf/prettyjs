using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gizmox.WebGUI.Common.Interfaces;
using System.Reflection;
using System.IO;

namespace Bronze.Controls.VWG
{
    public class HtcFileLoader : IStaticGateway
    {
        public IStaticGatewayHandler GetGatewayHandler(IContext objContext)
        {
            using (System.IO.Stream stream = Assembly.GetExecutingAssembly()
                           .GetManifestResourceStream("Bronze.Controls.VWG.OtherResources.PIE.htc"))
            using (StreamReader reader = new StreamReader(stream))
            {
                char[] objBuffer = new char[stream.Length];
                reader.ReadBlock(objBuffer, 0, (int)stream.Length);
                objContext.HttpContext.Response.Expires = 100000;
                objContext.HttpContext.Response.Cache.SetExpires(DateTime.Now.AddYears(1));
                objContext.HttpContext.Response.Cache.SetCacheability(System.Web.HttpCacheability.Public);
                objContext.HttpContext.Response.ContentType = "text/x-component";
                objContext.HttpContext.Response.Write(objBuffer, 0, objBuffer.Length);
                objContext.HttpContext.Response.Flush();
            }
            return null;
        }

    }

    
}