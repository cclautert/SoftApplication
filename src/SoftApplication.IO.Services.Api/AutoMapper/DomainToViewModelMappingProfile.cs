using AutoMapper;
using SoftApplication.IO.Domain.Models;
using SoftApplication.IO.Services.Api.ViewModels;

namespace SoftApplication.IO.Services.Api.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Evento, EventoViewModel>();
        }
    }
}
