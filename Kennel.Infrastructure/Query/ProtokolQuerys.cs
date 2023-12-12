using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Querys.AnimalQuerysDto;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Querys.ProtokolQuerysDto;

namespace Kennel.Infrastructure.Query
{
    public class ProtokolQuerys
    {
        private readonly KennelDbContext _context;

        public ProtokolQuerys(KennelDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProtokolDetails>> GetAllProtokols()
        {
            return await _context.Protokols.AsNoTracking()
                .Where(x => x.IsDeleted.Value == false)
                .Select(x => new ProtokolDetails
                {
                    ProtokolId = x.Id.Value,
                    KennelId = x.KennelId,
                    IsDeleted = x.IsDeleted.Value,

                    Animals = x.Animals.Select(x => new AnimalDetails
                    {
                        AnimalId = x.Id.Value,
                        ProtokolId = x.ProtokolId,
                        SubRaceId = x.SubRaceId.Value,
                        RegNo = x.RegNo.Value,
                        PedigreeName = x.PedigreeName.Value,
                        BirthDate = x.BirthDate.Value,
                        DeathDate = x.DeathDate.Value,
                        Gender = x.Gender.Value,
                        Color = x.Color.Value,
                        IsBreedable = x.IsBreedable.Value,
                        IsDeleted = x.IsDeleted.Value

                    }).Where(x => x.IsDeleted == false)
                    .ToList(),
                })
                 .ToListAsync();
        }
    }
}
