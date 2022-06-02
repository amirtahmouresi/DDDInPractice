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
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : AggregateRoot
    {
        private readonly ApplicationDBContext _context;
        private readonly DbSet<T> _dbset;
        public GenericRepository(ApplicationDBContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }


        public T GetById(long id)
        {
            return _dbset.Find(id);
        }

    }
}
