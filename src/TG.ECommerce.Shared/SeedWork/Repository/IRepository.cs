using Ardalis.Specification;

namespace TG.ECommerce.Shared.SeedWork.Repository;

public interface IRepository<T> : IRepositoryBase<T> where T : class
{
    IUnitOfWork UnitOfWork { get; }
}