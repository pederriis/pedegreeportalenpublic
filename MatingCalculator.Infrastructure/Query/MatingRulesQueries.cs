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
    public class MatingRulesQueries
    {

        private readonly MatingCalculatorDbContext _context;

        public MatingRulesQueries(MatingCalculatorDbContext matingCalculatorDbContext)
        {
            _context = matingCalculatorDbContext;
        }



        public async Task<List<MatingCalculationQueriesDto.MatingCalculationDetails>> GetAllMatingRulesDetails()
        {
            return await _context.MatingCalculations.Select(x => new MatingCalculationQueriesDto.MatingCalculationDetails


            {
                MatingCalculationId = x.MatingCalculationId,
                InbreedingPercent = x.InbreedingPercent,
                LitterAmount = x.LitterAmount,
                IsDeleted = x.IsDeleted,

            }).AsNoTracking()
                .ToListAsync();



        }
    }
}
