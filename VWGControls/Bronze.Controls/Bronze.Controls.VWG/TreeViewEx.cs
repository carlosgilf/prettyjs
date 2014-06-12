#region Using

using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;


using Gizmox.WebGUI;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Extensibility;


#endregion

namespace Bronze.Controls.VWG
{
    /// <summary>
    /// Summary description for TreeViewEx
    /// </summary>
    [ToolboxItem(true)]
    [Serializable()]
    [Skin(typeof(TreeViewExSkin))]
    public partial class TreeViewEx : TreeView
    {
        public TreeViewEx()
        {
            InitializeComponent();
            this.CustomStyle = "TreeViewEx";
        }


        private int nodeHeight = 20;

         [Description("Node�ĸ߶�")]
        [DefaultValue(20)]
        public int NodeHeight
        {
            get { return nodeHeight; }
            set { nodeHeight = value; }
        }

        [Description("�Ƿ�������ʾHTML")]
        [Browsable(false)]
        public bool AllowNodeTextAsHtml
        {
            get;
            set;
        }

        [Description("ѡ��ڵ������")]
        [Browsable(false)]
        public bool AllowSelectFullLine
        {
            get;
            set;
        }

        protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            MarkNode(Nodes);
            base.RenderControls(objContext, objWriter, lngRequestID);
        }

        private void MarkNode(TreeNodeCollection nodes)
        {
            foreach (TreeNode objNode in nodes)
            {
                var objAttributeExtender = objNode as IAttributeExtender;
                if (objAttributeExtender != null)
                {
                    objAttributeExtender.SetAttribute("JRT", "1");
                }
                MarkNode(objNode.Nodes);
            }
        }

        protected override void RenderAttributes(IContext context, IAttributeWriter objWriter)
        {
            base.RenderAttributes(context, objWriter);
            objWriter.WriteAttributeString(WGAttributes.ItemHeight, NodeHeight);
            objWriter.WriteAttributeString("showHtml", this.AllowNodeTextAsHtml ? "1" : "0");
            objWriter.WriteAttributeString("selectFullLine", this.AllowSelectFullLine ? "1" : "0");
        }

       
    }

   
}