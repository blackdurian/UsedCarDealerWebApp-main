using Ardalis.Specification;
using Microsoft.UsedCarDealerWeb.ApplicationCore.Entities;

namespace Microsoft.UsedCarDealerWeb.ApplicationCore.Specifications;

public class CatalogItemNameSpecification : Specification<CatalogItem>
{
    public CatalogItemNameSpecification(string catalogItemName)
    {
        Query.Where(item => catalogItemName == item.Name);
    }
}
