
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Project.Database;

#nullable disable

namespace Project.Migrations
{
    [DbContext(typeof(ProjectDbContext))]
    partial class ProjectDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Project.Database.Entities.TransactionEntity", b =>
            {
                b.Property<string>("Id")
                    .IsRequired()
                    .HasColumnType("character varying(64)");
                
                b.Property<string>("benName")
                    .HasColumnType("text");
        
                b.Property<int>("Direction")
                    .HasColumnType("integer");

                b.Property<string>("TransactionDate")
                    .HasColumnType("text");

                b.Property<double>("Amount")
                    .HasColumnType("double precision");

                b.Property<string>("Descripiton")
                    .HasColumnType("text");
                
                b.Property<string>("Currency")
                    .HasColumnType("character varying(3)");

                b.Property<int>("Mcc")
                    .HasColumnType("integer");

                b.Property<int>("Kind")
                    .HasColumnType("integer");

                b.HasKey("Id");

                b.ToTable("transactions", (string)null);
            });
            modelBuilder.Entity("Project.Models.Category", b =>
            {
                b.Property<string>("Code")
                    .IsRequired()
                    .HasColumnType("text");

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("text");

                b.Property<string>("ParentCode")
                    .HasColumnType("text");

                b.HasKey("Code");

                b.ToTable("Categories");
            });
#pragma warning restore 612, 618
        }
    }
}