using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using VeiculosApp.Core.Common.Query;
using VeiculosApp.Core.Domain.Models;
using VeiculosApp.Core.Domain.Queries;

namespace VeiculosApp.Application.QueryHandlers
{
    public static class QueryHandlersDependencyInjectionExtension
    {
        public static void AddQueryHandlers(this IServiceCollection services)
        {
            services.AddScoped<IQueryHandler<GetAllVehicleQuery, IList<Vehicle>>, GetAllVehiclesQueryHandler>();
            services.AddScoped<IQueryHandler<GetByIdVehicleQuery, Vehicle>, GetByIdVehicleQueryHandler>();
            services.AddScoped<IQueryHandler<GetByVehicleQuery, IList<Vehicle>>, GetByVehicleQueryHandler>();
        }
    }
}
