using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace KeepAcconts.Web
{
    partial class PathLinker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PathLinker));
            this.btnRoot = new Gizmox.WebGUI.Forms.Button();
            this.button2 = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRoot
            // 
            this.btnRoot.CustomStyle = "F";
            this.btnRoot.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.btnRoot.Font = new System.Drawing.Font("ËÎÌå", 9F);
            this.btnRoot.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRoot.Location = new System.Drawing.Point(7, 4);
            this.btnRoot.Name = "btnRoot";
            this.btnRoot.Size = new System.Drawing.Size(44, 23);
            this.btnRoot.TabIndex = 0;
            this.btnRoot.Text = "¸ùÂ·¾¶";
            this.btnRoot.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.CustomStyle = "F";
            this.button2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.button2.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("button2.Image"));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(50, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(13, 23);
            this.button2.TabIndex = 0;
            // 
            // PathLinker
            // 
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnRoot);
            this.Size = new System.Drawing.Size(561, 35);
            this.Text = "PathLinker";
            this.Load += new System.EventHandler(this.PathLinker_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnRoot;
        private Button button2;



    }
}