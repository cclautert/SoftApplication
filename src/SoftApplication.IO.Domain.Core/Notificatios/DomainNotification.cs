using SoftApplication.IO.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftApplication.IO.Domain.Core.Notificatios
{
    public class DomainNotification : Event
    {
        public DomainNotification(string pKey, string pValue)
        {
            _Key = pKey;
            _Value = pValue;
        }

        private Guid _DomainNotificationId;
        public Guid DomainNotificationId
        {
            get { return _DomainNotificationId; }
            private set { _DomainNotificationId = value; }
        }

        private string _Key;
        public string Key
        {
            get { return _Key; }
            private set { _Key = value; }
        }

        private string _Value;
        public string Value
        {
            get { return _Value; }
            private set { _Value = value; }
        }

        private int _Version;
        public int Version
        {
            get { return _Version; }
            private set { _Version = value; }
        }
    }
}
