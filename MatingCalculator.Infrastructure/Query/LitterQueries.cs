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
    public class LitterQueries
    {
        private readonly MatingCalculatorDbContext _context;

        public LitterQueries(MatingCalculatorDbContext matingCalculatorDbContext)
        {
            _context = matingCalculatorDbContext;
        }

        public async Task<List<LitterQuriesDto.LitterDetails>> GetAllLitterDetails()
        {
            return await _context.Litters.Select(x => new LitterQuriesDto.LitterDetails

            {
                LitterId=x.LitterId,
                Name=x.Name,
                Date=x.Date,
                IsDeleted=x.IsDeleted,

                DogDetails= x.Dogs.Select(x => new DogQuriesDto.DogDetails

                {
                    DogId = x.DogId,
                    Name=x.Name,
                    
                }).ToList(),
                ParentingDetails = x.Parentings.Select(x => new ParentingQuriesDto.ParentingDetails

                {
                    ParentingId = x.Id.Value,
                    DogId = x.DogId,
                    LitterId = x.LitterId,

                }).ToList()

            }).AsNoTracking()
              .ToListAsync();

        }

        public async Task<LitterQuriesDto.LitterDetails> GetSingleLitterDetails(Guid litterId)
        {
            return await _context.Litters.Select(x => new LitterQuriesDto.LitterDetails

            {
                LitterId = x.LitterId,
                Name = x.Name,
                Date = x.Date,
                IsDeleted = x.IsDeleted,

                DogDetails = x.Dogs.Select(x => new DogQuriesDto.DogDetails

                {
                    DogId = x.DogId,
                    Name = x.Name,

                }).ToList(),
                ParentingDetails = x.Parentings.Select(x => new ParentingQuriesDto.ParentingDetails

                {
                    ParentingId = x.Id.Value,
                    DogId = x.DogId,
                    LitterId = x.LitterId,

                }).ToList()
            })
              .AsNoTracking()
              .FirstOrDefaultAsync(x=>x.LitterId==litterId);

        }
    }
}
