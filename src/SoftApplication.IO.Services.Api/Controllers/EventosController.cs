using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftApplication.IO.Domain.Core.Notificatios;
using SoftApplication.IO.Domain.Interfaces;
using SoftApplication.IO.Domain.Models.Commands;
using SoftApplication.IO.Services.Api.ViewModels;

namespace SoftApplication.IO.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : BaseController
    {
        private readonly IDomainNotificationHandler<DomainNotification> _Notifications;
        private readonly IMediatorHandler _Mediator;        
        private readonly IMapper _Mapper;

        public EventosController(IDomainNotificationHandler<DomainNotification> pNotifications,
                                 IMapper pMapper,
                                 IMediatorHandler pMediator) : base(pNotifications, pMediator)
        {
            _Notifications = pNotifications;
            _Mapper = pMapper;
            _Mediator = pMediator;
        }

        [HttpGet]
        [Route("eventos")]
        [AllowAnonymous]
        public IEnumerable<EventoViewModel> Get()
        {
            return null;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("eventos")]
        public IActionResult Post([FromBody]EventoViewModel eventoViewModel)
        {
            if (!ModelStateValida())
            {
                return Response();
            }

            var eventoCommand = _Mapper.Map<RegistrarEventoCommand>(eventoViewModel);

            _Mediator.EnviarComando(eventoCommand);
            return Response(eventoCommand);
        }

        private bool ModelStateValida()
        {
            if (ModelState.IsValid) return true;

            NotificarErroModelInvalida();
            return false;
        }
    }
}