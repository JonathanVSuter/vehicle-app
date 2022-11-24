using System;
using System.Collections.Generic;
using System.Text;

namespace VeiculosApp.Core.Common.Exceptions
{
    public class NotFoundUserException : BusinessException
    {
        public NotFoundUserException(string message) : base(message)
        {
        }
    }
}
