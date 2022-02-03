using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Microsoft.UsedCarDealerWeb.Web.Areas.Identity.IdentityHostingStartup))]
namespace Microsoft.UsedCarDealerWeb.Web.Areas.Identity;

public class IdentityHostingStartup : IHostingStartup
{
    public void Configure(IWebHostBuilder builder)
    {
        builder.ConfigureServices((context, services) =>
        {
        });
    }
}
