using SoftApplication.IO.Domain.CommandHandlers;
using SoftApplication.IO.Domain.Core.Events;
using SoftApplication.IO.Domain.Core.Models;
using SoftApplication.IO.Domain.Models.Commands;
using SoftApplication.IO.Domain.Models.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftApplication.IO.Domain.Models.CommandsHandlers
{
    public class EventoCommandHandler : CommandHandler,
        IHandler<RegistrarEventoCommand>,
        IHandler<AtualizarEventoCommand>,
        IHandler<ExcluirEventoCommand>
    {
        private readonly IEventoRepository _eventoRepository;
        public EventoCommandHandler(IEventoRepository eventoRepository,
                                    IUnitOfWork uow): base(uow)
        {
            _eventoRepository = eventoRepository;
        }

        public void Handle(RegistrarEventoCommand pMessage)
        {
            var objEvento = new Evento(pMessage.Nome, pMessage.ValorCalculado);

            if (!objEvento.IsValid()){
                NotificarValidacoesErro(objEvento.ValidationResult);
                return;
            }

            //Persistenacia
            _eventoRepository.Add(objEvento);

            if (Commit())
            {
                //Notificar Processo
            }                
        }

        public void Handle(AtualizarEventoCommand pMessage)
        {
            throw new NotImplementedException();
        }

        public void Handle(ExcluirEventoCommand pMessage)
        {
            throw new NotImplementedException();
        }
    }
}
