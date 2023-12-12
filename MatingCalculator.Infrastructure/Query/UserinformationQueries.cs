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
    public class UserinformationQueries
    {

        private readonly MatingCalculatorDbContext _context;

        public UserinformationQueries(MatingCalculatorDbContext matingCalculatorDbContext)
        {
            _context = matingCalculatorDbContext;
        }



        public async Task<List<UserinformationCommandsDto.Userinformationdetails>> GetAllUserinformationDetails()
        {
            return await _context.Userinformations.Select(x => new UserinformationCommandsDto.Userinformationdetails


            {
                UserinformationId = x.UserinformationId,
                Email= x.Email,
                Name = x.Name,
                PhoneNo = x.PhoneNo,

                IsDeleted = x.IsDeleted,

                DogDetails = x.Dogs.Select(x => new DogQuriesDto.DogDetails
                {
                    
                    DogId = x.DogId,
                    UserinformationId = x.UserinformationId.ToString(),
                    //RaceId = x.RaceId,
                    SubRaceId = x.SubRaceId,
                    Name=x.Name,
                    ChildAmount=x.ChildAmount,
                    IsDeleted=x.IsDeleted


                })
                .ToList()
                



            }).AsNoTracking()
                .ToListAsync();



        }
    }
}
