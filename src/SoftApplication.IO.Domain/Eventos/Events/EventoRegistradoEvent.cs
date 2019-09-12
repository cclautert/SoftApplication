using SoftApplication.IO.Domain.Core.Events;
using SoftApplication.IO.Domain.Eventos.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftApplication.IO.Domain.Models.Events
{
    public class EventoRegistradoEvent : BaseEventoEvent
    {
        public EventoRegistradoEvent(Guid pId, string pNome, decimal pValorCalculado)
        {
            Id = pId;
            Nome = pNome;
            ValorCalculado = pValorCalculado;
            AggregateId = pId;
        }
    }
}
