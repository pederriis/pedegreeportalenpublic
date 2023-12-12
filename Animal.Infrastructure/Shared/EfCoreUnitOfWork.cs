using System.Threading.Tasks;
using PedigreePortalen.Framework;

namespace Animal.Infrastructure.Shared
{
    public class EfCoreUnitOfWork : IUnitOfWork
    {
        private readonly AnimalDbContext _dbContext;

        public EfCoreUnitOfWork(AnimalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public Task Commit() => _dbContext.SaveChangesAsync();
    }
}