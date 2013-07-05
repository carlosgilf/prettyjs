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
    /// Summary description for SupperPictureBox
    /// </summary>
    [ToolboxItem(true)]
    [Serializable()]
    [Skin(typeof(SupperPictureBoxSkin))]
    public partial class SupperPictureBox : PictureBox
    {
        public SupperPictureBox()
        {
            InitializeComponent();
            this.CustomStyle = "SupperPictureBox";
        }

        private static SerializableProperty RadiusProperty = SerializableProperty.Register("Radius", typeof(CornerRadius), typeof(SupperPictureBox), new SerializablePropertyMetadata());
        private static SerializableProperty BoxShadowProperty = SerializableProperty.Register("BoxShadow", typeof(BoxShadow), typeof(SupperPictureBox), new SerializablePropertyMetadata());

        public virtual CornerRadius Radius
        {
            get
            {
                return base.GetValue<CornerRadius>(RadiusProperty, this.DefaultRadius);
            }
            set
            {
                if (base.SetValue<CornerRadius>(RadiusProperty, value, this.DefaultRadius))
                {
                    this.Update();
                    base.FireObservableItemPropertyChanged("Radius");
                }
            }
        }


        protected virtual CornerRadius DefaultRadius
        {
            get
            {
                return CornerRadius.Empty;
            }
        }


        protected virtual BoxShadow DefaultBoxShadow
        {
            get
            {
                return BoxShadow.Empty;
            }
        }


        public virtual BoxShadow BoxShadow
        {
            get
            {
                return base.GetValue<BoxShadow>(BoxShadowProperty, this.DefaultBoxShadow);
            }
            set
            {
                if (base.SetValue<BoxShadow>(BoxShadowProperty, value, this.DefaultBoxShadow))
                {
                    this.Update();
                    base.FireObservableItemPropertyChanged("BoxShadow");
                }
            }
        }


        protected override void RenderAttributes(IContext context, IAttributeWriter writer)
        {
            base.RenderAttributes(context, writer);
            if (Radius != CornerRadius.Empty)
            {
                CornerRadiusValue rd = this.Radius;
                string style = rd.GetStyle();
                writer.WriteAttributeString("Radius", style);
            }

            if (this.BoxShadow != this.DefaultBoxShadow)
            {
                BoxShadowValue bs = this.BoxShadow;
                string style = bs.GetStyle();
                writer.WriteAttributeString("BoxShadow", style);
            }
        }

  
    }
}