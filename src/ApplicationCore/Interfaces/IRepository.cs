using Ardalis.Specification;

namespace Microsoft.UsedCarDealerWeb.ApplicationCore.Interfaces;

public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}
