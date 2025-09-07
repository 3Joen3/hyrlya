using HyrLya.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HyrLya.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options 
                => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddAuthorization();

            services.AddAuthentication()
                .AddBearerToken(IdentityConstants.BearerScheme);

            services.AddIdentityCore<User>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddApiEndpoints();

            return services;
        }
    }
}