using System.Threading.Tasks;
using PedigreePortalen.Framework;

namespace Kennel.Infrastructure.Shared
{
    public class EfCoreUnitOfWork : IUnitOfWork
    {
        private readonly KennelDbContext _dbContext;

        public EfCoreUnitOfWork(KennelDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public Task Commit() => _dbContext.SaveChangesAsync();
    }
}