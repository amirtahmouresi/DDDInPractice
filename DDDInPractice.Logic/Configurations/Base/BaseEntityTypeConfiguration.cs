using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDInPractice.Logic.Configurations.Base
{
    public interface IBaseEntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : class
    {
    }
}
