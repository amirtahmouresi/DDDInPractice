using DDDInPractice.Logic.Configurations.Base;
using DDDInPractice.Logic.Context.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDInPractice.Logic.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddDBSetFromModel(typeof(IEntity).Assembly, typeof(IEntity));
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IBaseEntityTypeConfiguration<>).Assembly);

        }
    }
}
