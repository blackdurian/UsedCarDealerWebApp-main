using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.UsedCarDealerWeb.ApplicationCore.Constants;
using Microsoft.UsedCarDealerWeb.Web.Extensions;
using Microsoft.UsedCarDealerWeb.Web.Services;
using Microsoft.UsedCarDealerWeb.Web.ViewModels;
using Microsoft.Extensions.Caching.Memory;

namespace Microsoft.UsedCarDealerWeb.Web.Pages.Admin;

[Authorize(Roles = BlazorShared.Authorization.Constants.Roles.ADMINISTRATORS)]
public class IndexModel : PageModel
{
    public IndexModel()
    {

    }
}
