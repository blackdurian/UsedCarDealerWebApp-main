using System.Threading.Tasks;
using Microsoft.UsedCarDealerWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.UsedCarDealerWeb.ApplicationCore.Interfaces;

public interface IOrderService
{
    Task CreateOrderAsync(int basketId, Address shippingAddress);
}
