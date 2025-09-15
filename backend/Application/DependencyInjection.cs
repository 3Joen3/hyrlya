using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddScoped<ILandlordService, LandlordService>();
            services.AddScoped<IRentalUnitService, RentalUnitService>();

            return services;
        }
    }
}
