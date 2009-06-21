namespace TestJsParser
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtActivePos = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rbSql = new System.Windows.Forms.RadioButton();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.cbIndent = new System.Windows.Forms.ComboBox();
            this.rbJS = new System.Windows.Forms.RadioButton();
            this.cbStyle = new System.Windows.Forms.ComboBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFormat = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtActivePos
            // 
            this.txtActivePos.Location = new System.Drawing.Point(644, 27);
            this.txtActivePos.Name = "txtActivePos";
            this.txtActivePos.Size = new System.Drawing.Size(70, 21);
            this.txtActivePos.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(538, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // rbSql
            // 
            this.rbSql.AutoSize = true;
            this.rbSql.Location = new System.Drawing.Point(431, 27);
            this.rbSql.Name = "rbSql";
            this.rbSql.Size = new System.Drawing.Size(41, 16);
            this.rbSql.TabIndex = 7;
            this.rbSql.Text = "SQL";
            this.rbSql.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.Location = new System.Drawing.Point(0, 201);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(730, 348);
            this.richTextBox2.TabIndex = 10;
            this.richTextBox2.Text = "";
            // 
            // cbIndent
            // 
            this.cbIndent.FormattingEnabled = true;
            this.cbIndent.Location = new System.Drawing.Point(254, 23);
            this.cbIndent.Name = "cbIndent";
            this.cbIndent.Size = new System.Drawing.Size(70, 20);
            this.cbIndent.TabIndex = 8;
            // 
            // rbJS
            // 
            this.rbJS.AutoSize = true;
            this.rbJS.Checked = true;
            this.rbJS.Location = new System.Drawing.Point(390, 26);
            this.rbJS.Name = "rbJS";
            this.rbJS.Size = new System.Drawing.Size(35, 16);
            this.rbJS.TabIndex = 6;
            this.rbJS.TabStop = true;
            this.rbJS.Text = "JS";
            this.rbJS.UseVisualStyleBackColor = true;
            // 
            // cbStyle
            // 
            this.cbStyle.FormattingEnabled = true;
            this.cbStyle.Location = new System.Drawing.Point(116, 22);
            this.cbStyle.Name = "cbStyle";
            this.cbStyle.Size = new System.Drawing.Size(70, 20);
            this.cbStyle.TabIndex = 5;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 198);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(730, 3);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtActivePos);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cbIndent);
            this.groupBox1.Controls.Add(this.rbSql);
            this.groupBox1.Controls.Add(this.rbJS);
            this.groupBox1.Controls.Add(this.cbStyle);
            this.groupBox1.Controls.Add(this.btnFormat);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 549);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(730, 61);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // btnFormat
            // 
            this.btnFormat.Location = new System.Drawing.Point(24, 20);
            this.btnFormat.Name = "btnFormat";
            this.btnFormat.Size = new System.Drawing.Size(70, 23);
            this.btnFormat.TabIndex = 4;
            this.btnFormat.Text = "格式化";
            this.btnFormat.UseVisualStyleBackColor = true;
            this.btnFormat.Click += new System.EventHandler(this.btnFormat_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(730, 198);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 610);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtActivePos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rbSql;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.ComboBox cbIndent;
        private System.Windows.Forms.RadioButton rbJS;
        private System.Windows.Forms.ComboBox cbStyle;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFormat;
        private System.Windows.Forms.RichTextBox richTextBox1;

    }
}

