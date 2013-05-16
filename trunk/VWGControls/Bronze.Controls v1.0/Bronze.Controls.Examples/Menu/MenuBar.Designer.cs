using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Bronze.Controls.Examples
{
    partial class MenuBar
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

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuBar));
            this.buttonLayout = new Bronze.Controls.VWG.SupperPanel();
            this.SuspendLayout();
            // 
            // buttonLayout
            // 
            this.buttonLayout.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("buttonLayout.BackgroundImage"));
            this.buttonLayout.BoxShadow = new Bronze.Controls.VWG.BoxShadow(System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))), 5, 5, 10);
            this.buttonLayout.CustomStyle = "HoverPanelSkin";
            this.buttonLayout.DisplayMode = Bronze.Controls.VWG.DisplayMode.Normal;
            this.buttonLayout.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.buttonLayout.Location = new System.Drawing.Point(0, 0);
            this.buttonLayout.Name = "buttonLayout";
            this.buttonLayout.Radius = new Gizmox.WebGUI.Forms.CornerRadius(10);
            this.buttonLayout.Size = new System.Drawing.Size(698, 40);
            this.buttonLayout.TabIndex = 2;
            // 
            // MenuBar
            // 
            this.Controls.Add(this.buttonLayout);
            this.Size = new System.Drawing.Size(698, 40);
            this.Text = "SupperMenu";
            this.Load += new System.EventHandler(this.SupperMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Bronze.Controls.VWG.SupperPanel buttonLayout;



    }
}