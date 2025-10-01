using Application.Interfaces;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddScoped<IMyLandlordService, MyLandlordService>();
            services.AddScoped<IMyRentalUnitService, MyRentalUnitService>();
            services.AddScoped<IMyListingService, MyListingService>();
            services.AddScoped<IListingService, ListingService>();

            return services;
        }
    }
}
