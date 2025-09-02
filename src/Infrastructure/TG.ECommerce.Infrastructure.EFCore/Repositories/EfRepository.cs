using Ardalis.Specification.EntityFrameworkCore;
using TG.ECommerce.Infrastructure.EFCore.Contexts;
using TG.ECommerce.Shared.SeedWork.Repository;
namespace TG.ECommerce.Infrastructure.EFCore.Repositories;

public class EfRepository<T> : RepositoryBase<T>, IRepository<T> where T : class
{
    protected readonly TGECommerceDbContext _context;
    public IUnitOfWork UnitOfWork => _context;

    public EfRepository(TGECommerceDbContext context) : base(context)
    {
        _context = context;
    }
}