namespace Bronze.Controls.VWG
{
    using Gizmox.WebGUI;
    using Gizmox.WebGUI.Common.Extensibility;
    using Gizmox.WebGUI.Common.Interfaces;
    using Gizmox.WebGUI.Forms.Design;
    using Gizmox.WebGUI.Forms.Skins;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using Gizmox.WebGUI.Forms;

    [Serializable,
    Skin(typeof(ScheduleBoxSkin)),
    DesignTimeController("Gizmox.WebGUI.Forms.Design.ScheduleBoxController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769"),
    ClientController("Gizmox.WebGUI.Client.Controllers.ScheduleBoxController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23"),
    ToolboxItem(true),
    ToolboxItemCategory("Common Controls"),
    MetadataTag("SCB")
    ]
    public class ScheduleBoxEx : Control, IRequiresRegistration
    {
        private bool displayMonthHeader;
        private const int mcntWorkEndHour = 0x11;
        private const int mcntWorkStartHour = 8;
        private Day menmFirstDayOfWeek;
        private ScheduleBoxHourFormat menmHour;
        private ScheduleBoxView menmView;
        private int mintWorkEndHour = 0x11;
        private int mintWorkStartHour = 8;
        private ArrayList mobjDays;
        private ScheduleBoxEventCollection mobjEvents;
        private DateTime mobjFirstDate = DateTime.Now;

        public event ScheduleBoxEventHandler EventDoubleClick;
        //public event ScheduleBoxRowHandler EventRowItemClick;


        /// <summary>
        /// The RowItemClick event registration.
        /// </summary>
        private static readonly SerializableEvent RowItemClickEvent = SerializableEvent.Register("RowItemClick", typeof(ScheduleBoxRowHandler), typeof(ScheduleBoxEx));

        /// <summary>
        /// Occurs when selection changed.
        /// </summary>
        public event ScheduleBoxRowHandler RowItemClick
        {
            add
            {
                this.AddHandler(ScheduleBoxEx.RowItemClickEvent, value);
            }
            remove
            {
                this.RemoveHandler(ScheduleBoxEx.RowItemClickEvent, value);
            }
        }

        /// <summary>
        /// Gets the hanlder for the RowItemClick event.
        /// </summary>
        private ScheduleBoxRowHandler RowItemClickHandler
        {
            get
            {
                return (ScheduleBoxRowHandler)this.GetHandler(ScheduleBoxEx.RowItemClickEvent);
            }
        }

        protected override void AddChild(object objValue)
        {
            if (objValue is ScheduleBoxEvent)
            {
                this.Events.Add((ScheduleBoxEvent)objValue);
            }
            else
            {
                base.AddChild(objValue);
            }
        }

        protected virtual ScheduleBoxEventCollection CreateEventsCollectionInstance()
        {
            return new ScheduleBoxEventCollection(this);
        }

        private int DayToNumber(Day enmDay)
        {
            switch (enmDay)
            {
                case Day.Monday:
                    return 2;

                case Day.Tuesday:
                    return 3;

                case Day.Wednesday:
                    return 4;

                case Day.Thursday:
                    return 5;

                case Day.Friday:
                    return 6;

                case Day.Saturday:
                    return 7;

                case Day.Sunday:
                    return 1;
            }
            return 1;
        }

        private int DayToNumber(DayOfWeek enmDay)
        {
            switch (enmDay)
            {
                case DayOfWeek.Sunday:
                    return 1;

                case DayOfWeek.Monday:
                    return 2;

                case DayOfWeek.Tuesday:
                    return 3;

                case DayOfWeek.Wednesday:
                    return 4;

                case DayOfWeek.Thursday:
                    return 5;

                case DayOfWeek.Friday:
                    return 6;

                case DayOfWeek.Saturday:
                    return 7;
            }
            return 1;
        }

        protected override void FireEvent(IEvent objEvent)
        {
            if (!CommonUtils.IsNullOrEmpty(new string[] { objEvent.Member }))
            {
                int num = -1;
                char ch = objEvent.Member[0];
                if (ch == 'E')
                {
                    num = int.Parse(objEvent.Member.Substring(1));
                    string type = objEvent.Type;
                    if (type != null)
                    {
                        if (!(type == "DoubleClick"))
                        {
                            if (!(type == "Click"))
                            {
                                return;
                            }
                        }
                        else
                        {
                            foreach (ScheduleBoxEvent event2 in this.Events)
                            {
                                if (event2.EventId == num)
                                {
                                    this.OnEventDoubleClick(new ScheduleBoxEventArgs(event2));
                                }
                            }
                            return;
                        }
                        foreach (ScheduleBoxEvent event3 in this.Events)
                        {
                            if (event3.EventId == num)
                            {
                                int intX = base.GetEventValue(objEvent, "X", 0);
                                int intY = base.GetEventValue(objEvent, "Y", 0);
                                MouseEventArgs objMouseEventArgs = new MouseEventArgs(base.GetEventButtonsValue(objEvent, MouseButtons.Left), 1, intX, intY, 0);
                                if ((objMouseEventArgs != null) && (objMouseEventArgs.Button == MouseButtons.Right))
                                {
                                    event3.OnRightClick(objMouseEventArgs);
                                }
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                if (objEvent.Type == "RowItemClick")
                {
                    try
                    {
                        var timeStr = objEvent["time"];
                        var time = DateTime.Parse(timeStr);
                        OnRowItemClick(new ScheduleBoxRowItemEventArgs(time));
                    }
                    catch (Exception)
                    {
                    }
                }
                base.FireEvent(objEvent);
            }
        }

        private EventTypes GetEventCriticalEvents(ScheduleBoxEvent objEvent)
        {
            EventTypes none = EventTypes.None;
            if ((objEvent.ContextMenu == null) && (this.ContextMenu == null))
            {
                return none;
            }
            return (none | EventTypes.RightClick);
        }

        internal string GetMonthString(int month)
        {
            switch (month)
            {
                case 1:
                    return WGLabels.January;

                case 2:
                    return WGLabels.February;

                case 3:
                    return WGLabels.March;

                case 4:
                    return WGLabels.April;

                case 5:
                    return WGLabels.May;

                case 6:
                    return WGLabels.June;

                case 7:
                    return WGLabels.July;

                case 8:
                    return WGLabels.August;

                case 9:
                    return WGLabels.September;

                case 10:
                    return WGLabels.October;

                case 11:
                    return WGLabels.November;

                case 12:
                    return WGLabels.December;
            }
            return "Undefined";
        }

        internal void OnEventAdded(ScheduleBoxEvent objEvent)
        {
            this.Update();
        }

        protected virtual void OnEventDoubleClick(ScheduleBoxEventArgs objScheduleBoxEventArgs)
        {
            ScheduleBoxEventHandler eventDoubleClick = this.EventDoubleClick;
            if (eventDoubleClick != null)
            {
                eventDoubleClick(this, objScheduleBoxEventArgs);
            }
        }

        protected virtual void OnRowItemClick(ScheduleBoxRowItemEventArgs objArgs)
        {
            if (RowItemClickHandler != null)
            {
                RowItemClickHandler(this, objArgs);
            }
        }

        internal void OnEventRemoved(ScheduleBoxEvent objEvent)
        {
            this.Update();
        }

        internal void OnEventsCleared()
        {
            this.Update();
        }

        internal void OnEventUpdated(ScheduleBoxEvent objEvent)
        {
            this.Update();
        }

        protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            objWriter.WriteAttributeString("HourFormat", this.HourFormat.ToString());
            objWriter.WriteAttributeString("DisplayMonthHeader", this.displayMonthHeader.ToString());
            if ((this.mintWorkStartHour != 8) || (this.mintWorkEndHour != 0x11))
            {
                objWriter.WriteAttributeString("WorkStartHour", this.mintWorkStartHour.ToString());
                objWriter.WriteAttributeString("WorkEndHour", this.mintWorkEndHour.ToString());
            }
            if (this.menmView != ScheduleBoxView.Month)
            {
                objWriter.WriteAttributeString("VW", "Days");
                if (this.menmView == ScheduleBoxView.FullMonth)
                {
                    objWriter.WriteAttributeString("FullMonth", "Yes");
                }
                else
                {
                    objWriter.WriteAttributeString("FullMonth", "No");
                }
            }
            else
            {
                objWriter.WriteAttributeString("VW", "Month");
                DateTime time = new DateTime(this.FirstDate.Year, this.FirstDate.Month, 1, 0, 0, 0);
                DateTime time2 = new DateTime(this.FirstDate.Year, this.FirstDate.Month, 1, 0, 0, 0);
                objWriter.WriteAttributeString("CurrentMonthHeader", this.FirstDate.ToString("yyyy年M月"));
                time2 = time2.AddMonths(1).AddDays(-1.0);
                int num = this.DayToNumber(this.menmFirstDayOfWeek);
                int num2 = this.DayToNumber(time.DayOfWeek);
                int num3 = 0;
                if (num <= num2)
                {
                    num3 = (num2 - num) + 1;
                }
                else
                {
                    num3 = (7 - (num - num2)) + 1;
                }
                objWriter.WriteAttributeString("DisplayStart", num3.ToString());
                objWriter.WriteAttributeString("DisplayDays", time2.Day.ToString());
            }
            switch (this.menmFirstDayOfWeek)
            {
                case Day.Sunday:
                case Day.Default:
                    objWriter.WriteAttributeString("DisplatFirstWeekDay", "1");
                    break;

                case Day.Monday:
                    objWriter.WriteAttributeString("DisplatFirstWeekDay", "2");
                    break;
            }
            ArrayList days = this.Days;
            ArrayList allDayEvents = this.Events.AllDayEvents;
            SortedList list3 = new SortedList();
            SortedList list4 = new SortedList();
            ScheduleBoxEvent[,] eventArray = new ScheduleBoxEvent[days.Count, 30];
            int index = 0;
            foreach (DateTime time3 in days)
            {
                if ((this.menmView == ScheduleBoxView.FullMonth) && this.displayMonthHeader)
                {
                    if ((list3.Count == 0) || !list3.ContainsKey(time3.Month))
                    {
                        list3.Add(time3.Month, 1);
                        list4.Add(time3.Month, time3.Year);
                    }
                    else if (list3.ContainsKey(time3.Month))
                    {
                        list3[time3.Month] = ((int)list3[time3.Month]) + 1;
                    }
                }
                foreach (ScheduleBoxEvent event2 in allDayEvents)
                {
                    if (!event2.IsInRange(time3))
                    {
                        continue;
                    }
                    int num5 = -1;
                    for (int j = 0; j < 30; j++)
                    {
                        if (num5 == -1)
                        {
                            if (eventArray[index, j] != null)
                            {
                                continue;
                            }
                            if ((index > 0) && (eventArray[index - 1, j] != null))
                            {
                                ScheduleBoxEvent event3 = eventArray[index - 1, j];
                                if ((event3 != event2) && event3.IsInRange(time3))
                                {
                                    continue;
                                }
                            }
                            if (eventArray[index, j] == null)
                            {
                                num5 = j;
                                if (index == 0)
                                {
                                    break;
                                }
                            }
                        }
                        if ((index > 0) && (eventArray[index - 1, j] == event2))
                        {
                            num5 = j;
                            break;
                        }
                    }
                    eventArray[index, num5] = event2;
                }
                index++;
            }
            if ((this.menmView == ScheduleBoxView.FullMonth) && this.displayMonthHeader)
            {
                if (list3.Count > 1)
                {
                    if (((int)list4.GetByIndex(0)) <= ((int)list4.GetByIndex(1)))
                    {
                        objWriter.WriteStartElement("Month");
                        objWriter.WriteAttributeString("MonthDays", list3.GetByIndex(0).ToString());
                        objWriter.WriteAttributeString("MonthHeader", this.GetMonthString((int)list3.GetKey(0)) + " / " + ((int)list4[(int)list3.GetKey(0)]).ToString());
                        objWriter.WriteEndElement();
                        objWriter.WriteStartElement("Month");
                        objWriter.WriteAttributeString("MonthDays", list3.GetByIndex(1).ToString());
                        objWriter.WriteAttributeString("MonthHeader", this.GetMonthString((int)list3.GetKey(1)) + " / " + ((int)list4[(int)list3.GetKey(1)]).ToString());
                        objWriter.WriteEndElement();
                    }
                    else
                    {
                        objWriter.WriteStartElement("Month");
                        objWriter.WriteAttributeString("MonthDays", list3.GetByIndex(1).ToString());
                        objWriter.WriteAttributeString("MonthHeader", this.GetMonthString((int)list3.GetKey(1)) + " / " + ((int)list4[(int)list3.GetKey(1)]).ToString());
                        objWriter.WriteEndElement();
                        objWriter.WriteStartElement("Month");
                        objWriter.WriteAttributeString("MonthDays", list3.GetByIndex(0).ToString());
                        objWriter.WriteAttributeString("MonthHeader", this.GetMonthString((int)list3.GetKey(0)) + " / " + ((int)list4[(int)list3.GetKey(0)]).ToString());
                        objWriter.WriteEndElement();
                    }
                }
                else
                {
                    objWriter.WriteStartElement("Month");
                    objWriter.WriteAttributeString("MonthDays", list3.GetByIndex(0).ToString());
                    objWriter.WriteAttributeString("MonthHeader", this.GetMonthString((int)list3.GetKey(0)) + " / " + ((int)list4[(int)list3.GetKey(0)]).ToString());
                    objWriter.WriteEndElement();
                }
            }
            for (int i = 0; i < 30; i++)
            {
                bool flag = false;
                ScheduleBoxEvent event4 = null;
                index = 0;
                while (index < days.Count)
                {
                    if (eventArray[index, i] != null)
                    {
                        objWriter.WriteStartElement("Row");
                        flag = true;
                        break;
                    }
                    index++;
                }
                for (index = 0; index < days.Count; index++)
                {
                    ScheduleBoxEvent objEvent = eventArray[index, i];
                    if ((objEvent != null) && (event4 != objEvent))
                    {
                        objWriter.WriteStartElement("Event");
                        objWriter.WriteAttributeString("mId", objEvent.ID);
                        objWriter.WriteAttributeString("oId", this.ID.ToString());
                        this.RenderEventEvents(objWriter, objEvent);
                        objWriter.WriteAttributeString("Start", (index + 1).ToString());
                        int num8 = 1;
                        while ((index + num8) < days.Count)
                        {
                            if (eventArray[index + num8, i] != objEvent)
                            {
                                break;
                            }
                            num8++;
                        }
                        objWriter.WriteAttributeString("Duration", num8.ToString());
                        objWriter.WriteAttributeString("Subject", objEvent.Subject);
                        objWriter.WriteEndElement();
                        event4 = objEvent;
                    }
                }
                if (!flag)
                {
                    break;
                }
                objWriter.WriteEndElement();
            }
            ArrayList[] listArray = new ArrayList[days.Count];
            ArrayList partialDayEvents = this.Events.PartialDayEvents;
            index = 0;
            foreach (DateTime time4 in days)
            {
                listArray[index] = new ArrayList();
                ArrayList list6 = new ArrayList(partialDayEvents);
                foreach (ScheduleBoxEvent event6 in list6)
                {
                    if (event6.IsInRange(time4))
                    {
                        partialDayEvents.Remove(event6);
                        listArray[index].Add(new EventSite(event6));
                    }
                }
                index++;
            }
            index = 0;
            foreach (ArrayList list7 in listArray)
            {
                list7.Sort();
                foreach (EventSite site in list7)
                {
                    foreach (EventSite site2 in list7)
                    {
                        if ((!site.HasShare(site2) && (site != site2)) && (((site.Event.Start <= site2.Event.Start) && (site.Event.End >= site2.Event.Start)) || ((site.Event.End >= site2.Event.End) && (site.Event.Start <= site2.Event.End))))
                        {
                            site.Share++;
                            site.AddShare(site2);
                            site2.Share++;
                            site2.AddShare(site);
                            site2.Left++;
                        }
                    }
                }
                objWriter.WriteStartElement("Day");
                DateTime time11 = (DateTime)days[index];
                objWriter.WriteAttributeString("Number", time11.Day.ToString());
                DateTime time5 = (DateTime)days[index];
                if (time5.Day == DateTime.Now.Day)
                {
                    objWriter.WriteAttributeString("IsToday", "1");
                }
                if (this.menmView != ScheduleBoxView.FullMonth)
                {
                    time5 = (DateTime)days[index];
                    if (this.menmView == ScheduleBoxView.FullWeek || this.menmView == ScheduleBoxView.Week)
                    {
                        var week = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(time5.DayOfWeek);
                        objWriter.WriteAttributeString("TL", ToShortTimeAndWeekDay(time5));
                    }
                    else
                    {
                        objWriter.WriteAttributeString("TL", time5.ToShortDateString());
                    }
                }
                else
                {
                    objWriter.WriteAttributeString("TL", ((DateTime)days[index]).ToString("dd"));
                }
                foreach (EventSite site3 in list7)
                {
                    objWriter.WriteStartElement("Event");
                    objWriter.WriteAttributeString("Start", site3.Event.StartHalfHoursFromMidnight.ToString());
                    objWriter.WriteAttributeString("Duration", site3.Event.Duration.ToString(CultureInfo.InvariantCulture));
                    double offsetY = site3.Event.OffsetY;
                    if (offsetY > 0.0)
                    {
                        objWriter.WriteAttributeString("OY", offsetY.ToString(CultureInfo.InvariantCulture));
                    }
                    objWriter.WriteAttributeString("mId", site3.Event.ID);
                    objWriter.WriteAttributeString("oId", this.ID.ToString());
                    this.RenderEventEvents(objWriter, site3.Event);
                    objWriter.WriteAttributeString("Subject", site3.Event.Subject);
                    objWriter.WriteAttributeString("Left", site3.Left.ToString());
                    objWriter.WriteAttributeString("Share", site3.Share.ToString());
                    objWriter.WriteEndElement();
                }
                objWriter.WriteEndElement();
                index++;
            }
        }

        private void RenderEventEvents(IResponseWriter objWriter, ScheduleBoxEvent objEvent)
        {
            EventTypes eventCriticalEvents = this.GetEventCriticalEvents(objEvent);
            if (eventCriticalEvents != EventTypes.None)
            {
                objWriter.WriteAttributeString("E", ((int)eventCriticalEvents).ToString());
            }
        }

        private bool ValidateWorkHour(int intStartWorkHour, int intEndWorkHour, int intNewValue, bool bIsStartHour)
        {
            if ((intNewValue < 0) || (intNewValue > 0x18))
            {
                throw new Exception("Work hour must be bettwen 0 and 24.");
            }
            if (bIsStartHour)
            {
                if (intNewValue > intEndWorkHour)
                {
                    throw new Exception("Work start hour cant be higher then the work end hour.");
                }
            }
            else if (intStartWorkHour > intNewValue)
            {
                throw new Exception("Work start hour cant be higher then the work end hour.");
            }
            return true;
        }


        protected override EventTypes GetCriticalEvents()
        {
            EventTypes enmTypes = base.GetCriticalEvents();
            if (this.RowItemClickHandler != null) enmTypes |= EventTypes.CheckedChange;
            return enmTypes;
        }

        internal ArrayList Days
        {
            get
            {
                if (this.mobjDays == null)
                {
                    this.mobjDays = new ArrayList();
                    DateTime date = this.mobjFirstDate.Date;
                    if (this.menmView == ScheduleBoxView.Month)
                    {
                        date = new DateTime(date.Year, date.Month, 1);
                    }
                    this.mobjDays.Add(date);
                    for (int i = 0; i < (this.TotalDaysToDisplay - 1); i++)
                    {
                        date = date.AddDays(1.0);
                        this.mobjDays.Add(date);
                    }
                }
                return this.mobjDays;
            }
        }

        public bool DisplayMonthHeader
        {
            get
            {
                return this.displayMonthHeader;
            }
            set
            {
                if (this.displayMonthHeader != value)
                {
                    this.displayMonthHeader = value;
                    this.Update();
                }
            }
        }

        public ScheduleBoxEventCollection Events
        {
            get
            {
                if (this.mobjEvents == null)
                {
                    this.mobjEvents = this.CreateEventsCollectionInstance();
                }
                return this.mobjEvents;
            }
        }

        public DateTime FirstDate
        {
            get
            {
                return this.mobjFirstDate;
            }
            set
            {
                if (this.mobjFirstDate != value)
                {
                    this.mobjFirstDate = value;
                    this.mobjDays = null;
                    this.Update();
                }
            }
        }

        public Day FirstDayOfWeek
        {
            get
            {
                return this.menmFirstDayOfWeek;
            }
            set
            {
                if ((value != Day.Sunday) && (value != Day.Monday))
                {
                    throw new ArgumentOutOfRangeException("FirstDayOfWeek", "Schedule box FirstDayOfWeek can receive Monday or Sunday.");
                }
                if (this.menmFirstDayOfWeek != value)
                {
                    this.menmFirstDayOfWeek = value;
                    this.Update();
                }
            }
        }

        public ScheduleBoxHourFormat HourFormat
        {
            get
            {
                return this.menmHour;
            }
            set
            {
                if (this.menmHour != value)
                {
                    this.menmHour = value;
                    this.Update();
                }
            }
        }

        protected override bool IsDelayedDrawing
        {
            get
            {
                return true;
            }
        }

        internal int TotalDaysToDisplay
        {
            get
            {
                switch (this.menmView)
                {
                    case ScheduleBoxView.Week:
                        return 5;

                    case ScheduleBoxView.FullWeek:
                        return 7;

                    case ScheduleBoxView.FullMonth:
                    case ScheduleBoxView.Month:
                        return DateTime.DaysInMonth(this.FirstDate.Year, this.FirstDate.Month);

                    case ScheduleBoxView.Day:
                        return 1;
                }
                return 5;
            }
        }

        public ScheduleBoxView View
        {
            get
            {
                return this.menmView;
            }
            set
            {
                if (this.menmView != value)
                {
                    this.menmView = value;
                    this.mobjDays = null;
                    this.Update();
                }
            }
        }

        public int WorkEndHour
        {
            get
            {
                return this.mintWorkEndHour;
            }
            set
            {
                if (this.ValidateWorkHour(this.mintWorkStartHour, this.mintWorkEndHour, value, false))
                {
                    this.mintWorkEndHour = value;
                    this.Update();
                }
            }
        }

        public int WorkStartHour
        {
            get
            {
                return (this.mintWorkStartHour + 1);
            }
            set
            {
                if (this.ValidateWorkHour(this.mintWorkStartHour, this.mintWorkEndHour, value, true))
                {
                    this.mintWorkStartHour = value - 1;
                    this.Update();
                }
            }
        }

        private string ToWeekDay(DateTime time)
        {
            string[] Day = new string[] { "周日", "周一", "周二", "周三", "周四", "周五", "周六" };
            return Day[Convert.ToInt16(time.DayOfWeek)];
        }

        private string ToShortTimeAndWeekDay(DateTime time)
        {
            string timeStr = "";
            if (time.Year == DateTime.Now.Year)
            {
                timeStr = time.Month + "/" + time.Day;
            }
            else
            {
                timeStr = time.Year + "/" + time.Month + "/" + time.Day;
            }
            var week = ToWeekDay(time);
            return timeStr + "(" + week + ")";
        }

        [Serializable]
        internal class EventSite : IComparable
        {
            public readonly ScheduleBoxEvent Event;
            public int Left;
            private ArrayList mobjShared;
            public int Share = 1;

            internal EventSite(ScheduleBoxEvent objEvent)
            {
                this.Event = objEvent;
                this.mobjShared = new ArrayList();
            }

            public void AddShare(ScheduleBoxEx.EventSite objEvent)
            {
                this.mobjShared.Add(objEvent);
            }

            public int CompareTo(object objValue)
            {
                int num = 0;
                ScheduleBoxEx.EventSite site = objValue as ScheduleBoxEx.EventSite;
                if (site != null)
                {
                    if (this.Event.Start < site.Event.Start)
                    {
                        return -1;
                    }
                    if (this.Event.Start > site.Event.Start)
                    {
                        num = 1;
                    }
                }
                return num;
            }

            public bool HasShare(ScheduleBoxEx.EventSite objEvent)
            {
                return this.mobjShared.Contains(objEvent);
            }

            [Browsable(false), Obsolete("This property is obsolete - use the event.End instead.")]
            public int End
            {
                get
                {
                    return (this.Event.StartHalfHoursFromMidnight + this.Event.HalfHours);
                }
            }

            [Browsable(false), Obsolete("This property is obsolete - use the event.Start instead.")]
            public int Start
            {
                get
                {
                    return this.Event.StartHalfHoursFromMidnight;
                }
            }
        }

        [Serializable]
        public class ScheduleBoxEventArgs : EventArgs
        {
            private ScheduleBoxEvent mobjEvent;

            public ScheduleBoxEventArgs(ScheduleBoxEvent objEvent)
            {
                this.mobjEvent = objEvent;
            }

            public ScheduleBoxEvent Event
            {
                get
                {
                    return this.mobjEvent;
                }
            }
        }

        [Serializable]
        public class ScheduleBoxRowItemEventArgs : EventArgs
        {
            private DateTime time;

            public DateTime Time
            {
                get { return time; }
                set { time = value; }
            }

            public ScheduleBoxRowItemEventArgs(DateTime time)
            {
                this.time = time;
            }
        }

        public delegate void ScheduleBoxEventHandler(object sender, ScheduleBoxEx.ScheduleBoxEventArgs e);
        public delegate void ScheduleBoxRowHandler(object sender, ScheduleBoxEx.ScheduleBoxRowItemEventArgs e);
    }
}

