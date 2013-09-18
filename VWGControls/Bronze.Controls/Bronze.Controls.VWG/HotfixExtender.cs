using System;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI;

namespace Bronze.Controls.VWG
{
    [ProvideProperty("RequestTimeout", typeof(Gizmox.WebGUI.Forms.Control))]
    [ToolboxItem(true)]
    [ToolboxItemFilter("Gizmox.WebGUI.Forms", ToolboxItemFilterType.Require), Serializable()]
    public class HotfixExtender : Gizmox.WebGUI.Forms.ComponentBase, IExtenderProvider
    {
        /// <summary>
        /// 设置Ajax请求超时时间
        /// </summary>
        /// <param name="objComponent">The component.</param>
        /// <param name="strId">The unique id.</param>
        public void SetRequestTimeout(Gizmox.WebGUI.Forms.Control objComponent, int timeoutSeconds)
        {
            IAttributeExtender objAttributeExtender = objComponent as IAttributeExtender;
            if (objAttributeExtender != null)
            {
                objAttributeExtender.SetAttribute("XhrTime", timeoutSeconds.ToString());
            }
        }

        /// <summary>
        /// 获取Ajax请求超时时间
        /// </summary>
        /// <param name="objComponent">The component.</param>
        /// <returns></returns>
        [Description("Ajax请求超时时间(秒)."), DefaultValue(0)]
        public int GetRequestTimeout(Gizmox.WebGUI.Forms.Control objComponent)
        {
            int result = 0;
            IAttributeExtender objAttributeExtender = objComponent as IAttributeExtender;
            if (objAttributeExtender != null)
            {
                int.TryParse(objAttributeExtender.GetAttribute("XhrTime"), out result);
            }
            return result;
        }




        #region IExtenderProvider Members

        /// <summary>
        /// Specifies whether this object can provide its extender properties to the specified object.
        /// </summary>
        /// <param name="objExtendee">The <see cref="T:System.Object"/> to receive the extender properties.</param>
        /// <returns>
        /// true if this object can provide extender properties to the specified object; otherwise, false.
        /// </returns>
        public bool CanExtend(object objExtendee)
        {
            return ((objExtendee is Gizmox.WebGUI.Forms.Control) && !(objExtendee is HotfixExtender));
        }

        #endregion
    }


}