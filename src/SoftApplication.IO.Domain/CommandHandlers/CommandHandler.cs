using FluentValidation.Results;
using SoftApplication.IO.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftApplication.IO.Domain.CommandHandlers
{
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommandHandler(IUnitOfWork pUnitOfWork)
        {
            _unitOfWork = pUnitOfWork;
        }

        protected void NotificarValidacoesErro(ValidationResult pValidationResult)
        {
            foreach (var objErro in pValidationResult.Errors)
            {
                Console.WriteLine(objErro.ErrorMessage);
            }
        }

        protected bool Commit()
        {
            var commandResponse = _unitOfWork.Commit();
            if (commandResponse.Success) return true;

            Console.WriteLine("Ocorreu um erro ao salvar os dados no banco");
            return false;
        }
    }
}
