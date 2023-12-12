using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Application.Intefaces
{
   public interface IDogRepository
    {
        

            Task AddDog(Domain.Dog.Dog entity);
            Task<bool> DogExists(Guid id);
            Task<Domain.Dog.Dog> LoadDog(Guid id);

        
    }
}
