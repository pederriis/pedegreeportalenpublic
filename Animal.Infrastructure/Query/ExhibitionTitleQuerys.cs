using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Querys.ExhibitionTitleQuerysDto;

namespace Animal.Infrastructure.Query
{
    public class ExhibitionTitleQuerys
    {
        private readonly AnimalDbContext _context;

        public ExhibitionTitleQuerys(AnimalDbContext context)
        {
            _context = context;
        }

        public async Task<List<ExhibitionTitleDetails>> GetAllExhibitionTitles()
        {
            return await _context.ExhibitionTitles.AsNoTracking()
                .Where(x => x.IsDeleted.Value == false)
                .Select(x => new ExhibitionTitleDetails
                {
                    ExhibitionTitleId = x.Id.Value,
                    AnimalId = x.AnimalId,
                    Name = x.Name.Value,
                    Date = x.Date.Value,
                    IsDeleted = x.IsDeleted.Value
                })
                 .ToListAsync();
        }
    }
}
