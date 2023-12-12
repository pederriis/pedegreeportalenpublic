using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Querys.ParrentQuerysDto;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Querys.LitterQuerysDto;

namespace Kennel.Infrastructure.Query
{
    public class LitterQuerys
    {
        private readonly KennelDbContext _context;

        public LitterQuerys(KennelDbContext context)
        {
            _context = context;
        }

        public async Task<List<LitterDetails>> GetAllLitters()
        {
            return await _context.Litters.AsNoTracking()
                .Where(x => x.IsDeleted.Value == false)
                .Select(x => new LitterDetails
                {
                    LitterId = x.Id.Value,
                    LitterName = x.LitterName.Value,
                    LitterBirthDate = x.LitterBirthDate.Value,
                    IsDeleted = x.IsDeleted.Value,

                    Parrents = x.Parrents.Select(x => new ParrentDetails
                    {
                        ParrentId = x.Id.Value,
                        AnimalId = x.AnimalId,
                        LitterId = x.LitterId,
                        IsDeleted = x.IsDeleted.Value
                    }).Where(x => x.IsDeleted == false)
                    .ToList()

                })
                 .ToListAsync();
        }
    }
}
