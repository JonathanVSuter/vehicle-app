using Microsoft.Extensions.DependencyInjection;

namespace VeiculosApp.Application.CommandHandlers
{
    public static class CommandHandlersDependencyInjectionExtension
    {
        public static void AddCommandHandlers(this IServiceCollection services)
        {
            //services.AddScoped<ICommandHandlerWithResult<GuardarDadosCidadesCommand, IList<CidadeCommandDto>>, GuardarDadosCidadesCommandHandler>();
            //services.AddTransient<ICommandHandler<GuardarDadosClimaTempoCommand>, GuardarDadosClimaTempoUmaSemanaCommandHandler>();
        }
    }
}
