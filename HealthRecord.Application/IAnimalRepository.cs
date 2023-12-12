using HealthRecord.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HealthRecord.Application
{
    public interface IAnimalRepository
    {
        Task AddAnimal(Domain.Animal.Animal entity);
        Task<bool> AnimalExists(Guid id);
        Task<Domain.Animal.Animal> LoadAnimal(Guid id);
    }
}
