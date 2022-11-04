using System;
using System.Collections.Generic;
using System.Text;

namespace VeiculosApp.Core.Common.Exceptions
{
    public class NotFoundVehicleException : BusinessException
    {
        public NotFoundVehicleException(string message):base(message) { }
    }
}
