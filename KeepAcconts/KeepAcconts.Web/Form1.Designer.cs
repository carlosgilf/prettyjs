namespace KeepAcconts.Web
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new Gizmox.WebGUI.Forms.Button();
            this.dataGridView1 = new Gizmox.WebGUI.Forms.DataGridView();
            this.txtUserName = new Gizmox.WebGUI.Forms.TextBox();
            this.txtLoginName = new Gizmox.WebGUI.Forms.TextBox();
            this.navBar1 = new KeepAcconts.Web.UI.NavBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(499, 246);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.dataGridView1.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 9);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(565, 208);
            this.dataGridView1.TabIndex = 1;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(48, 246);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 21);
            this.txtUserName.TabIndex = 2;
            // 
            // txtLoginName
            // 
            this.txtLoginName.Location = new System.Drawing.Point(181, 246);
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.Size = new System.Drawing.Size(100, 21);
            this.txtLoginName.TabIndex = 3;
            // 
            // navBar1
            // 
            this.navBar1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.navBar1.Location = new System.Drawing.Point(254, 270);
            this.navBar1.Name = "navBar1";
            this.navBar1.Size = new System.Drawing.Size(257, 109);
            this.navBar1.TabIndex = 4;
            this.navBar1.Text = "NavBar";
            // 
            // Form1
            // 
            this.Controls.Add(this.navBar1);
            this.Controls.Add(this.txtLoginName);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.SizableToolWindow;
            this.Size = new System.Drawing.Size(656, 404);
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Button button1;
        private Gizmox.WebGUI.Forms.DataGridView dataGridView1;
        private Gizmox.WebGUI.Forms.TextBox txtUserName;
        private Gizmox.WebGUI.Forms.TextBox txtLoginName;
        private KeepAcconts.Web.UI.NavBar navBar1;
    }
}