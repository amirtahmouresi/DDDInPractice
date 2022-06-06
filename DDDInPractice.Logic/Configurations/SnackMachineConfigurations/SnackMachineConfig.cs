using DDDInPractice.Logic.Configurations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDInPractice.Logic.Configurations.SnackMachineConfigurations
{
    public class SnackMachineConfig : IBaseEntityTypeConfiguration<SnackMachine>
    {
        public void Configure(EntityTypeBuilder<SnackMachine> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("ID");
            builder.OwnsOne(x => x.MoneyInside,
                money =>
                {
                    money.Property(x => x.OneCentCount).HasColumnName("OneCentCount");
                    money.Property(x => x.TenCentCount).HasColumnName("TenCentCount");
                    money.Property(x => x.QuarterCount).HasColumnName("QuarterCount");
                    money.Property(x => x.OneDollarCount).HasColumnName("OneDollarCount");
                    money.Property(x => x.FiveDollarCount).HasColumnName("FiveDollarCount");
                    money.Property(x => x.TwentyDollarCount).HasColumnName("TwentyDollarCount");
                });
            builder.Ignore(x => x.MoneyInTransaction);

            var navigation = builder.Metadata.FindNavigation(nameof(SnackMachine.Slots));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
