using DDDInPractice.Logic.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDInPractice.Logic.Interface.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> GetNewRepository<T>() where T : AggregateRoot;

        int SaveChanges();
    }
}
