using DDDInPractice.Logic.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDInPractice.Logic.Configurations.SlotConfigurations
{
    public class SlotConfig : IBaseEntityTypeConfiguration<Slot>
    {
        public void Configure(EntityTypeBuilder<Slot> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID");

            builder.OwnsOne(x => x.SnackPile,
                snackPile =>
                {
                    snackPile.Property(x => x.Price).HasColumnName("Price");
                    snackPile.Property(x => x.Quantity).HasColumnName("Quantity");
                    snackPile.HasOne(x => x.Snack).WithOne();
                });

        }
    }
}
