using SoftApplication.IO.Domain.Core.Commands;
using System;

namespace SoftApplication.IO.Domain.Models.Commands
{
    public abstract class BaseEventoCommand : Command
    {
        private Guid _Id;
        public Guid Id {
            get { return _Id; }
            protected set { _Id = value; }
        }

        private string _Nome;
        public string Nome {
            get { return _Nome; }
            protected set { _Nome = value; }
        }

        private decimal _ValorCalculado;
        public decimal ValorCalculado {
            get { return _ValorCalculado; }
            protected set { _ValorCalculado = value; }
        }
    }
}
