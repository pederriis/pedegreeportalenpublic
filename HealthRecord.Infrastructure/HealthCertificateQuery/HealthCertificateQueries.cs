using HealthRecord.Domain.HealthCertificate;
using HealthRecord.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.HealthRecordMicroservice.Queries.HealthCertificateQueriesDTO;

namespace HealthRecord.Infrastructure.HealthCertificateQuery
{
    public class HealthCertificateQueries
    {
        private readonly HealthRecordDbContext _context;

        public HealthCertificateQueries(HealthRecordDbContext healthRecordDbContext)
        {
            _context = healthRecordDbContext;
        }

        public async Task<List<HealthCertificateDetails>> GetAllHealRecordDetails()
        {
            return await _context.HealthCertificates.Select(x => new HealthCertificateDetails


            {
                HealthCertificateId = x.Id.Value,


            }).AsNoTracking()
            .ToListAsync();

        }

        public async Task<HealthCertificateDetails> GetSingleHealRecordDetails(Guid healthCertificateId)
        {
            return await _context.HealthCertificates.Select(x => new HealthCertificateDetails


            {
                HealthCertificateId = x.Id.Value
            }).FirstOrDefaultAsync(x => x.HealthCertificateId == healthCertificateId);

        }
    }
}
