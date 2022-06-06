using DDDInPractice.Logic.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DDDInPractice.Logic.Repository
{
    public class QueryBuilder<TEntity> : FetchQueryBuilder<TEntity>, IQueryBuilder<TEntity>
        where TEntity : class, IEntity
    {

        public QueryBuilder(IQueryable<TEntity> query) : base(query, null)
        {
        }

        public QueryBuilder(IQueryable<TEntity> query, PagingConfig pagingConfig) : base(query, pagingConfig)
        {
        }

        public IQueryBuilder<TEntity> Filter(Expression<Func<TEntity, bool>> filter)
        {
            Query = Query.Where(filter);
            return this;
        }

        public virtual IIncludeQueryBuilder<TEntity, TRelation> Include<TRelation>(
            Expression<Func<TEntity, ICollection<TRelation>>> member)
        {
            var query = Query.Include(member);
            return new IncludeQueryBuilder<TEntity, TRelation>(query);
        }

        public virtual IIncludeQueryBuilder<TEntity, TRelation> Include<TRelation>(
            Expression<Func<TEntity, IEnumerable<TRelation>>> member)
        {
            var query = Query.Include(member);
            return new IncludeQueryBuilder<TEntity, TRelation>(query);
        }

        public virtual IIncludeQueryBuilder<TEntity, TRelation> Include<TRelation>(
            Expression<Func<TEntity, List<TRelation>>> member)
        {
            var query = Query.Include(member);
            return new IncludeQueryBuilder<TEntity, TRelation>(query);
        }

        public virtual IIncludeQueryBuilder<TEntity, TRelation> Include<TRelation>(
            Expression<Func<TEntity, TRelation>> member)
        {
            var query = Query.Include(member);
            return new IncludeQueryBuilder<TEntity, TRelation>(query);
        }

        public int Sum(Func<TEntity, int> selector) => Query.Sum(selector);

        public long Sum(Func<TEntity, long> selector) => Query.Sum(selector);

        public decimal Sum(Func<TEntity, decimal> selector) => Query.Sum(selector);

        public async Task<int> SumAsync(Expression<Func<TEntity, int>> selector) => await Query.SumAsync(selector);

        public async Task<long> SumAsync(Expression<Func<TEntity, long>> selector) => await Query.SumAsync(selector);

        public async Task<decimal> SumAsync(Expression<Func<TEntity, decimal>> selector) => await Query.SumAsync(selector);


        public async Task<int> Count() => await Query.CountAsync();


        public bool Any() => Query.Any();

        public async Task<bool> AnyAsync() => await Query.AnyAsync();

    }
}
