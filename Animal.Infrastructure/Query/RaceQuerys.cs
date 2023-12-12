using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Querys.RaceQuerysDto;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Querys.SubRaceQuerysDto;

namespace Animal.Infrastructure.Query
{
    public class RaceQuerys
    {
        private readonly AnimalDbContext _context;

        public RaceQuerys(AnimalDbContext context)
        {
            _context = context;
        }

        public async Task<List<RaceDetails>> GetAllRaces()
        {
            return await _context.Races.AsNoTracking()
                .Where(x => x.IsDeleted.Value == false)
                .Select(x => new RaceDetails
                {
                    RaceId = x.Id.Value,
                    RaceName = x.RaceName.Value,
                    IsDeleted = x.IsDeleted.Value,

                    SubRaces = x.SubRaces.Select(x => new SubRaceDetails
                    {
                        SubRaceId = x.Id.Value,
                        RaceId = x.RaceId,
                        SubRaceName = x.SubRaceName.Value,
                        IsDeleted = x.IsDeleted.Value,
                    }).Where(x => x.IsDeleted == false)
                    .ToList()
                })
                 .ToListAsync();
        }

        public async Task<RaceDetails> GetRaceById(QueryModels.RaceQueryModel.GetRaceByRaceId query)
        {
            return await _context.Races.AsNoTracking()
                .Where(x => x.RaceId == query.RaceId && x.IsDeleted.Value == false)
                .Select(x => new RaceDetails
                {
                    RaceId = x.Id.Value,
                    RaceName = x.RaceName.Value,
                    IsDeleted = x.IsDeleted.Value,

                    SubRaces = x.SubRaces.Select(x => new SubRaceDetails
                    {
                        SubRaceId = x.Id.Value,
                        RaceId = x.RaceId,
                        SubRaceName = x.SubRaceName.Value,
                        IsDeleted = x.IsDeleted.Value,
                    }).Where(x => x.IsDeleted == false)
                    .ToList()
                })
                .FirstOrDefaultAsync();
        }
    }
}
