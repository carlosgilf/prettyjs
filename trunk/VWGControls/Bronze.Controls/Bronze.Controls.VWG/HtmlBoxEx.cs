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
    /// Summary description for HtmlBoxEx
    /// </summary>
    [ToolboxItem(true)]
    [Serializable()]
    [Skin(typeof(HtmlBoxExSkin))]
    public partial class HtmlBoxEx : HtmlBox
    {
        /// <summary>
        /// Provides a property reference to SelectableProperty property.
        /// </summary>
        private static SerializableProperty SelectableProperty = SerializableProperty.Register("Selectable", typeof(bool), typeof(HtmlBoxEx), new SerializablePropertyMetadata(false));


        public HtmlBoxEx()
        {
            InitializeComponent();
            this.CustomStyle = "HtmlBoxEx";
        }

        protected override void RenderAttributes(IContext context, IAttributeWriter writer)
        {
            base.RenderAttributes(context, writer);
            writer.WriteAttributeString("SEL", this.Selectable ? "1" : "0");
        }

        /// <summary>
        /// 文本是否可以选择
        /// </summary>
        [DefaultValue(false)]
        public bool Selectable
        {
            get
            {
                return this.GetValue<bool>(HtmlBoxEx.SelectableProperty);
            }
            set
            {
                // If the value of window less had changed
                if (this.SetValue<bool>(HtmlBoxEx.SelectableProperty, value))
                {
                    // Redraw the control
                    this.Update();
                }
            }
        }
       
    }
}