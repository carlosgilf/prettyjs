namespace JrtCoder
{
    partial class JsFormatSettings
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbAddSpaceAfterCtrlWord = new System.Windows.Forms.CheckBox();
            this.groupBlankLine = new System.Windows.Forms.GroupBox();
            this.numKeep = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numMax = new System.Windows.Forms.NumericUpDown();
            this.rbKeepBlankLine = new System.Windows.Forms.RadioButton();
            this.rbCleanAllBlankLine = new System.Windows.Forms.RadioButton();
            this.rbRemoveBlankLine = new System.Windows.Forms.RadioButton();
            this.rbSpace = new System.Windows.Forms.RadioButton();
            this.rbTab = new System.Windows.Forms.RadioButton();
            this.numIndent = new System.Windows.Forms.NumericUpDown();
            this.cbStyle = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cbCompletBracket = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBlankLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKeep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIndent)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(6, 9);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(335, 287);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBlankLine);
            this.tabPage1.Controls.Add(this.rbSpace);
            this.tabPage1.Controls.Add(this.rbTab);
            this.tabPage1.Controls.Add(this.numIndent);
            this.tabPage1.Controls.Add(this.cbStyle);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(327, 262);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "常规";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbAddSpaceAfterCtrlWord);
            this.groupBox2.Location = new System.Drawing.Point(16, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(305, 48);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "间距";
            // 
            // cbAddSpaceAfterCtrlWord
            // 
            this.cbAddSpaceAfterCtrlWord.AutoSize = true;
            this.cbAddSpaceAfterCtrlWord.Location = new System.Drawing.Point(31, 20);
            this.cbAddSpaceAfterCtrlWord.Name = "cbAddSpaceAfterCtrlWord";
            this.cbAddSpaceAfterCtrlWord.Size = new System.Drawing.Size(156, 16);
            this.cbAddSpaceAfterCtrlWord.TabIndex = 11;
            this.cbAddSpaceAfterCtrlWord.Text = "在控制语句后面添加空格";
            this.cbAddSpaceAfterCtrlWord.UseVisualStyleBackColor = true;
            // 
            // groupBlankLine
            // 
            this.groupBlankLine.Controls.Add(this.numKeep);
            this.groupBlankLine.Controls.Add(this.label6);
            this.groupBlankLine.Controls.Add(this.label7);
            this.groupBlankLine.Controls.Add(this.label5);
            this.groupBlankLine.Controls.Add(this.numMax);
            this.groupBlankLine.Controls.Add(this.rbKeepBlankLine);
            this.groupBlankLine.Controls.Add(this.rbCleanAllBlankLine);
            this.groupBlankLine.Controls.Add(this.rbRemoveBlankLine);
            this.groupBlankLine.Location = new System.Drawing.Point(16, 170);
            this.groupBlankLine.Name = "groupBlankLine";
            this.groupBlankLine.Size = new System.Drawing.Size(305, 86);
            this.groupBlankLine.TabIndex = 15;
            this.groupBlankLine.TabStop = false;
            this.groupBlankLine.Text = "空行";
            // 
            // numKeep
            // 
            this.numKeep.Location = new System.Drawing.Point(255, 15);
            this.numKeep.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numKeep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numKeep.Name = "numKeep";
            this.numKeep.Size = new System.Drawing.Size(31, 21);
            this.numKeep.TabIndex = 14;
            this.numKeep.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(210, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "行,保留";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(287, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "行";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(148, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "大于";
            // 
            // numMax
            // 
            this.numMax.Location = new System.Drawing.Point(178, 15);
            this.numMax.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numMax.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numMax.Name = "numMax";
            this.numMax.Size = new System.Drawing.Size(31, 21);
            this.numMax.TabIndex = 14;
            this.numMax.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // rbKeepBlankLine
            // 
            this.rbKeepBlankLine.AutoSize = true;
            this.rbKeepBlankLine.Location = new System.Drawing.Point(29, 62);
            this.rbKeepBlankLine.Name = "rbKeepBlankLine";
            this.rbKeepBlankLine.Size = new System.Drawing.Size(107, 16);
            this.rbKeepBlankLine.TabIndex = 13;
            this.rbKeepBlankLine.TabStop = true;
            this.rbKeepBlankLine.Tag = "3";
            this.rbKeepBlankLine.Text = "保留原来的空行";
            this.rbKeepBlankLine.UseVisualStyleBackColor = true;
            // 
            // rbCleanAllBlankLine
            // 
            this.rbCleanAllBlankLine.AutoSize = true;
            this.rbCleanAllBlankLine.Location = new System.Drawing.Point(29, 40);
            this.rbCleanAllBlankLine.Name = "rbCleanAllBlankLine";
            this.rbCleanAllBlankLine.Size = new System.Drawing.Size(95, 16);
            this.rbCleanAllBlankLine.TabIndex = 12;
            this.rbCleanAllBlankLine.TabStop = true;
            this.rbCleanAllBlankLine.Tag = "2";
            this.rbCleanAllBlankLine.Text = "清除所有空行";
            this.rbCleanAllBlankLine.UseVisualStyleBackColor = true;
            // 
            // rbRemoveBlankLine
            // 
            this.rbRemoveBlankLine.AutoSize = true;
            this.rbRemoveBlankLine.Location = new System.Drawing.Point(29, 17);
            this.rbRemoveBlankLine.Name = "rbRemoveBlankLine";
            this.rbRemoveBlankLine.Size = new System.Drawing.Size(107, 16);
            this.rbRemoveBlankLine.TabIndex = 12;
            this.rbRemoveBlankLine.TabStop = true;
            this.rbRemoveBlankLine.Tag = "1";
            this.rbRemoveBlankLine.Text = "清除连续的空行";
            this.rbRemoveBlankLine.UseVisualStyleBackColor = true;
            // 
            // rbSpace
            // 
            this.rbSpace.AutoSize = true;
            this.rbSpace.Location = new System.Drawing.Point(75, 72);
            this.rbSpace.Name = "rbSpace";
            this.rbSpace.Size = new System.Drawing.Size(71, 16);
            this.rbSpace.TabIndex = 14;
            this.rbSpace.TabStop = true;
            this.rbSpace.Text = "空格缩进";
            this.rbSpace.UseVisualStyleBackColor = true;
            // 
            // rbTab
            // 
            this.rbTab.AutoSize = true;
            this.rbTab.Location = new System.Drawing.Point(75, 50);
            this.rbTab.Name = "rbTab";
            this.rbTab.Size = new System.Drawing.Size(65, 16);
            this.rbTab.TabIndex = 14;
            this.rbTab.TabStop = true;
            this.rbTab.Text = "Tab缩进";
            this.rbTab.UseVisualStyleBackColor = true;
            // 
            // numIndent
            // 
            this.numIndent.Location = new System.Drawing.Point(153, 68);
            this.numIndent.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numIndent.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numIndent.Name = "numIndent";
            this.numIndent.Size = new System.Drawing.Size(44, 21);
            this.numIndent.TabIndex = 13;
            this.numIndent.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbStyle
            // 
            this.cbStyle.FormattingEnabled = true;
            this.cbStyle.Location = new System.Drawing.Point(75, 17);
            this.cbStyle.Name = "cbStyle";
            this.cbStyle.Size = new System.Drawing.Size(121, 20);
            this.cbStyle.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "缩进:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "代码风格:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cbCompletBracket);
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(327, 262);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "代码完成";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cbCompletBracket
            // 
            this.cbCompletBracket.AutoSize = true;
            this.cbCompletBracket.Location = new System.Drawing.Point(39, 26);
            this.cbCompletBracket.Name = "cbCompletBracket";
            this.cbCompletBracket.Size = new System.Drawing.Size(174, 16);
            this.cbCompletBracket.TabIndex = 12;
            this.cbCompletBracket.Text = "输入}时设置以完成块的格式";
            this.cbCompletBracket.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(327, 262);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "关于";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "JavaScript格式化工具 V1.01";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 48);
            this.label3.TabIndex = 0;
            this.label3.Text = "作者:靳如坦\r\nhttp://jintan.cnblogs.com\r\n\r\n版权所有.\r\n";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(269, 302);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(69, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(191, 302);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(69, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // JsFormatSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 337);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Name = "JsFormatSettings";
            this.Text = "javascript格式化选项";
            this.Load += new System.EventHandler(this.JsFormatSettings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBlankLine.ResumeLayout(false);
            this.groupBlankLine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numKeep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numIndent)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cbStyle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbAddSpaceAfterCtrlWord;
        private System.Windows.Forms.NumericUpDown numIndent;
        private System.Windows.Forms.RadioButton rbSpace;
        private System.Windows.Forms.RadioButton rbTab;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox cbCompletBracket;
        private System.Windows.Forms.GroupBox groupBlankLine;
        private System.Windows.Forms.RadioButton rbCleanAllBlankLine;
        private System.Windows.Forms.RadioButton rbRemoveBlankLine;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbKeepBlankLine;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numKeep;
        private System.Windows.Forms.NumericUpDown numMax;
        private System.Windows.Forms.Label label7;
    }
}