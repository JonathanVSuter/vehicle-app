using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Domain.Commands;
using VeiculosApp.Core.Domain.Dtos;
using VeiculosApp.Core.Domain.Models;

namespace VeiculosApp.Application.CommandHandlers
{
    public static class CommandHandlersDependencyInjectionExtension
    {
        public static void AddCommandHandlers(this IServiceCollection services)
        {
            services.AddScoped<ICommandHandlerWithResult<SaveVehicleCommand, Vehicle>, AddVehicleCommandHandler>();
            services.AddScoped<ICommandHandler<SaveVehicleImageCommand>, SaveVehicleImageCommandHandler>();
            services.AddScoped<ICommandHandler<RemoveVehicleCommand>, RemoveVehicleCommandHandler>();
        }
    }
}
