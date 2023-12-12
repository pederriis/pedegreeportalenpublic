using MatingCalculator.Infrastructure.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Queries;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MatingCalculator.Infrastructure.Query
{
    public class DiseaseQueries
    {

        private readonly MatingCalculatorDbContext _context;

        public DiseaseQueries(MatingCalculatorDbContext matingCalculatorDbContext)
        {
            _context = matingCalculatorDbContext;
        }



        public async Task<List<DiseaseQuriesDto.DiseaseDetails>> GetAllDiseaseDetails()
        {
            return await _context.Diseases.Select(x => new DiseaseQuriesDto.DiseaseDetails


            {
                DiseaseId=x.DiseaseId,
                HealthRecordId = x.HealthRecordId,
                Name = x.Name,
                Date=x.Date,
                Note=x.Note,
                IsHereditary=x.IsHereditary,
                Probability=x.Probability,
                IsDeleted = x.IsDeleted,

            }).AsNoTracking()
                .ToListAsync();



        }
    }
}
