using AutoMapper;
using SoftApplication.IO.Domain.Models;
using SoftApplication.IO.Services.Api2.ViewModels;

namespace SoftApplication.IO.Services.Api2.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Evento, EventoViewModel>();
        }
    }
}
