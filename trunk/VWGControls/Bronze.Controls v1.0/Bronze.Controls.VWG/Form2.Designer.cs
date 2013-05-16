using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Bronze.Controls.VWG
{
    partial class Form2
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
            this.hoverPanel1 = new Bronze.Controls.VWG.SupperHoverPanel();
            this.SuspendLayout();
            // 
            // hoverPanel1
            // 
            this.hoverPanel1.BoxShadow = new Bronze.Controls.VWG.BoxShadow(System.Drawing.Color.Empty, 0, 0, 0);
            this.hoverPanel1.CustomStyle = "SupperHoverPanelSkin";
            this.hoverPanel1.DisplayMode = Bronze.Controls.VWG.DisplayMode.Normal;
            this.hoverPanel1.Location = new System.Drawing.Point(79, 87);
            this.hoverPanel1.Name = "hoverPanel1";
            this.hoverPanel1.OnClientMouseLeave = null;
            this.hoverPanel1.OnClientMouseOver = null;
            this.hoverPanel1.Opacity = 100;
            this.hoverPanel1.Overable = true;
            this.hoverPanel1.Radius = new Gizmox.WebGUI.Forms.CornerRadius(0);
            this.hoverPanel1.RenderRunClientMouseLeave = false;
            this.hoverPanel1.Size = new System.Drawing.Size(233, 174);
            this.hoverPanel1.TabIndex = 0;
            // 
            // Form2
            // 
            this.Controls.Add(this.hoverPanel1);
            this.Size = new System.Drawing.Size(419, 466);
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private SupperHoverPanel hoverPanel1;


    }
}