#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Threading;
using Gizmox.WebGUI.Common.Interfaces;

#endregion

namespace Bronze.WebGui.Skin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.listView1.AllowListItemDisplayHtml = true;
            listView1.SetColumnDisplayHtml(this.columnHeader1);
            button1.SetLoadingMessage("撒旦解放开绿灯撒看见法律监督所");
            Gizmox.WebGUI.Forms.ListViewGroup listViewGroup1 = new Gizmox.WebGUI.Forms.ListViewGroup("小组1", Gizmox.WebGUI.Forms.HorizontalAlignment.Left);
            Gizmox.WebGUI.Forms.ListViewGroup listViewGroup2 = new Gizmox.WebGUI.Forms.ListViewGroup("列表组2", Gizmox.WebGUI.Forms.HorizontalAlignment.Left);
            //this.listView1.CheckBoxes = true;
            //this.listView1.Groups.Add(listViewGroup1);
            //this.listView1.Groups.Add(listViewGroup2);
            //this.listViewItem1.Group = listViewGroup1;
            //this.listViewItem2.Group = listViewGroup1;
            //this.listViewItem3.Group = listViewGroup1;
            //this.listViewItem4.Group = listViewGroup1;
            this.listViewItem7.IndentCount = 5;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Thread.Sleep(25 * 1000);

            //button1.SetLoadingMessage("撒旦解放开绿灯撒看见法律监督所");
            new Form1().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form1().ShowDialog();
        }
    }


    internal class TestListView : ListView
    {
        ListViewColumnExtender ext = new ListViewColumnExtender();
        bool allowListItemDisplayHtml;

        [Description("是否允许显示HTML")]
        [Browsable(false)]
        public bool AllowListItemDisplayHtml
        {
            get
            {
                return allowListItemDisplayHtml;
            }
            set
            {
                allowListItemDisplayHtml = value;
            }
        }

        public void SetColumnDisplayHtml(ColumnHeader column)
        {
            ext.SetIsShowHtml(column, true);
        }
        
        protected override void RenderAttributes(Gizmox.WebGUI.Common.Interfaces.IContext objContext, Gizmox.WebGUI.Common.Interfaces.IAttributeWriter objWriter)
        {
            //Gizmox.WebGUI.WGAttributes.FullRowSelect
            base.RenderAttributes(objContext, objWriter);
            objWriter.WriteAttributeString("showHtml", this.AllowListItemDisplayHtml ? "1" : "0");
        }
    }


    [ProvideProperty("RequestTimeout", typeof(Gizmox.WebGUI.Forms.Control))]
    [ToolboxItem(true)]
    [ToolboxItemFilter("Gizmox.WebGUI.Forms", ToolboxItemFilterType.Require), Serializable()]
    public class ListViewColumnExtender : Gizmox.WebGUI.Forms.ComponentBase, IExtenderProvider
    {
        /// <summary>
        /// 设置Ajax请求超时时间
        /// </summary>
        /// <param name="objComponent">The component.</param>
        /// <param name="strId">The unique id.</param>
        public void SetIsShowHtml(Gizmox.WebGUI.Forms.Component objComponent, bool isShowHtml)
        {
            IAttributeExtender objAttributeExtender = objComponent as IAttributeExtender;
            if (objAttributeExtender != null)
            {
                objAttributeExtender.SetAttribute("showHtmlx", isShowHtml?"1":"0");
            }
        }

        /// <summary>
        /// 获取Ajax请求超时时间
        /// </summary>
        /// <param name="objComponent">The component.</param>
        /// <returns></returns>
        [Description("该列是否显示Html内容."), DefaultValue(0)]
        public bool GetIsShowHtml(Gizmox.WebGUI.Forms.Component objComponent)
        {
            int result = 0;
            IAttributeExtender objAttributeExtender = objComponent as IAttributeExtender;
            if (objAttributeExtender != null)
            {
                int.TryParse(objAttributeExtender.GetAttribute("showHtmlx"), out result);
            }
            return result==1;
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
            return ((objExtendee is Gizmox.WebGUI.Forms.ColumnHeader) && !(objExtendee is ListViewColumnExtender));
        }

        #endregion
    }
}