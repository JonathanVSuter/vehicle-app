using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using VeiculosApp.Core.Domain.Services;

namespace VeiculosApp.Infra.Services
{
    public static class ServicesDependencyInjection
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddScoped<ITokenService>(x => new TokenService(configuration.GetSection("SecretJWT").Value));
        }
    }
}
