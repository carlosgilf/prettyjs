namespace GridFilter
{
    partial class ProductFilter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboProduct = new Gizmox.WebGUI.Forms.ComboBox();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.btnApply = new Gizmox.WebGUI.Forms.Button();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.btnClose = new Gizmox.WebGUI.Forms.Button();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.cboPrice = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboQuantity = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboCatagory = new Gizmox.WebGUI.Forms.ComboBox();
            this.grpDiscontinued = new Gizmox.WebGUI.Forms.GroupBox();
            this.rbtnDiscontinuedProducts = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbtnOpenProducts = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbtnProductsAll = new Gizmox.WebGUI.Forms.RadioButton();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.cboReorder = new Gizmox.WebGUI.Forms.ComboBox();
            this.grpDiscontinued.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboProduct
            // 
            this.cboProduct.FormattingEnabled = true;
            this.cboProduct.Location = new System.Drawing.Point(113, 25);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Size = new System.Drawing.Size(242, 21);
            this.cboProduct.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 51;
            this.label6.Text = "Product Name";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(97, 284);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(78, 23);
            this.btnApply.TabIndex = 9;
            this.btnApply.Text = "Apply Filters";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Unit Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Quantity Per Unit";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(218, 284);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Cancel";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Catagory Name";
            // 
            // cboPrice
            // 
            this.cboPrice.FormattingEnabled = true;
            this.cboPrice.Location = new System.Drawing.Point(113, 126);
            this.cboPrice.Name = "cboPrice";
            this.cboPrice.Size = new System.Drawing.Size(242, 21);
            this.cboPrice.TabIndex = 8;
            // 
            // cboQuantity
            // 
            this.cboQuantity.FormattingEnabled = true;
            this.cboQuantity.Location = new System.Drawing.Point(113, 92);
            this.cboQuantity.Name = "cboQuantity";
            this.cboQuantity.Size = new System.Drawing.Size(242, 21);
            this.cboQuantity.TabIndex = 7;
            // 
            // cboCatagory
            // 
            this.cboCatagory.FormattingEnabled = true;
            this.cboCatagory.Location = new System.Drawing.Point(113, 58);
            this.cboCatagory.Name = "cboCatagory";
            this.cboCatagory.Size = new System.Drawing.Size(242, 21);
            this.cboCatagory.TabIndex = 6;
            // 
            // grpDiscontinued
            // 
            this.grpDiscontinued.Controls.Add(this.rbtnDiscontinuedProducts);
            this.grpDiscontinued.Controls.Add(this.rbtnOpenProducts);
            this.grpDiscontinued.Controls.Add(this.rbtnProductsAll);
            this.grpDiscontinued.Location = new System.Drawing.Point(17, 213);
            this.grpDiscontinued.Name = "grpDiscontinued";
            this.grpDiscontinued.Size = new System.Drawing.Size(354, 48);
            this.grpDiscontinued.TabIndex = 54;
            this.grpDiscontinued.TabStop = false;
            this.grpDiscontinued.Text = "Discontinued";
            // 
            // rbtnDiscontinuedProducts
            // 
            this.rbtnDiscontinuedProducts.AutoSize = true;
            this.rbtnDiscontinuedProducts.Location = new System.Drawing.Point(208, 19);
            this.rbtnDiscontinuedProducts.Name = "rbtnDiscontinuedProducts";
            this.rbtnDiscontinuedProducts.Size = new System.Drawing.Size(132, 17);
            this.rbtnDiscontinuedProducts.TabIndex = 2;
            this.rbtnDiscontinuedProducts.Text = "Discontinued Products";
            this.rbtnDiscontinuedProducts.UseVisualStyleBackColor = true;
            // 
            // rbtnOpenProducts
            // 
            this.rbtnOpenProducts.AutoSize = true;
            this.rbtnOpenProducts.Location = new System.Drawing.Point(106, 19);
            this.rbtnOpenProducts.Name = "rbtnOpenProducts";
            this.rbtnOpenProducts.Size = new System.Drawing.Size(96, 17);
            this.rbtnOpenProducts.TabIndex = 1;
            this.rbtnOpenProducts.Text = "Open Products";
            this.rbtnOpenProducts.UseVisualStyleBackColor = true;
            // 
            // rbtnProductsAll
            // 
            this.rbtnProductsAll.AutoSize = true;
            this.rbtnProductsAll.Checked = true;
            this.rbtnProductsAll.Location = new System.Drawing.Point(6, 19);
            this.rbtnProductsAll.Name = "rbtnProductsAll";
            this.rbtnProductsAll.Size = new System.Drawing.Size(81, 17);
            this.rbtnProductsAll.TabIndex = 0;
            this.rbtnProductsAll.TabStop = true;
            this.rbtnProductsAll.Text = "All Products";
            this.rbtnProductsAll.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 56;
            this.label4.Text = "Reorder Level";
            // 
            // cboReorder
            // 
            this.cboReorder.FormattingEnabled = true;
            this.cboReorder.Location = new System.Drawing.Point(113, 164);
            this.cboReorder.Name = "cboReorder";
            this.cboReorder.Size = new System.Drawing.Size(242, 21);
            this.cboReorder.TabIndex = 55;
            // 
            // ProductFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = Gizmox.WebGUI.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(396, 324);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboReorder);
            this.Controls.Add(this.grpDiscontinued);
            this.Controls.Add(this.cboProduct);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboPrice);
            this.Controls.Add(this.cboQuantity);
            this.Controls.Add(this.cboCatagory);
            this.Name = "ProductFilter";
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Filter";
            this.Load += new System.EventHandler(this.ProductFilter_Load);
            this.grpDiscontinued.ResumeLayout(false);
            this.grpDiscontinued.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Gizmox.WebGUI.Forms.ComboBox cboProduct;
        private Gizmox.WebGUI.Forms.Label label6;
        private Gizmox.WebGUI.Forms.Button btnApply;
        private Gizmox.WebGUI.Forms.Label label3;
        private Gizmox.WebGUI.Forms.Label label2;
        private Gizmox.WebGUI.Forms.Button btnClose;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.ComboBox cboPrice;
        private Gizmox.WebGUI.Forms.ComboBox cboQuantity;
        private Gizmox.WebGUI.Forms.ComboBox cboCatagory;
        private Gizmox.WebGUI.Forms.GroupBox grpDiscontinued;
        private Gizmox.WebGUI.Forms.RadioButton rbtnDiscontinuedProducts;
        private Gizmox.WebGUI.Forms.RadioButton rbtnOpenProducts;
        private Gizmox.WebGUI.Forms.RadioButton rbtnProductsAll;
        private Gizmox.WebGUI.Forms.Label label4;
        private Gizmox.WebGUI.Forms.ComboBox cboReorder;
    }
}