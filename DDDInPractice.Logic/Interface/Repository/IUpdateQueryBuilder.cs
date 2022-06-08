using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DDDInPractice.Logic.Interface.Repository
{
    public interface IUpdateQueryBuilder<TEntity>
    {
        IUpdateQueryBuilder<TEntity> ExcludeCollection(Expression<Func<TEntity, IEnumerable<IEntity>>> expression);
        IUpdateQueryBuilder<TEntity> ExcludeRelation(Expression<Func<TEntity, IEntity>> expression);
        IUpdateQueryBuilder<TEntity> Exclude<TProp>(Expression<Func<TEntity, TProp>> expression);


        IUpdateQueryBuilder<TEntity> OnlyInclude<TProp>(Expression<Func<TEntity, TProp>> expression);
        IUpdateQueryBuilder<TEntity> OnlyIncludeItems(params Expression<Func<TEntity, object>>[] expressions);
        public IUpdateQueryBuilder<TEntity> UpdateRelations(Expression<Func<TEntity, IEnumerable<IEntity>>> expression);
        IUpdateQueryBuilder<TEntity> UpdateOwnedEntity<TProp>(Expression<Func<TEntity, TProp>> expression) where TProp : class;
    }
}
