using MatingCalculator.Infrastructure.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Queries;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace MatingCalculator.Infrastructure.Query
{
    public class HealthRecordQueries
    {
        private readonly MatingCalculatorDbContext _context;

        public HealthRecordQueries(MatingCalculatorDbContext matingCalculatorDbContext)
        {
            _context = matingCalculatorDbContext;
        }

        public async Task<List<HealthRecordQuriesDto.HealthRecordDetails>> GetAllHealthRecords()
        {
            return await _context.HealthRecords.AsNoTracking()
                .Where(x => x.IsDeleted.Value == false)
                .Select(x => new HealthRecordQuriesDto.HealthRecordDetails
                {
                    HealthRecordId = x.Id.Value,
                    DogId = x.DogId,
                    IsDeleted = x.IsDeleted.Value
                })
                 .ToListAsync();
        }
    }
}
