using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.UsedCarDealerWeb.ApplicationCore.Entities;
using Microsoft.Extensions.Logging;

namespace Microsoft.UsedCarDealerWeb.Infrastructure.Data;

public class CatalogContextSeed
{
    public static async Task SeedAsync(CatalogContext catalogContext,
        ILogger logger,
        int retry = 0)
    {
        var retryForAvailability = retry;
        try
        {
            if (catalogContext.Database.IsSqlServer())
            {
                catalogContext.Database.Migrate();
            }

            if (!await catalogContext.CatalogBrands.AnyAsync())
            {
                await catalogContext.CatalogBrands.AddRangeAsync(
                    GetPreconfiguredCatalogBrands());

                await catalogContext.SaveChangesAsync();
            }

            if (!await catalogContext.CatalogTypes.AnyAsync())
            {
                await catalogContext.CatalogTypes.AddRangeAsync(
                    GetPreconfiguredCatalogTypes());

                await catalogContext.SaveChangesAsync();
            }

            if (!await catalogContext.CatalogItems.AnyAsync())
            {
                await catalogContext.CatalogItems.AddRangeAsync(
                    GetPreconfiguredItems());

                await catalogContext.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            if (retryForAvailability >= 10) throw;

            retryForAvailability++;
            
            logger.LogError(ex.Message);
            await SeedAsync(catalogContext, logger, retryForAvailability);
            throw;
        }
    }

    static IEnumerable<CatalogBrand> GetPreconfiguredCatalogBrands()
    {
        return new List<CatalogBrand>
            {
                new("Honda"),
                new("Toyota"),
                new("Perodua"),
                new("Mercedes Benz"),
                new("Other")
            };
    }

    static IEnumerable<CatalogType> GetPreconfiguredCatalogTypes()
    {
        return new List<CatalogType>
            {
                new("Sedan"),
                new("SUV"),
                new("Coupe"),
                new("Other")
            };
    }

    static IEnumerable<CatalogItem> GetPreconfiguredItems()
    {
        return new List<CatalogItem>
            {
                new(1,1, "2016, Black, 30k mileages", "Honda City", 60000,  "http://catalogbaseurltobereplaced/images/products/1.png"),
                new(1,1, "2018, White, 20k mileages", "Honda Civic", 90000, "http://catalogbaseurltobereplaced/images/products/2.png"),
                new(1,2, "2019, Red, 10k mileages", "Toyota Vios", 70000,  "http://catalogbaseurltobereplaced/images/products/3.png"),
                new(1,2, "2019, White, 10k mileages", "Toyota Altis", 80000, "http://catalogbaseurltobereplaced/images/products/4.png"),
                new(4,3, "2021, Red, 4k mileages", "Perodua Myvi", 40000, "http://catalogbaseurltobereplaced/images/products/5.png"),
                new(2,3, "2018, White, 10k mileages", "Perodua Ativa", 40000, "http://catalogbaseurltobereplaced/images/products/6.png"),
                new(2,3, "2019, Silver, 20k mileages", "Perodua Aruz",  50000, "http://catalogbaseurltobereplaced/images/products/7.png"),
                new(1,4, "2018, Grey, 40k mileages", "Mercedes Benz C200", 150000, "http://catalogbaseurltobereplaced/images/products/8.png"),
                new(1,5, "2020, Orange, 30k mileages", "BMW 3 Series", 160000, "http://catalogbaseurltobereplaced/images/products/9.png"),
                new(2,5, "2018, Red, 30k mileages", "Mazda CX-5", 120000, "http://catalogbaseurltobereplaced/images/products/10.png"),
                new(1,2, "2019, White, 20k mileages", "Toyota Camry", 110000, "http://catalogbaseurltobereplaced/images/products/11.png"),
                new(1,1, "2020, Red, 10k mileages", "Honda Accord", 120000, "http://catalogbaseurltobereplaced/images/products/12.png")
            };
    }
}
