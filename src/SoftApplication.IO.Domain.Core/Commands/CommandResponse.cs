using System;
using System.Collections.Generic;
using System.Text;

namespace SoftApplication.IO.Domain.Core.Commands
{
    public class CommandResponse
    {
        public CommandResponse(bool pSuccess = false)
        {
            _Success = pSuccess;
        }

        public static CommandResponse Ok = new CommandResponse( pSuccess: true);
        public static CommandResponse Fail = new CommandResponse(pSuccess: false);

        private bool _Success;
        public bool Success {
            get { return _Success; }
            private set { _Success = value; }
        }


    }
}
