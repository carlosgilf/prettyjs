#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.IO;
using Gizmox.WebGUI.Common.Resources;

#endregion

namespace KeepAcconts.Web
{
    public partial class FileManager : Form
    {
        public FileManager()
        {
            InitializeComponent();

        }


        private string rootRelPath = "test";
        private string currentPath = "";
        private string rootPath = "";
        private void FileManager_Load(object sender, EventArgs e)
        {
            this.fileDlg.MaxFileSize = 1024000;
            Filelist.GridLines = false;
            Filelist.CheckBoxes = false;
            rootPath = currentPath = VWGContext.Current.HttpContext.Server.MapPath( "~/"+rootRelPath);
            this.pathLinker1.RootPath = rootPath;

            this.pathLinker1.LinkClick = (button, path) => {
                var fullPath=Path.Combine(rootPath, path);
                BindList(fullPath);
            };
            BindList(currentPath);
        }


        public List<FileStruck> GetList(string parentPath)
        {
            List<FileStruck> dirAndFiles = new List<FileStruck>();

            DirectoryInfo directory = new DirectoryInfo(parentPath);
            foreach (var dir in directory.GetDirectories())
            {
                var struck = new FileStruck() { Type = "文件夹", Name = dir.Name, ModifyDate = dir.LastWriteTime };
                dirAndFiles.Add(struck);
            }

            foreach (FileInfo f in directory.GetFiles())
            {
                var struck = new FileStruck() { Type = "文件", Name = f.Name, FileSize = f.Length, ModifyDate = f.LastWriteTime };
                dirAndFiles.Add(struck);
            }
            return dirAndFiles;
        }

        void BindList(string parentPath)
        {
            var list = GetList(parentPath);
            this.Filelist.DataListSource = list;
            this.Filelist.Bind();
            currentPath = parentPath;
            string path = currentPath.Remove(0,rootPath.Length);
            this.pathLinker1.CurrentPath = path;
        }

        private void Filelist_DoubleClick(object sender, EventArgs e)
        {
            var es = (Gizmox.WebGUI.Forms.MouseEventArgs)e;
            var item = Filelist.GetItemAt(es.X, es.Y);
            if (item != null && item.Tag != null)
            {
                var struck = item.Tag as FileStruck;
                if (struck != null && struck.Type == "文件夹")
                {
                    var name = struck.Name;
                    currentPath = System.IO.Path.Combine(currentPath, name);
                    BindList(currentPath);
                }
            }
        }


        /*
 * A recursive method to populate a TreeView
 * Author: Danny Battison
 * Contact: gabehabe@googlemail.com
 */

        /// <summary>
        /// A method to populate a TreeView with directories, subdirectories, etc
        /// </summary>
        /// <param name="dir">The path of the directory</param>
        /// <param name="node">The "master" node, to populate</param>
        public void PopulateTree(string dir, TreeNode node)
        {
            // get the information of the directory
            DirectoryInfo directory = new DirectoryInfo(dir);
            // loop through each subdirectory
            foreach (DirectoryInfo d in directory.GetDirectories())
            {
                // create a new node
                TreeNode t = new TreeNode(d.Name);
                // populate the new node recursively
                PopulateTree(d.FullName, t);
                node.Nodes.Add(t); // add the node to the "master" node
            }
            // lastly, loop through each file in the directory, and add these as nodes
            foreach (FileInfo f in directory.GetFiles())
            {
                // create a new node
                TreeNode t = new TreeNode(f.Name);
                // add it to the "master"
                node.Nodes.Add(t);
            }
        }



      

        private void Filelist_RowItemBinding(object sender, ListViewItemBindingEventArgs e)
        {
            var struck = (FileStruck)(e.DataRow);
            if (struck.Type == "文件夹")
            {
                e.ListViewItem.SmallImage = new ImageResourceHandle("FileIcons.dir_16.png");
            }
            else
            {
                e.ListViewItem.SmallImage = new ImageResourceHandle("FileIcons.file_16.png");
            }
        }

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button.Name=="tbtNewDirectory")
            {
                var frm = new frmAddEditDir();
                frm.fileManager = this;
                frm.Action = FileAction.AddDir;
                frm.ShowDialog();
            }
            else if (e.Button.Name == "tbtnAddFiles")
            {
                fileDlg.ShowDialog();
            }
            else if (e.Button.Name == "tbtnDelete")
            {
                Delete();
            }
        }

        public void CreateDir(string name)
        {
            Directory.CreateDirectory(Path.Combine(currentPath, name));
            BindList(currentPath);
        }

        private void fileDlg_FileOk(object sender, CancelEventArgs e)
        {
            var files = fileDlg.Files;
            for (int i = 0; i < files.Count; i++)
            {
                var path = Path.Combine(currentPath, files[i].OriginalFileName);
                var file = files[i];
                if (File.Exists(path))
                {
                    MessageBox.Show(string.Format("此文件夹已包含和“{0}”的文件，是否覆盖?",file.OriginalFileName), "提示", MessageBoxButtons.YesNo, (obj, ev) =>
                    {
                        if (((Form)obj).DialogResult == DialogResult.Yes)
	                    {
                            file.SaveAs(path);
	                    }
                    });
                }
                else
                {
                    file.SaveAs(path);
                }
            }
            BindList(currentPath);
        }

        private void meunDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        internal void Delete()
        {
            if (this.Filelist.SelectedItems != null)
            {

                MessageBox.Show(string.Format("你确定要删除？"), "提示", MessageBoxButtons.YesNo, (obj, ev) =>
                {
                    if (((Form)obj).DialogResult == DialogResult.Yes)
                    {
                        foreach (ListViewItem item in Filelist.SelectedItems)
                        {
                            var struck = item.Tag as FileStruck;
                            if (struck != null)
                            {
                                var name = struck.Name;
                                var path = System.IO.Path.Combine(currentPath, name);
                                if (struck.Type == "文件夹")
                                {
                                    Directory.Delete(path, true);
                                }
                                else
                                {
                                    File.Delete(path);
                                }
                            }
                        }
                        BindList(currentPath);
                    }
                });
            }
        }
        
        internal void RenameFile(string newName)
        {
            var item = Filelist.SelectedItem;
            var struck = item.Tag as FileStruck;
            if (struck != null)
            {
                var oldPath = Path.Combine(currentPath, struck.Name);
                var newPath = Path.Combine(currentPath, newName);
                FileInfo file = new FileInfo(oldPath);
                file.MoveTo(newPath);
                BindList(currentPath);
            }
        }

        internal void RenameDir(string newName)
        {
            var item = Filelist.SelectedItem;
            var struck = item.Tag as FileStruck;
            if (struck != null)
            {
                var oldPath = Path.Combine(currentPath, struck.Name);
                var newPath = Path.Combine(currentPath, newName);
                DirectoryInfo dir = new DirectoryInfo(oldPath);
                dir.MoveTo(newPath);
                BindList(currentPath);
            }
        }

        private void menuRename_Click(object sender, EventArgs e)
        {
             var item = Filelist.SelectedItem;
            var struck = item.Tag as FileStruck;
            if (struck != null)
            {
                var frm = new frmAddEditDir();
                frm.fileManager = this;
                frm.TxtFiledValue = struck.Name;
                if (struck.Type=="文件夹")
                {
                    frm.Action = FileAction.RenameDir;
                }
                else
                {
                    frm.Action = FileAction.RenameFile;
                    
                }
                frm.ShowDialog();
               
            }
        }

        private void menuCopyUrl_Click(object sender, EventArgs e)
        {
            var item = Filelist.SelectedItem;
            var struck = item.Tag as FileStruck;
            if (struck != null)
            {
                string strLink = struck.Name;



                string relPath = currentPath.Remove(0, rootPath.Length);

                relPath = "/" + rootRelPath + relPath;

                relPath=relPath.Replace("\\", "/").Replace("//", "/");

                if (Context.HttpContext.Request.ApplicationPath.EndsWith("/"))
                    strLink = Context.HttpContext.Request.ApplicationPath + strLink;
                else
                    strLink = Context.HttpContext.Request.ApplicationPath + "/" + strLink;
                strLink = "http://" + Context.HttpContext.Request.Url.Authority + relPath + strLink;


                var frm = new frmAddEditDir();
                frm.Action = FileAction.ShowUrl;
                frm.TxtFiledValue = strLink;
                frm.ShowDialog();
            }
        }
    }

    public class FileStruck
    {

        private SizeType sizeType = SizeType.KB;

        public SizeType SizeType
        {
            get { return sizeType; }
            set { sizeType = value; }
        }


        long fileSize;

        public long FileSize
        {
            get { return fileSize; }
            set { fileSize = value; }
        }

        public string Size
        {
            get
            {
                if (Type == "文件夹")
                {
                    return "";
                }
                switch (SizeType)
                {
                    case SizeType.Byte:
                        var s = FileSize;
                        return s.ToString() + "字节";
                        break;
                    case SizeType.KB:
                        if (FileSize.Equals(0))
                        {
                            return 0 + "KB";
                        }
                        var ss = FileSize / 1024.0;
                        var kb = Math.Round(ss + 0.5, 0);
                        return kb.ToString() + "KB";
                        break;
                    case SizeType.MB:
                        var size = FileSize / (1024.0 * 1024.0);
                        var mbs = Math.Round(size, 2);
                        return mbs.ToString() + "MB";
                        break;
                }
                return "";

            }
        }
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        DateTime modifyDate;

        public DateTime ModifyDate
        {
            get { return modifyDate; }
            set { modifyDate = value; }
        }

        string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

    }

    public enum SizeType
    {
        Byte,
        KB,
        MB
    }
}