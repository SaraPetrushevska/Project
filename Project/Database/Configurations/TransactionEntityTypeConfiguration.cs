using Microsoft.EntityFrameworkCore;
using Project.Database.Entities;

namespace Project.Database.Configurations
{
    public class TransactionEntityTypeConfiguration
    {
        public class TransactionEntittyTypeConfiguration : IEntityTypeConfiguration<TransactionEntity>
        {
            public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TransactionEntity> builder)
            {
                builder.ToTable("transactions");

                builder.HasKey(x => x.Id);

                builder.Property(x => x.Id).IsRequired().HasMaxLength(64);
                builder.Property(x => x.benName).HasConversion<string>().IsRequired();
                builder.Property(x => x.TransactionDate).IsRequired().HasMaxLength(10);
                builder.Property(x => x.Direction).HasConversion<string>().IsRequired();
                builder.Property(x => x.Amount).IsRequired();
                builder.Property(x => x.Currency).HasConversion<string>();
                builder.Property(x => x.Description);
                builder.Property(x => x.TransactionKind).HasConversion<string>().IsRequired();
                builder.Property(x => x.Mcc).HasConversion<string>();
                
            }
        }
    }
}
