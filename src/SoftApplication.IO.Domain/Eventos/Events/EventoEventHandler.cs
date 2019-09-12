using SoftApplication.IO.Domain.Core.Events;
using SoftApplication.IO.Domain.Eventos.Events;
using SoftApplication.IO.Domain.Models.Events;

namespace SoftApplication.IO.Domain.Eventos.Events
{
    public class EventoEventHandler :
        IHandler<EventoRegistradoEvent>,
        IHandler<EventoAtualizadoEvent>,
        IHandler<EventoExcluidoEvent>
    {
        public void Handle(EventoRegistradoEvent pMessage)
        {
            //Enviar Notificação
        }

        public void Handle(EventoAtualizadoEvent pMessage)
        {
            //Enviar Notificação
        }

        public void Handle(EventoExcluidoEvent pMessage)
        {
            //Enviar Notificação
        }
    }
}
