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
    public class DogMatingCalculationQueries
    {
        private readonly MatingCalculatorDbContext _context;

        public DogMatingCalculationQueries(MatingCalculatorDbContext matingCalculatorDbContext)
        {
            _context = matingCalculatorDbContext;
        }



        public async Task<List<DogMatingCalculationQuriesDto.DogMatingCalculationDetails>> GetAllDogDogMatingCalculationDetails()
        {
            return await _context.DogMatingCalculations.Select(x => new DogMatingCalculationQuriesDto.DogMatingCalculationDetails


            {
                DogMatingCalculationId = x.DogMatingCalculationId,
                DogId = x.DogId,
                MatingCalculationId = x.MatingCalculationId,
                IsDeleted = x.IsDeleted,


            }).AsNoTracking()
              .ToListAsync();



        }
    }
}
