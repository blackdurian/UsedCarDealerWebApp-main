﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.UsedCarDealerWeb.ApplicationCore.Entities.BasketAggregate;

namespace Microsoft.UsedCarDealerWeb.ApplicationCore.Interfaces;

public interface IBasketService
{
    Task TransferBasketAsync(string anonymousId, string userName);
    Task<Basket> AddItemToBasket(string username, int catalogItemId, decimal price, int quantity = 1);
    Task<Basket> SetQuantities(int basketId, Dictionary<string, int> quantities);
    Task DeleteBasketAsync(int basketId);
}
