using Microsoft.Extensions.DependencyInjection;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Common.Query;

namespace VeiculosApp.Application
{
    public static class ExecutorsDependencyInjectionExtension
    {
        public static void AddExecutors(this IServiceCollection services)
        {
            services.AddScoped<IQueryExecutor, QueryExecutor>();
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();            
        }
    }
}
