using Microsoft.EntityFrameworkCore;
using Project.Database.Entities;

namespace Project.Database.Configurations
{
    public class CategoryEntityTypeConfiguration
    {
        public class CategoryEntittyTypeConfiguration : IEntityTypeConfiguration<CategoryEntity>
        {
            public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CategoryEntity> builder)
            {
                builder.ToTable("categories");
                builder.Property(x => x.Code).IsRequired();
                builder.HasKey(x => x.Name);
                builder.Property(x => x.ParentCode);
                
            }
        }
    }
}
