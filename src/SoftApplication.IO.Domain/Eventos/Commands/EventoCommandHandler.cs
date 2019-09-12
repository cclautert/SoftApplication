using SoftApplication.IO.Domain.Handlers;
using SoftApplication.IO.Domain.Core.Bus;
using SoftApplication.IO.Domain.Core.Events;
using SoftApplication.IO.Domain.Core.Models;
using SoftApplication.IO.Domain.Core.Notificatios;
using SoftApplication.IO.Domain.Eventos.Events;
using SoftApplication.IO.Domain.Models.Commands;
using SoftApplication.IO.Domain.Models.Events;
using SoftApplication.IO.Domain.Models.Repository;
using System;
using SoftApplication.IO.Domain.Interfaces;

namespace SoftApplication.IO.Domain.Models.Commands
{
    public class EventoCommandHandler : CommandHandler,
        IHandler<RegistrarEventoCommand>,
        IHandler<AtualizarEventoCommand>,
        IHandler<ExcluirEventoCommand>
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IBus _Bus;
        public EventoCommandHandler(IEventoRepository eventoRepository,
                                    IUnitOfWork pUow,
                                    IBus pBus,
                                    IDomainNotificationHandler<DomainNotification> pDomainNotificationHandler) : base(pUow, pBus, pDomainNotificationHandler)
        {
            _eventoRepository = eventoRepository;
            _Bus = pBus;
        }

        public void Handle(RegistrarEventoCommand pMessage)
        {
            var objEvento = new Evento(pMessage.Nome, pMessage.ValorCalculado);

            //if (!objEvento.IsValid()){
            //    NotificarValidacoesErro(objEvento.ValidationResult);
            //    return;
            //}

            this.EventoValido(objEvento);

            _eventoRepository.Add(objEvento);

            if (Commit())
            {
                Console.WriteLine("Evento Registrado com Sucesso");
                _Bus.RaiseEvent(new EventoRegistradoEvent(objEvento.Id, objEvento.Nome, objEvento.ValorCalculado));
            }                
        }

        public void Handle(AtualizarEventoCommand pMessage)
        {
            if (!this.EventoExistente(pMessage.Id, pMessage.MessageType)) return;

            var objEvento = Evento.EventoFactory.NovoEvento(pMessage.Id, pMessage.Nome, pMessage.ValorCalculado);

            this.EventoValido(objEvento);

            _eventoRepository.Update(objEvento);

            if (Commit())
            {
                _Bus.RaiseEvent(new EventoAtualizadoEvent(objEvento.Id, objEvento.Nome, objEvento.ValorCalculado));
            }
        }

        public void Handle(ExcluirEventoCommand pMessage)
        {
            if (!this.EventoExistente(pMessage.Id, pMessage.MessageType)) return;

            _eventoRepository.Remove(pMessage.Id);

            if (Commit())
            {
                _Bus.RaiseEvent(new EventoExcluidoEvent(pMessage.Id));
            }
        }

        public bool EventoValido(Evento pEvento)
        {
            if (pEvento.IsValid()) return true;

            NotificarValidacoesErro(pEvento.ValidationResult);
            return false;
        }

        public bool EventoExistente(Guid pId, string pMessageType)
        {
            var objEvento = _eventoRepository.GetById(pId);

            if (objEvento != null) return true;

            _Bus.RaiseEvent(new DomainNotification(pMessageType, "Evento não Encontrado"));
            return false;
        }
    }
}
