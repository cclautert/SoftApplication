using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SoftApplication.IO.Services.Api.ViewModels
{
    public class EventoViewModel
    {
        public EventoViewModel()
        {            
        }

        private Guid _Id;
        [Key]
        public Guid Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Nome;
        [Required(ErrorMessage = "O Nome é requerido")]
        [MinLength(2, ErrorMessage = "O tamanho minimo do Nome é {1}")]
        [MaxLength(150, ErrorMessage = "O tamanho máximo do Nome é {1}")]
        [Display(Name = "Nome do Evento")]        
        public string Nome
        {
            get { return _Nome; }
            set { _Nome = value; }
        }

        private decimal _ValorCalculado;
        [Display(Name = "Valor")]
        public decimal ValorCalculado
        {
            get { return _ValorCalculado; }
            private set { _ValorCalculado = value; }
        }

    }
}
