using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.UsedCarDealerWeb.ApplicationCore.Interfaces;

namespace Microsoft.UsedCarDealerWeb.Infrastructure.Data;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
    public EfRepository(CatalogContext dbContext) : base(dbContext)
    {
    }
}
