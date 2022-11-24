using System;
using System.Collections.Generic;
using System.Text;

namespace VeiculosApp.Core.Common.Exceptions
{
    public class NotFoundAnnoucementImageException : BusinessException
    {
        public NotFoundAnnoucementImageException(string message) : base(message) { }
    }
}
