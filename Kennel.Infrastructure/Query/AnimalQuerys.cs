using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Querys.ParrentQuerysDto;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Querys.AnimalQuerysDto;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Querys.HealthRecordQuerysDto;

namespace Kennel.Infrastructure.Query
{
    public class AnimalQuerys
    {
        private readonly KennelDbContext _context;

        public AnimalQuerys(KennelDbContext context)
        {
            _context = context;
        }

        public async Task<List<AnimalDetails>> GetAllAnimals()
        {
            return await _context.Animals.AsNoTracking()
                .Where(x => x.IsDeleted.Value == false)
                .Select(x => new AnimalDetails
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
                    IsDeleted = x.IsDeleted.Value,

                    Parrents = x.Parrents.Select(x => new ParrentDetails
                    {
                        ParrentId = x.Id.Value,
                        AnimalId = x.AnimalId,
                        LitterId = x.LitterId,
                        IsDeleted = x.IsDeleted.Value
                    }).Where(x => x.IsDeleted == false)
                    .ToList(),

                    HealthRecord = new HealthRecordDetails
                    {
                        HealthRecordId = x.HealthRecord.Id.Value,
                        AnimalId = x.HealthRecord.AnimalId,
                        IsDeleted = x.HealthRecord.IsDeleted.Value
                    }
                })
                 .ToListAsync();
        }
    }
}
