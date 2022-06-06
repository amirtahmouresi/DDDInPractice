using DDDInPractice.Logic.Context;
using DDDInPractice.Logic.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDInPractice.Logic.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : AggregateRoot
    {
        private readonly ApplicationDBContext _context;
        private readonly DbSet<TEntity> _dbSet;
        private bool _isTrackingEnabled = false;


        public GenericRepository(ApplicationDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public IQueryBuilder<TEntity> Get()
        {
            var query = _isTrackingEnabled ? _dbSet : _dbSet.AsNoTracking();

            return new QueryBuilder<TEntity>(query);
        }
        public TEntity GetById(long id)
        {
            return _dbSet.Find(id);
        }

        public virtual IUpdateQueryBuilder<TEntity> Update(TEntity entityToUpdate)
        {
            var entry = _context.Entry(entityToUpdate);
            if (entry.State == EntityState.Detached)
            {
                _dbSet.Attach(entityToUpdate);
            }
            entry.State = EntityState.Modified;

            return new UpdateQueryBuilder<TEntity>(entityToUpdate, entry);
        }
    }
}
