using MediatR;
using Microsoft.UsedCarDealerWeb.Web.Interfaces;
using Microsoft.UsedCarDealerWeb.Web.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.UsedCarDealerWeb.Web.Configuration;

public static class ConfigureWebServices
{
    public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(typeof(BasketViewModelService).Assembly);
        services.AddScoped<IBasketViewModelService, BasketViewModelService>();
        services.AddScoped<CatalogViewModelService>();
        services.AddScoped<ICatalogItemViewModelService, CatalogItemViewModelService>();
        services.Configure<CatalogSettings>(configuration);
        services.AddScoped<ICatalogViewModelService, CachedCatalogViewModelService>();

        return services;
    }
}
