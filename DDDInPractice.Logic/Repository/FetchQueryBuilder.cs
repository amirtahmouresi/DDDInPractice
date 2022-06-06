using DDDInPractice.Logic.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDInPractice.Logic.Repository
{
    public class FetchQueryBuilder<TEntity> : IFetchQueryBuilder<TEntity>
    {
        protected IQueryable<TEntity> Query;

        protected PagingConfig PagingConfig;

        public FetchQueryBuilder(IQueryable<TEntity> query, PagingConfig pagingConfig)
        {
            Query = query;
            PagingConfig = pagingConfig;
        }

        public List<TEntity> ToList()
        {
            HandlePaging();
            return Query.ToList();
        }

        public async Task<List<TEntity>> ToListAsync()
        {
            HandlePaging();
            return await Query.ToListAsync();
        }

        public TEntity First()
        {
            HandlePaging();
            return Query.FirstOrDefault();
        }

        public async Task<TEntity> FirstAsync()
        {
            HandlePaging();
            return await Query.FirstOrDefaultAsync();
        }


        private void HandlePaging()
        {
            if (PagingConfig != null)
                Query = Query.Skip(PagingConfig.Skip).Take(PagingConfig.Take);
        }
    }
}
