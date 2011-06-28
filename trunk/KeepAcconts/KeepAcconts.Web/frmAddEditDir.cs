#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace KeepAcconts.Web
{
    public partial class frmAddEditDir : Form
    {
        public frmAddEditDir()
        {
            InitializeComponent();
        }

        public FileManager fileManager;
        public FileAction Action = FileAction.None;
        public string TxtFiledValue = "";

        private void btnSure_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtName.Text))
            {
                MessageBox.Show("必须填写文件夹名称");
                return;
            }

            try
            {
                switch (Action)
                {
                    case FileAction.RenameFile:
                        fileManager.RenameFile(this.txtName.Text);
                        break;
                    case FileAction.RenameDir:
                        fileManager.RenameDir(this.txtName.Text);
                        break;
                    case FileAction.AddDir:
                        fileManager.CreateDir(this.txtName.Text);
                        break;
                }
                
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void frmAddEditDir_Load(object sender, EventArgs e)
        {
            this.txtName.Text = TxtFiledValue;
            switch (Action)
            {
                case FileAction.RenameFile:
                    this.Text = "重命名文件";
                    break;
                case FileAction.RenameDir:
                    this.Text = "重命名文件夹";
                    break;
                case FileAction.AddDir:
                    this.Text = "创建名文件夹";
                    break;
                case FileAction.ShowUrl:
                    this.Text = "文件URL";
                    this.btnSure.Visible = false;
                    break;
                default:
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public enum FileAction
    {
        None,RenameFile,RenameDir,AddDir,ShowUrl
    }
}