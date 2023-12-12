using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Querys.HealthCertificateQuerysDto;

namespace Kennel.Infrastructure.Query
{
    public class HealthCertificateQuerys
    {
        private readonly KennelDbContext _context;

        public HealthCertificateQuerys(KennelDbContext context)
        {
            _context = context;
        }

        public async Task<List<HealthCertificateDetails>> GetAllHealthCertificates()
        {
            return await _context.HealthCertificates.AsNoTracking()
                .Where(x => x.IsDeleted.Value == false)
                .Select(x => new HealthCertificateDetails
                {
                    HealthCertificateId = x.Id.Value,
                    HealthRecordId = x.HealthRecordId,
                    HealthCertificateName = x.HealthCertificateName.Value,
                    HealthCertificateDate = x.HealthCertificateDate.Value,
                    HealthCertificateNote = x.HealthCertificateNote.Value,
                    IsDeleted = x.IsDeleted.Value,
                })
                 .ToListAsync();
        }
    }
}
