﻿using System.Collections.Generic;
using Ardalis.GuardClauses;
using Microsoft.UsedCarDealerWeb.ApplicationCore.Interfaces;

namespace Microsoft.UsedCarDealerWeb.ApplicationCore.Entities.BuyerAggregate;

public class Buyer : BaseEntity, IAggregateRoot
{
    public string IdentityGuid { get; private set; }

    private List<PaymentMethod> _paymentMethods = new List<PaymentMethod>();

    public IEnumerable<PaymentMethod> PaymentMethods => _paymentMethods.AsReadOnly();

    private Buyer()
    {
        // required by EF
    }

    public Buyer(string identity) : this()
    {
        Guard.Against.NullOrEmpty(identity, nameof(identity));
        IdentityGuid = identity;
    }
}
