#define VWG
//
//       FILE:  Form1.cs
//
//     AUTHOR:  Kenneth Minear
//
//
//  Provided By: KennWare Solutions LLC
//               7100 Bellaire Ave.
//               Windsor Heights, IA 50324 USA
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Forms;




namespace GridFilter
{
    public partial class GridFilter : Form
    {
        /// <summary>
        /// Provides an example of filtering a DataGridView
        /// </summary>
        /// 
        /// <remarks>
        /// <para>
        /// 
        /// </para>
        /// </remarks>
        /// 


        private DataTable dtProducts = new DataTable();
        private DataView dvProducts = new DataView();

        // Product DataTable Column Definitions
        DataColumn ProductName = new DataColumn(
            "ProductName", Type.GetType("System.String"));
        DataColumn CatagoryName = new DataColumn(
            "CatagoryName", Type.GetType("System.String"));
        DataColumn QuantityPerUnit = new DataColumn(
            "QuantityPerUnit", Type.GetType("System.String"));
        DataColumn UnitPrice = new DataColumn(
            "UnitPrice", Type.GetType("System.Decimal"));
        DataColumn ReorderLevel = new DataColumn(
            "ReorderLevel", Type.GetType("System.Decimal"));
        DataColumn Discontinued = new DataColumn(
            "Discontinued", Type.GetType("System.Boolean"));




        public GridFilter()
        {
            InitializeComponent();

            // Wire up an event handler so we can display the count of items in the grid when a filter changes it
            dgProducts.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgProducts_DataBindingComplete);

            buildProductTable();
            buildProductGrid();
        }

        #region "Build Product Table"
        private void buildProductTable()
        {
            // Name the table and add the columns
            dtProducts.TableName = "dtProducts";
            dtProducts.Columns.Add(ProductName);
            dtProducts.Columns.Add(CatagoryName);
            dtProducts.Columns.Add(QuantityPerUnit);
            dtProducts.Columns.Add(UnitPrice);
            dtProducts.Columns.Add(ReorderLevel);
            dtProducts.Columns.Add(Discontinued);

            // Now add some sample data to the table
            DataRow newRow;

            // Add a row
            newRow = dtProducts.NewRow();
            newRow[ProductName] = "Coke";
            newRow[CatagoryName] = "Beverages";
            newRow[QuantityPerUnit] = "24 -12 oz bottles";
            newRow[UnitPrice] = (decimal)19;
            newRow[ReorderLevel] = (decimal)25;
            newRow[Discontinued] = false;
            dtProducts.Rows.Add(newRow);

            // Add a row
            newRow = dtProducts.NewRow();
            newRow[ProductName] = "Shrimp";
            newRow[CatagoryName] = "Seafood";
            newRow[QuantityPerUnit] = "24 - 250 g jars";
            newRow[UnitPrice] = (decimal)19;
            newRow[ReorderLevel] = (decimal)20;
            newRow[Discontinued] = false;
            dtProducts.Rows.Add(newRow);

            // Add a row
            newRow = dtProducts.NewRow();
            newRow[ProductName] = "Sprite";
            newRow[CatagoryName] = "Beverages";
            newRow[QuantityPerUnit] = "24 -12 oz bottles";
            newRow[UnitPrice] = (decimal)19;
            newRow[ReorderLevel] = (decimal)25;
            newRow[Discontinued] = false;
            dtProducts.Rows.Add(newRow);

            // Add a row
            newRow = dtProducts.NewRow();
            newRow[ProductName] = "Tuna";
            newRow[CatagoryName] = "Seafood";
            newRow[QuantityPerUnit] = "12 - Packages";
            newRow[UnitPrice] = (decimal)26;
            newRow[ReorderLevel] = (decimal)34;
            newRow[Discontinued] = false;
            dtProducts.Rows.Add(newRow);

            // Add a row
            newRow = dtProducts.NewRow();
            newRow[ProductName] = "Mackeral";
            newRow[CatagoryName] = "Seafood";
            newRow[QuantityPerUnit] = "12 - Ounces";
            newRow[UnitPrice] = (decimal)40;
            newRow[ReorderLevel] = (decimal)62;
            newRow[Discontinued] = true;
            dtProducts.Rows.Add(newRow);

        }
        #endregion

        #region "Build Product DataGridView"
        private void buildProductGrid()
        {
            // Bind Grid to DataTable
            try
            {
                // If rows in grid already exist, clear them
                dgProducts.DataSource = null;
                dgProducts.Rows.Clear();

                // Relate the DataView to a DataTable
                dvProducts.Table = dtProducts;

                // This is the default sort, you can change the sort by clicking on any column header
                dvProducts.Sort = "ProductName";

                // Relate the binding source to the dataview
                bsProducts.DataSource = dvProducts;

                // Relate the DataGridView to the binding source
                dgProducts.DataSource = bsProducts;

            }
            catch (Exception exc)
            {
                MessageBox.Show("Create Products Datagrid", "Error binding grid: " + exc.ToString());
            }
        }
        #endregion

        #region "Clear the filter for the DataGridView"
        private void btnClear_Click(object sender, EventArgs e)
        {
            bsProducts.RemoveFilter();
#if VWG
            dgProducts_Rebind();
#endif
        }
        #endregion

        #region "Rebind The DataGridView"
        private void dgProducts_Rebind()
        {
            // Rebind grid to bindingsource
            // Note: Gizmox said I shouldn't have to do this
            // but in v6.3 I found I did, I don't know if this
            // is necessary in v6.4
            dgProducts.DataSource = null;
            dgProducts.DataSource = bsProducts;
        }
        #endregion

        #region "Set the filter for the DataGridView"
        private void btnSet_Click(object sender, EventArgs e)
        {
            ProductFilter ifilter = new ProductFilter(ref dgProducts, "");
#if VWG
            ifilter.Closed += new EventHandler(ifilter_Closed);
#endif
                ifilter.ShowDialog();
                ifilter = null;
        }

        private void ifilter_Closed(object sender, EventArgs e)
        {
            dgProducts_Rebind();
        }

        #endregion

        #region "Binding Complete, show total items displayed"
        private void dgProducts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Int32 dataRowCount; // Un-filtered count
            Int32 currentRowCount; // Filtered count
            string _saveFilter;
            _saveFilter = bsProducts.Filter;
            currentRowCount = bsProducts.Count; // Filtered count
            bsProducts.RaiseListChangedEvents = false;
            bsProducts.Filter = null;
            dataRowCount = bsProducts.Count; // Un-filtered count
            bsProducts.Filter = _saveFilter;
            bsProducts.RaiseListChangedEvents = true;

            string _filterMsg = String.Format("{0} of {1} items displayed", currentRowCount, dataRowCount);
            string _totalMsg = String.Format("{0} items displayed", dataRowCount);
            if (dataRowCount != currentRowCount)
            {
                lblDisplayCount.Text = _filterMsg;
                lblDisplayCount.Visible = true;
            }
            else
            {
                if (dataRowCount > 0)
                {
                    lblDisplayCount.Text = _totalMsg;
                    lblDisplayCount.Visible = true;
                }
                else
                {
                    lblDisplayCount.Visible = false;
                }
            }
        #endregion
        }
    }
}
