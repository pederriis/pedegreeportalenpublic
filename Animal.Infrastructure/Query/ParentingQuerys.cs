using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Querys.ParentingQuerysDto;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Querys.LitterQuerysDto;

namespace Animal.Infrastructure.Query
{
    public class ParentingQuerys
    {
        private readonly AnimalDbContext _context;

        public ParentingQuerys(AnimalDbContext context)
        {
            _context = context;
        }

        public async Task<List<ParentingDetails>> GetAllParentings()
        {
            return await _context.Parentings.AsNoTracking()
                .Where(x => x.IsDeleted.Value == false)
                .Select(x => new ParentingDetails
                {
                    ParentingId = x.Id.Value,
                    AnimalId = x.AnimalId,
                    LitterId = x.LitterId,
                    IsDeleted = x.IsDeleted.Value
                })
                 .ToListAsync();
        }

        public async Task<List<ParentingDetails>> GetAllParentingsByAnimalId(QueryModels.ParentingQueryModel.GetAnimalPedegreeByAnimalId query)
        {
            return await _context.Parentings.AsNoTracking()
                .Where(x => x.AnimalId == query.AnimalId && x.IsDeleted.Value == false)
                .Select(x => new ParentingDetails
                {
                    ParentingId = x.Id.Value,
                    AnimalId = x.AnimalId,
                    LitterId = x.LitterId,
                    IsDeleted = x.IsDeleted.Value,

                    Litter = new LitterDetails 
                    {
                        LitterId = x.Litter.Id.Value,
                        BreedById = x.Litter.BreedById,
                        LitterName = x.Litter.LitterName,
                        LitterBirthDate = x.Litter.LitterBirthDate,
                        MatingDate = x.Litter.MatingDate
                    }
                })
                 .ToListAsync();
        }
    }
}
