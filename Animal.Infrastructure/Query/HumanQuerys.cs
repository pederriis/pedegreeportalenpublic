using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Querys.AnimalQuerysDto;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Querys.HumanQuerysDto;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Querys.LitterQuerysDto;

namespace Animal.Infrastructure.Query
{
    public class HumanQuerys
    {
        private readonly AnimalDbContext _context;

        public HumanQuerys(AnimalDbContext context)
        {
            _context = context;
        }

        public async Task<List<HumanDetails>> GetAllHumans()
        {
            return await _context.Humans.AsNoTracking()
                .Where(x => x.IsDeleted.Value == false)
                .Select(x => new HumanDetails
                {
                    HumanId = x.Id.Value,
                    IsDeleted = x.IsDeleted.Value,
                    
                    Animals = x.Animals.Select(x => new AnimalDetails
                    {
                        AnimalId = x.Id.Value,
                        OwnerId = x.OwnerId,
                        SubRaceId = x.SubRaceId,
                        RegNo = x.RegNo.Value,
                        PedigreeName = x.PedigreeName.Value,
                        ShortName = x.ShortName.Value,
                        BirthDate = x.BirthDate.Value,
                        DeathDate = x.DeathDate.Value,
                        Gender = x.Gender.Value,
                        Color = x.Color.Value,
                        WeightInKg = x.WeightInKg.Value,
                        IsBreedable = x.IsBreedable.Value,
                        ProfileText = x.ProfileText.Value,
                        IsDeleted = x.IsDeleted.Value,
                    }).Where(x => x.IsDeleted == false)
                    .ToList(),

                    Litters = x.Litters.Select(x => new LitterDetails
                    {
                        LitterId = x.Id.Value,
                        BreedById = x.BreedById,
                        LitterName = x.LitterName.Value,
                        LitterBirthDate = x.LitterBirthDate.Value,
                        MatingDate = x.MatingDate.Value,
                        IsDeleted = x.IsDeleted.Value,
                    }).Where(x => x.IsDeleted == false)
                    .ToList()
                })
                 .ToListAsync();
        }
    }
}
