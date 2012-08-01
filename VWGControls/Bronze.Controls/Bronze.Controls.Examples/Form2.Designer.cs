using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Bronze.Controls.Examples
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
            this.supperPanel1 = new Bronze.Controls.VWG.SupperPanel();
            this.treeView1 = new Gizmox.WebGUI.Forms.TreeView();
            this.treeNode1 = new Gizmox.WebGUI.Forms.TreeNode();
            this.treeNode4 = new Gizmox.WebGUI.Forms.TreeNode();
            this.treeNode5 = new Gizmox.WebGUI.Forms.TreeNode();
            this.treeNode6 = new Gizmox.WebGUI.Forms.TreeNode();
            this.treeNode2 = new Gizmox.WebGUI.Forms.TreeNode();
            this.treeNode3 = new Gizmox.WebGUI.Forms.TreeNode();
            this.supperPanel2 = new Bronze.Controls.VWG.SupperPanel();
            this.supperPanel3 = new Bronze.Controls.VWG.SupperPanel();
            this.supperPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // supperPanel1
            // 
            this.supperPanel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.supperPanel1.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Gray);
            this.supperPanel1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.supperPanel1.BoxShadow = new Bronze.Controls.VWG.BoxShadow(System.Drawing.Color.Empty, 0, 0, 0);
            this.supperPanel1.Controls.Add(this.treeView1);
            this.supperPanel1.CustomStyle = "SupperPanelSkin";
            this.supperPanel1.DisplayMode = Bronze.Controls.VWG.DisplayMode.Normal;
            this.supperPanel1.Location = new System.Drawing.Point(27, 20);
            this.supperPanel1.Name = "supperPanel1";
            this.supperPanel1.Radius = new Gizmox.WebGUI.Forms.CornerRadius(3);
            this.supperPanel1.Size = new System.Drawing.Size(294, 448);
            this.supperPanel1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(13, 20);
            this.treeView1.Name = "treeView1";
            this.treeView1.Nodes.AddRange(new Gizmox.WebGUI.Forms.TreeNode[] {
            this.treeNode1,
            this.treeNode2,
            this.treeNode3});
            this.treeView1.Size = new System.Drawing.Size(266, 409);
            this.treeView1.TabIndex = 0;
            // 
            // treeNode1
            // 
            this.treeNode1.CheckBox = Gizmox.WebGUI.Forms.CheckBoxVisibility.Inherited;
            this.treeNode1.Name = "treeNode1";
            this.treeNode1.Nodes.AddRange(new Gizmox.WebGUI.Forms.TreeNode[] {
            this.treeNode4,
            this.treeNode5,
            this.treeNode6});
            this.treeNode1.Text = "treeNode1";
            this.treeNode1.ToolTipText = "";
            // 
            // treeNode4
            // 
            this.treeNode4.CheckBox = Gizmox.WebGUI.Forms.CheckBoxVisibility.Inherited;
            this.treeNode4.Name = "treeNode4";
            this.treeNode4.Text = "treeNode4";
            this.treeNode4.ToolTipText = "";
            // 
            // treeNode5
            // 
            this.treeNode5.CheckBox = Gizmox.WebGUI.Forms.CheckBoxVisibility.Inherited;
            this.treeNode5.Name = "treeNode5";
            this.treeNode5.Text = "treeNode5";
            this.treeNode5.ToolTipText = "";
            // 
            // treeNode6
            // 
            this.treeNode6.CheckBox = Gizmox.WebGUI.Forms.CheckBoxVisibility.Inherited;
            this.treeNode6.Name = "treeNode6";
            this.treeNode6.Text = "treeNode6";
            this.treeNode6.ToolTipText = "";
            // 
            // treeNode2
            // 
            this.treeNode2.CheckBox = Gizmox.WebGUI.Forms.CheckBoxVisibility.Inherited;
            this.treeNode2.Name = "treeNode2";
            this.treeNode2.Text = "treeNode2";
            this.treeNode2.ToolTipText = "";
            // 
            // treeNode3
            // 
            this.treeNode3.CheckBox = Gizmox.WebGUI.Forms.CheckBoxVisibility.Inherited;
            this.treeNode3.Name = "treeNode3";
            this.treeNode3.Text = "treeNode3";
            this.treeNode3.ToolTipText = "";
            // 
            // supperPanel2
            // 
            this.supperPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.supperPanel2.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.supperPanel2.BoxShadow = new Bronze.Controls.VWG.BoxShadow(System.Drawing.Color.Gray, 5, 5, 5);
            this.supperPanel2.CustomStyle = "SupperPanelSkin";
            this.supperPanel2.DisplayMode = Bronze.Controls.VWG.DisplayMode.Normal;
            this.supperPanel2.Location = new System.Drawing.Point(387, 93);
            this.supperPanel2.Name = "supperPanel2";
            this.supperPanel2.Radius = new Gizmox.WebGUI.Forms.CornerRadius(5);
            this.supperPanel2.Size = new System.Drawing.Size(200, 100);
            this.supperPanel2.TabIndex = 1;
            // 
            // supperPanel3
            // 
            this.supperPanel3.BackColor = System.Drawing.Color.DarkGray;
            this.supperPanel3.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.supperPanel3.BoxShadow = new Bronze.Controls.VWG.BoxShadow(System.Drawing.Color.Teal, 0, 0, 3);
            this.supperPanel3.CustomStyle = "SupperPanelSkin";
            this.supperPanel3.DisplayMode = Bronze.Controls.VWG.DisplayMode.Normal;
            this.supperPanel3.Location = new System.Drawing.Point(387, 262);
            this.supperPanel3.Name = "supperPanel3";
            this.supperPanel3.Radius = new Gizmox.WebGUI.Forms.CornerRadius(0);
            this.supperPanel3.Size = new System.Drawing.Size(200, 100);
            this.supperPanel3.TabIndex = 2;
            // 
            // Form2
            // 
            this.Controls.Add(this.supperPanel3);
            this.Controls.Add(this.supperPanel2);
            this.Controls.Add(this.supperPanel1);
            this.Size = new System.Drawing.Size(694, 568);
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.supperPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private VWG.SupperPanel supperPanel1;
        private TreeView treeView1;
        private TreeNode treeNode1;
        private TreeNode treeNode4;
        private TreeNode treeNode5;
        private TreeNode treeNode6;
        private TreeNode treeNode2;
        private TreeNode treeNode3;
        private VWG.SupperPanel supperPanel2;
        private VWG.SupperPanel supperPanel3;


    }
}