using System;
using System.Collections.Generic;
using System.Text;

namespace VeiculosApp.Core.Common.Exceptions
{
    public class IncorrectPasswordException : BusinessException
    {
        public IncorrectPasswordException(string message) : base(message)
        {
        }
    }
}
