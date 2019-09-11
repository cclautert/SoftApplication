using SoftApplication.IO.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftApplication.IO.Domain.Core.Commands
{
    public class Command : Message
    {
        public Command()
        {
            _TimeStamp = DateTime.Now;
        }
        private DateTime _TimeStamp;
        public DateTime TimeStamp {
            get { return _TimeStamp; }
            set { _TimeStamp = value; }
        }

    }
}
