using System;
using System.Collections.Generic;
using System.Text;

namespace VeiculosApp.Core.Common.Exceptions
{
    public class NotFoundAdvertisementException : BusinessException
    {
        public NotFoundAdvertisementException(string message) : base(message) { }
    }
}
