using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Bronze.Controls.Examples
{
    partial class SelectorTextboxListTest
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
            this.selectorTextboxList1 = new Bronze.Controls.VWG.SelectorTextboxList();
            this.SuspendLayout();
            // 
            // selectorTextboxList1
            // 
            this.selectorTextboxList1.CustomStyle = "SelectorTextboxListSkin";
            this.selectorTextboxList1.Location = new System.Drawing.Point(25, 32);
            this.selectorTextboxList1.Name = "selectorTextboxList1";
            this.selectorTextboxList1.Size = new System.Drawing.Size(520, 184);
            this.selectorTextboxList1.TabIndex = 0;
            // 
            // SelectorTextboxListTest
            // 
            this.Controls.Add(this.selectorTextboxList1);
            this.Size = new System.Drawing.Size(567, 466);
            this.Text = "SelectorTextboxListTest";
            this.Load += new System.EventHandler(this.SelectorTextboxListTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private VWG.SelectorTextboxList selectorTextboxList1;


    }
}