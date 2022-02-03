using Ardalis.Specification;

namespace Microsoft.UsedCarDealerWeb.ApplicationCore.Interfaces;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
