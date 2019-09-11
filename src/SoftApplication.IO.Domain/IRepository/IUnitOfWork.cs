using SoftApplication.IO.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftApplication.IO.Domain.Core.Models
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();        
    }
}
