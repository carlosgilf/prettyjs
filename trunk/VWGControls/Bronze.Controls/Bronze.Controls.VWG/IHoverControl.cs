using System;
namespace Bronze.Controls.VWG
{
    public interface IHoverControl
    {
        System.Drawing.Color HoverBackColor { get; set; }
        Gizmox.WebGUI.Common.Resources.ResourceHandle HoverImage { get; set; }
        string OnClientMouseLeave { get; set; }
        string OnClientMouseOver { get; set; }
        bool Overable { get; set; }
        bool RenderRunClientMouseLeave { get; set; }
    }
}
