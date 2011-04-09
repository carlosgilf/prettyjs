//
//       FILE:  ProductFilter.cs
//
//     AUTHOR:  Kenneth Minear
//
//
//  SUBMITTED BY: KennWare Solutions LLC
//                7100 Bellaire Ave.
//                Windsor Heights, IA 50324 USA
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Data;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Reflection;

using Gizmox.WebGUI.Forms;




namespace GridFilter
{
    public partial class ProductFilter : Form
    {
        /// <summary>
        /// Apply filters to a DataGridView
        /// </summary>
        /// 
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// 

        public DataGridView _dataGridView;
        public DataGridViewColumnHeaderCell dgvHeader;
        public BindingSource data;

        private string mySessionId = string.Empty;

        private string oldFilter;
        private string newFilter;

        // String containing column headers to exclude
        private string excludeColumns;

        // Ordered Dictionary collections of column filter values
        private System.Collections.Specialized.OrderedDictionary productFilters =
            new System.Collections.Specialized.OrderedDictionary();
        private System.Collections.Specialized.OrderedDictionary catagoryFilters =
            new System.Collections.Specialized.OrderedDictionary();
        private System.Collections.Specialized.OrderedDictionary QuantityFilters =
            new System.Collections.Specialized.OrderedDictionary();
        private System.Collections.Specialized.OrderedDictionary priceFilters =
            new System.Collections.Specialized.OrderedDictionary();
        private System.Collections.Specialized.OrderedDictionary reorderFilters =
            new System.Collections.Specialized.OrderedDictionary();

        public ProductFilter()
        {
            InitializeComponent();
        }
        
        public ProductFilter(ref DataGridView dataGridView, string ExcludeColumns)
        {
            InitializeComponent();
            _dataGridView = dataGridView;
            excludeColumns = ExcludeColumns;

            try
            {
                data = dataGridView.DataSource as BindingSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Product Filter", "The datasource property of the containing DataGridView control " +
                    "must be set to a BindingSource.");
            }
        }

        private void ProductFilter_Load(object sender, EventArgs e)
        {
#if VWG
            mySessionId = Gizmox.WebGUI.Forms.VWGContext.Current.Session.SessionID;
#endif

            this.AcceptButton = btnApply;
            btnApply.NotifyDefault(true);
            UpdateDefaultButton();

            // Continue only if there is a DataGridView.
            if (_dataGridView == null) { return; }
            // Continue only if there is a datasource
            if (_dataGridView.DataSource == null) { return; }

            // Create error if the data source is not a BindingSource
            if (data == null)
            {
                MessageBox.Show("Product Filter", "The datasource property of the containing DataGridView control " +
                    "must be set to a BindingSource (data == null).");
                return;
            }

            // Prevent the data source from notifying the DataGridView of changes
            data.RaiseListChangedEvents = false;

            // Save the original filter
            oldFilter = data.Filter;

            // Remove the filter before building dictionaries
            data.RemoveFilter();

            // Populate filter values for each column
            int index1;
            index1 = excludeColumns.IndexOf("ProductName");
            if (index1 == -1) { productPopulateFilter(); }
            index1 = excludeColumns.IndexOf("CatagoryName");
            if (index1 == -1) { catagoryPopulateFilter(); }
            index1 = excludeColumns.IndexOf("QuantityPerUnit");
            if (index1 == -1) { quantityPopulateFilter(); }
            index1 = excludeColumns.IndexOf("UnitPrice");
            if (index1 == -1) { pricePopulateFilter(); }
            index1 = excludeColumns.IndexOf("ReorderLevel");
            if (index1 == -1) { reorderPopulateFilter(); }

            index1 = excludeColumns.IndexOf("Discontinued");
            if (index1 > -1) { grpDiscontinued.Enabled = false; }

            // Reapply the filter
            data.Filter = oldFilter;

            setCurrentFilters();

            data.RaiseListChangedEvents = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Reapply old filter
            try
            {
                data.Filter = oldFilter;
            }
            catch (InvalidExpressionException ex)
            {
                MessageBox.Show("Apply Filter", "Error reapplying original filter" + ex.ToString());
            }
            this.Close();
        }

        #region "Populate Filters"
        private void productPopulateFilter()
        {
            dgvHeader = _dataGridView.Columns["ProductName"].HeaderCell;
            PopulateFilter(productFilters);

            String[] filterArray = new String[productFilters.Count];
            productFilters.Keys.CopyTo(filterArray, 0);
            cboProduct.Items.Clear();
            cboProduct.Items.AddRange(filterArray);
        }

        private void catagoryPopulateFilter()
        {
            dgvHeader = _dataGridView.Columns["CatagoryName"].HeaderCell;
            PopulateFilter(catagoryFilters);

            String[] filterArray = new String[catagoryFilters.Count];
            catagoryFilters.Keys.CopyTo(filterArray, 0);
            cboCatagory.Items.Clear();
            cboCatagory.Items.AddRange(filterArray);
        }

        private void quantityPopulateFilter()
        {
            dgvHeader = _dataGridView.Columns["QuantityPerUnit"].HeaderCell;
            PopulateFilter(QuantityFilters);

            String[] filterArray = new String[QuantityFilters.Count];
            QuantityFilters.Keys.CopyTo(filterArray, 0);
            cboQuantity.Items.Clear();
            cboQuantity.Items.AddRange(filterArray);
        }

        private void pricePopulateFilter()
        {
            dgvHeader = _dataGridView.Columns["UnitPrice"].HeaderCell;
            PopulateFilter(priceFilters);

            String[] filterArray = new String[priceFilters.Count];
            priceFilters.Keys.CopyTo(filterArray, 0);
            cboPrice.Items.Clear();
            cboPrice.Items.AddRange(filterArray);
        }

        private void reorderPopulateFilter()
        {
            dgvHeader = _dataGridView.Columns["ReorderLevel"].HeaderCell;
            PopulateFilter(reorderFilters);

            String[] filterArray = new String[reorderFilters.Count];
            reorderFilters.Keys.CopyTo(filterArray, 0);
            cboReorder.Items.Clear();
            cboReorder.Items.AddRange(filterArray);
        }

        private void PopulateFilter(System.Collections.Specialized.OrderedDictionary filters)
        {
            string addValue;

            // Reset the filters dictionary and initialize some flags
            // to track whether special filter options are needed. 
            filters.Clear();
            Boolean containsBlanks = false;
            Boolean containsNonBlanks = false;

            // Initialize an ArrayList to store the values in their original
            // types. This enables the values to be sorted appropriately.  
            ArrayList list = new ArrayList(data.Count);

            // Retrieve each value and add it to the ArrayList if it isn't
            // already present. 
            foreach (Object item in data)
            {
                Object value = null;

                // Use the ICustomTypeDescriptor interface to retrieve properties
                // if it is available; otherwise, use reflection. The 
                // ICustomTypeDescriptor interface is useful to customize 
                // which values are exposed as properties. For example, the 
                // DataRowView class implements ICustomTypeDescriptor to expose 
                // cell values as property values.                
                // 
                // Iterate through the property names to find a case-insensitive
                // match with the DataGridViewColumn.DataPropertyName value.
                // This is necessary because DataPropertyName is case-
                // insensitive, but the GetProperties and GetProperty methods
                // used below are case-sensitive.
                ICustomTypeDescriptor ictd = item as ICustomTypeDescriptor;
                if (ictd != null)
                {
                    PropertyDescriptorCollection properties = ictd.GetProperties();
                    foreach (PropertyDescriptor property in properties)
                    {
                        if (String.Compare(dgvHeader.OwningColumn.DataPropertyName,
                            property.Name, true /*case insensitive*/,
                            System.Globalization.CultureInfo.InvariantCulture) == 0)
                        {
                            value = property.GetValue(item);
                            break;
                        }
                    }
                }
                else
                {
                    PropertyInfo[] properties = item.GetType().GetProperties(
                        BindingFlags.Public | BindingFlags.Instance);
                    foreach (PropertyInfo property in properties)
                    {
                        if (String.Compare(dgvHeader.OwningColumn.DataPropertyName,
                           property.Name, true /*case insensitive*/,
                           System.Globalization.CultureInfo.InvariantCulture) == 0)
                        {
                            value = property.GetValue(item, null /*property index*/);
                            break;
                        }
                    }
                }

                // Skip empty values, but note that they are present. 
                if (value == null || value == DBNull.Value)
                {
                    containsBlanks = true;
                    continue;
                }

                // Add values to the ArrayList if they are not already there.
                if (!list.Contains(value))
                {
                    list.Add(value);
                }
            }

            // Sort the ArrayList. The default Sort method uses the IComparable 
            // implementation of the stored values so that string, numeric, and 
            // date values will all be sorted correctly. 
            list.Sort();

            // Convert each value in the ArrayList to its formatted representation
            // and store both the formatted and unformatted string representations
            // in the filters dictionary. 
            foreach (Object value in list)
            {
                // Use the cell's GetFormattedValue method with the column's
                // InheritedStyle property so that the dropDownListBox format
                // will match the display format used for the column's cells. 
                String formattedValue = null;

                Type dataType;
                dataType = _dataGridView.Columns[dgvHeader.OwningColumn.DataPropertyName].ValueType;
                formattedValue = FormatValue(value, dataType);

                if (String.IsNullOrEmpty(formattedValue))
                {
                    // Skip empty values, but note that they are present.
                    containsBlanks = true;
                }
                else if (!filters.Contains(formattedValue))
                {
                    // Note whether non-empty values are present. 
                    containsNonBlanks = true;

                    // For all non-empty values, add the formatted and 
                    // unformatted string representations to the filters 
                    // dictionary.

                    addValue = value.ToString();
                    addValue = addValue.Trim();
                    filters.Add(formattedValue, addValue);
                }
            }

            // Add special filter options to the filters dictionary
            // along with null values, since unformatted representations
            // are not needed. 
            filters.Insert(0, "(All)", null);

            if (containsBlanks && containsNonBlanks)
            {
                filters.Add("(Blanks)", null);
                filters.Add("(NonBlanks)", null);
            }
        }

        private string FormatValue(object value, Type targetType)
        {
            if (targetType == typeof(string))
            {
                return value.ToString();
            }
            if (targetType == typeof(bool))
            {
                return ((bool)value) ? "1" : "0";
            }
            if (targetType == typeof(DateTime))
            {
                return ((DateTime)value).ToString("yyyy'-'MM'-'dd");
            }
            // Numeric Types
            return ((IFormattable)value).ToString(null, NumberFormatInfo.InvariantInfo);
        }
        #endregion

        #region "Set Current Filters"
        private void setCurrentFilters()
        {
            cboProduct.SelectedItem = "(All)";
            cboCatagory.SelectedItem = "(All)";
            cboQuantity.SelectedItem = "(All)";
            cboPrice.SelectedItem = "(All)";
            cboReorder.SelectedItem = "(All)";

            int index1;

            // Disable any excluded columns
            index1 = excludeColumns.IndexOf("ProductName");
            if (index1 != -1) { cboProduct.Enabled = false; }
            index1 = excludeColumns.IndexOf("CatagoryName");
            if (index1 != -1) { cboCatagory.Enabled = false; }
            index1 = excludeColumns.IndexOf("QuantityPerUnit");
            if (index1 != -1) { cboQuantity.Enabled = false; }
            index1 = excludeColumns.IndexOf("UnitPrice");
            if (index1 != -1) { cboPrice.Enabled = false; }
            index1 = excludeColumns.IndexOf("ReorderLevel");
            if (index1 != -1) { cboReorder.Enabled = false; }

            // Get current filter string
            string filterString = oldFilter;
            // If nothing filtered, return
            if (string.IsNullOrEmpty(filterString)) { return; }

            index1 = excludeColumns.IndexOf("ProductName");
            if (index1 == -1)
            {
                dgvHeader = _dataGridView.Columns["ProductName"].HeaderCell;
                cboProduct.SelectedItem = getFilter(filterString);
            }
            else
            {
                cboProduct.Enabled = false;
            }

            index1 = excludeColumns.IndexOf("CatagoryName");
            if (index1 == -1)
            {
                dgvHeader = _dataGridView.Columns["CatagoryName"].HeaderCell;
                cboCatagory.SelectedItem = getFilter(filterString);
            }
            else
            {
                cboCatagory.Enabled = false;
            }

            index1 = excludeColumns.IndexOf("QuantityPerUnit");
            if (index1 == -1)
            {
                dgvHeader = _dataGridView.Columns["QuantityPerUnit"].HeaderCell;
                cboQuantity.SelectedItem = getFilter(filterString);
            }
            else
            {
                cboQuantity.Enabled = false;
            }

            index1 = excludeColumns.IndexOf("UnitPrice");
            if (index1 == -1)
            {
                dgvHeader = _dataGridView.Columns["UnitPrice"].HeaderCell;
                cboPrice.SelectedItem = getFilter(filterString);
            }
            else
            {
                cboPrice.Enabled = false;
            }

            index1 = excludeColumns.IndexOf("ReorderLevel");
            if (index1 == -1)
            {
                dgvHeader = _dataGridView.Columns["ReorderLevel"].HeaderCell;
                cboReorder.SelectedItem = getFilter(filterString);
            }
            else
            {
                cboReorder.Enabled = false;
            }
        }

        private string getFilter(string filterString)
        {
            int index1;
            int index2;
            int index3;

            string dataProperty;
            string colValue;

            dataProperty = dgvHeader.OwningColumn.DataPropertyName.Replace("]", @"\]");
            index1 = filterString.IndexOf(dataProperty);
            if (index1 == -1) // Not filtered
            {
                return "(All)";
            }
            else
            {
                index2 = filterString.IndexOf("'", index1 + 1);
                index3 = filterString.IndexOf("'", index2 + 1);
                colValue = filterString.Substring(index2 + 1, index3 - index2 - 1);
                return colValue;
            }
        }
        #endregion

        #region "Apply Filters"
        private void btnApply_Click(object sender, EventArgs e)
        {
            applyFilters();
        }

        private void applyFilters()
        {
            newFilter = "";

            string _product = (string)cboProduct.SelectedItem;
            string _catagory = (string)cboCatagory.SelectedItem;
            string _quantity = (string)cboQuantity.SelectedItem;
            string _price = (string)cboPrice.SelectedItem;
            string _reorder = (string)cboReorder.SelectedItem;

            if (!string.IsNullOrEmpty(_product) && _product != "(All)")
            {
                dgvHeader = _dataGridView.Columns["ProductName"].HeaderCell;
                setFilter(_product);
            }

            if (!string.IsNullOrEmpty(_catagory) && _catagory != "(All)")
            {
                dgvHeader = _dataGridView.Columns["CatagoryName"].HeaderCell;
                setFilter(_catagory);
            }

            if (!string.IsNullOrEmpty(_quantity) && _quantity != "(All)")
            {
                dgvHeader = _dataGridView.Columns["QuantityPerUnit"].HeaderCell;
                setFilter(_quantity);
            }

            if (!string.IsNullOrEmpty(_price) && _price != "(All)")
            {
                dgvHeader = _dataGridView.Columns["UnitPrice"].HeaderCell;
                setFilter(_price);
            }

            if (!string.IsNullOrEmpty(_reorder) && _reorder != "(All)")
            {
                dgvHeader = _dataGridView.Columns["ReorderLevel"].HeaderCell;
                setFilter(_reorder);
            }

            // Only discontinuted items
            if (rbtnDiscontinuedProducts.Checked)
            {
                dgvHeader = _dataGridView.Columns["Discontinued"].HeaderCell;
                setFilter("(True)");
            }

            // Only non-suspended tasks
            if (rbtnOpenProducts.Checked)
            {
                dgvHeader = _dataGridView.Columns["Discontinued"].HeaderCell;
                setFilter("(False)");
            }

            // Set the filter
            try
            {
                data.Filter = newFilter;
            }
            catch (InvalidExpressionException ex)
            {
                MessageBox.Show("Product Filter", "Error setting filter: " + ex.ToString());
            }
            this.Close();
        }

        private void setFilter(string colValue)
        {
            string colFilter = addFilter(colValue, false);
            if (string.IsNullOrEmpty(newFilter))
            {
                newFilter += colFilter;
            }
            else
            {
                newFilter += " AND " + colFilter;
            }
        }

        private void setFilter(string colValue, bool EndDate)
        {
            string colFilter = addFilter(colValue, EndDate);
            if (string.IsNullOrEmpty(newFilter))
            {
                newFilter += colFilter;
            }
            else
            {
                newFilter += " AND " + colFilter;
            }
        }

        private string addFilter(string colValue, bool EndDate)
        {
            string columnFilter = "";
            string columnProperty = dgvHeader.OwningColumn.DataPropertyName.Replace("]", @"\]");

            switch (colValue)
            {
                case "(Blanks)":
                    columnFilter = string.Format(
                        "ISNULL(CONVERT([{0}], 'System.String'),'NULLVALUE') = 'NULLVALUE'",
                        columnProperty);
                    break;
                case "(NonBlanks)":
                    columnFilter = string.Format(
                        "ISNULL(CONVERT([{0}], 'System.String'),'NULLVALUE') <> 'NULLVALUE'",
                        columnProperty);
                    break;
                case "(False)":
                    columnFilter = string.Format("[{0}]='False'",
                         columnProperty,
                         ((String)colValue).Replace("'", "''"));
                    break;
                case "(True)":
                    columnFilter = string.Format("[{0}]='True'",
                         columnProperty,
                         ((String)colValue).Replace("'", "''"));
                    break;

                default:
                    Type dataType;
                    dataType = _dataGridView.Columns[dgvHeader.OwningColumn.DataPropertyName].ValueType;

                    if (dataType == typeof(DateTime))
                    {
                        if (EndDate)
                        {
                            {
                                DateTime dtm = Convert.ToDateTime(colValue);
                                dtm = dtm.AddDays(1);
                                columnFilter = string.Format("[{0}]< '" + FormatValue(dtm, dataType) + "'", columnProperty);
                            }
                        }
                        else
                        {
                            DateTime dtm = Convert.ToDateTime(colValue);
                            dtm = dtm.AddDays(1);
                            columnFilter = string.Format("[{0}]>='" + colValue + "'", columnProperty);
                        }
                    }
                    else
                    {
                        columnFilter = string.Format("[{0}]='{1}'",
                            columnProperty,
                            ((String)colValue).Replace("'", "''"));
                    }
                    break;
            }
            return columnFilter;
        }
        #endregion
    }
}
