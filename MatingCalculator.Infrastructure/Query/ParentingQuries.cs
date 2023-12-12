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
    public class ParentingQuries
    {
        private readonly MatingCalculatorDbContext _context;

        public ParentingQuries(MatingCalculatorDbContext matingCalculatorDbContext)
        {
            _context = matingCalculatorDbContext;
        }

        public async Task<List<ParentingQuriesDto.ParentingDetails>> GetAllParentingDetails()
        {
            return await _context.Parentings.Select(x => new ParentingQuriesDto.ParentingDetails


            {
                ParentingId = x.ParentingId,
                DogId = x.DogId,
                LitterId = x.LitterId,
                IsDeleted = x.IsDeleted,


            }).AsNoTracking()
              .ToListAsync();



        }
    }
}
