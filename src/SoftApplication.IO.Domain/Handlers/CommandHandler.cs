using FluentValidation.Results;
using SoftApplication.IO.Domain.Core.Bus;
using SoftApplication.IO.Domain.Core.Models;
using SoftApplication.IO.Domain.Core.Notificatios;
using SoftApplication.IO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftApplication.IO.Domain.Handlers
{
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBus _Bus;
        private readonly IDomainNotificationHandler<DomainNotification> _DomainNotificationHandler;

        public CommandHandler(IUnitOfWork pUnitOfWork, IBus pIbus, IDomainNotificationHandler<DomainNotification> pDomainNotificationHandler)
        {
            _unitOfWork = pUnitOfWork;
            _Bus = pIbus;
            _DomainNotificationHandler = pDomainNotificationHandler;
        }

        protected void NotificarValidacoesErro(ValidationResult pValidationResult)
        {
            foreach (var objErro in pValidationResult.Errors)
            {
                Console.WriteLine(objErro.ErrorMessage);
                _Bus.RaiseEvent(new DomainNotification(objErro.PropertyName, objErro.ErrorMessage));
            }
        }

        protected bool Commit()
        {
            if (_DomainNotificationHandler.HasNotifications()) return false;
            var commandResponse = _unitOfWork.Commit();
            if (commandResponse.Success) return true;

            Console.WriteLine("Ocorreu um erro ao salvar os dados no banco");
            _Bus.RaiseEvent(new DomainNotification("Commit", "Ocorreu um erro ao salvar os dados no banco"));

            return false;
        }
    }
}
