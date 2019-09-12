using System;
using System.Collections.Generic;
using System.Text;

namespace SoftApplication.IO.Domain.Eventos.Events
{
    public class EventoAtualizadoEvent : BaseEventoEvent
    {
        public EventoAtualizadoEvent(Guid pId, string pNome, decimal pValorCalculado)
        {
            Id = pId;
            Nome = pNome;
            ValorCalculado = pValorCalculado;
            AggregateId = pId;
        }
    }
}
