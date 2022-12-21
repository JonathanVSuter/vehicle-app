using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace VeiculosApp.Extensions
{
    public static class ControllerExtensions
    {
        public static ClaimsIdentity GetClaimsIdentity(this ControllerBase controller)
        {
            return (ClaimsIdentity)controller.User?.Identity;
        }
    }
}
