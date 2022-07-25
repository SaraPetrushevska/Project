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
                builder.Property(x => x.Direction);
                builder.Property(x => x.Amount);
                builder.Property(x => x.Currency).HasConversion<string>();
                builder.Property(x => x.TransactionKind);
                builder.Property(x => x.Kind);
                builder.Property(x => x.Mcc);
                builder.Property(x => x.Category);
            }
        }
    }
}
