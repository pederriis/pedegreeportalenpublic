using MatingCalculator.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Queries;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Infrastructure.Query
{
   public class MatingCalculationQueries
    {
        private readonly MatingCalculatorDbContext _context;

        public MatingCalculationQueries(MatingCalculatorDbContext matingCalculatorDbContext)
        {
            _context = matingCalculatorDbContext;
        }



        public async Task<List<MatingCalculationQueriesDto.MatingCalculationDetails>> GetAllMatingCalculationDetails()
        {
            return await _context.MatingCalculations.Select(x => new MatingCalculationQueriesDto.MatingCalculationDetails


            {
                MatingCalculationId = x.MatingCalculationId,
                ExpectedChildren = x.ExpectedChildren,
                LitterAmount = x.LitterAmount,
                InbreedingPercent = x.InbreedingPercent,
                IsDeleted = x.IsDeleted,

                CalculatedDiseaseDetails=_context.CalculatedDiseases.Select(d=> new CalculatedDiseaseQueriesDto.CalculatedDiseaseDetails
                {
                    CalculatedDiseaseId=d.CalculatedDiseaseId,
                    MatingCalculationId=d.MatingCalculationId,
                    Name=d.Name,
                    Probability=d.Probability
                }).Where(d=>d.MatingCalculationId==x.MatingCalculationId).AsNoTracking(). ToList(),

            }).AsNoTracking()
                .ToListAsync();

        }

        public async Task<MatingCalculationQueriesDto.MatingCalculationDetails> GetSingleMatingCalculationDetails(Guid matingcalculationId)
        {
            return await _context.MatingCalculations.Select(x => new MatingCalculationQueriesDto.MatingCalculationDetails



            {
                MatingCalculationId = x.MatingCalculationId,
                ExpectedChildren = x.ExpectedChildren,
                LitterAmount = x.LitterAmount,
                InbreedingPercent = x.InbreedingPercent,
                IsLegal=x.IsLegal,
                IsDeleted = x.IsDeleted,

                CalculatedDiseaseDetails = _context.CalculatedDiseases.Select(d => new CalculatedDiseaseQueriesDto.CalculatedDiseaseDetails
                {
                    CalculatedDiseaseId = d.CalculatedDiseaseId,
                    MatingCalculationId = d.MatingCalculationId,
                    Name = d.Name,
                    Probability = d.Probability
                }).Where(d => d.MatingCalculationId == x.MatingCalculationId).AsNoTracking().ToList(),

            }).Where(x => x.MatingCalculationId == matingcalculationId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
                
               

        }
    }
}
