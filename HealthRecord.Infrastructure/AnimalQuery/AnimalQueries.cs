using HealthRecord.Infrastructure.Mappers;
using HealthRecord.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.HealthRecordMicroservice.Queries.AnimalQuriesDTO;
using static PedigreePortalen.Shared.HealthRecordMicroservice.Queries.HealthRecordQueriesDTO;

namespace HealthRecord.Infrastructure.AnimalQuery
{
    public class AnimalQueries
    {
        private readonly HealthRecordDbContext _context;

        public AnimalQueries(HealthRecordDbContext healthRecordDbContext)
        {
            _context = healthRecordDbContext;
        }

        public async Task<List<AnimalDetails>> GetAllAnimalDetails()
        {
            var animals = await _context.Animals
                .AsNoTracking()
                .ToListAsync();

            return AnimalMapper.AnimalDtoMapper.Map(animals).ToList();
        }
        //public async Task<List<AnimalDetails>> GetAllAnimalDetails()
        //{
        //    return await _context.Animals.Select(x => new AnimalDetails


        //    {
        //        AnimalId = x.AnimalId,
        //        Name = x.Name,
        //        OwnerId = x.OwnerId,
        //        IsDeleted = x.IsDeleted,

        //        HealthRecordDetails = new HealthRecordDetails
        //        {

        //            HealthRecordID = x.HealthRecord.Id.Value,
        //            AnimalId = x.HealthRecord.AnimalId
        //        }


        //    }).AsNoTracking()
        //      .ToListAsync();

        //}
        public async Task<AnimalDetails> GetSingleAnimalDetails(Guid animalID)
        {
            var animal = await _context.Animals
               
                .FirstOrDefaultAsync(a => a.AnimalId == animalID);

            return AnimalMapper.AnimalDtoMapper.Map(animal);

        }
        //public async Task<AnimalDetails> GetSingleAnimalDetails(Guid animalID)
        //{

        //    return await _context.Animals.Select(x => new AnimalDetails

        //    {
        //        AnimalId = x.AnimalId,
        //        Name = x.Name,
        //        OwnerId = x.OwnerId,
        //        IsDeleted = x.IsDeleted

        //    }).AsNoTracking()
        //    .FirstOrDefaultAsync(p=>p.AnimalId==animalID);
           
        //}
    }
}
