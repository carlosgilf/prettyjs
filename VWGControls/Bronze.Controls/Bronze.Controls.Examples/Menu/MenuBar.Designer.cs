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
            this.buttonLayout = new Bronze.Controls.VWG.HoverPanel();
            this.SuspendLayout();
            // 
            // buttonLayout
            // 
            this.buttonLayout.BackgroundImage = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("buttonLayout.BackgroundImage"));
            this.buttonLayout.CustomStyle = "HoverPanelSkin";
            this.buttonLayout.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.buttonLayout.Hidden = false;
            this.buttonLayout.Location = new System.Drawing.Point(0, 0);
            this.buttonLayout.Name = "buttonLayout";
            this.buttonLayout.OnClientMouseLeave = null;
            this.buttonLayout.OnClientMouseOver = null;
            this.buttonLayout.Overable = true;
            this.buttonLayout.Radius = new Gizmox.WebGUI.Forms.CornerRadius(10);
            this.buttonLayout.RenderRunClientMouseLeave = false;
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

        private Bronze.Controls.VWG.HoverPanel buttonLayout;



    }
}