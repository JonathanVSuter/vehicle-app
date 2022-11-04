using System;
using System.Collections.Generic;
using System.Text;

namespace VeiculosApp.Core.Common.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message) { }
    }
}
