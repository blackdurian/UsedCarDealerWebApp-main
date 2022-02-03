using Ardalis.Specification;
using Microsoft.UsedCarDealerWeb.ApplicationCore.Entities.OrderAggregate;

namespace Microsoft.UsedCarDealerWeb.ApplicationCore.Specifications;

public class CustomerOrdersWithItemsSpecification : Specification<Order>
{
    public CustomerOrdersWithItemsSpecification(string buyerId)
    {
        Query.Where(o => o.BuyerId == buyerId)
            .Include(o => o.OrderItems)
                .ThenInclude(i => i.ItemOrdered);
    }
}
