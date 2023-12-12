using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Querys.AnimalQuerysDto;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Querys.SubRaceQuerysDto;

namespace Animal.Infrastructure.Query
{
    public class SubRaceQuerys
    {
        private readonly AnimalDbContext _context;

        public SubRaceQuerys(AnimalDbContext context)
        {
            _context = context;
        }

        public async Task<List<SubRaceDetails>> GetAllSubRaces()
        {
            return await _context.SubRaces.AsNoTracking()
                .Where(x => x.IsDeleted.Value == false)
                .Select(x => new SubRaceDetails
                {
                    SubRaceId = x.Id.Value,
                    RaceId = x.RaceId,
                    SubRaceName = x.SubRaceName.Value,
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
                    .ToList()
                })
                 .ToListAsync();
        }

        public async Task<List<SubRaceDetails>> GetAllSubRacesByRaceId(QueryModels.SubRaceQueryModel.GetAllSubRaceByRaceId query)
        {
            return await _context.SubRaces.AsNoTracking()
                .Where(x => x.IsDeleted.Value == false && x.RaceId == query.RaceId)
                .Select(x => new SubRaceDetails
                {
                    SubRaceId = x.Id.Value,
                    RaceId = x.RaceId,
                    SubRaceName = x.SubRaceName.Value,
                    IsDeleted = x.IsDeleted.Value,

                })
                 .ToListAsync();
        }


    }
}
