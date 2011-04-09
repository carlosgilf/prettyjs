namespace GridFilter
{
    partial class GridFilter
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
            this.components = new System.ComponentModel.Container();
            this.dgProducts = new Gizmox.WebGUI.Forms.DataGridView();
            this.bsProducts = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            this.btnClear = new Gizmox.WebGUI.Forms.Button();
            this.btnSet = new Gizmox.WebGUI.Forms.Button();
            this.lblDisplayCount = new Gizmox.WebGUI.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgProducts
            // 
            this.dgProducts.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProducts.Location = new System.Drawing.Point(12, 74);
            this.dgProducts.Name = "dgProducts";
            this.dgProducts.Size = new System.Drawing.Size(882, 439);
            this.dgProducts.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(120, 36);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear Filter";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(25, 36);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 2;
            this.btnSet.Text = "Set Filter";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // lblDisplayCount
            // 
            this.lblDisplayCount.AutoSize = true;
            this.lblDisplayCount.Location = new System.Drawing.Point(228, 41);
            this.lblDisplayCount.Name = "lblDisplayCount";
            this.lblDisplayCount.Size = new System.Drawing.Size(87, 13);
            this.lblDisplayCount.TabIndex = 79;
            this.lblDisplayCount.Text = "0 items displayed";
            // 
            // GridFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = Gizmox.WebGUI.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 536);
            this.Controls.Add(this.lblDisplayCount);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dgProducts);
            this.Name = "GridFilter";
            this.Text = "Grid Filter Example";
            ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Gizmox.WebGUI.Forms.DataGridView dgProducts;
        private Gizmox.WebGUI.Forms.BindingSource bsProducts;
        private Gizmox.WebGUI.Forms.Button btnClear;
        private Gizmox.WebGUI.Forms.Button btnSet;
        private Gizmox.WebGUI.Forms.Label lblDisplayCount;
    }
}

