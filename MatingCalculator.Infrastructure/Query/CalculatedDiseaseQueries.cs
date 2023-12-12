using MatingCalculator.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Infrastructure.Query
{
    public class CalculatedDiseaseQueries
    {

        private readonly MatingCalculatorDbContext _context;

        public CalculatedDiseaseQueries(MatingCalculatorDbContext matingCalculatorDbContext)
        {
            _context = matingCalculatorDbContext;
        }

        public async Task<List<CalculatedDiseaseQueriesDto.CalculatedDiseaseDetails>> GetAllCalculatedDiseaseDetails()
        {
            return await _context.CalculatedDiseases.Select(x => new CalculatedDiseaseQueriesDto.CalculatedDiseaseDetails

            {
                CalculatedDiseaseId=x.CalculatedDiseaseId,
               MatingCalculationId=x.MatingCalculationId,
                Name = x.Name,
                Probability = x.Probability,
                IsDeleted = x.IsDeleted,

            }).AsNoTracking()
                .ToListAsync();

        }

        public async Task<List<CalculatedDiseaseQueriesDto.CalculatedDiseaseDetails>> GetAllCalculatedDiseaseDetailsFromMatingCalculationId(Guid matingCalculationId)
        {
            return await _context.CalculatedDiseases.Select(x => new CalculatedDiseaseQueriesDto.CalculatedDiseaseDetails

            {
                CalculatedDiseaseId = x.CalculatedDiseaseId,
                MatingCalculationId = x.MatingCalculationId,
                Name = x.Name,
                Probability = x.Probability,
                IsDeleted = x.IsDeleted,

            }).Where(x => x.MatingCalculationId == matingCalculationId)
            .AsNoTracking()
                .ToListAsync();

        }
    }
}
