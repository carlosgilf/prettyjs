using System;
using Gizmox.WebGUI.Forms;

namespace Bronze.WebGuiCommonLib
{

    public delegate void ItemEventHandler(object sender, ItemEventArgs args);
    public delegate ColumnHeader GenerateColumnHandler(object sender, ColumnHeader column);
    public delegate void CommonSort_MovingHandler(object sender, SortEventArgs args);
    public delegate void CommonSort_MovedHandler(object sender, SortEventArgs args);
    public delegate void CommonOperate_Click(object sender, OperateEventArgs args);

    [Serializable]
    public class ItemEventArgs : EventArgs
    {
        private ListViewItem itemItem;
        public ListViewItem Item
        {
            get { return itemItem; }
            set { itemItem = value; }
        }

        public ColumnHeader CurrentColumn
        {
            get;
            set;
        }

        public Control Control;

    }

    [Serializable]
    public class SortEventArgs : EventArgs
    {
        private ListViewItem item;
        public ListViewItem Item
        {
            get { return item; }
            set { item = value; }
        }

        private CommonSortInfo commonSortInfo;
        public CommonSortInfo CommonSortInfo
        {
            get { return commonSortInfo; }
            set { commonSortInfo = value; }
        }

        private SignType signType;
        public SignType SignType
        {
            get { return signType; }
            set { signType = value; }
        }

        private double sortedIndex;
        public double SortedIndex
        {
            get { return sortedIndex; }
            set { sortedIndex = value; }
        }
    }
    [Serializable]
    public class OperateEventArgs : EventArgs
    {
        private ListViewItem item;
        public ListViewItem Item
        {
            get { return item; }
            set { item = value; }
        }

        private LinkLabel currentOperatingItem;
        public LinkLabel CurrentOperatingItem
        {
            get { return currentOperatingItem; }
            set { currentOperatingItem = value; }
        }

        private string currentOperatingText;
        public string CurrentOperatingText
        {
            get { return currentOperatingText; }
            set { currentOperatingText = value; }
        }

        private string key;
        public string Key
        {
            get { return key; }
            set { key = value; }
        }
    }

    [Serializable]
    public class CreateColumnEventArgs : EventArgs
    {
        public ColumnHeader Column
        {
            get;
            set;
        }


    }

    public enum SignType
    {
        …œ“∆ = 0, œ¬“∆ = 1, ÷√∂• = 2, ÷√Œ≤ = 3
    }

}
