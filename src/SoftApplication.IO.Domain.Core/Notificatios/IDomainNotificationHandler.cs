using SoftApplication.IO.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftApplication.IO.Domain.Core.Notificatios
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message 
    {
        bool HasNotifications();
        List<T> GetNotificatios();
    }
}
