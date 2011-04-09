using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace KeepAcconts.Web
{
    partial class ListViewCheckAll
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

        #region Visual WebGui Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numCount = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.btnApply = new Gizmox.WebGUI.Forms.Button();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.listView1 = new KeepAcconts.Web.CListView();
            ((System.ComponentModel.ISupportInitialize)(this.numCount)).BeginInit();
            this.SuspendLayout();
            // 
            // numCount
            // 
            this.numCount.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.numCount.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.numCount.CurrentValue = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numCount.CurrentValueChanged = false;
            this.numCount.Location = new System.Drawing.Point(123, 15);
            this.numCount.Name = "numCount";
            this.numCount.Size = new System.Drawing.Size(83, 20);
            this.numCount.TabIndex = 1;
            this.numCount.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            this.numCount.UpDownAlign = Gizmox.WebGUI.Forms.LeftRightAlignment.Right;
            this.numCount.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(216, 15);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Set display row count";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.listView1.AutoGenerateColumns = true;
            this.listView1.CheckBoxes = true;
            this.listView1.DataMember = null;
            this.listView1.GridLines = true;
            this.listView1.ItemsPerPage = 20;
            this.listView1.Location = new System.Drawing.Point(9, 51);
            this.listView1.Name = "listView1";
            this.listView1.RowHeight = 50;
            this.listView1.ShowItemToolTips = false;
            this.listView1.Size = new System.Drawing.Size(602, 394);
            this.listView1.TabIndex = 0;
            // 
            // ListViewCheckAll
            // 
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.numCount);
            this.Controls.Add(this.listView1);
            this.Size = new System.Drawing.Size(620, 466);
            this.Text = "ListViewCheckAll";
            this.Load += new System.EventHandler(this.ListViewCheckAll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CListView listView1;
        private NumericUpDown numCount;
        private Button btnApply;
        private Label label1;


    }
}