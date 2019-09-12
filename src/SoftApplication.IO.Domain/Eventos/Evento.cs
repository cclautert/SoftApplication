using FluentValidation;
using SoftApplication.IO.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftApplication.IO.Domain.Models
{
    public class Evento: Entity<Evento>
    {
        public Evento(string pNome, decimal pValorCalculado)
        {
            Id = Guid.NewGuid();
            _Nome = pNome;
            _ValorCalculado = ValorCalculado;            
        }

        private Evento()
        {

        }

        private string _Nome;
        public string Nome {
            get { return _Nome; }
            private set { _Nome = value; }
        }

        private string _Descricao;
        public string Descricao {
            get { return _Descricao; }
            private set { _Descricao = value; }
        }

        private DateTime _DataExecucao;
        public DateTime DataExecucao {
            get { return _DataExecucao; }
            private set { _DataExecucao = value; }
        }

        private decimal _ValorCalculado;
        public decimal ValorCalculado {
            get { return _ValorCalculado; }
            private set { _ValorCalculado = value; }
        }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }

        #region Validações
        private void Validar() {
            this.ValidarValorCalculado();
        }

        private void ValidarValorCalculado()
        {
            RuleFor(c => c.ValorCalculado)
                .NotEmpty().WithMessage("O ValorCalculado não pode ser zero");
        }
        #endregion

        //Factory
        public static class EventoFactory
        {
            public static Evento NovoEvento(Guid pId, string pNome, decimal pValorCalculado)
            {
                var objEvento = new Evento()
                {
                    Id = pId,
                    Nome = pNome,
                    ValorCalculado = pValorCalculado
                };

                return objEvento;
            }
            
            public static Evento NovoEventoCompleto(Guid pId, string pNome, string pDescricao, DateTime pDataExecucao, decimal pValorCalculado)
            {
                var objEvento = new Evento()
                {
                    Id = pId,
                    Nome = pNome,
                    Descricao = pDescricao,
                    DataExecucao = pDataExecucao,
                    ValorCalculado = pValorCalculado
                };

                return objEvento;
            }
        }
    }
}
