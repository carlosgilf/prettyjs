#region Using

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;

#endregion

namespace KeepAcconts.Web.UI
{
    [Serializable]
    public partial class NavItemButton : UserControl
    {
       

        public NavItemButton()
        {
            InitializeComponent();

            
        }

        public event EventHandler ItemClick;
       

        private string _img;
        public string Image
        {
            get { return _img; }
            set
            {
                _img = value;
                if (this.DesignMode)
                {
                    return;
                }
                this.pictureBox1.Image = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(_img);
            }
        }

        public override string Text
        {
            get { return this.lbText.Text; }
            set
            {
                this.lbText.Text = value;
            }
        }


        private bool _selected;
        public bool Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                if (this.DesignMode)
                {
                    return;
                }
                if (_selected)
                {
                    
                    this.BackgroundImage = new ImageResourceHandle(SelectedBackgroundImage);
                    this.lbText.ForeColor = Color.White;
                    this.lbText.Font = new System.Drawing.Font("ËÎÌו", 9F, FontStyle.Bold);
                    this.BorderWidth = 0;
                }
                else
                {
                    this.BorderWidth = new BorderWidth(0,1,0,1);
                    this.lbText.ForeColor = Color.Black;
                    this.lbText.Font= new System.Drawing.Font("ËÎÌו", 9F);
                    var b = this.BorderColor;
                    b.Top = Color.FromArgb(238, 246, 255);  //Color.FromArgb(101, 147, 207);
                    b.Bottom = Color.FromArgb(211, 217, 225);
                    this.BackgroundImage = null;
                }
            }
        }

        private string _selectedBackgroundImage="Images.Apple.navItemBg.png";
        public string SelectedBackgroundImage
        {
            get { return _selectedBackgroundImage; }
            set { _selectedBackgroundImage = value; }
        }

        private void NavItemButton_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }
            this.lbText.Click += new EventHandler(NavItemButton_Click);
            this.pictureBox1.Click += new EventHandler(NavItemButton_Click);
            this.Click += new EventHandler(NavItemButton_Click);
            // this.BorderColor.Bottom=new Color();
            if (Selected)
            {
                this.BorderWidth = 0;
                this.BackgroundImage = new ImageResourceHandle(SelectedBackgroundImage);
            }
            else
            {
                this.BackgroundImage = null;
            }

            //ToolBarButton t;t.ToolBar
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public NavBar NavBar { get; set; }

        void NavItemButton_Click(object sender, EventArgs e)
        {
            if (ItemClick != null)
            {
                ItemClick(this, e);
            }
        }

    }




















    #region NavBarItemCollection Class

    /// <summary>
    ///
    /// </summary>
    [Serializable()]
    public class NavBarItemCollection : ICollection, IList, IEnumerable, IObservableList
    {
        private ArrayList mobjButtons = null;

        #region C'Tor

        /// <summary>
        /// Creates a new <see cref="NavBarItemCollection"/> instance.
        /// </summary>
        /// <param name="objNavBar">The obj tool bar.</param>
        public NavBarItemCollection(NavBar objNavBar)
        {
            mobjNavBar = objNavBar;
            mobjButtons = new ArrayList();
        }

        #endregion C'Tor

        #region Class Members

        private NavBar mobjNavBar;

        #endregion Class Members

        #region Methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="objNavItemButton"></param>
        /// <returns></returns>
        public int Add(NavItemButton objNavItemButton)
        {
            int intIndex = -1;

            if (objNavItemButton != null)
            {
                objNavItemButton.NavBar = mobjNavBar;
                objNavItemButton.InternalParent = mobjNavBar;

                intIndex = List.Add(objNavItemButton);

                //mobjNavBar.InvalidateLayout(new LayoutEventArgs(false, true, true));

                mobjNavBar.Update();

                if (ObservableItemAdded != null)
                {
                    ObservableItemAdded(this, new ObservableListEventArgs(objNavItemButton));
                }
            }

            return intIndex;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arrNavItemButtons"></param>
        public void AddRange(NavItemButton[] arrNavItemButtons)
        {
            foreach (NavItemButton objNavItemButton in arrNavItemButtons)
            {
                Add(objNavItemButton);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="objNavItemButton"></param>
        public void Remove(NavItemButton objNavItemButton)
        {
            if (objNavItemButton != null)
            {
                if (objNavItemButton.NavBar == mobjNavBar)
                {
                    objNavItemButton.NavBar = null;
                }

                //mobjNavBar.InternalRemove(objNavItemButton);

                List.Remove(objNavItemButton);

                //mobjNavBar.InvalidateLayout(new LayoutEventArgs(false, true, true));

                mobjNavBar.Update();

                if (ObservableItemRemoved != null)
                {
                    ObservableItemRemoved(this, new ObservableListEventArgs(objNavItemButton));
                }
            }
        }

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.IList"/>.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">
        /// The <see cref="T:System.Collections.IList"/> is read-only.
        /// </exception>
        public void Clear()
        {
            //mobjNavBar.InternalClear(List);
            mobjButtons.Clear();
            if (ObservableListCleared != null)
            {
                ObservableListCleared(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Return the index of objNavItemButton in the Buttons collection
        /// </summary>
        /// <param name="objNavItemButton"></param>
        public int IndexOf(NavItemButton objNavItemButton)
        {
            return this.mobjButtons.IndexOf(objNavItemButton);
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <value>The list.</value>
        protected virtual ArrayList List
        {
            get
            {
                return mobjButtons;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="NavItemButton"/> with the specified int index.
        /// </summary>
        /// <value></value>
        public NavItemButton this[int intIndex]
        {
            get
            {
                return (NavItemButton)List[intIndex];
            }
            set
            {
                value.InternalParent = mobjNavBar;
                List[intIndex] = value;
            }
        }

        #endregion Properties

        #region IList Members

        bool IList.IsReadOnly
        {
            get
            {
                return false;
            }
        }

        object IList.this[int index]
        {
            get
            {
                return this[index];
            }
            set
            {
                this[index] = (NavItemButton)value;
            }
        }

        void IList.RemoveAt(int index)
        {
            this.Remove((NavItemButton)this[index]);
        }

        void IList.Insert(int index, object objValue)
        {
        }

        void IList.Remove(object objValue)
        {
            this.Remove((NavItemButton)objValue);
        }

        bool IList.Contains(object objValue)
        {

            return this.mobjButtons.Contains(objValue);
        }

        int IList.IndexOf(object objValue)
        {
            return this.mobjButtons.IndexOf(objValue);
        }

        int IList.Add(object objValue)
        {
            return this.Add((NavItemButton)objValue);
        }

        bool IList.IsFixedSize
        {
            get
            {
                return false;
            }
        }

        #endregion

        #region ICollection Members

        bool ICollection.IsSynchronized
        {
            get
            {

                return mobjButtons.IsSynchronized;
            }
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.ICollection"/>.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// The number of elements contained in the <see cref="T:System.Collections.ICollection"/>.
        /// </returns>
        public int Count
        {
            get
            {
                return mobjButtons.Count;
            }
        }

        void ICollection.CopyTo(Array objArray, int index)
        {
            this.List.CopyTo(objArray, index);
        }

        object ICollection.SyncRoot
        {
            get
            {
                return mobjButtons.SyncRoot;
            }
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return mobjButtons.GetEnumerator();
        }

        #endregion

        #region IObservableList Members

        /// <summary>
        /// Occurs when [observable item inserted].
        /// </summary>
        public event Gizmox.WebGUI.Common.Interfaces.ObservableListEventHandler ObservableItemInserted;

        /// <summary>
        /// Occurs when [observable item added].
        /// </summary>
        public event Gizmox.WebGUI.Common.Interfaces.ObservableListEventHandler ObservableItemAdded;

        /// <summary>
        /// Occurs when [observable list cleared].
        /// </summary>
        public event System.EventHandler ObservableListCleared;

        /// <summary>
        /// Occurs when [observable item removed].
        /// </summary>
        public event Gizmox.WebGUI.Common.Interfaces.ObservableListEventHandler ObservableItemRemoved;

        #endregion
    }

    #endregion NavBarItemCollection Class0.








}