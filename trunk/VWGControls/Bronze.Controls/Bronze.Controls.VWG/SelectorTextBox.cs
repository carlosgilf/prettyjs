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
using System.Collections;
using System.Globalization;
using System.Drawing.Design;


#endregion

namespace Bronze.Controls.VWG
{
    /// <summary>
    /// Summary description for SelectorTextBox
    /// </summary>
    //[ToolboxItem(true)]
    //[ToolboxBitmapAttribute(typeof(SelectorTextBox), "Bronze.Controls.VWG.SelectorTextBox.bmp")]
    //[DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    //[ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    [Serializable()]
    //[MetadataTag("BronzeSelctorTextBox")]
    [Skin(typeof(SelectorTextBoxSkin))]
    public partial class SelectorTextBox : Panel
    {
        public SelectorTextBox()
        {
            InitializeComponent();
            this.CustomStyle = "SelectorTextBoxSkin";
            // initialize collections
            //mobjItems = CreateItemCollection();
        }


        //private ObjectCollection mobjItems;

        /// <summary>
        /// The list box item collection
        /// </summary>
        private List<Selector> mobjItems = null;


        [Browsable(false)]
        [DefaultValue(null)]
        public List<Selector> Items
        {
            get
            {
                if (mobjItems == null)
                {
                    mobjItems = new List<Selector>();
                }
                return mobjItems;
            }
        }

        protected override void RenderAttributes(IContext context, IAttributeWriter objWriter)
        {
            base.RenderAttributes(context, objWriter);
            string json = "";
            json = Newtonsoft.Json.JsonConvert.SerializeObject(this.Items);
            objWriter.WriteAttributeString(WGAttributes.Code, json);
        }

        protected override void FireEvent(IEvent objEvent)
        {
            if (objEvent.Type == "ItemsChanged")
            {

                var json = objEvent["items"];
                var items = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Selector>>(json);
                if (items != null)
                {
                    this.mobjItems = items;
                }

                //    var id = objEvent["ItemId"];
                //    var isRemove=objEvent["IsRemove"];
                //    if (string.IsNullOrEmpty(id))
                //    {
                //        return;
                //    }


                //    Selector findItem = null;
                //    foreach (var item in this.Items)
                //    {
                //        if (item.Id.ToString() == id)
                //        {
                //            findItem = item;
                //        }
                //    }
                //    if (isRemove == "1" )
                //    {
                //        if (findItem!=null)
                //        {
                //            this.Items.Remove(findItem);
                //        }
                //    }
                //    else
                //    {
                //        var item = new Selector();

                //        item.Id = id;
                //        if (objEvent["Text"] != null)
                //        {
                //            item.Text = objEvent["Text"];
                //        }

                //        if (objEvent["Value"] != null)
                //        {
                //            item.Value = objEvent["Value"];
                //        }

                //        if (objEvent["Tooltip"] != null)
                //        {
                //            item.Tooltip = objEvent["Tooltip"];
                //        }
                //        this.Items.Add(item);
                //    }

                //}

            }


            /*


            /// <summary>
            /// Gets an object representing the collection of the items contained in this <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.
            /// </summary>
            /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ObjectCollection"></see> representing the items in the <see cref="T:Gizmox.WebGUI.Forms.ComboBox"></see>.</returns>
    #if WG_NET40
            [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    #elif WG_NET35
            [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    #elif WG_NET2
            [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    #else
            [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    #endif
            public ObjectCollection Items
            {
                get
                {
                    return mobjItems;
                }
            }

            /// <summary>
            /// Gets the items comparer object.
            /// </summary>
            [Browsable(false)]
            public virtual IComparer ItemsComparer
            {
                get
                {
                    return new SelectorTextBox.ItemComparer(this);
                }
            }

    

        

            /// <summary>
            /// Checks the no data source.
            /// </summary>
            private void CheckNoDataSource()
            {
                if (this.DataSource != null)
                {
                    throw new ArgumentException("DataSourceLocksItems");
                }
            }

            /// <summary>
            /// Creates the item collection.
            /// </summary>
            protected virtual SelectorTextBox.ObjectCollection CreateItemCollection()
            {
                return new SelectorTextBox.ObjectCollection(this);
            }


            /// <summary>
            /// Operated on this instance after clear items action
            /// </summary>
            internal void Clear()
            {
                //this.RemoveValue<int>(ComboBox.SelectedIndexProperty);
            }

        


            #region ItemComparer Class

            /// <summary>
            /// 
            /// </summary>
            [Serializable()]
            private sealed class ItemComparer : IComparer
            {
                #region Class Members

                private SelectorTextBox mobjSelectorTextBox;

                #endregion

                #region C'Tor

                /// <summary>
                /// Initializes a new instance of the <see cref="ItemComparer"/> class.
                /// </summary>
                /// <param name="objSelectorTextBox">The combo box.</param>
                public ItemComparer(SelectorTextBox objSelectorTextBox)
                {
                    this.mobjSelectorTextBox = objSelectorTextBox;
                }

                #endregion

                #region Methods

                /// <summary>
                /// Compares the specified item1.
                /// </summary>
                /// <param name="objItem1">The obj item1.</param>
                /// <param name="objItem2">The obj item2.</param>
                /// <returns></returns>
                public int Compare(object objItem1, object objItem2)
                {
                    if (objItem1 == null)
                    {
                        if (objItem2 == null)
                        {
                            return 0;
                        }
                        return -1;
                    }
                    if (objItem2 == null)
                    {
                        return 1;
                    }
                    string strItem1 = this.mobjSelectorTextBox.GetItemText(objItem1);
                    string strItem2 = this.mobjSelectorTextBox.GetItemText(objItem2);
                    return Application.CurrentCulture.CompareInfo.Compare(strItem1, strItem2, CompareOptions.StringSort);
                }

                #endregion
            }

            #endregion



            #region ObjectCollection Class

            /// <summary>
            /// Represents the collection of items in a <see cref="T:Gizmox.WebGUI.Forms.SelectorTextBox"></see>.
            /// </summary>
            [ListBindable(false)]
            [Serializable()]
            public class ObjectCollection : ICollection, IList
            {
                #region Class Members

                /// <summary>
                /// The owner tab control
                /// </summary>
                private ArrayList mobjList = null;

                /// <summary>
                /// The object collection parent control
                /// </summary>
                private SelectorTextBox mobjParent = null;

                #endregion Class Members

                #region C'Tor

                /// <summary>
                /// Initializes a new instance of <see cref="T:Gizmox.WebGUI.Forms.SelectorTextBox.ObjectCollection"></see>.
                /// </summary>
                /// <param name="objOwner">The <see cref="T:Gizmox.WebGUI.Forms.SelectorTextBox"></see> that owns this object collection. </param>
                protected internal ObjectCollection(SelectorTextBox objOwner)
                {
                    if (objOwner == null)
                    {
                        throw new NullReferenceException("SelectorTextBox.ObjectCollection has been initialized with a null owner");
                    }
                    // Initialize list
                    mobjList = new ArrayList();

                    // Set parent
                    mobjParent = objOwner;
                }

                #endregion C'Tor

                #region Members

                /// <summary>
                /// For a description of this member, see <see cref="P:System.Collections.ICollection.IsSynchronized"></see>.
                /// </summary>
                public bool IsSynchronized
                {
                    get
                    {
                        return mobjList.IsSynchronized;
                    }
                }

                /// <summary>
                /// Gets the number of items in the collection.
                /// </summary>
                /// <returns>The number of items in the collection.</returns>
                public int Count
                {
                    get
                    {
                        return mobjList.Count;
                    }
                }

                /// <summary>
                /// For a description of this member, see <see cref="M:System.Collections.ICollection.CopyTo(System.Array,System.Int32)"></see>.
                /// </summary>
                /// <param name="objDestination">The one-dimensional array that is the destination of the elements copied from the collection. The array must have zero-based indexing.</param>
                /// <param name="intIndex">The zero-based index in the array at which copying begins.</param>
                public void CopyTo(Array objDestination, int intIndex)
                {
                    mobjList.CopyTo(objDestination, intIndex);
                }

                /// <summary>
                /// Gets the sync root.
                /// </summary>
                /// <value></value>
                public object SyncRoot
                {
                    get
                    {
                        return mobjList.SyncRoot;
                    }
                }

                /// <summary>
                /// Adds an item to the list of items for a <see cref="T:Gizmox.WebGUI.Forms.SelectorTextBox"></see>.
                /// </summary>
                /// <returns>The zero-based index of the item in the collection.</returns>
                /// <param name="objItem">An object representing the item to add to the collection. </param>
                /// <exception cref="T:System.ArgumentNullException">The item parameter was null. </exception>
                public virtual int Add(object objItem)
                {
                    // Ensure that no data source is assigned.
                    this.mobjParent.CheckNoDataSource();

                    int intIndex = this.AddInternal(objItem);
                    mobjParent.Update();
                    return intIndex;

                }

                /// <summary>
                /// Adds an item with sorting.
                /// </summary>
                /// <param name="objItem">The obj item.</param>
                /// <returns></returns>
                private int AddInternal(object objItem)
                {
                    // Verifiy valid item
                    if (objItem == null)
                    {
                        throw new ArgumentNullException("item");
                    }
                    int intIndex = -1;
                    if (!this.mobjParent.Sorted)
                    {
                        intIndex = this.mobjList.Add(objItem);
                    }
                    else
                    {
                        intIndex = this.mobjList.BinarySearch(objItem, this.Comparer);
                        if (intIndex < 0)
                        {
                            intIndex = ~intIndex;
                        }
                        this.mobjList.Insert(intIndex, objItem);
                    }

                    return intIndex;
                }

                private IComparer mobjComparer;

                /// <summary>
                /// Gets the comparer.
                /// </summary>
                private IComparer Comparer
                {
                    get
                    {
                        return mobjParent.ItemsComparer;
                    }
                }

                /// <summary>
                /// Determines if the specified item is located within the collection.
                /// </summary>
                /// <returns>true if the item is located within the collection; otherwise, false.</returns>
                /// <param name="objValue">An object representing the item to locate in the collection. </param>
                public bool Contains(object objValue)
                {
                    return mobjList.Contains(objValue);
                }

                /// <summary>
                /// Adds an array of items to the list of items for a <see cref="T:Gizmox.WebGUI.Forms.SelectorTextBox"></see>.
                /// </summary>
                /// <param name="arrObjects">An array of objects to add to the list. </param>
                /// <exception cref="T:System.ArgumentNullException">An item in the items parameter was null. </exception>
                public virtual void AddRange(Object[] arrObjects)
                {
                    this.AddRangeInternal(arrObjects);
                }

                /// <summary>
                /// Adds the range internal.
                /// </summary>
                /// <param name="arrObjects">The objects.</param>
                internal void AddRangeInternal(Object[] arrObjects)
                {
                    foreach (object objObject in arrObjects)
                    {
                        this.AddInternal(objObject);
                    }

                    mobjParent.Update();
                }

                /// <summary>
                /// Adds the range internal.
                /// </summary>
                /// <param name="objObjects">The objects.</param>
                internal void AddRangeInternal(ICollection objObjects)
                {
                    if (objObjects == null)
                    {
                        throw new ArgumentNullException("objObjects");
                    }

                    foreach (object objObject in objObjects)
                    {
                        this.AddInternal(objObject);
                    }

                    mobjParent.Update();
                }

                /// <summary>
                /// Sets the item with a new value.
                /// </summary>
                /// <param name="intIndex">The index.</param>
                /// <param name="objValue">The value.</param>
                internal void SetItemInternal(int intIndex, object objValue)
                {
                    if (objValue == null)
                    {
                        throw new ArgumentNullException("value");
                    }
                    if ((intIndex < 0) || (intIndex >= this.mobjList.Count))
                    {
                        throw new ArgumentOutOfRangeException("index", "InvalidArgument");
                    }

                    //Set the selected SelectorTextBox item with a new value set from the binding manager
                    this.mobjList[intIndex] = objValue;

                    //update the combo box
                    mobjParent.Update();
                }

                /// <summary>
                /// Adds a range of objects.
                /// </summary>
                /// <param name="objObjects">objects.</param>
                public void AddRange(ICollection objObjects)
                {
                    if (objObjects == null)
                    {
                        throw new ArgumentNullException("objObjects");
                    }

                    // Ensure that no data source is assigned.
                    this.mobjParent.CheckNoDataSource();

                    this.AddRangeInternal(objObjects);
                }

                /// <summary>
                /// Removes the specified item from the <see cref="T:Gizmox.WebGUI.Forms.SelectorTextBox"></see>.
                /// </summary>
                /// <param name="objValue">The <see cref="T:System.Object"></see> to remove from the list. </param>
                /// <exception cref="T:System.ArgumentOutOfRangeException">The value parameter was less than zero.-or- The value parameter was greater than or equal to the count of items in the collection. </exception>
                public void Remove(object objValue)
                {
                    mobjParent.Update();
                    mobjList.Remove(objValue);
                }

                /// <summary>
                /// Returns an enumerator that can be used to iterate through the item collection.
                /// </summary>
                /// <returns>An <see cref="T:System.Collections.IEnumerator"></see> that represents the item collection.</returns>
                public IEnumerator GetEnumerator()
                {
                    return mobjList.GetEnumerator();
                }

                /// <summary>
                /// Clears the collection.
                /// </summary>
                internal void ClearInternal()
                {
                    mobjList.Clear();
                    mobjParent.Clear();
                    mobjParent.Update();
                }

                /// <summary>
                /// Removes all items from the <see cref="T:Gizmox.WebGUI.Forms.SelectorTextBox"></see>.
                /// </summary>
                public void Clear()
                {
                    // Ensure that no data source is assigned.
                    this.mobjParent.CheckNoDataSource();
                    this.ClearInternal();
                }

                /// <summary>
                /// Retrieves the index within the collection of the specified item.
                /// </summary>
                /// <returns>The zero-based index where the item is located within the collection; otherwise, -1.</returns>
                /// <param name="objValue">An object representing the item to locate in the collection. </param>
                /// <exception cref="T:System.ArgumentNullException">The value parameter was null. </exception>
                public int IndexOf(object objValue)
                {
                    return mobjList.IndexOf(objValue);
                }

                /// <summary>
                /// Gets the <see cref="object"/> with the specified int index.
                /// </summary>
                [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
                public object this[int intIndex]
                {
                    get
                    {
                        return mobjList[intIndex];
                    }
                    set
                    {
                        if (this.mobjList != null && this.mobjList[intIndex] != value)
                        {
                            this.mobjList[intIndex] = value;
                            this.mobjParent.Update();
                        }
                    }
                }

                /// <summary>
                /// Provides a way to initialize the collection from serialization
                /// </summary>
                /// <param name="arrItems"></param>
                internal void SetItemsInternal(object[] arrItems)
                {
                    mobjList.AddRange(arrItems);
                }

                #endregion Members

                #region IList Members

                /// <summary>
                /// Gets a value indicating whether this collection can be modified.
                /// </summary>
                /// <returns>Always false.</returns>
                public bool IsReadOnly
                {
                    get
                    {
                        return false;
                    }
                }

                /// <summary>
                /// Gets or sets the <see cref="System.Object"/> at the specified index.
                /// </summary>
                object System.Collections.IList.this[int intIndex]
                {
                    get
                    {
                        return mobjList[intIndex];
                    }
                    set
                    {
                        mobjList[intIndex] = value;
                    }
                }

                /// <summary>
                /// Removes an item from the <see cref="T:Gizmox.WebGUI.Forms.SelectorTextBox"></see> at the specified index.
                /// </summary>
                /// <param name="intIndex">The index of the item to remove. </param>
                /// <exception cref="T:System.ArgumentOutOfRangeException">The value parameter was less than zero.-or- The value parameter was greater than or equal to the count of items in the collection. </exception>
                public void RemoveAt(int intIndex)
                {
                    // Ensure that no data source is assigned.
                    this.mobjParent.CheckNoDataSource();

                    mobjList.RemoveAt(intIndex);
                    mobjParent.Update();
                }

                /// <summary>
                /// Inserts an item into the collection at the specified index.
                /// </summary>
                /// <returns>The zero-based index of the newly added item.</returns>
                /// <param name="objItem">An object representing the item to insert. </param>
                /// <param name="intIndex">The zero-based index location where the item is inserted. </param>
                /// <exception cref="T:System.ArgumentNullException">The item was null. </exception>
                /// <exception cref="T:System.ArgumentOutOfRangeException">The index was less than zero.-or- The index was greater than the count of items in the collection. </exception>
                public void Insert(int intIndex, object objItem)
                {
                    // Ensure that no data source is assigned.
                    this.mobjParent.CheckNoDataSource();
                    mobjParent.Update();
                    mobjList.Insert(intIndex, objItem);
                }

                /// <summary>
                /// For a description of this member, see <see cref="P:System.Collections.IList.IsFixedSize"></see>.
                /// </summary>
                /// <returns>false in all cases.</returns>
                public bool IsFixedSize
                {
                    get
                    {
                        // TODO:  Add ObjectCollection.IsFixedSize getter implementation
                        return false;
                    }
                }

                #endregion IList Members
            }
            #endregion


            */








        }

        [Serializable]
        public class Selector
        {
            public string Text
            {
                get;
                set;
            }

            private object value;

            public object Value
            {
                get { return this.value; }
                set { this.value = value; }
            }

            //[Newtonsoft.Json.JsonProperty(PropertyName="uid")]
            public object Id
            {
                get;
                set;
            }

            public string Tooltip
            {
                get;
                set;
            }

        }
    }
}