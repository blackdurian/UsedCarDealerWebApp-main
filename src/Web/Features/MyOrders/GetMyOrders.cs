﻿using System.Collections.Generic;
using MediatR;
using Microsoft.UsedCarDealerWeb.Web.ViewModels;

namespace Microsoft.UsedCarDealerWeb.Web.Features.MyOrders;

public class GetMyOrders : IRequest<IEnumerable<OrderViewModel>>
{
    public string UserName { get; set; }

    public GetMyOrders(string userName)
    {
        UserName = userName;
    }
}
