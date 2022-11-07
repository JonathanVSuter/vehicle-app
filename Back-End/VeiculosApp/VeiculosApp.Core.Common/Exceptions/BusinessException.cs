using System;

namespace VeiculosApp.Core.Common.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message) { }
    }
}
