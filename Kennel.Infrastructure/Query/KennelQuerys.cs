using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Querys.ProtokolQuerysDto;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Querys.KennelQuerysDto;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Querys.OwnerQuerysDto;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Kennel.Infrastructure.Query
{
    public class KennelQuerys
    {
        private readonly KennelDbContext _context;

        public KennelQuerys(KennelDbContext context)
        {
            _context = context;
        }

        public async Task<List<KennelDetails>> GetAllKennels()
        {
            return await _context.Kennels.AsNoTracking()
                .Where(x => x.IsDeleted.Value == false)
                .Select(x => new KennelDetails
                {
                    KennelId = x.Id.Value,
                    OwnerId = x.Owner.OwnerId,
                    KennelName = x.KennelName.Value,
                    KennelSmiley = x.KennelSmiley.Value,
                    IsDeleted = x.IsDeleted.Value,

                    Protokol = new ProtokolDetails
                    {
                        ProtokolId = x.Protokol.Id.Value,
                        KennelId = x.Protokol.KennelId,
                        IsDeleted = x.IsDeleted.Value
                    }
                })
                 .ToListAsync();
        }
    }
}
