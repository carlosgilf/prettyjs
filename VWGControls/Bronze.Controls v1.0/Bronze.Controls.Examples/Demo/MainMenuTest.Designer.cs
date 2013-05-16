using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Bronze.Controls.Examples.Demo
{
    partial class MainMenuTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuTest));
            this.mainMenu1 = new Bronze.Controls.Examples.Menu.MainMenu();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.Animate = "dropDown,dropUp";
            this.mainMenu1.CustomStyle = "SupperPanelSkin";
            this.mainMenu1.DisplayMode = Bronze.Controls.VWG.DisplayMode.Normal;
            this.mainMenu1.Location = new System.Drawing.Point(31, 31);
            this.mainMenu1.Name = "mainMenu1";
            this.mainMenu1.Size = new System.Drawing.Size(634, 40);
            this.mainMenu1.TabIndex = 0;
            // 
            // MainMenuTest
            // 
            this.Controls.Add(this.mainMenu1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(697, 466);
            this.Text = "MainMenuTest";
            this.Load += new System.EventHandler(this.MainMenuTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Menu.MainMenu mainMenu1;



    }
}