using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Data
{
    public static class BookStoreDbContextFactory
    {
        public static IServiceCollection ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("Connection string is not configured.");

            var builder = new SqlConnectionStringBuilder(connectionString);

            services.AddDbContext<BookStoreDbContext>(options =>
                options.UseSqlServer(builder.ConnectionString, sqlServerOptions =>
                    sqlServerOptions.MigrationsAssembly(typeof(BookStoreDbContext).Assembly.FullName)));

            return services;
        }

        public static IServiceCollection ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            return services;
        }
    }
}
