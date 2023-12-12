using HealthRecord.Application;
using HealthRecord.Infrastructure.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HealthRecord.Domain.Animal;

namespace HealthRecord.Infrastructure
{
    public class AnimalRepository : IAnimalRepository, IDisposable
    {
        private readonly HealthRecordDbContext _dbContext;

        public AnimalRepository(HealthRecordDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose() => _dbContext.Dispose();

        public async Task AddAnimal(HealthRecord.Domain.Animal.Animal entity)
            => await _dbContext.Animals.AddAsync(entity);

        public async Task<bool> AnimalExists(Guid id)
            => await _dbContext.Animals.FindAsync(id) != null;

        public async Task<Domain.Animal.Animal> LoadAnimal(Guid id)
            => await _dbContext.Animals.FindAsync(id);
    }
}
