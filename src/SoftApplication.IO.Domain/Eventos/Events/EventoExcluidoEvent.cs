using System;
using System.Collections.Generic;
using System.Text;

namespace SoftApplication.IO.Domain.Eventos.Events
{
    public class EventoExcluidoEvent : BaseEventoEvent
    {
        public EventoExcluidoEvent(Guid pId)
        {
            Id = pId;
            AggregateId = pId;
        }
    }
}
