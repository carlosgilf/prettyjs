using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace Bronze.Controls.Examples
{
    partial class TestPopup
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
            this.popup = new Bronze.Controls.VWG.SupperHoverPanel();
            this.popupInner = new Bronze.Controls.VWG.SupperHoverPanel();
            this.popupTop = new Gizmox.WebGUI.Forms.Panel();
            this.lbClose = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.button1 = new Gizmox.WebGUI.Forms.Button();
            this.htmlBox1 = new Gizmox.WebGUI.Forms.HtmlBox();
            this.popup.SuspendLayout();
            this.popupInner.SuspendLayout();
            this.popupTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // popup
            // 
            this.popup.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Bottom | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.popup.ArrowStart = ((uint)(10u));
            this.popup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.popup.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
            this.popup.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125))))));
            this.popup.BoxShadow = new Bronze.Controls.VWG.BoxShadow(System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))), 0, 0, 10);
            this.popup.Controls.Add(this.popupInner);
            this.popup.CustomStyle = "SupperHoverPanelSkin";
            this.popup.DisplayMode = Bronze.Controls.VWG.DisplayMode.Normal;
            this.popup.DockPadding.All = 1;
            this.popup.Location = new System.Drawing.Point(438, 445);
            this.popup.Name = "popup";
            this.popup.OnClientMouseLeave = null;
            this.popup.OnClientMouseOver = null;
            this.popup.Opacity = 100;
            this.popup.Overable = true;
            this.popup.Padding = new Gizmox.WebGUI.Forms.Padding(1);
            this.popup.Radius = new Gizmox.WebGUI.Forms.CornerRadius(6);
            this.popup.RenderRunClientMouseLeave = false;
            this.popup.Size = new System.Drawing.Size(305, 185);
            this.popup.TabIndex = 0;
            // 
            // popupInner
            // 
            this.popupInner.ArrowStart = ((uint)(10u));
            this.popupInner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.popupInner.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
            this.popupInner.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125))))));
            this.popupInner.BoxShadow = new Bronze.Controls.VWG.BoxShadow(System.Drawing.Color.Empty, 0, 0, 0);
            this.popupInner.Controls.Add(this.popupTop);
            this.popupInner.CustomStyle = "SupperHoverPanelSkin";
            this.popupInner.DisplayMode = Bronze.Controls.VWG.DisplayMode.Normal;
            this.popupInner.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.popupInner.Location = new System.Drawing.Point(1, 1);
            this.popupInner.Name = "popupInner";
            this.popupInner.OnClientMouseLeave = null;
            this.popupInner.OnClientMouseOver = null;
            this.popupInner.Opacity = 100;
            this.popupInner.Overable = true;
            this.popupInner.Radius = new Gizmox.WebGUI.Forms.CornerRadius(6);
            this.popupInner.RenderRunClientMouseLeave = false;
            this.popupInner.Size = new System.Drawing.Size(303, 183);
            this.popupInner.TabIndex = 0;
            // 
            // popupTop
            // 
            this.popupTop.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125))))));
            this.popupTop.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.popupTop.BorderWidth = new Gizmox.WebGUI.Forms.BorderWidth(0, 0, 0, 1);
            this.popupTop.Controls.Add(this.lbClose);
            this.popupTop.Controls.Add(this.label1);
            this.popupTop.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.popupTop.Location = new System.Drawing.Point(0, 0);
            this.popupTop.Name = "popupTop";
            this.popupTop.Size = new System.Drawing.Size(303, 27);
            this.popupTop.TabIndex = 1;
            // 
            // lbClose
            // 
            this.lbClose.AutoSize = true;
            this.lbClose.Cursor = Gizmox.WebGUI.Forms.Cursors.Hand;
            this.lbClose.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbClose.Location = new System.Drawing.Point(283, 3);
            this.lbClose.Name = "lbClose";
            this.lbClose.Size = new System.Drawing.Size(35, 13);
            this.lbClose.TabIndex = 1;
            this.lbClose.Text = "°¡";
            // 
            // label1
            // 
            this.label1.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new Gizmox.WebGUI.Forms.Padding(9, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(271, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "œ˚œ¢Ã·–—";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(233, 186);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // htmlBox1
            // 
            this.htmlBox1.ContentType = "text/html";
            this.htmlBox1.Expires = -1;
            this.htmlBox1.Html = "<HTML><div>ddssfs<div></HTML>";
            this.htmlBox1.Location = new System.Drawing.Point(491, 354);
            this.htmlBox1.Name = "htmlBox1";
            this.htmlBox1.Size = new System.Drawing.Size(250, 250);
            this.htmlBox1.TabIndex = 7;
            // 
            // Form5
            // 
            this.Controls.Add(this.button1);
            this.Controls.Add(this.popup);
            this.Controls.Add(this.htmlBox1);
            this.Size = new System.Drawing.Size(750, 636);
            this.Text = "Form5";
            this.popup.ResumeLayout(false);
            this.popupInner.ResumeLayout(false);
            this.popupTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private VWG.SupperHoverPanel popup;
        private Button button1;
        private VWG.SupperHoverPanel popupInner;
        private Label label1;
        private Panel popupTop;
        private Label lbClose;
        private HtmlBox htmlBox1;



    }
}