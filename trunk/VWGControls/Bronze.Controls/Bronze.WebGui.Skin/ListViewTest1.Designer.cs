using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Bronze.WebGui.Skin
{
    partial class ListViewTest1
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
            this.toolBar1 = new Gizmox.WebGUI.Forms.ToolBar();
            this.button1 = new Gizmox.WebGUI.Forms.Button();
            this.toolBarButton1 = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.toolBarButton2 = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.toolBarButton3 = new Gizmox.WebGUI.Forms.ToolBarButton();
            this.SuspendLayout();
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.toolBar1.Buttons.AddRange(new Gizmox.WebGUI.Forms.ToolBarButton[] {
            this.toolBarButton1,
            this.toolBarButton2,
            this.toolBarButton3});
            this.toolBar1.DragHandle = true;
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageSize = new System.Drawing.Size(16, 16);
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.MenuHandle = true;
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(662, 42);
            this.toolBar1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.Right;
            this.button1.Location = new System.Drawing.Point(556, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.CustomStyle = "";
            this.toolBarButton1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Size = 24;
            this.toolBarButton1.Text = "sss";
            this.toolBarButton1.ToolTipText = "";
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.CustomStyle = "";
            this.toolBarButton2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Size = 24;
            this.toolBarButton2.Text = "ddd";
            this.toolBarButton2.ToolTipText = "";
            // 
            // toolBarButton3
            // 
            this.toolBarButton3.CustomStyle = "";
            this.toolBarButton3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.toolBarButton3.Name = "toolBarButton3";
            this.toolBarButton3.Size = 24;
            this.toolBarButton3.Text = "eee";
            this.toolBarButton3.ToolTipText = "";
            // 
            // ListViewTest1
            // 
            this.Controls.Add(this.button1);
            this.Controls.Add(this.toolBar1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(662, 495);
            this.Text = "ListViewTest1";
            this.ResumeLayout(false);

        }

        #endregion

        private ToolBar toolBar1;
        private Button button1;
        private ToolBarButton toolBarButton1;
        private ToolBarButton toolBarButton2;
        private ToolBarButton toolBarButton3;


    }
}