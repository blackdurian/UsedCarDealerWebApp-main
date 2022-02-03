using System.Threading.Tasks;
using Microsoft.UsedCarDealerWeb.ApplicationCore.Entities.BasketAggregate;
using Microsoft.UsedCarDealerWeb.ApplicationCore.Interfaces;
using Microsoft.UsedCarDealerWeb.ApplicationCore.Services;
using Moq;
using Xunit;

namespace Microsoft.UsedCarDealerWeb.UnitTests.ApplicationCore.Services.BasketServiceTests;

public class DeleteBasket
{
    private readonly string _buyerId = "Test buyerId";
    private readonly Mock<IRepository<Basket>> _mockBasketRepo = new();

    [Fact]
    public async Task ShouldInvokeBasketRepositoryDeleteAsyncOnce()
    {
        var basket = new Basket(_buyerId);
        basket.AddItem(1, It.IsAny<decimal>(), It.IsAny<int>());
        basket.AddItem(2, It.IsAny<decimal>(), It.IsAny<int>());
        _mockBasketRepo.Setup(x => x.GetByIdAsync(It.IsAny<int>(), default))
            .ReturnsAsync(basket);
        var basketService = new BasketService(_mockBasketRepo.Object, null);

        await basketService.DeleteBasketAsync(It.IsAny<int>());

        _mockBasketRepo.Verify(x => x.DeleteAsync(It.IsAny<Basket>(), default), Times.Once);
    }
}
