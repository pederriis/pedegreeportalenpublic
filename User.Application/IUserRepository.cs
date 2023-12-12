using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace User.Application
{
    public interface IUserRepository
    {
        //User
        Task AddUser(Domain.User.User entity);
        Task<bool> UserExists(Guid id);
        Task<Domain.User.User> LoadUser(Guid id);

        //Animal
        Task AddAnimal(Domain.Animal.Animal entity);
        Task<bool> AnimalExists(Guid id);
        Task<Domain.Animal.Animal> LoadAnimal(Guid id);
    }
}
