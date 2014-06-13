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
        #region TreeNodeExtClick event
        public delegate void NodeExtHandler(object sender, TreeViewEx.TreeNodeExtEventArgs e);
        /// <summary>
        /// The RowItemClick event registration.
        /// </summary>
        private static readonly SerializableEvent NodeExtClickEvent = SerializableEvent.Register("NodeExtClick", typeof(NodeExtHandler), typeof(TreeViewEx));

        /// <summary>
        /// Occurs when selection changed.
        /// </summary>
        public event NodeExtHandler NodeExtClick
        {
            add
            {
                this.AddHandler(TreeViewEx.NodeExtClickEvent, value);
            }
            remove
            {
                this.RemoveHandler(TreeViewEx.NodeExtClickEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the TreeNodeExtClick event.
        /// </summary>
        private NodeExtHandler NodeExtClickHandler
        {
            get
            {
                return (NodeExtHandler)this.GetHandler(TreeViewEx.NodeExtClickEvent);
            }
        }

        protected virtual void OnNodeExtClick(TreeNodeExtEventArgs objArgs)
        {
            if (NodeExtClickHandler != null)
            {
                NodeExtClickHandler(this, objArgs);
            }
        } 
        #endregion

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

        protected override EventTypes GetCriticalEvents()
        {
            EventTypes enmTypes = base.GetCriticalEvents();
            if (this.NodeExtClickHandler != null) enmTypes |= EventTypes.Enter;
            return enmTypes;
        }

        protected override void FireEvent(IEvent objEvent)
        {
            if (objEvent.Type == "NodeExtClick")
            {
                try
                {
                    var id = objEvent["id"];
                    if (string.IsNullOrEmpty( id))
                    {
                        return;
                    }
                    var nodeId = long.Parse(id);
                    var currentNode = this.FindNodeById(nodeId);
                    var name = objEvent["srcName"];
                    var arg = new TreeNodeExtEventArgs() {Node=currentNode, SourceName = name };
                    this.OnNodeExtClick(arg);
                }
                catch (Exception)
                {
                }
            }
            base.FireEvent(objEvent);
        }


        public TreeNode FindNodeById(long id)
        {
            return FindNodeById(this.Nodes, id);
        }

        private  TreeNode FindNodeById(TreeNodeCollection nodes, long id)
        {
            foreach (TreeNode item in nodes)
            {
                if (item.ID == id)
                {
                    return item;
                }
                else
                {
                    var node= FindNodeById(item.Nodes, id);
                    if (node!=null)
                    {
                        return node;
                    }
                }
            }
            return null;
        }


        public class TreeNodeExtEventArgs : EventArgs
        {
            public TreeNode Node
            { get; set; }

            public string SourceName
            { get; set; }
        }


    }


}