using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DDDInPractice.Logic.Interface.Repository
{
    public interface IIncludeQueryBuilder<TEntity, TMember> : IQueryBuilder<TEntity>
        where TEntity : class, IEntity
    {
        IIncludeQueryBuilder<TEntity, TRelation> ThenInclude<TRelation>(Expression<Func<TMember, TRelation>> member);
    }
}
