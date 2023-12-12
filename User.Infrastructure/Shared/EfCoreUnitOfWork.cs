using System.Threading.Tasks;
using PedigreePortalen.Framework;

namespace User.Infrastructure.Shared
{
    public class EfCoreUnitOfWork : IUnitOfWork
    {
        private readonly UserDbContext _dbContext;

        public EfCoreUnitOfWork(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public Task Commit() => _dbContext.SaveChangesAsync();
    }
}