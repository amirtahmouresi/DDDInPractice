﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDInPractice.Logic.Interface.Repository
{
    public interface IGenericRepository<T> where T : AggregateRoot
    {
        IQueryBuilder<T> Get();
        T GetById(long id);
        IUpdateQueryBuilder<T> Update(T entityToUpdate);

    }
}