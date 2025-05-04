using Core.Repositories.EntityFramework;
using Entities;
using Repositories.Abstracts;
using Repositories.Concretes.EntityFramework.Contexts;

namespace Repositories.Concretes.EntityFramework;

public class CarRepository : EfRepositoryBase<Car, Guid, BaseDbContext>, ICarRepository
{
    public CarRepository(BaseDbContext context) : base(context)
    {
    }
}
