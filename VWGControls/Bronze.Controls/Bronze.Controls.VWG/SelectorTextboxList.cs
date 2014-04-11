#region Using

using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;


using Gizmox.WebGUI;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Extensibility;


#endregion

namespace Bronze.Controls.VWG
{
    /// <summary>
    /// Summary description for SelectorTextboxList
    /// </summary>
    [ToolboxItem(true)]
    [Serializable()]
    [Skin(typeof(SelectorTextboxListSkin))]
    public partial class SelectorTextboxList : SelectorTextBox
    {
        public SelectorTextboxList()
        {
            InitializeComponent();
            this.CustomStyle = "SelectorTextboxListSkin";
        }


    }
}