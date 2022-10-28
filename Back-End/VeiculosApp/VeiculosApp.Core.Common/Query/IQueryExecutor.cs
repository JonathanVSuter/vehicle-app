namespace VeiculosApp.Core.Common.Query
{
    public interface IQueryExecutor
    {
        TResult Execute<T, TResult>(T query) where T : IQuery<TResult>;
    }
}
