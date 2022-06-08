using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDInPractice.Logic.Interface.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : AggregateRoot
    {
        IQueryBuilder<TEntity> Get();
        TEntity GetById(long id);
        IUpdateQueryBuilder<TEntity> Update(TEntity entityToUpdate);

    }
}
