using Microsoft.UsedCarDealerWeb.ApplicationCore.Entities.BasketAggregate;
using Microsoft.UsedCarDealerWeb.Web.Pages.Basket;

namespace Microsoft.UsedCarDealerWeb.Web.Interfaces;

public interface IBasketViewModelService
{
    Task<BasketViewModel> GetOrCreateBasketForUser(string userName);
    Task<int> CountTotalBasketItems(string username);
    Task<BasketViewModel> Map(Basket basket);
}
