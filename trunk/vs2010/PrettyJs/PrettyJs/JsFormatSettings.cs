#region Disclaimer/Info
/*
 * PrettyJs  - http://jintan.cnblogs.com
 * Copyright (c) 靳如坦.  All rights reserved.
 * 
 * The contents of this file are subject to the Mozilla Public
 * License Version 1.1 (the "License"); you may not use this file
 * except in compliance with the License. You may obtain a copy of
 * the License at http://www.mozilla.org/MPL/
 * 
 * Software distributed under the License is distributed on an 
 * "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, either express or
 * implied. See the License for the specific language governing
 * rights and limitations under the License.
 */
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using AMS.Profile;

namespace Jrt.PrettyJs
{
    public partial class JsFormatSettings : Form
    {
        public JsFormatSettings(PrettyJsPackage c)
        {
            InitializeComponent();
            this.Host = c;
        }
        public PrettyJsPackage Host;


        private void btnSave_Click(object sender, EventArgs e)
        {
            CodeOption option = new CodeOption();
            CodeStyle style = (CodeStyle)Enum.Parse(typeof(CodeStyle), cbStyle.Text.ToString());
            option.Style = style;
            option.IdentUseTab = rbTab.Checked;
            option.AddSpaceAfterCtrlWord = cbAddSpaceAfterCtrlWord.Checked;
            option.IdentNumber = int.Parse(numIndent.Value.ToString());
            foreach (Control c in groupBlankLine.Controls)
            {
                if (c is RadioButton)
                {
                    if(((RadioButton)c).Checked)
                    {
                        option.RemoveBlankLine = (BlankLineOption)(int.Parse(c.Tag.ToString()));
                        break;
                    }
                }
            }
            option.AutoCompleteBracket = cbCompletBracket.Checked;

            option.KeepBlankLineCount=(int)numKeep.Value;
            option.MaxBlankLine=(int)numMax.Value;
            Host.option = option;

            option.Save();
            MessageBox.Show("设置成功");
            this.DialogResult = DialogResult.OK;

        }

        private void JsFormatSettings_Load(object sender, EventArgs e)
        {
            string[] style = Enum.GetNames(typeof(CodeStyle));
            this.cbStyle.Items.Clear();
            this.cbStyle.Items.AddRange(style);
            this.cbStyle.SelectedText = Host.option.Style.ToString();


            rbTab.Checked = Host.option.IdentUseTab;
            cbAddSpaceAfterCtrlWord.Checked = Host.option.AddSpaceAfterCtrlWord;
            numIndent.Value= Host.option.IdentNumber;
            cbCompletBracket.Checked = Host.option.AutoCompleteBracket;
            foreach (Control c in groupBlankLine.Controls)
            {
                if (c is RadioButton)
                {
                    if (int.Parse(c.Tag.ToString()) == (int)Host.option.RemoveBlankLine)
                    {
                        ((RadioButton)c).Checked = true;
                        break;
                    }
                }
            }

            this.numKeep.Value = Host.option.KeepBlankLineCount;
            this.numMax.Value = Host.option.MaxBlankLine;
            //DataTable dt = new DataTable();
            //dt.Columns.Add("Teax");
            //dt.Columns.Add("Value");
            //dt.Rows.Add("TAB缩进", "\t");
            //dt.Rows.Add("4个空格", "    ");
            //dt.Rows.Add("2个空格", "  ");
            //cbIndent.DataSource = dt;
            //cbIndent.DisplayMember = "Teax";
            //cbIndent.ValueMember = "Value";

            //this.cbIndent.SelectedText = Host.option.IdentStr;
            //foreach (DataRow row in dt.Rows)
            //{
            //    if (row["Value"].ToString() == Host.option.IdentStr)
            //    {
            //        this.cbIndent.SelectedValue = Host.option.IdentStr;
            //    }
            //}

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://jintan.cnblogs.com");
        }
    }
}
