﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.UsedCarDealerWeb.ApplicationCore.Entities.OrderAggregate;
using Microsoft.UsedCarDealerWeb.ApplicationCore.Interfaces;
using Microsoft.UsedCarDealerWeb.ApplicationCore.Specifications;
using Microsoft.UsedCarDealerWeb.Web.ViewModels;

namespace Microsoft.UsedCarDealerWeb.Web.Features.OrderDetails;

public class GetOrderDetailsHandler : IRequestHandler<GetOrderDetails, OrderViewModel>
{
    private readonly IReadRepository<Order> _orderRepository;

    public GetOrderDetailsHandler(IReadRepository<Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<OrderViewModel> Handle(GetOrderDetails request,
        CancellationToken cancellationToken)
    {
        var spec = new OrderWithItemsByIdSpec(request.OrderId);
        var order = await _orderRepository.GetBySpecAsync(spec, cancellationToken);

        if (order == null)
        {
            return null;
        }

        return new OrderViewModel
        {
            OrderDate = order.OrderDate,
            OrderItems = order.OrderItems.Select(oi => new OrderItemViewModel
            {
                PictureUrl = oi.ItemOrdered.PictureUri,
                ProductId = oi.ItemOrdered.CatalogItemId,
                ProductName = oi.ItemOrdered.ProductName,
                UnitPrice = oi.UnitPrice,
                Units = oi.Units
            }).ToList(),
            OrderNumber = order.Id,
            ShippingAddress = order.ShipToAddress,
            Total = order.Total()
        };
    }
}
