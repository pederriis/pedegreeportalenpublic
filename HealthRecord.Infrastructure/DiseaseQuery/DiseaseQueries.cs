using HealthRecord.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.HealthRecordMicroservice.Queries.DiseaseQuerysDto;

namespace HealthRecord.Infrastructure.DiseaseQuery
{
    public class DiseaseQueries
    {
        private readonly HealthRecordDbContext _context;

        public DiseaseQueries(HealthRecordDbContext healthRecordDbContext)
        {
            _context = healthRecordDbContext;
        }

        public async Task<List<DiseaseDetails>> GetAllDiseaseDetails()
        {
            return await _context.Diseases.Select(x => new DiseaseDetails


            {
                DiseaseId = x.Id.Value,
                Name = x.Name,
                Date=x.Date,
                Note=x.Note,
                IsHereditary=x.IsHereditary,
               

            }).AsNoTracking()
              .ToListAsync();

        }

        public async Task<DiseaseDetails> GetSingleDiseaseDetails(Guid diseaseId)
        {
            return await _context.Diseases.Select(x => new DiseaseDetails


            {
                DiseaseId = x.Id.Value,
                Name = x.Name,
                Date = x.Date,
                Note = x.Note,
                IsHereditary = x.IsHereditary,


            }).AsNoTracking()
              .FirstOrDefaultAsync(x=>x.DiseaseId==diseaseId);

        }

        public async Task<List<DiseaseDetails>> GetAllDiseaseDetailsFromHealthRecordId(Guid healthRecordId)
        {
            return await _context.Diseases.Select(x => new DiseaseDetails


            {
                DiseaseId = x.Id.Value,
                HealthRecordId=x.HealtRecordId,
                Name = x.Name,
                Date = x.Date,
                Note = x.Note,
                IsHereditary = x.IsHereditary,


            }).Where(x=>x.HealthRecordId==healthRecordId)
            .AsNoTracking()
              .ToListAsync();

        }
    }
}
