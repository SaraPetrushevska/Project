using Microsoft.EntityFrameworkCore;
using Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Project.Database;
using Project.Database.Repositories;
using Project.Services;


namespace Product
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

 

            builder.Services.AddScoped<ITransactionService, TransactionService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            builder.Services.AddDbContext<ProjectDbContext>(options =>
            {
                options.UseNpgsql(CreateConnectionString(builder.Configuration));
            });

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            InitializeDatabase(app);

            app.MapControllers();

            app.Run();
        }

        private static void InitializeDatabase(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                using var scope = app.Services.GetService<IServiceScopeFactory>().CreateScope();

                scope.ServiceProvider.GetRequiredService<ProjectDbContext>().Database.Migrate();
            }
        }

        private static string CreateConnectionString(IConfiguration configuration)
        {
            var username = Environment.GetEnvironmentVariable("DATABASE_USERNAME") ?? configuration["Database:Username"];
            var password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? configuration["Database:Password"];
            var database = Environment.GetEnvironmentVariable("DATABASE_NAME") ?? configuration["Database:Name"];
            var host = Environment.GetEnvironmentVariable("DATABASE_HOST") ?? configuration["Database:Host"];
            var port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? configuration["Database:Port"];

            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = host,
                Port = int.Parse(port),
                Database = database,
                Username = username,
                Password = password,
                Pooling = true,
            };

            return builder.ConnectionString;
        }
    }
}