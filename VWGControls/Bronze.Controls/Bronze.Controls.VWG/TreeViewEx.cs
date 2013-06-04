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

         [Description("Node的高度")]
        [DefaultValue(20)]
        public int NodeHeight
        {
            get { return nodeHeight; }
            set { nodeHeight = value; }
        }

        [Description("是否允许显示HTML")]
        [Browsable(false)]
        public bool AllowNodeTextAsHtml
        {
            get;
            set;
        }

        [Description("选择节点的整行")]
        [Browsable(false)]
        public bool AllowSelectFullLine
        {
            get;
            set;
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