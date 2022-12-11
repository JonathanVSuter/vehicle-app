using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Core.Domain.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
