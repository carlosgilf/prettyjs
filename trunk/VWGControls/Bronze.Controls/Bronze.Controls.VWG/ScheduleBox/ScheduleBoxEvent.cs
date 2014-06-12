namespace Bronze.Controls.VWG
{
    using Gizmox.WebGUI.Common.Interfaces;
    using Gizmox.WebGUI.Forms.Skins;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using Gizmox.WebGUI.Forms;

    [Serializable]
    public class ScheduleBoxEvent : SerializableObject, IClientComponent
    {
        private static SerializableProperty ContextMenuProperty = SerializableProperty.Register("ContextMenu", typeof(Gizmox.WebGUI.Forms.ContextMenu), typeof(ScheduleBoxEvent));
        private static SerializableProperty EndProperty = SerializableProperty.Register("End", typeof(DateTime), typeof(ScheduleBoxEvent), new SerializablePropertyMetadata(DateTime.MinValue));
        private static SerializableProperty EventIdProperty = SerializableProperty.Register("EventId", typeof(int), typeof(ScheduleBoxEvent), new SerializablePropertyMetadata(0));
        private static SerializableProperty OwnerProperty = SerializableProperty.Register("Owner", typeof(ScheduleBoxEx), typeof(ScheduleBoxEvent));
        private static SerializableProperty StartProperty = SerializableProperty.Register("Start", typeof(DateTime), typeof(ScheduleBoxEvent), new SerializablePropertyMetadata(DateTime.MinValue));
        private static SerializableProperty SubjectProperty = SerializableProperty.Register("Subject", typeof(string), typeof(ScheduleBoxEvent), new SerializablePropertyMetadata(string.Empty));
        private static SerializableProperty TagProperty = SerializableProperty.Register("Tag", typeof(object), typeof(ScheduleBoxEvent));

        public ScheduleBoxEvent()
        {
            DateTime now = DateTime.Now;
            this.End = now.AddHours(1.0);
            this.Start = now;
        }

        internal ScheduleBoxEvent(ScheduleBoxEx objOwner, int intEventId, string strSubject, DateTime objStart, DateTime objEnd)
        {
            this.EventId = intEventId;
            this.Owner = objOwner;
            this.Subject = strSubject;
            this.End = objEnd;
            this.Start = objStart;
        }

        internal bool IsEndDay(DateTime objDay)
        {
            return (this.End.Date == objDay.Date);
        }

        internal bool IsInRange(DateTime objDay)
        {
            if (((this.Start.CompareTo(objDay) != -1) || (this.End.CompareTo(objDay) != 1)) && (!this.IsStartDay(objDay) && !this.IsEndDay(objDay)))
            {
                return false;
            }
            return true;
        }

        internal bool IsStartDay(DateTime objDay)
        {
            return (this.Start.Date == objDay.Date);
        }

        internal void OnRightClick(MouseEventArgs objMouseEventArgs)
        {
            Gizmox.WebGUI.Forms.ContextMenu contextMenu = this.ContextMenu;
            if (contextMenu != null)
            {
                contextMenu.Show(this.Owner, this, new Point(objMouseEventArgs.X, objMouseEventArgs.Y), DialogAlignment.Custom);
            }
        }

        public override string ToString()
        {
            return ("Event: {" + this.Subject + "}");
        }

        internal bool AllDayEvent
        {
            get
            {
                return (this.Start.Date != this.End.Date);
            }
        }

        [DefaultValue((string) null), Browsable(true)]
        public virtual Gizmox.WebGUI.Forms.ContextMenu ContextMenu
        {
            get
            {
                Gizmox.WebGUI.Forms.ContextMenu contextMenu = base.GetValue<Gizmox.WebGUI.Forms.ContextMenu>(ContextMenuProperty);
                if ((contextMenu == null) && (this.Owner != null))
                {
                    contextMenu = this.Owner.ContextMenu;
                }
                return contextMenu;
            }
            set
            {
                base.SetValue<Gizmox.WebGUI.Forms.ContextMenu>(ContextMenuProperty, value);
            }
        }

        internal TimeSpan DateDiff
        {
            get
            {
                return new TimeSpan(this.End.Ticks - this.Start.Ticks);
            }
        }

        internal double Days
        {
            get
            {
                return Math.Ceiling(this.DateDiff.TotalDays);
            }
        }

        internal double Duration
        {
            get
            {
                ScheduleBoxSkin skin = null;
                if (this.Owner != null)
                {
                    skin = SkinFactory.GetSkin(this.Owner, typeof(ScheduleBoxSkin)) as ScheduleBoxSkin;
                }
                int num = (skin != null) ? skin.HalfHourHeight : 20;
                double num2 = this.DateDiff.TotalHours * 2.0;
                if ((num2 * num) < 1.0)
                {
                    return (1.0 / ((double) num));
                }
                return num2;
            }
        }

        public DateTime End
        {
            get
            {
                return base.GetValue<DateTime>(EndProperty);
            }
            set
            {
                if (DateTime.Compare(value, this.Start) == -1)
                {
                    throw new ArgumentOutOfRangeException();
                }
                if (base.SetValue<DateTime>(EndProperty, value) && (this.Owner != null))
                {
                    this.Owner.OnEventUpdated(this);
                }
            }
        }

        internal int EventId
        {
            get
            {
                return base.GetValue<int>(EventIdProperty);
            }
            set
            {
                base.SetValue<int>(EventIdProperty, value);
            }
        }

        internal int HalfHours
        {
            get
            {
                return (int) Math.Ceiling((double) (this.DateDiff.TotalHours * 2.0));
            }
        }

        internal double Hours
        {
            get
            {
                return Math.Ceiling(this.DateDiff.TotalHours);
            }
        }

        public string ID
        {
            get
            {
                return string.Format("E{0}", this.EventId);
            }
        }

        internal int OffsetY
        {
            get
            {
                ScheduleBoxSkin skin = null;
                if (this.Owner != null)
                {
                    skin = SkinFactory.GetSkin(this.Owner, typeof(ScheduleBoxSkin)) as ScheduleBoxSkin;
                }
                int num = (skin != null) ? skin.HalfHourHeight : 20;
                int minute = this.Start.Minute;
                if (minute >= 30)
                {
                    minute -= 30;
                }
                return ((num * minute) / 30);
            }
        }

        internal ScheduleBoxEx Owner
        {
            get
            {
                return base.GetValue<ScheduleBoxEx>(OwnerProperty);
            }
            set
            {
                base.SetValue<ScheduleBoxEx>(OwnerProperty, value);
            }
        }

        public DateTime Start
        {
            get
            {
                return base.GetValue<DateTime>(StartProperty);
            }
            set
            {
                if (base.SetValue<DateTime>(StartProperty, value))
                {
                    if (DateTime.Compare(value, this.End) == 1)
                    {
                        base.SetValue<DateTime>(EndProperty, value.AddHours(1.0));
                    }
                    if (this.Owner != null)
                    {
                        this.Owner.OnEventUpdated(this);
                    }
                }
            }
        }

        internal int StartHalfHoursFromMidnight
        {
            get
            {
                return (int) Math.Floor((double) (this.Start.TimeOfDay.TotalHours * 2.0));
            }
        }

        public string Subject
        {
            get
            {
                return base.GetValue<string>(SubjectProperty);
            }
            set
            {
                if (base.SetValue<string>(SubjectProperty, value) && (this.Owner != null))
                {
                    this.Owner.OnEventUpdated(this);
                }
            }
        }

        [TypeConverter(typeof(StringConverter)), DefaultValue((string) null), Bindable(true)]
        public object Tag
        {
            get
            {
                return base.GetValue<object>(TagProperty);
            }
            set
            {
                base.SetValue<object>(TagProperty, value);
            }
        }
    }
}

