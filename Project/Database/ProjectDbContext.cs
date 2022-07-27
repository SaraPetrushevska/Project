using Microsoft.EntityFrameworkCore;
using Project.Database.Entities;
using System.Reflection;

namespace Project.Database
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<TransactionEntity> Transactions { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }

        public ProjectDbContext()
        {

        }

        public ProjectDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}