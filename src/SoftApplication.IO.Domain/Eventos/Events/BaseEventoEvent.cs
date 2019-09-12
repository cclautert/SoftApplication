using SoftApplication.IO.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftApplication.IO.Domain.Eventos.Events
{
    public abstract class BaseEventoEvent : Event
    {
        private Guid _Id;
        public Guid Id
        {
            get { return _Id; }
            protected set { _Id = value; }
        }

        private string _Nome;
        public string Nome
        {
            get { return _Nome; }
            protected set { _Nome = value; }
        }

        private decimal _ValorCalculado;
        public decimal ValorCalculado
        {
            get { return _ValorCalculado; }
            protected set { _ValorCalculado = value; }
        }
    }
}
