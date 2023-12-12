using System;
using System.Threading.Tasks;
using User.Application;
using User.Infrastructure.Shared;

namespace User.Infrastructure
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private readonly UserDbContext _dbContext;

        public UserRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //User
        public void Dispose() => _dbContext.Dispose();

        public async Task AddUser(Domain.User.User entity)
            => await _dbContext.Users.AddAsync(entity);

        public async Task<bool> UserExists(Guid id)
            => await _dbContext.Users.FindAsync(id) != null;

        public async Task<Domain.User.User> LoadUser(Guid id)
            => await _dbContext.Users.FindAsync(id);

        //Animal
        public async Task AddAnimal(Domain.Animal.Animal entity)
            => await _dbContext.Animals.AddAsync(entity);

        public async Task<bool> AnimalExists(Guid id)
            => await _dbContext.Animals.FindAsync(id) != null;

        public async Task<Domain.Animal.Animal> LoadAnimal(Guid id)
            => await _dbContext.Animals.FindAsync(id);
    }
}
