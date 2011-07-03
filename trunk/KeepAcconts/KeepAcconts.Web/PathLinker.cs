#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Bronze.WebGuiCommonLib;

#endregion

namespace KeepAcconts.Web
{
    public partial class PathLinker : UserControl
    {
        public PathLinker()
        {
            InitializeComponent();
        }

      

        string rootPath = "";

        public string RootPath
        {
            get { return rootPath; }
            set { rootPath = value; }
        }

        string currentPath = "";
        public string CurrentPath
        {
            get
            {
                return currentPath;
            }
            set
            {
                currentPath = value;
                CreateLinker();
            }
        }

        public Action<Button, string> LinkClick;

        private Button CreateButton(string text)
        {
            var width = Convert.ToInt32(Utility.GetWidthByText(text, new System.Drawing.Font("宋体", 9F)));
            Button btn = new Button();
            btn.CustomStyle = "F";
            btn.Font = new System.Drawing.Font("宋体", 9F);
            btn.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            btn.Location = new System.Drawing.Point(0, 0);
            btn.Size = new System.Drawing.Size(width, 22);
            btn.TabIndex = 0;
            btn.Text = text;
            return btn;
        }


        private Button CreateImgButton()
        {
            Button button2 = new Button();
            button2.CustomStyle = "F";
            button2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            button2.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle("arrow_right1.png");
            button2.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            button2.Location = new System.Drawing.Point(50, 0);
            button2.Size = new System.Drawing.Size(13, 22);
            return button2;
        }

        private void PathLinker_Load(object sender, EventArgs e)
        {
            CreateLinker();
        }

        private void CreateLinker()
        {
            this.Controls.Clear();
            var path = ":\\" + currentPath;
            path = path.Replace("\\\\", "\\");
            if (path.EndsWith("\\"))
            {
                path = path.Remove(path.Length - 1, 1);
            }

            var paths = path.Split('\\');


            int lastX = 1;

            Button lastButton = null;
            foreach (var p in paths)
            {
                if (string.IsNullOrEmpty(p))
                {
                    return;
                }
                var imgBtn = CreateImgButton();
                imgBtn.Location = new System.Drawing.Point(lastX, 0);
                this.Controls.Add(imgBtn);

                lastX += imgBtn.Size.Width;


                Button btn = null;
                if (p == ":")
                {
                    btn = CreateButton("根目录");
                    btn.ImageKey = "";
                }
                else
                {
                    btn = CreateButton(p);
                    btn.ImageKey = p;
                }


                btn.Click += new EventHandler(btn_Click);



                btn.Tag = lastButton;
                btn.Location = new System.Drawing.Point(lastX, 0);
                lastButton = btn;
                this.Controls.Add(btn);
                lastX += btn.Size.Width;



            }
        }



        void btn_Click(object sender, EventArgs e)
        {
            if (LinkClick != null)
            {
                
                var btn = sender as Button;
                string path = btn.ImageKey;

                var preBtn = btn;
                while (preBtn.Tag != null)
                {
                    preBtn = preBtn.Tag as Button;
                    path = System.IO.Path.Combine(preBtn.ImageKey, path);
                }
                
                LinkClick(btn, path);
            }
        }
    }


}