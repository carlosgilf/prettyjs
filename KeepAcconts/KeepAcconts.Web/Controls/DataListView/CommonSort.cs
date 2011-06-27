using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms;

namespace Bronze.WebGuiCommonLib
{
    [Serializable]
    public partial class CommonSort : UserControl
    {
        public event CommonSort_MovingHandler CommonSort_Moving;
        private CommonSortInfo commonSortInfo;
        private Button btnUp;
        private Button btnDown;
        private Button btnTop;
        private Button btnBottom;
        public ListViewItem Item { get; set; }

        /// <summary>
        /// 排序标记，为SignType类型的枚举值(上移 = 0,下移 = 1,置顶=2,置尾=3)
        /// </summary>
        //private Bronze.WebGuiCommonLib.Enums.SignType sign;

        public CommonSort()
        {
            InitializeComponent();
        }

        public CommonSort(CommonSortInfo commonSortInfo)
            : this()
        {
            this.commonSortInfo = commonSortInfo;
            this.SetButtonStatus(commonSortInfo.SortValue, commonSortInfo.SortRowCount);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommonSort));
            this.btnUp = new Gizmox.WebGUI.Forms.Button();
            this.btnDown = new Gizmox.WebGUI.Forms.Button();
            this.btnTop = new Gizmox.WebGUI.Forms.Button();
            this.btnBottom = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUp
            // 
            this.btnUp.CustomStyle = "F";
            this.btnUp.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnUp.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnUp.Image"));
            this.btnUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUp.Location = new System.Drawing.Point(9, -1);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(42, 22);
            this.btnUp.TabIndex = 0;
            this.btnUp.Tag = "0";
            this.btnUp.Text = "上移";
            this.btnUp.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnUp.Click += new System.EventHandler(this.Move_Click);
            // 
            // btnDown
            // 
            this.btnDown.CustomStyle = "F";
            this.btnDown.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnDown.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnDown.Image"));
            this.btnDown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDown.Location = new System.Drawing.Point(57, -1);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(42, 22);
            this.btnDown.TabIndex = 1;
            this.btnDown.Tag = "1";
            this.btnDown.Text = "下移";
            this.btnDown.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnDown.Click += new System.EventHandler(this.Move_Click);
            // 
            // btnTop
            // 
            this.btnTop.CustomStyle = "F";
            this.btnTop.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnTop.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnTop.Image"));
            this.btnTop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTop.Location = new System.Drawing.Point(105, -1);
            this.btnTop.Name = "btnTop";
            this.btnTop.Size = new System.Drawing.Size(42, 22);
            this.btnTop.TabIndex = 2;
            this.btnTop.Tag = "2";
            this.btnTop.Text = "置顶";
            this.btnTop.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnTop.Click += new System.EventHandler(this.Move_Click);
            // 
            // btnBottom
            // 
            this.btnBottom.CustomStyle = "F";
            this.btnBottom.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnBottom.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle(resources.GetString("btnBottom.Image"));
            this.btnBottom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBottom.Location = new System.Drawing.Point(154, -1);
            this.btnBottom.Name = "btnBottom";
            this.btnBottom.Size = new System.Drawing.Size(42, 22);
            this.btnBottom.TabIndex = 3;
            this.btnBottom.Tag = "3";
            this.btnBottom.Text = "置尾";
            this.btnBottom.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnBottom.Click += new System.EventHandler(this.Move_Click);
            // 
            // CommonSort
            // 
            this.Controls.Add(this.btnBottom);
            this.Controls.Add(this.btnTop);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Size = new System.Drawing.Size(205, 25);
            this.ResumeLayout(false);

        }

        private void SetButtonStatus(double sort, int count)
        {
            if (commonSortInfo.OrderBy.ToUpper() == "DESC")
            {
                if (sort == count)
                {
                    btnUp.Enabled = false;
                    btnDown.Enabled = true;
                    btnTop.Enabled = false;
                    btnBottom.Enabled = true;

                    btnUp.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Icons.s_up2.png");
                    btnDown.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Icons.s_down.png");
                    btnTop.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Icons.s_top2.png");
                    btnBottom.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Icons.s_bottom.png");

                    if (sort == commonSortInfo.FirstSort)
                    {
                        btnUp.Enabled = false;
                        btnDown.Enabled = false;
                        btnTop.Enabled = false;
                        btnBottom.Enabled = false;

                        btnUp.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Icons.s_up2.png");
                        btnDown.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Icons.s_down2.png");
                        btnTop.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Icons.s_top2.png");
                        btnBottom.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Icons.s_bottom2.png");
                    }
                }
                else if (sort == commonSortInfo.FirstSort)
                {
                    btnUp.Enabled = true;
                    btnDown.Enabled = false;
                    btnTop.Enabled = true;
                    btnBottom.Enabled = false;

                    btnUp.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Icons.s_up.png");
                    btnDown.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Icons.s_down2.png");
                    btnTop.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Icons.s_top.png");
                    btnBottom.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Icons.s_bottom2.png");

                }
                else
                {
                    btnUp.Enabled = true;
                    btnDown.Enabled = true;
                    btnTop.Enabled = true;
                    btnBottom.Enabled = true;

                    btnUp.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Icons.s_up.png");
                    btnDown.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Icons.s_down.png");
                    btnTop.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Icons.s_top.png");
                    btnBottom.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Icons.s_bottom.png");
                }
            }
            else
            {
                if (sort == count)
                {
                    btnUp.Enabled = true;
                    btnDown.Enabled = false;
                    btnTop.Enabled = true;
                    btnBottom.Enabled = false;

                    btnUp.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Icons.s_up.png");
                    btnDown.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Icons.s_down2.png");
                    btnTop.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Icons.s_top.png");
                    btnBottom.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Icons.s_bottom2.png");

                    if (sort == commonSortInfo.FirstSort)
                    {
                        btnUp.Enabled = false;
                        btnDown.Enabled = false;
                        btnTop.Enabled = false;
                        btnBottom.Enabled = false;

                        btnUp.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Icons.s_up2.png");
                        btnDown.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Icons.s_down2.png");
                        btnTop.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Icons.s_top2.png");
                        btnBottom.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Icons.s_bottom2.png");
                    }
                }
                else if (sort == commonSortInfo.FirstSort)
                {
                    btnUp.Enabled = false;
                    btnDown.Enabled = true;
                    btnTop.Enabled = false;
                    btnBottom.Enabled = true;

                    btnUp.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Icons.s_up2.png");
                    btnDown.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Icons.s_down.png");
                    btnTop.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Icons.s_top2.png");
                    btnBottom.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Icons.s_bottom.png");
                }
                else
                {
                    btnUp.Enabled = true;
                    btnDown.Enabled = true;
                    btnTop.Enabled = true;
                    btnBottom.Enabled = true;

                    btnUp.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Icons.s_up.png");
                    btnDown.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Icons.s_down.png");
                    btnTop.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Icons.s_top.png");
                    btnBottom.Image = new Gizmox.WebGUI.Common.Resources.IconResourceHandle("Icons.s_bottom.png");
                }
            }
        }

        private void Move_Click(object sender, EventArgs e)
        {
            if (commonSortInfo != null)
            {
                if (CommonSort_Moving != null)
                {
                    SortEventArgs args = new SortEventArgs();
                    args.CommonSortInfo = commonSortInfo;
                    args.Item = Item;
                    args.SignType = (SignType)Convert.ToInt32((sender as Button).Tag);
                    args.SortedIndex = commonSortInfo.SortValue;

                    CommonSort_Moving(this, args);
                }
            }
        }
    }

    #region 公用排序辅助信息类
    [Serializable]
    public class CommonSortInfo
    {
        #region 私有变量

        private string itemId = string.Empty;
        private string itemName = "FID";
        private string tableName = string.Empty;
        private string orderBy = "ASC";
        public string sortFilter = "";
        private string sortName = "FSort";
        private double sortValue = 0;
        private double firstSort = 0;
        private int sortRowCount = 0;

        #endregion

        #region 属性成员

        /// <summary>
        /// 排序所对应的数据库表的名称
        /// </summary>
        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        /// <summary>
        /// 主键字段名
        /// </summary>
        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        /// <summary>
        /// 主键ID
        /// </summary>
        public string ItemID
        {
            get { return itemId; }
            set { itemId = value; }
        }

        /// <summary>
        /// 排序列名
        /// </summary>
        public string SortName
        {
            get { return sortName; }
            set { sortName = value; }
        }

        /// <summary>
        /// 排序列名
        /// </summary>
        public double SortValue
        {
            get { return sortValue; }
            set { sortValue = value; }
        }

        /// <summary>
        /// 排序方式
        /// </summary>
        public string OrderBy
        {
            get { return orderBy; }
            set { orderBy = value; }
        }

        /// <summary>
        /// 排序条件
        /// </summary>
        public string SortFilter
        {
            get { return sortFilter; }
            set { sortFilter = value; }
        }

        /// <summary>
        /// 起始数据排序索引
        /// </summary>
        public double FirstSort
        {
            get { return firstSort; }
            set { firstSort = value; }
        }

        /// <summary>
        /// 总条数
        /// </summary>
        public int SortRowCount
        {
            get { return sortRowCount; }
            set { sortRowCount = value; }
        }

        #endregion
    }

    [Serializable]
    public class PageEvent : IEvent
    {
        Dictionary<string, string> paramList = new Dictionary<string, string>();

        public bool AltKey
        {
            get;
            set;
        }

        public bool Contains(string strParam)
        {
            return false;
        }

        public bool ControlKey
        {
            get;
            set;
        }

        public Keys KeyCode
        {
            get;
            set;
        }

        public string Member
        {
            get;
            set;
        }

        public bool ShiftKey
        {
            get;
            set;
        }

        public string Source
        {
            get;
            set;
        }

        public string Target
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }

        public string this[string strParam]
        {
            get
            {
                return this.paramList[strParam];
            }
            set
            {
                this.paramList.Add(strParam, value);
            }
        }
    }

    #endregion

    #region 排序条件分类辅助类

    /// <summary>
    /// 排序条件分类辅助类
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    //[TypeConverter(typeof(SortItemConverter))]
    [DesignTimeVisible(false)]
    [ToolboxItem(false)]
    public class SortFilterItem : Gizmox.WebGUI.Forms.Component
    {
        [DefaultValue("")]
        [SRCategory("CatData")]
        [Description("字段名")]
        [NotifyParentProperty(true)]
        public string ItemName { get; set; }

        [DefaultValue("")]
        [SRCategory("CatData")]
        [Description("字段值,如果为空则从绑定的数据源中获取")]
        [NotifyParentProperty(true)]
        public string ItemValue { get; set; }

        public SortFilterItem() { }

        public SortFilterItem(string itemName)
        {
            ItemName = itemName;
        }

        public SortFilterItem(string itemName, string itemValue)
        {
            ItemName = itemName;
            ItemValue = itemValue;
        }
    }

    [Serializable]
    public class SortItemConverter : ExpandableObjectConverter
    {
        public SortItemConverter() { }

        public override bool CanConvertTo(ITypeDescriptorContext objContext, Type objDestinationType)
        {
            return ((objDestinationType == typeof(InstanceDescriptor)) || base.CanConvertTo(objContext, objDestinationType));
        }

        public override object ConvertTo(ITypeDescriptorContext objContext, CultureInfo objCulture, object objValue, Type objDestinationType)
        {
            if (objDestinationType == null)
            {
                throw new ArgumentNullException("objDestinationType");
            }
            if ((objDestinationType == typeof(InstanceDescriptor)) && (objValue is SortFilterItem))
            {
                object obj2 = this.ConvertToInstanceDescriptor(objContext, objValue);
                if (obj2 != null)
                {
                    return obj2;
                }
            }
            return base.ConvertTo(objContext, objCulture, objValue, objDestinationType);
        }

        private object ConvertToInstanceDescriptor(ITypeDescriptorContext objContext, object objValue)
        {
            if (objValue != null)
            {
                ConstructorInfo constructor;
                Type[] typeArray;
                SortFilterItem item = (SortFilterItem)objValue;

                if (!string.IsNullOrEmpty(item.ItemName))
                {
                    if (!string.IsNullOrEmpty(item.ItemValue))
                    {
                        typeArray = new Type[] { typeof(string), typeof(string) };
                        constructor = typeof(SortFilterItem).GetConstructor(typeArray);

                        if (constructor != null)
                        {
                            return new InstanceDescriptor(constructor, new object[] { item.ItemName, item.ItemValue }, false);
                        }
                    }

                    typeArray = new Type[] { typeof(string) };
                    constructor = typeof(SortFilterItem).GetConstructor(typeArray);

                    if (constructor != null)
                    {
                        return new InstanceDescriptor(constructor, new object[] { item.ItemName }, false);
                    }
                }
            }
            return null;
        }
    }

    #endregion
}
