using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using Gizmox.WebGUI.Forms;

namespace KeepAcconts.Web
{
    public class CListView : ListView
    {
        private readonly CheckBox _checkBox;

        private bool _selecting;
        private bool _checking;
        private bool _handleAll;

        private bool _trunPerformance = true;


        int _rowHeight = 50;
        public int RowHeight
        {
            get
            {
                return _rowHeight;
            }
            set
            {
                _rowHeight = value;
            }
        }

        public bool TrunPerformance
        {
            get { return _trunPerformance; }
            set { _trunPerformance = value; }
        }

        public CListView()
        {
            _checkBox = new CheckBox() { Width = 14, Height = 16 };

            _checkBox.CheckedChanged += new EventHandler(_checkBox_CheckedChanged);
            base.ItemCheck += new ItemCheckHandler(CListview_ItemCheck);
            this.MouseClick += new MouseEventHandler(CListview_MouseClick);
            this.SelectedIndexChanged += new EventHandler(CListView_SelectedIndexChanged);
            this.GridLines = true;
            this.CheckBoxes = true;
        }

        void CListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_checking || _handleAll) return;
            bool batchUpdate = false;
            try
            {
                if (this.CheckedItems.Count > 3)
                {
                    this.SuspendLayout();
                    this.BeginUpdate();
                    batchUpdate = true;
                }
                _selecting = true;
                foreach (ListViewItem item in this.Items)
                {
                    if (item.Selected != item.Checked)
                    {
                        item.Checked = item.Selected;
                    }

                }
            }
            finally
            {
                if (batchUpdate)
                {
                    this.Update();
                }
                _selecting = false;
            }
        }

        void CListview_MouseClick(object sender, MouseEventArgs e)
        {
     
        }

        void CListview_ItemCheck(object objSender, ItemCheckEventArgs objArgs)
        {
            if (_selecting || _handleAll) return;


            try
            {
                //this.Visible = false;
                //this.SuspendLayout();
                _checking = true;

                foreach (ListViewItem item in this.Items)
                {
                    if (item.Checked != item.Selected)
                    {
                        item.Selected = item.Checked;
                    }
                }
            }
            finally
            {
                _checking = false;
                //this.Visible = true;
            }

        }


        void _checkBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                _handleAll = true;
                //this.Visible = false;
                this.BeginUpdate();//.SuspendLayout();
                foreach (ListViewItem item in this.Items)
                {
                    if (_checkBox.Checked != item.Checked)
                    {
                        item.Checked = _checkBox.Checked;
                    }
                    if (_checkBox.Checked != item.Selected)
                    {
                        item.Selected = _checkBox.Checked;
                    }
                }
            }
            finally
            {
                this.Update();
                _handleAll = false;
                //this.Visible = true;
            }
        }

        protected override void PreRenderControl(Gizmox.WebGUI.Common.Interfaces.IContext objContext)
        {
            base.PreRenderControl(objContext);

            if (this.Parent.Controls.IndexOf(_checkBox) == -1)
            {
                this.Parent.Controls.Add(_checkBox);
            }
            _checkBox.BringToFront();
            _checkBox.Location = new Point(Location.X + 5, Location.Y + 2);
        }

    }
}
