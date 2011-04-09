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
    public partial class ListViewCheckAll : Form
    {
        public ListViewCheckAll()
        {
            InitializeComponent();
        }

        private void BindList()
        {
            DataTable dt = new DataTable();
            int columnCount = 10;
            int rowCount = (int)numCount.Value;

            var mobjRandomData = new RandomData();

            for (int i = 0; i < columnCount; i++)
            {
                dt.Columns.Add("Column" + i);
            }

            for (int j = 0; j < rowCount; j++)
            {
                var rowArray = new object[columnCount];
                for (int i = 0; i < columnCount; i++)
                {
                    rowArray[i] = mobjRandomData.GetDate().ToString();
                }
                dt.Rows.Add(rowArray);
            }

            this.listView1.DataSource = dt;
        }

        private void ListViewCheckAll_Load(object sender, EventArgs e)
        {
            BindList();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            BindList();
        }


        [Serializable()]
        public class RandomData
        {
            private Random mobjRandom;

            public RandomData()
            {
                mobjRandom = new Random(0);
            }

            public bool GetBoolean()
            {
                return mobjRandom.NextDouble() > 0.5;
            }

            public string GetSize()
            {
                return mobjRandom.Next(1, 2000).ToString() + "kb";
            }

            public DateTime GetDate()
            {
                return DateTime.Now.AddDays((double)mobjRandom.Next(-100, 100));
            }
        }


    }
}