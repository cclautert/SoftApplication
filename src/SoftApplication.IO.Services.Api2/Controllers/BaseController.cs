using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftApplication.IO.Domain.Core.Notificatios;
using SoftApplication.IO.Domain.Interfaces;

namespace SoftApplication.IO.Services.Api2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private readonly IDomainNotificationHandler<DomainNotification> _Notifications;
        private readonly IMediatorHandler _mediator;

        protected BaseController(IDomainNotificationHandler<DomainNotification> pNotifications,
                                 IMediatorHandler pMediator)
        {
            _Notifications = pNotifications;
            _mediator = pMediator;
        }

        protected new IActionResult Response(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _Notifications.GetNotificatios().Select(n => n.Value)
            });
        }

        protected bool OperacaoValida()
        {
            return (!_Notifications.HasNotifications());
        }
        protected void NotificarErroModelInvalida()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(string.Empty, erroMsg);
            }
        }

        protected void NotificarErro(string codigo, string mensagem)
        {
            _mediator.PublicarEvento(new DomainNotification(codigo, mensagem));
        }
    }
}