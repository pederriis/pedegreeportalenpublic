using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Querys.ChildQuerysDto;

namespace Kennel.Infrastructure.Query
{
    public class ChildQuerys
    {
        private readonly KennelDbContext _context;

        public ChildQuerys(KennelDbContext context)
        {
            _context = context;
        }
        public async Task<List<ChildDetails>> GetAllChildren()
        {
            return await _context.Children.AsNoTracking()
                .Where(x => x.IsDeleted.Value == false)
                .Select(x => new ChildDetails
                {
                    ChildId = x.Id.Value,
                    AnimalId = x.AnimalId,
                    LitterId = x.LitterId,
                    IsDeleted = x.IsDeleted.Value
                })
                 .ToListAsync();
        }

    }
}
