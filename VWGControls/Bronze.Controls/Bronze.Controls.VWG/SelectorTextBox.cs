#region Using

using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

using Gizmox.WebGUI;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Extensibility;
using System.Collections;
using System.Globalization;
using System.Drawing.Design;
using Bronze.Controls.VWG.Common;


#endregion

namespace Bronze.Controls.VWG
{
    /// <summary>
    /// Summary description for SelectorTextBox
    /// </summary>
    //[ToolboxItem(true)]
    //[ToolboxBitmapAttribute(typeof(SelectorTextBox), "Bronze.Controls.VWG.SelectorTextBox.bmp")]
    //[DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    //[ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Serializable()]
    //[MetadataTag("BronzeSelctorTextBox")]
    [Skin(typeof(SelectorTextBoxSkin))]
    public partial class SelectorTextBox : Panel
    {
        public SelectorTextBox()
        {
            InitializeComponent();
            this.CustomStyle = "SelectorTextBoxSkin";
            // initialize collections
            //mobjItems = CreateItemCollection();
        }


        //private ObjectCollection mobjItems;

        /// <summary>
        /// The list box item collection
        /// </summary>
        private List<Selector> mobjItems = null;


        private bool editable = false;

        /// <summary>
        /// 是否可编辑
        /// </summary>
        [DefaultValue(false)]
        public bool Editable
        {
            get { return editable; }
            set
            {
                editable = value;
                this.Update();
            }
        }

        private string splitStr;

        /// <summary>
        /// 分隔字符
        /// </summary>
        [DefaultValue(null)]
        public string SplitString
        {
            get { return splitStr; }
            set
            {
                splitStr = value;
                this.Update();
            }
        }

        [Browsable(false)]
        [DefaultValue(null)]
        public List<Selector> Items
        {
            get
            {
                if (mobjItems == null)
                {
                    mobjItems = new List<Selector>();
                }
                return mobjItems;
            }
        }

        [DefaultValue(null)]
        public string DisplayFormat
        {
            get;
            set;
        }

        [DefaultValue(null)]
        public string ClientInputDisplayFormat
        {
            get;
            set;
        }


        /// <summary>
        /// 验证的表达式
        /// </summary>
        [DefaultValue(null)]
        public string VaildExpression
        {
            get;
            set;
        }

        /// <summary>
        /// 验证失败现实的消息
        /// </summary>
        [DefaultValue(null)]
        public string VaildExpressionMsg
        {
            get;
            set;
        }


        /// <summary>
        /// 客户端删除的事件
        /// </summary>
        [DefaultValue(null)]
        public string OnClientRemoveScript
        {
            get;
            set;
        }

        /// <summary>
        /// 客户端删除的事件
        /// </summary>
        [DefaultValue(null)]
        public string OnClientChanagedScript
        {
            get;
            set;
        }

        private string emptyMsg;
        [DefaultValue(null)]
        public string EmptyMessage
        {
            get { return emptyMsg; }
            set { emptyMsg = value; }
        }

        [DefaultValue(null)]
        public string OtherInfo
        {
            get;
            set;
        }

        /// <summary>
        /// The SelectionChanged event registration.
        /// </summary>
        private static readonly SerializableEvent SelectionChangedEvent = SerializableEvent.Register("SelectionChanged", typeof(EventHandler), typeof(ImageProcessor));



        /// <summary>
        /// Occurs when selection changed.
        /// </summary>
        public event EventHandler SelectionChanged
        {
            add
            {
                this.AddHandler(SelectorTextBox.SelectionChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(SelectorTextBox.SelectionChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the SelectionChanged event.
        /// </summary>
        private EventHandler SelectionChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(SelectorTextBox.SelectionChangedEvent);
            }
        }

        protected override EventTypes GetCriticalEvents()
        {
            EventTypes enmTypes = base.GetCriticalEvents();
            if (SelectionChangedHandler != null) enmTypes |= EventTypes.SelectionChange;
            return enmTypes;
        }

        protected override void RenderAttributes(IContext context, IAttributeWriter objWriter)
        {
            base.RenderAttributes(context, objWriter);
            string json = "";
            json = Newtonsoft.Json.JsonConvert.SerializeObject(this.Items);
            objWriter.WriteAttributeString(WGAttributes.Code, json);
            if (!string.IsNullOrWhiteSpace(DisplayFormat))
            {
                objWriter.WriteAttributeString(WGAttributes.Format, DisplayFormat);
            }
            if (!string.IsNullOrWhiteSpace(ClientInputDisplayFormat))
            {
                objWriter.WriteAttributeString("ClientInputDisplayFormat", ClientInputDisplayFormat);
            }
            if (!string.IsNullOrWhiteSpace(this.VaildExpression))
            {
                objWriter.WriteAttributeString(WGAttributes.ValueValidationExpression, VaildExpression);
            }
            if (!string.IsNullOrWhiteSpace(this.VaildExpressionMsg))
            {
                objWriter.WriteAttributeString(WGAttributes.InValidateMessage, VaildExpressionMsg);
            }
            objWriter.WriteAttributeString(WGAttributes.LabelEdit, this.Editable ? "1" : "0");
            if (!string.IsNullOrEmpty(SplitString))
            {
                objWriter.WriteAttributeString("SplitStr", this.SplitString);
            }

            if (!string.IsNullOrWhiteSpace(OnClientRemoveScript))
            {
                objWriter.WriteAttributeString("OnRemove", this.OnClientRemoveScript);
            }

            if (!string.IsNullOrWhiteSpace(OnClientChanagedScript))
            {
                objWriter.WriteAttributeString("OnChanged", this.OnClientChanagedScript);
            }

            if (!string.IsNullOrWhiteSpace(EmptyMessage))
            {
                objWriter.WriteAttributeString(WGAttributes.LoadingMessage, this.EmptyMessage);
                if (this.Items.Count == 0)
                {
                    objWriter.WriteAttributeString("ShowEmptyMsg", "1");
                }
            }
        }

        protected virtual void OnSelectionChange(EventArgs objArgs)
        {
            if (SelectionChangedHandler != null)
            {
                SelectionChangedHandler(this, objArgs);
            }
        }

        protected override void FireEvent(IEvent objEvent)
        {
            if (objEvent.Type == "ItemsChanged")
            {
                var strJson = objEvent["items"];
               
                strJson = LZStringCompress.DecompressFromBase64(strJson);
                var items = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Selector>>(strJson);

                if (items != null)
                {
                    foreach (var item in items)
                    {
                        if (item.Id != null)
                        {
                            var oldItem = this.mobjItems.FirstOrDefault(o => item.Id.Equals(o.Id));
                            if (oldItem != null)
                            {
                                item.Tag = oldItem.Tag;
                            }
                        }
                    }
                    this.mobjItems = items;
                    OnSelectionChange(EventArgs.Empty);
                }
            }
            else if (objEvent.Type == "SaveOtherInfo")
            {
                var info = objEvent["info"];
                this.OtherInfo = info;
            }
        }

        [Serializable]
        public class Selector
        {
            public string Text
            {
                get;
                set;
            }

            private object value;

            public object Value
            {
                get { return this.value; }
                set { this.value = value; }
            }


            public object Id
            {
                get;
                set;
            }

            public string Tooltip
            {
                get;
                set;
            }

            /// <summary>
            /// 来自客户端用户自行输入
            /// </summary>
            public bool FromClient
            {
                get;
                set;
            }

            [Newtonsoft.Json.JsonIgnore]
            public object Tag
            { get; set; }

        }
    }
}