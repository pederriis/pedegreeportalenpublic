using Microsoft.EntityFrameworkCore;
using User.Infrastructure.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.UserMicroserviceDto.Querys.AnimalQuriesDto;
using System;
using User.Infrastructure.Mappers;

namespace User.Infrastructure.Query
{
    public class AnimalQueries
    {
        private readonly UserDbContext _context;

        public AnimalQueries(UserDbContext userDbContext)
        {
            _context = userDbContext;
        }
        public async Task<List<AnimalDetails>> GetAllAnimals()
        {
            var animals = await _context.Animals
                .AsNoTracking()
                .ToListAsync();

            return AnimalMapper.AnimalDtoMapper.Map(animals).ToList();
        }
     

        public async Task<AnimalDetails> GetSingleAnimal(Guid animalID)
        {
            var animal = await _context.Animals

                .FirstOrDefaultAsync(a => a.AnimalId == animalID);

            return AnimalMapper.AnimalDtoMapper.Map(animal);

        }


    }
}