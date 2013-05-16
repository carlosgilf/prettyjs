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
using Gizmox.WebGUI.Common.Resources;


#endregion

namespace Bronze.Controls.VWG
{
    /// <summary>
    /// Summary description for ImageProcessor
    /// </summary>
    [ToolboxItem(true)]
    [ToolboxBitmapAttribute(typeof(ImageProcessor), "Bronze.Controls.VWG.ImageProcessor.bmp")]
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0 , Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=4.0.5701.0 , Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Serializable()]
    [MetadataTag("IMGPRC")]
    [Skin(typeof(ImageProcessorSkin))]
    public partial class ImageProcessor : Control
    {
        /// <summary>
        /// 
        /// </summary>
        private ResourceHandle mobjImage = null;

        /// <summary>
        /// 
        /// </summary>
        private RectangleF mobjSelection = RectangleF.Empty;

        /// <summary>
        /// Opacity of outer image when cropping: 0 - 1	 
        /// default = 0.6
        /// </summary>
        private float bgOpacity = 0.6F;

        private Color bgColor = Color.Black;

        private float aspectRatio = 0;


        /// <summary>
        /// The SelectionChanged event registration.
        /// </summary>
        private static readonly SerializableEvent SelectionChangedEvent = SerializableEvent.Register("SelectionChanged", typeof(EventHandler), typeof(ImageProcessor));



        /// <summary>
        /// Occurs when selection changed.
        /// </summary>
        public event EventHandler SelectionChanged
        {
            add
            {
                this.AddHandler(ImageProcessor.SelectionChangedEvent, value);
            }
            remove
            {
                this.RemoveHandler(ImageProcessor.SelectionChangedEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the SelectionChanged event.
        /// </summary>
        private EventHandler SelectionChangedHandler
        {
            get
            {
                return (EventHandler)this.GetHandler(ImageProcessor.SelectionChangedEvent);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageProcessor"/> class.
        /// </summary>
        public ImageProcessor()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Renders the attributes.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="writer">The writer.</param>
        protected override void RenderAttributes(IContext context, IAttributeWriter writer)
        {
            base.RenderAttributes(context, writer);

            if (mobjImage != null)
            {
                writer.WriteAttributeString(WGAttributes.Image, mobjImage.ToString());
                if (mobjSelection != null)
                {
                    string size = string.Format("{{ x: {0}, y:{1}, w:{2}, h:{3} }}",
                        mobjSelection.X, mobjSelection.Y, mobjSelection.Width, mobjSelection.Height
                        );
                    writer.WriteAttributeString(WGAttributes.SelectedImage, size);
                }
                writer.WriteAttributeString("bgOpacity", this.BgOpacity);
                writer.WriteAttributeString("bgColor", ColorTranslator.ToHtml(this.BgColor));
                if (AspectRatio > 0)
                {
                    writer.WriteAttributeString("aspectRatio", AspectRatio);
                }
            }
        }

        protected override void FireEvent(IEvent objEvent)
        {
            if (objEvent.Type == "ValueChange")
            {
                mobjSelection = new RectangleF(float.Parse(objEvent["X"]), float.Parse(objEvent["Y"]), float.Parse(objEvent["W"]), float.Parse(objEvent["H"]));
                OnSelectionChange(EventArgs.Empty);
            }

            base.FireEvent(objEvent);
        }

        protected virtual void OnSelectionChange(EventArgs objArgs)
        {
            if (SelectionChangedHandler != null)
            {
                SelectionChangedHandler(this, objArgs);
            }
        }

        protected override EventTypes GetCriticalEvents()
        {
            EventTypes enmTypes = base.GetCriticalEvents();
            if (SelectionChangedHandler != null) enmTypes |= EventTypes.SelectionChange;
            return enmTypes;
        }

        /// <summary>
        /// Gets or sets the image path.
        /// </summary>
        /// <value>The image path.</value>
        public ResourceHandle ImagePath
        {
            get { return mobjImage; }
            set
            {
                mobjImage = value;
                this.Update();
            }
        }

        /// <summary>
        /// Gets the selection.
        /// </summary>
        /// <value>The selection.</value>
        public RectangleF Selection
        {
            get { return mobjSelection; }
            set { mobjSelection = value; }
        }

        /// <summary>
        /// Opacity of outer image when cropping: 0 - 1	 
        /// default = 0.6
        /// </summary>
        public float BgOpacity
        {
            get { return bgOpacity; }
            set
            {
                bgOpacity = value;
                this.Update();
            }
        }

        /// <summary>
        /// Set color of background container
        /// </summary>
        public Color BgColor
        {
            get { return bgColor; }
            set
            {
                bgColor = value;
                this.Update();
            }
        }

        /// <summary>
        /// Aspect ratio of w/h (e.g. 1 for square)
        /// 固定选择框的比例，0-1之间，例如1就是正方形，0表示不限制
        /// </summary>
        public float AspectRatio
        {
            get { return aspectRatio; }
            set
            {
                if (value > 1 || value < 0)
                {

                    throw new ArgumentOutOfRangeException("AspectRatio value out of range, the value should in 0 to 1");
                }
                aspectRatio = value;
                this.Update();
            }
        }

    }




}