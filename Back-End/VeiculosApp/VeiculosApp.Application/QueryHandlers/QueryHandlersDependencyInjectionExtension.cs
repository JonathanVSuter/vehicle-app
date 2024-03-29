﻿using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeiculosApp.Core.Common.Query;
using VeiculosApp.Core.Domain.Dtos;
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
            services.AddScoped<IQueryHandler<GetByIdAdvertisementImageQuery, AdvertisementImage>, GetByIdAnnouncementImageQueryHandler>();
            services.AddScoped<IQueryHandler<GetByTermAdvertisementImageQuery, IList<AdvertisementImage>>, GetByTermAdvertisementImageQueryHandler>();
            services.AddScoped<IQueryHandler<GetAllAnnouncementImagesQuery, IList<AdvertisementImage>>, GetAllAdvertisementImagesQueryHandler>();
            services.AddScoped<IQueryHandler<GetAllUsersQuery, IList<User>>, GetAllUsersQueryHandler>();
            services.AddScoped<IQueryHandler<GetByIdUserQuery, User>, GetByIdUserQueryHandler>();
            services.AddScoped<IQueryHandler<GetByTermUserQuery, IList<User>>, GetByTermUserQueryHandler>();
            services.AddScoped<IQueryHandler<LoginQuery, Task<LoginSucessDto>>, LoginQueryHandler>();
            services.AddScoped<IQueryHandler<GetByTermAdvertisementQuery, IList<Advertisement>>, GetByTermAdvertisementQueryHandler>();
        }
    }
}
