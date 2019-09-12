using System;

namespace SoftApplication.IO.Domain.Models.Commands
{
    public class AtualizarEventoCommand : BaseEventoCommand
    {
        public AtualizarEventoCommand(Guid pID, string pNome, decimal pValorCalculado)
        {
            Id = pID;
            Nome = pNome;
            ValorCalculado = pValorCalculado;
        }
    }
}
