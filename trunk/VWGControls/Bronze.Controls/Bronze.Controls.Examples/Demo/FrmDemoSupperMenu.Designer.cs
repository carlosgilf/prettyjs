using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Bronze.Controls.Examples
{
    partial class FrmDemoSupperMenu
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
            this.supperMenu1 = new Bronze.Controls.Examples.SimpleMenu.SupperMenu();
            this.dataGridView1 = new Gizmox.WebGUI.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // supperMenu1
            // 
            this.supperMenu1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)
                        | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.supperMenu1.Animate = "dropDown,dropUp";
            this.supperMenu1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.supperMenu1.Location = new System.Drawing.Point(9, 54);
            this.supperMenu1.Name = "supperMenu1";
            this.supperMenu1.Size = new System.Drawing.Size(820, 50);
            this.supperMenu1.TabIndex = 0;
            this.supperMenu1.Text = "SupperMenu";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(96, 117);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("zh-CN");
            this.dataGridView1.Size = new System.Drawing.Size(309, 207);
            this.dataGridView1.TabIndex = 1;
            // 
            // FrmDemoSupperMenu
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.supperMenu1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(838, 466);
            this.Text = "FrmDemoSupperMenu";
            this.Load += new System.EventHandler(this.FrmDemoSupperMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bronze.Controls.Examples.SimpleMenu.SupperMenu supperMenu1;
        private DataGridView dataGridView1;


    }
}