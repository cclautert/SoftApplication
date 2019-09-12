using System;
using System.Collections.Generic;
using System.Text;

namespace SoftApplication.IO.Domain.Core.Events
{
    public abstract class Event : Message
    {
        public Event()
        {
            _TimeStamp = DateTime.Now;
        }

        private DateTime _TimeStamp;
        public DateTime TimeStamp
        {
            get { return _TimeStamp; }
            private set { _TimeStamp = value; }
        }

    }
}
