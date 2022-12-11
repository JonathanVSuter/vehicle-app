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
            services.AddScoped<IQueryHandler<GetByIdAnnouncementImageQuery, AnnouncementImage>, GetByIdAnnouncementImageQueryHandler>();
            services.AddScoped<IQueryHandler<GetByTermAnnouncementImageQuery, IList<AnnouncementImage>>, GetByTermAnnouncementImageQueryHandler>();
            services.AddScoped<IQueryHandler<GetAllAnnouncementImagesQuery, IList<AnnouncementImage>>, GetAllAnnouncementImagesQueryHandler>();
            services.AddScoped<IQueryHandler<GetAllUsersQuery, IList<User>>, GetAllUsersQueryHandler>();
            services.AddScoped<IQueryHandler<GetByIdUserQuery, User>, GetByIdUserQueryHandler>();
            services.AddScoped<IQueryHandler<GetByTermUserQuery, IList<User>>, GetByTermUserQueryHandler>();
        }
    }
}
