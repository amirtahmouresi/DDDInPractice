﻿using DDDInPractice.Logic.Context;
using DDDInPractice.Logic.Interface.Repository;
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
            var isSaved = _context.SaveChanges();
            return isSaved;
        }

        IGenericRepository<T> IUnitOfWork.GetNewRepository<T>() =>
            new GenericRepository<T>(_context);
    }
}
