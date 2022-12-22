using System;
using System.Collections.Generic;
using System.Text;

namespace VeiculosApp.Core.Common.Exceptions
{
    public class ErrorOnCreateUserException : BusinessException
    {
        public ErrorOnCreateUserException(string message) : base(message)
        {
        }
    }
}
