using System;
using System.Collections.Generic;
using System.Text;

namespace VeiculosApp.Core.Common.Exceptions
{
    public class NotFoundAnnoucementException : BusinessException
    {
        public NotFoundAnnoucementException(string message) : base(message) { }
    }
}
