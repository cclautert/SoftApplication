using System;

namespace SoftApplication.IO.Domain.Core.Events
{
    public abstract class Message
    {
        protected Message()
        {
            _MessageType = GetType().Name;
        }
        private string _MessageType;
        public string MessageType {
            get { return _MessageType; }
            protected set { _MessageType = value; }
        }

        private Guid _AggregateId;
        public Guid AggregateId {
            get { return _AggregateId; }
            protected set { _AggregateId = value; }
        }

    }
}
