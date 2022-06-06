using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DDDInPractice.Logic.Interface.Repository
{
    public interface IQueryBuilder<TEntity> : IFetchQueryBuilder<TEntity>
    where TEntity : class, IEntity
    {

        IQueryBuilder<TEntity> Filter(Expression<Func<TEntity, bool>> filter);

        IIncludeQueryBuilder<TEntity, TRelation> Include<TRelation>(
            Expression<Func<TEntity, ICollection<TRelation>>> member);

        IIncludeQueryBuilder<TEntity, TRelation> Include<TRelation>(
            Expression<Func<TEntity, IEnumerable<TRelation>>> member);

        IIncludeQueryBuilder<TEntity, TRelation> Include<TRelation>(
            Expression<Func<TEntity, List<TRelation>>> member);

        IIncludeQueryBuilder<TEntity, TRelation> Include<TRelation>(
            Expression<Func<TEntity, TRelation>> member);

        int Sum(Func<TEntity, int> selector);
        long Sum(Func<TEntity, long> selector);
        decimal Sum(Func<TEntity, decimal> selector);
        Task<int> SumAsync(Expression<Func<TEntity, int>> selector);
        Task<long> SumAsync(Expression<Func<TEntity, long>> selector);
        Task<decimal> SumAsync(Expression<Func<TEntity, decimal>> selector);

        public Task<int> Count();

        bool Any();
        Task<bool> AnyAsync();
    }
}
