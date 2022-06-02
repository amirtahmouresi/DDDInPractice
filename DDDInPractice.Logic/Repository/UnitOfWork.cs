using DDDInPractice.Logic.Context;
using DDDInPractice.Logic.Interface.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDInPractice.Logic.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
        }
        public void Dispose()
        {
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        private void DetachAll()
        {
            EntityEntry[] entityEntries = _context.ChangeTracker.Entries().ToArray();

            foreach (EntityEntry entityEntry in entityEntries)
            {
                entityEntry.State = EntityState.Detached;
            }
        }

        IGenericRepository<T> IUnitOfWork.GetNewRepository<T>() =>
            new GenericRepository<T>(_context, _mapper);
    }
}
