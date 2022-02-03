using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.Specification;
using Microsoft.UsedCarDealerWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.UsedCarDealerWeb.ApplicationCore.Interfaces;
using Microsoft.UsedCarDealerWeb.Web.Features.MyOrders;
using Moq;
using Xunit;

namespace Microsoft.UsedCarDealerWeb.UnitTests.MediatorHandlers.OrdersTests;

public class GetMyOrders
{
    private readonly Mock<IReadRepository<Order>> _mockOrderRepository;

    public GetMyOrders()
    {
        var item = new OrderItem(new CatalogItemOrdered(1, "ProductName", "URI"), 10.00m, 10);
        var address = new Address(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());
        Order order = new Order("buyerId", address, new List<OrderItem> { item });

        _mockOrderRepository = new Mock<IReadRepository<Order>>();
        _mockOrderRepository.Setup(x => x.ListAsync(It.IsAny<ISpecification<Order>>(), default)).ReturnsAsync(new List<Order> { order });
    }

    [Fact]
    public async Task NotReturnNullIfOrdersArePresIent()
    {
        var request = new UsedCarDealerWeb.Web.Features.MyOrders.GetMyOrders("SomeUserName");

        var handler = new GetMyOrdersHandler(_mockOrderRepository.Object);

        var result = await handler.Handle(request, CancellationToken.None);

        Assert.NotNull(result);
    }
}
