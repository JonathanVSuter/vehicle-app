﻿using System;
using System.Threading.Tasks;
using VeiculosApp.Core.Common.Query;

namespace VeiculosApp.Application
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly IServiceProvider _context;
        public QueryExecutor(IServiceProvider context)
        {
            _context = context;
        }
        public TResult Execute<T, TResult>(T query) where T : IQuery<TResult>
        {
            if (query == null) throw new ArgumentNullException(nameof(query));

            var executor = _context.GetService(typeof(IQueryHandler<T, TResult>)) as IQueryHandler<T, TResult>;

            return executor.Execute(query);
        }

        public async Task<TResult> ExecuteAsync<T, TResult>(T query) where T : IQuery<Task<TResult>>
        {
            if (query == null) throw new ArgumentNullException(nameof(query));

            var executor = _context.GetService(typeof(IQueryHandler<T, Task<TResult>>)) as IQueryHandler<T, Task<TResult>>;

            return await executor.Execute(query).ConfigureAwait(true);
        }
    }
}
