using System;

namespace SoftApplication.IO.Domain.Models.Commands
{
    public class ExcluirEventoCommand : BaseEventoCommand
    {
        public ExcluirEventoCommand(Guid pId)
        {
            Id = pId;
            AggregateId = pId;
        }
    }
}
