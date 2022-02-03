using Microsoft.UsedCarDealerWeb.ApplicationCore.Interfaces;

namespace Microsoft.UsedCarDealerWeb.ApplicationCore.Entities;

public class CatalogType : BaseEntity, IAggregateRoot
{
    public string Type { get; private set; }
    public CatalogType(string type)
    {
        Type = type;
    }
}
