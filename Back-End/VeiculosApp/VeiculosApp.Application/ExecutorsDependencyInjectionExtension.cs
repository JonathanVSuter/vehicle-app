using Microsoft.Extensions.DependencyInjection;
using VeiculosApp.Core.Common.Command;
using VeiculosApp.Core.Common.Query;

namespace VeiculosApp.Application
{
    public static class ExecutorsDependencyInjectionExtension
    {
        public static void AddExecutors(this IServiceCollection services)
        {
            services.AddTransient<IQueryExecutor, QueryExecutor>();
            services.AddTransient<ICommandDispatcher, CommandDispatcher>();
        }
    }
}
