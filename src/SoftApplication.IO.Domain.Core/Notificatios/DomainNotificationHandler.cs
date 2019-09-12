using System.Collections.Generic;
using System.Linq;

namespace SoftApplication.IO.Domain.Core.Notificatios
{
    public class DomainNotificationHandler : IDomainNotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _lstNotifications;

        public DomainNotificationHandler()
        {
            _lstNotifications = new List<DomainNotification>();
        }
        public virtual List<DomainNotification> GetNotificatios()
        {
            return _lstNotifications;
        }

        public void Handle(DomainNotification pMessage)
        {
            _lstNotifications.Add(pMessage);
        }

        public bool HasNotifications()
        {
            return _lstNotifications.Any();
        }

        public void Dispose()
        {
            _lstNotifications = new List<DomainNotification>();
        }
    }
}
