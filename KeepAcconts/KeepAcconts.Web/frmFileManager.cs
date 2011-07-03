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
    public partial class frmFileManager : Form
    {
        public frmFileManager()
        {
            InitializeComponent();
        }

        private void frmFileManager_Load(object sender, EventArgs e)
        {
            var frm = new FileManager();
            frm.Show();
        }
    }
}