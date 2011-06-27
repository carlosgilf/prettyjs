using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;

namespace Bronze.WebGuiCommonLib
{
    [Serializable]
    public class DataListView : ListView
    {
        public event ItemEventHandler ItemControlClick;
        public event ItemEventHandler ItemControlCreating;
        public event ListViewItemBindingEventHandler RowItemBinding;
        public event GenerateColumnHandler OnAutoGenerateColumns;

        #region CommonOperate相关

        #region 私用变量

        private List<LinkLabel> operateItems;

        #endregion

        #region 属性成员

        [DefaultValue(false)]
        [SRCategory("CommonOperate")]
        [Description("是否允许启用通用操作功能")]
        public bool AllowOperate { get; set; }

        [DefaultValue(null)]
        [SRCategory("CommonOperate")]
        [Description("操作项")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [System.Web.UI.PersistenceMode(System.Web.UI.PersistenceMode.InnerProperty)]
        public List<LinkLabel> OperateItems
        {
            get
            {
                if (operateItems == null)
                {
                    operateItems = new List<LinkLabel>();
                }
                return operateItems;
            }
        }

        #endregion

        #region 事件

        [SRCategory("CommonOperate")]
        [Description("操作项触发时执行")]
        public event CommonOperate_Click CommonOperate_Click;

        #endregion

        #endregion

        #region CommonSort相关

        #region 私用变量

        private double firstSort = 0;
        private List<SortFilterItem> sortFilterItems;
        private string sortFilter = "";
        private int sortRowCount = 0;

        #endregion

        #region 属性成员

        [DefaultValue(false)]
        [SRCategory("CommonSort")]
        [Description("是否允许启用通用排序功能，默认为不开启")]
        public bool AllowSort { get; set; }

        [DefaultValue("")]
        [SRCategory("CommonSort")]
        [Description("排序所对应的数据库表的名称")]
        public string TableName { get; set; }

        [DefaultValue("FSort")]
        [SRCategory("CommonSort")]
        [Description("排序列名")]
        public string SortName { get; set; }

        [DefaultValue("ASC")]
        [SRCategory("CommonSort")]
        [Description("排序方式")]
        public string OrderBy { get; set; }

        [DefaultValue(null)]
        [SRCategory("CommonSort")]
        [Description("排序条件过滤项")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [System.Web.UI.PersistenceMode(System.Web.UI.PersistenceMode.InnerProperty)]
        public List<SortFilterItem> SortFilterItems
        {
            get
            {
                if (sortFilterItems == null)
                {
                    sortFilterItems = new List<SortFilterItem>();
                }
                return sortFilterItems;
            }
        }


        [SRCategory("CommonSort")]
        [Description("起始数据排序索引")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public double FirstSort
        {
            get { return firstSort; }
        }


        [SRCategory("CommonSort")]
        [Description("总条数")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int SortRowCount
        {
            get { return sortRowCount; }
        }

        #endregion

        #region 事件

        [SRCategory("CommonSort")]
        [Description("排序时调用")]
        public event CommonSort_MovingHandler CommonSort_Moving;

        [SRCategory("CommonSort")]
        [Description("排序完成后调用")]
        public event CommonSort_MovedHandler CommonSort_Moved;

        #endregion

        #endregion

        #region CheckBox相关
        //private readonly CheckBox _checkbox;

        //private bool selecting;
        //private bool checking;
        //private bool handleAll;




        void CListview_MouseClick(object sender, MouseEventArgs e)
        {

        }

        //void CListview_ItemCheck(object objSender, ItemCheckEventArgs objArgs)
        //{
        //    if (selecting || handleAll) return;

        //    try
        //    {
        //        checking = true;
        //        foreach (ListViewItem item in this.Items)
        //        {
        //            item.Selected = item.Checked;
        //        }
        //    }
        //    finally
        //    {
        //        checking = false;
        //    }

        //}


        //void checkAllBox_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        handleAll = true;
        //        this.SuspendLayout();
        //        foreach (ListViewItem item in this.Items)
        //        {
        //            item.Checked = _checkbox.Checked;
        //            item.Selected = _checkbox.Checked;
        //        }
        //    }
        //    finally
        //    {
        //        this.Update();
        //        handleAll = false;
        //    }
        //}


        //void DataListView_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (checking || handleAll) return;
        //    bool needUpdate = false;
        //    try
        //    {
        //        if (this.CheckedItems.Count >= 3)
        //        {
        //            needUpdate = true;
        //            this.SuspendLayout();
        //        }
        //        selecting = true;
        //        foreach (ListViewItem item in this.Items)
        //        {
        //            item.Checked = item.Selected;
        //        }
        //    }
        //    finally
        //    {
        //        if (needUpdate)
        //        {
        //            this.Update();
        //        }
        //        selecting = false;
        //    }
        //}

        //protected override void PreRenderControl(Gizmox.WebGUI.Common.Interfaces.IContext objContext, long lngRequestID)
        //{
        //    base.PreRenderControl(objContext, lngRequestID);

        //    if (this.CheckBoxes == false)
        //    {
        //        return;
        //    }

        //    if (this.Parent.Controls.IndexOf(_checkbox) == -1)
        //    {
        //        this.Parent.Controls.Add(_checkbox);
        //        if (this.CheckBoxes)
        //        {
        //            base.ItemCheck += new ItemCheckHandler(CListview_ItemCheck);
        //            base.MouseClick += new MouseEventHandler(CListview_MouseClick);
        //            base.SelectedIndexChanged += new EventHandler(DataListView_SelectedIndexChanged);
        //        }
        //        _checkbox.BringToFront();
        //        _checkbox.Location = new Point(Location.X + 5, Location.Y + 2);
        //    }
        //}

        //protected override void PreRenderControl(Gizmox.WebGUI.Common.Interfaces.IContext objContext, long lngRequestID)
        //{
        //    base.PreRenderControl(objContext, lngRequestID);
        //}


        #endregion

        int rowHeight = 21;
        public int RowHeight
        {
            get
            {
                
                return rowHeight;
            }
            set
            {
                rowHeight = value;
            }
        }

        public DataListView()
        {
            //_checkbox = new CheckBox();
            //_checkbox.Width = 14;
            //_checkbox.Height = 16;
            //_checkbox.CheckedChanged += new EventHandler(checkAllBox_CheckedChanged);

            base.GridLines = true;
            base.CheckBoxes = true;
        }

        #region Fire Event
        /// <summary>
        /// Raises the <see cref="E:ItemBinding"/> event.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ListViewItemBindingEventArgs"/> instance containing the event data.</param>
        private void OnItemBinding(ListViewItemBindingEventArgs e)
        {
            // Get Handler.
            ListViewItemBindingEventHandler objEventHandler = this.RowItemBinding;
            if (objEventHandler != null)
            {
                //Raise the event
                objEventHandler(this, e);
            }
        }

        private void OnItemControlClick(ItemEventArgs e)
        {
            // Get Handler.
            ItemEventHandler objEventHandler = this.ItemControlClick;
            if (objEventHandler != null)
            {
                //Raise the event
                objEventHandler(this, e);
            }
        }

        private ColumnHeader FireAutoGenerateColumns(ColumnHeader e)
        {
            // Get Handler.
            GenerateColumnHandler objEventHandler = this.OnAutoGenerateColumns;
            if (objEventHandler != null)
            {
                //Raise the event
                return objEventHandler(this, e);
            }
            return e;
        }

        #endregion


        /// <summary>
        /// Gets the data source list.
        /// </summary>
        /// <param name="objDataSource">The data source.</param>
        /// <returns></returns>
        private IList GetDataSourceList(object objDataSource)
        {
            IList objList = null;

            // Try to get list
            if (this.DataMember == null)
            {
                // Get list from datasource
                objList = ListBindingHelper.GetList(objDataSource) as IList;
            }
            else
            {
                // Get list from datasource and datamember
                objList = ListBindingHelper.GetList(objDataSource, this.DataMember) as IList;
            }
            return objList;
        }


        /// <summary>
        /// Gets the property descriptor.
        /// </summary>
        /// <param name="strPropertyName">Name of the property.</param>
        /// <returns></returns>
        private PropertyDescriptor GetPropertyDescriptor(string strPropertyName)
        {
            PropertyDescriptor objPropertyDescriptor = null;

            // Validate property name.
            if (!string.IsNullOrEmpty(strPropertyName))
            {
                object objDataSource = this.DataListSource;
                if (objDataSource != null)
                {
                    // Gets the data source list.
                    IList objList = GetDataSourceList(objDataSource);

                    // If is a valid list
                    if (objList != null && !(objList is DataViewManager))
                    {
                        // Get properties collection.
                        PropertyDescriptorCollection objProperties = ListBindingHelper.GetListItemProperties(objList);
                        if (objProperties != null)
                        {
                            // Get requeted property by name.
                            objPropertyDescriptor = objProperties[strPropertyName];
                        }
                    }
                }
            }

            return objPropertyDescriptor;
        }

        private bool ShoudRegenerateColumns(ListChangedEventArgs objBindArgs)
        {
            if (objBindArgs != null)
            {
                return objBindArgs.ListChangedType == ListChangedType.Reset;
            }
            return true;
        }

        private bool ShouldRegenerateItems(ListChangedEventArgs objBindArgs)
        {
            if (objBindArgs != null)
            {
                return objBindArgs.ListChangedType == ListChangedType.Reset;
            }
            return true;
        }

        private void CreateOrUpdateBindableItem(object objRow, ListViewItem objExistingListViewItem, bool clear)
        {
            int intPosition = 0;
            ListViewItem objListViewItem = objExistingListViewItem;
            if (objExistingListViewItem == null)
            {
                objListViewItem = new ListViewItem();
            }

            bool selected = false;
            // Loop all coluns
            foreach (ColumnHeader objColumnHeader in this.Columns)
            {
                PropertyDescriptor objProperty = null;

                if (objColumnHeader.Tag != null)
                {
                    // Get new property
                    objProperty = this.GetPropertyDescriptor(Convert.ToString(objColumnHeader.Tag));
                }

                // The current value
                string strValue = "";

                // If property found
                if (objProperty != null)
                {
                    strValue = OnGetCellValue(objRow, objProperty);
                }

                // Func<Control> createControl = () =>
                //{
                //    return CreateControl(objRow, objListViewItem, objColumnHeader, ref objProperty, strValue);
                //};

                if (clear || objExistingListViewItem == null)
                {
                    if (objColumnHeader.Type == ListViewColumnType.Control)
                    {
                        //var control = createControl();

                        var control = CreateControl(objRow, objListViewItem, objColumnHeader, ref objProperty, strValue);
                        if (ItemControlCreating != null)
                        {
                            ItemControlCreating(this, control.Tag as ItemEventArgs);
                        }
                        objListViewItem.SubItems.Add(control);
                    }
                    else if (objColumnHeader.Type == ListViewColumnType.Icon)
                    {
                        objListViewItem.SubItems.Add(GetIcon(strValue));
                    }
                    else
                    {
                        objListViewItem.SubItems.Add(strValue);
                    }
                    objListViewItem.Tag = objRow;
                }
                else
                {
                    if (objColumnHeader.Type == ListViewColumnType.Control)
                    {
                        var controlItem = objListViewItem.SubItems[intPosition] as ListViewItem.ListViewSubControlItem;
                        if (controlItem != null)
                        {
                            controlItem.Control.Text = strValue;
                        }
                    }
                    else
                    {
                        objListViewItem.SubItems[intPosition].Text = strValue;
                    }
                    objListViewItem.Tag = objRow;

                }

                if (!string.IsNullOrEmpty(strValue) && objColumnHeader.Text == KEY_COLUMN_NAME && this.lastSelecValues.Contains(strValue))
                {
                    selected = true;
                }
                intPosition++;
            }

            if (this.CheckBoxes)
            {
                objListViewItem.Checked = selected;
            }
            objListViewItem.Selected = selected;
            if (objExistingListViewItem == null)
            {
                this.Items.Add(objListViewItem);
            }

            // Enable row formating.
            this.OnRowFormating(objRow, objListViewItem);

            // Enable item binding.
            this.OnItemBinding(new ListViewItemBindingEventArgs(objRow, objListViewItem));
            //objListViewItem.Selected = true;
        }

        private Control CreateControl(object objRow, ListViewItem objListViewItem, ColumnHeader objColumnHeader, ref PropertyDescriptor objProperty, string strValue)
        {
            Control subControl = null;
            if (objColumnHeader.CustomTemplate == "button")
            {
                subControl = new Button();
                subControl.Text = strValue;
            }
            else if (objColumnHeader.Text == SORT_COLUMN_NAME)
            {
                if (string.IsNullOrEmpty(TableName))
                {
                    throw new Exception("排序相对应的数据库表不能为空");
                }

                if (string.IsNullOrEmpty(SortName))
                {
                    //throw new Exception("排序相对应的列名不能为空");
                    SortName = "FSort";
                }

                CommonSortInfo commonSortInfo = new CommonSortInfo();
                commonSortInfo.TableName = TableName;
                commonSortInfo.ItemName = KeyField;
                commonSortInfo.ItemID = strValue;
                commonSortInfo.SortName = SortName;
                commonSortInfo.OrderBy = OrderBy;

                objProperty = this.GetPropertyDescriptor(SortName);

                if (objProperty != null)
                {
                    var sortValue = OnGetCellValue(objRow, objProperty);

                    if (!string.IsNullOrEmpty(sortValue))
                    {
                        commonSortInfo.SortValue = Convert.ToDouble(sortValue);
                    }
                }
                else
                {
                    throw new Exception("绑定的数据源中不存在" + SortName);
                }

                if (string.IsNullOrEmpty(sortFilter) && SortFilterItems != null && SortFilterItems.Count > 0)
                {
                    StringBuilder sortStr = new StringBuilder();

                    foreach (var item in SortFilterItems)
                    {
                        if (!string.IsNullOrEmpty(item.ItemName))
                        {
                            sortStr.Append(" " + item.ItemName.Trim() + " =");

                            if (!string.IsNullOrEmpty(item.ItemValue))
                            {
                                sortStr.Append(" '" + item.ItemValue.Trim() + "' AND");
                            }
                            else
                            {
                                objProperty = this.GetPropertyDescriptor(item.ItemName.Trim());

                                if (objProperty != null)
                                {
                                    var typeValue = OnGetCellValue(objRow, objProperty);

                                    if (!string.IsNullOrEmpty(typeValue))
                                    {
                                        sortStr.Append(" '" + typeValue + "' AND");
                                    }
                                }
                                else
                                {
                                    throw new Exception("绑定的数据源中不存在" + item.ItemName);
                                }
                            }
                        }
                        else
                        {
                            throw new Exception("过滤条件的ItemName不能为空");
                        }
                    }

                    sortFilter = sortStr.ToString(0, sortStr.Length - 4);
                }

                if (firstSort == 0 || sortRowCount == 0)
                {
                    //var dt = RetrievalProcedures.GetSortCount(commonSortInfo.TableName, commonSortInfo.SortName, sortFilter);
                    //if (dt.Rows.Count > 0)
                    //{
                    //    var row = dt.Rows[0];

                    //    firstSort = Convert.ToDouble(row["firstSort"]);
                    //    sortRowCount = Convert.ToInt32(row["count"]);
                    //}
                }

                commonSortInfo.SortFilter = sortFilter;
                commonSortInfo.FirstSort = firstSort;
                commonSortInfo.SortRowCount = sortRowCount;
                subControl = CreateCommonSort(commonSortInfo, objListViewItem);
            }
            else if (objColumnHeader.Text == OPERATE_COLUMN_NAME)
            {
                subControl = CreateCommonOperate(strValue, objListViewItem);
            }
            else
            {
                //var link = new Gizmox.WebGUI.Forms.LinkLabel();
                //link.AutoSize = false;
                //link.TextAlign = ContentAlignment.MiddleCenter;
                subControl = createLink();
                subControl.Text = strValue;
            }

            subControl.Tag = new ItemEventArgs() { Item = objListViewItem, CurrentColumn = objColumnHeader, Control = subControl };
            subControl.Click += new EventHandler(subControl_Click);
            return subControl;
        }

        void subControl_Click(object sender, EventArgs e)
        {
            var c = sender as Control;
            if (c != null)
            {
                OnItemControlClick(c.Tag as ItemEventArgs);
            }
        }


        private LinkLabel createLink()
        {
            var link = new Gizmox.WebGUI.Forms.LinkLabel();
            link.BorderStyle = BorderStyle.FixedSingle;
            if (this.GridLines == true)
            {
                link.BorderColor = new BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213))))));
                link.BorderWidth = new BorderWidth() { All = 0, Bottom = 1 };
            }
            //link.AutoSize = false;
            link.Padding = new Gizmox.WebGUI.Forms.Padding(5, 0, 0, 0);
            link.TextAlign = ViewControlTextAlign;
            return link;
        }

        private Panel CreateCommonOperate(string itemValue, ListViewItem listViewItem)
        {
            Panel panel = new Panel();
            panel.SuspendLayout();
            panel.Location = new System.Drawing.Point(9, 4);
            panel.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
            panel.Size = new System.Drawing.Size(120, 31);
            panel.Name = itemValue;
            if (this.OperateItems != null && this.OperateItems.Count > 0)
            {
                int i = 0;
                int x = 9;
                int y = 4;
                int size = 0;
                LinkLabel currentItem;

                foreach (LinkLabel item in this.OperateItems)
                {
                    currentItem = new LinkLabel();
                    currentItem.Text = item.Text;
                    currentItem.Name = item.Name;
                    currentItem.Tag = item.Tag;
                    currentItem.Click += delegate(object sender, EventArgs e)
                    {
                        if (sender != null && this.CommonOperate_Click != null)
                        {
                            LinkLabel lnk = sender as LinkLabel;
                            OperateEventArgs args = new OperateEventArgs();
                            args.Item = listViewItem;
                            args.CurrentOperatingItem = lnk;
                            args.CurrentOperatingText = lnk.Text;
                            args.Key = itemValue;
                            this.CommonOperate_Click(this, args);
                        }
                    };

                    if (i == 0)
                    {
                        currentItem.Location = new System.Drawing.Point(x, y);
                    }
                    else
                    {
                        x = panel.Controls[i - 1].Location.X + panel.Controls[i - 1].Size.Width;
                        currentItem.Location = new System.Drawing.Point(x, y);
                    }

                    currentItem.Size = new System.Drawing.Size(Convert.ToInt32(Utility.GetWidthByText(item.Text, item.Font)), 13);
                    //currentItem.Tag = itemValue;
                    size += currentItem.Size.Width;
                    i++;
                    panel.Controls.Add(currentItem);
                }
                panel.Size = new System.Drawing.Size(size, 31);
            }

            if (this.GridLines == true)
            {
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.BorderColor = new BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213))))));
                panel.BorderWidth = new BorderWidth() { All = 0, Bottom = 1 };
            }

     

            return panel;
        }

        private CommonSort CreateCommonSort(CommonSortInfo commonSortInfo, ListViewItem listViewItem)
        {
            CommonSort commonSort = new CommonSort(commonSortInfo);

            if (this.GridLines == true)
            {
                commonSort.BorderStyle = BorderStyle.FixedSingle;
                commonSort.BorderColor = new BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213))))));
                commonSort.BorderWidth = new BorderWidth() { All = 0, Bottom = 1 };
            }

            commonSort.Dock = DockStyle.Fill;
            commonSort.Item = listViewItem;
            commonSort.CommonSort_Moving += new CommonSort_MovingHandler(commonSort_CommonSort_Moving);
            return commonSort;
        }

        private void commonSort_CommonSort_Moving(object sender, SortEventArgs args)
        {
           
        }

        private List<string> lastSelecValues = new List<string>();
        private const string KEY_COLUMN_NAME = "KeyColumn";
        private const string OPERATE_COLUMN_NAME = "操作";
        private const string SORT_COLUMN_NAME = "排序";

        public void Bind()
        {
            Bind(true);
            this.Update();
        }

        public void Bind(bool clear)
        {
            lastSelecValues = new List<string>();
            var keyIndex = this.GetKeyColumnIndex();
            if (keyIndex >= 0)
            {
                foreach (ListViewItem item in this.SelectedItems)
                {
                    lastSelecValues.Add(item.SubItems[keyIndex].Text);
                }
            }

            // 
            bool blnRegenerateColumns = ShoudRegenerateColumns(null);

            //
            bool blnRegenerateItems = ShouldRegenerateItems(null);

            // Clear current list context
            if (this.AutoGenerateColumns && blnRegenerateColumns)
            {
                // Clear columns
                this.Columns.Clear();
            }

            if (blnRegenerateItems)
            {
                // Clear items
                this.Items.Clear();
            }


            var listSource = this.DataListSource;

            IList objList = GetDataSourceList(listSource);
            //if (objList != null && objList.Count == 0)
            //{
            //    this._checkbox.Visible = false;
            //}
            //else
            //{
            //    this._checkbox.Visible = true;
            //}

            // If is a valid list
            if (objList != null && !(objList is DataViewManager))
            {
                // Get properties from list
                PropertyDescriptorCollection objProperties = ListBindingHelper.GetListItemProperties(objList);
                if (objProperties != null)
                {
                    // Loop all properties
                    foreach (PropertyDescriptor objProperty in objProperties)
                    {
                        // If auto generation of columns is required
                        if (this.AutoGenerateColumns && blnRegenerateColumns)
                        {
                            // Get column 
                            ColumnHeader objColumn = OnGetColumn(objProperty);
                            if (objColumn != null)
                            {
                                // Set column mapping
                                objColumn.Tag = objProperty.Name;
                                objColumn = FireAutoGenerateColumns(objColumn);

                                // Add column
                                this.Columns.Add(objColumn);
                            }
                        }
                    }
                }
            }

            if (!string.IsNullOrEmpty(KeyField))
            {
                bool hasExsitKeyCol = false;
                foreach (ColumnHeader c in this.Columns)
                {
                    if (c.Text == KEY_COLUMN_NAME)
                    {
                        hasExsitKeyCol = true;
                        break;
                    }
                }

                if (!hasExsitKeyCol)
                {
                    var keycol = new ColumnHeader();
                    keycol.PreferedItemHeight = RowHeight;
                    keycol.Type = ListViewColumnType.Control;
                    keycol.Text = KEY_COLUMN_NAME;
                    keycol.Tag = KeyField;
                    keycol.Visible = false;
                    this.Columns.Add(keycol);
                }
            }

            if (this.AllowOperate)
            {
                bool hasExsitOperateCol = false;
                foreach (ColumnHeader c in this.Columns)
                {
                    if (c.Text == OPERATE_COLUMN_NAME)
                    {
                        hasExsitOperateCol = true;
                        break;
                    }
                }

                if (!hasExsitOperateCol)
                {
                    var operatecol = new ColumnHeader();
                    operatecol.Width = 120;

                    if (this.OperateItems != null && this.OperateItems.Count > 0)
                    {
                        operatecol.Width = 10;
                        this.OperateItems.ForEach(item => operatecol.Width += Convert.ToInt32(Utility.GetWidthByText(item.Text, item.Font) + 5));
                    }

                    operatecol.PreferedItemHeight = RowHeight;
                    operatecol.Type = ListViewColumnType.Control;
                    operatecol.Text = OPERATE_COLUMN_NAME;
                    operatecol.Tag = KeyField;
                    operatecol.TextAlign = HorizontalAlignment.Center;
                    operatecol.Visible = true;
                    operatecol.SortOrder = SortOrder.None;
                    this.Columns.Add(operatecol);
                }
            }

            if (this.AllowSort)
            {
                firstSort = 0;
                sortRowCount = 0;
                bool hasExsitSortCol = false;
                foreach (ColumnHeader c in this.Columns)
                {
                    if (c.Text == SORT_COLUMN_NAME)
                    {
                        hasExsitSortCol = true;
                        break;
                    }
                }

                if (!hasExsitSortCol)
                {
                    var sortcol = new ColumnHeader();
                    sortcol.Width = 205;
                    sortcol.PreferedItemHeight = RowHeight;
                    sortcol.Type = ListViewColumnType.Control;
                    sortcol.Text = SORT_COLUMN_NAME;
                    sortcol.Tag = KeyField;
                    sortcol.TextAlign = HorizontalAlignment.Center;
                    sortcol.Visible = true;
                    sortcol.SortOrder = SortOrder.None;
                    this.Columns.Add(sortcol);
                }
            }

            if (clear)
            {
                this.Items.Clear();
            }
            //this.Select()

            // Loop all rows in list
            int index = 0;
            foreach (object objRow in objList)
            {

                var exsitItem = this.Items.Count > index ? this.Items[index] : null;
                CreateOrUpdateBindableItem(objRow, exsitItem, clear);
                index++;
            }

            var count = this.Items.Count;
            for (int i = count - 1; i >= index; i--)
            {
                this.Items.RemoveAt(i);
            }
        }

        private string GetIcon(string strName)
        {
            return (new IconResourceHandle(strName)).ToString();
        }

        #region 属性成员

        ContentAlignment viewControlTextAlign = ContentAlignment.MiddleLeft;
        public ContentAlignment ViewControlTextAlign
        {
            get { return viewControlTextAlign; }
            set { viewControlTextAlign = value; }
        }

        private object dataSource;
        public object DataListSource
        {
            get
            {
                return dataSource;
            }
            set
            {
                dataSource = value;
            }

        }

        public string KeyField
        {
            get;
            set;
        }

        #endregion 属性成员

        private ContainerControl GetContainerContronl(Control control)
        {
            if (control.Parent == null && (control is ContainerControl))
            {
                ContainerControl containerControl = control as ContainerControl;

                object[] customAttributes = containerControl.GetType().GetCustomAttributes(true);

                foreach (var attributes in customAttributes)
                {
                    if (attributes is UserControl)
                    {
                        return containerControl;
                    }
                }

                return null;
            }
            else
            {
                return GetContainerContronl(control.Parent);
            }
        }

        private int GetKeyColumnIndex()
        {
            return GetColumnIndexByHeaderText(KEY_COLUMN_NAME);
        }

        public int GetColumnIndexByHeaderText(string name)
        {
            int index = -1;
            foreach (ColumnHeader col in this.Columns)
            {
                if (col.Text == name)
                {
                    index = this.Columns.IndexOf(col);
                }
            }
            return index;
        }

        public int GetColumnIndex(string name)
        {
            int index = 0;
            foreach (ColumnHeader col in this.Columns)
            {
                if (col.Tag.ToString() == name)
                {
                    index = this.Columns.IndexOf(col);
                }
            }
            return index;
        }

        public object[] GetSelectedIds<T>(int idColumnIndex)
        {
            List<object> ids = new List<object>();

            //HACK 暂时解决单击checkbox清除全部选择项时，不能获得选择的值
            if (this.CheckBoxes)
            {
                var items = this.CheckedItems;
                foreach (ListViewItem item in items)
                {
                    var id = item.SubItems[idColumnIndex].Text;
                    ids.Add(id.ConvertType(typeof(T)));
                }
            }
            else
            {
                var items = this.SelectedItems;
                foreach (ListViewItem item in items)
                {
                    var id = item.SubItems[idColumnIndex].Text;
                    ids.Add(id.ConvertType(typeof(T)));
                }
            }
            return ids.ToArray();
        }

        public string[] GetSelectedIds(int idColumnIndex)
        {
            List<string> ids = new List<string>();

            ////HACK 暂时解决单击checkbox清除全部选择项时，不能获得选择的值
            //if (this.CheckBoxes)
            //{
            //    var items = this.CheckedItems;
            //    foreach (ListViewItem item in items)
            //    {
            //        var id = item.SubItems[idColumnIndex].Text;
            //        ids.Add(id);
            //    }
            //}
            //else
            //{
                var items = this.SelectedItems;
                foreach (ListViewItem item in items)
                {
                    var id = item.SubItems[idColumnIndex].Text;
                    ids.Add(id);
                }
            //}
            
            return ids.ToArray();
        }

        public string[] GetSelectedIds()
        {
            return GetSelectedIds(GetKeyColumnIndex());
        }

        public object[] GetSelectedIds<T>()
        {
            return GetSelectedIds<T>(GetKeyColumnIndex());
        }


        public string GetSelectedText(int idColumnIndex)
        {
            return this.SelectedItem.SubItems[idColumnIndex].Text;
        }

        public string GetSelectedText(string culumnName)
        {
            var idColumnIndex = GetColumnIndex(culumnName);
            return this.SelectedItem.SubItems[idColumnIndex].Text;
        }



        public string GetSelectedId()
        {
            return GetSelectedText(GetKeyColumnIndex());
        }

        public object GetSelectedData(string columnName)
        {
            var item = this.SelectedItem;
            if (item == null || item.Tag == null) return null;
            var row = item.Tag as System.Data.DataRowView;
            if (row == null) return null;
            return row[columnName];
        }

        public void ChangePage(PageEvent pageEvent)
        {
            FireEvent(pageEvent);
        }

    }

    #region SRCategoryAttribute Class

    /// <summary>
    /// Summary description for SRCategoryAttribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.All), Serializable()]
    //================================================================
    //This object should not be Serializable because it inherits from
    //a non serializable class.
    //In a case of a SQLServer session state, we'll serialize it ourself
    //================================================================
    internal sealed class SRCategoryAttribute : CategoryAttribute
    {
        #region C'Tor / D'Tor

        /// <summary>
        ///
        /// </summary>
        public SRCategoryAttribute(string strCategory)
            : base(strCategory)
        {
        }


        #endregion C'Tor / D'Tor


    }

    #endregion SRCategoryAttribute Class
}
