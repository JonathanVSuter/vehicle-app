using System;
using System.Collections.Generic;
using System.Text;

namespace VeiculosApp.Core.Common.Exceptions
{
    public class EmailInUseException : BusinessException
    {
        public EmailInUseException(string message) : base(message)
        {
        }
    }
}
