using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Querys.KennelQuerysDto;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Querys.OwnerQuerysDto;

namespace Kennel.Infrastructure.Query
{
    public class OwnerQuerys
    {
        private readonly KennelDbContext _context;

        public OwnerQuerys(KennelDbContext context)
        {
            _context = context;
        }

        public async Task<List<OwnerDetails>> GetAllOwners()
        {
            return await _context.Owners.AsNoTracking()
                .Where(x => x.IsDeleted.Value == false)
                .Select(x => new OwnerDetails
                {
                    OwnerId = x.Id.Value,
                    FirstName = x.FirstName.Value,
                    LastName = x.LastName.Value,
                    Email = x.Email.Value,
                    PhoneNo = x.PhoneNo.Value,
                    Street = x.Street.Value,
                    City = x.City.Value,
                    Zipcode = x.Zipcode.Value,
                    IsDeleted = x.IsDeleted.Value,

                    Kennel = new KennelDetails
                    {

                        KennelId = x.Kennel.Id.Value,
                        OwnerId = x.Kennel.OwnerId,
                       KennelName = x.Kennel.KennelName.Value,
                        KennelSmiley = x.Kennel.KennelSmiley.Value,
                        IsDeleted = x.Kennel.IsDeleted.Value,

                    }
                })
                 .ToListAsync();
        }
    }
}
