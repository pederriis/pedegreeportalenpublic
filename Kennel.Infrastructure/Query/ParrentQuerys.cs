using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Querys.ParrentQuerysDto;

namespace Kennel.Infrastructure.Query
{
    public class ParrentQuerys
    {
        private readonly KennelDbContext _context;

        public ParrentQuerys(KennelDbContext context)
        {
            _context = context;
        }

        public async Task<List<ParrentDetails>> GetAllParrents()
        {
            return await _context.Parrents.AsNoTracking()
                .Where(x => x.IsDeleted.Value == false)
                .Select(x => new ParrentDetails
                {
                    ParrentId = x.Id.Value,
                    AnimalId = x.AnimalId,
                    LitterId = x.LitterId,
                    IsDeleted = x.IsDeleted.Value
                })
                 .ToListAsync();
        }
    }
}
