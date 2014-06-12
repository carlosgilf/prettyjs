namespace Bronze.Controls.VWG
{
    using System;
    using System.Collections;
    using System.Reflection;
    using Gizmox.WebGUI.Forms;

    [Serializable]
    public class ScheduleBoxEventCollection : BaseCollection, IList, ICollection, IEnumerable
    {
        private int mintLastEventId;
        private ArrayList mobjEvents;
        private ScheduleBoxEx mobjOwner;

        internal ScheduleBoxEventCollection(ScheduleBoxEx objOwner)
        {
            this.mobjOwner = objOwner;
            this.mobjEvents = new ArrayList();
        }

        public int Add(ScheduleBoxEvent objEvent)
        {
            if (objEvent != null)
            {
                this.mintLastEventId++;
                objEvent.EventId = this.mintLastEventId;
                objEvent.Owner = this.mobjOwner;
                int num = this.mobjEvents.Add(objEvent);
                this.mobjOwner.OnEventAdded(objEvent);
                return num;
            }
            return -1;
        }

        public ScheduleBoxEvent Add(string strSubject, DateTime objStart, DateTime objEnd)
        {
            this.mintLastEventId++;
            ScheduleBoxEvent event2 = new ScheduleBoxEvent(this.mobjOwner, this.mintLastEventId, strSubject, objStart, objEnd);
            this.mobjEvents.Add(event2);
            this.mobjOwner.OnEventAdded(event2);
            return event2;
        }

        public void Clear()
        {
            this.mobjEvents.Clear();
            this.mobjOwner.OnEventsCleared();
        }

        public bool Contains(object value)
        {
            return this.mobjEvents.Contains(value);
        }

        public int IndexOf(object value)
        {
            return this.mobjEvents.IndexOf(value);
        }

        public void Insert(int index, object value)
        {
            this[index] = (ScheduleBoxEvent) value;
        }

        public void Remove(ScheduleBoxEvent objEvent)
        {
            if (this.mobjEvents.Contains(objEvent))
            {
                this.mobjEvents.Remove(objEvent);
                this.mobjOwner.OnEventRemoved(objEvent);
            }
        }

        public void RemoveAt(int index)
        {
            this.Remove((ScheduleBoxEvent) this.mobjEvents[index]);
        }

        int IList.Add(object value)
        {
            return this.mobjEvents.Add(value);
        }

        void IList.Remove(object value)
        {
            this.Remove((ScheduleBoxEvent) value);
        }

        internal ArrayList AllDayEvents
        {
            get
            {
                ArrayList list = new ArrayList();
                foreach (ScheduleBoxEvent event2 in this)
                {
                    if (event2.AllDayEvent)
                    {
                        list.Add(event2);
                    }
                }
                return list;
            }
        }

        public bool IsFixedSize
        {
            get
            {
                return false;
            }
        }

        public ScheduleBoxEvent this[int index]
        {
            get
            {
                return (ScheduleBoxEvent) this.mobjEvents[index];
            }
            set
            {
                if (value != null)
                {
                    this.mintLastEventId++;
                    value.EventId = this.mintLastEventId;
                    value.Owner = this.mobjOwner;
                    this.mobjEvents[index] = value;
                    this.mobjOwner.OnEventAdded(value);
                }
            }
        }

        protected override ArrayList List
        {
            get
            {
                return this.mobjEvents;
            }
        }

        internal ArrayList PartialDayEvents
        {
            get
            {
                ArrayList list = new ArrayList();
                foreach (ScheduleBoxEvent event2 in this)
                {
                    if (!event2.AllDayEvent)
                    {
                        list.Add(event2);
                    }
                }
                return list;
            }
        }

        bool IList.IsReadOnly
        {
            get
            {
                return base.IsReadOnly;
            }
        }

        object IList.this[int index]
        {
            get
            {
                return this.mobjEvents[index];
            }
            set
            {
                this[index] = (ScheduleBoxEvent) value;
            }
        }
    }
}

