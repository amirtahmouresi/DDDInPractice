using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDInPractice.Logic.Interface.Repository
{
    public interface IFetchQueryBuilder<TEntity>
    {
        List<TEntity> ToList();
        Task<List<TEntity>> ToListAsync();
        TEntity First();
        Task<TEntity> FirstAsync();

    }
}
