using MatingCalculator.Infrastructure.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Queries;
using Animal.Domain.SubRace;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace MatingCalculator.Infrastructure.Query
{
    public class DogQueries
    {
        private readonly MatingCalculatorDbContext _context;

        public DogQueries(MatingCalculatorDbContext matingCalculatorDbContext)
        {
            _context = matingCalculatorDbContext;
        }


        public async Task<List<DogQuriesDto.DogDetails>> GetAllDogDetails()
        {
            return await _context.Dogs.Select(x => new DogQuriesDto.DogDetails
            {
                DogId = x.DogId,
                Name = x.Name,
                SubRaceId = x.SubRaceId,
                UserinformationId=x.UserinformationId.ToString(),
                ChildAmount=x.ChildAmount,
                Gender=x.Gender,
                IsDeleted = x.IsDeleted,

                DiseaseDetails = x.HealthRecord.Diseases.Select(x => new DiseaseQuriesDto.DiseaseDetails
                {
                    DiseaseId = x.Id.Value,
                    HealthRecordId=x.HealthRecordId,
                    Date = x.Date,
                    Name = x.Name,
                    Note = x.Note,
                    IsHereditary = x.IsHereditary
                }).ToList(),
                
                HomeLitter =new LitterQuriesDto.LitterDetails
                {
                    LitterId = x.HomeLitter.LitterId,
                    Date = x.HomeLitter.Date,
                    Name = x.HomeLitter.Name,

                    ParentingDetails = x.HomeLitter.Parentings.Select(z=>new ParentingQuriesDto.ParentingDetails
                    {
                        ParentingId = z.Id.Value,
                        DogId = z.DogId,
                        LitterId = z.LitterId,
                        DogDetail=new DogQuriesDto.DogDetails
                        {
                            DogId = z.Dog.DogId,
                            Name = z.Dog.Name
                        }   
                    }).ToList(),
                },
              
                 ParentingDetails = x.Parentings.Select(x => new ParentingQuriesDto.ParentingDetails
                 {
                     ParentingId = x.Id.Value,
                     DogId = x.DogId,
                     LitterId = x.LitterId,
                   
                     LitterDetails= new LitterQuriesDto.LitterDetails
                     {
                         LitterId=x.Litter.LitterId,
                         Name=x.Litter.Name,

                         DogDetails=x.Litter.Dogs.Select(y=> new DogQuriesDto.DogDetails
                         { 
                         DogId=y.DogId,
                             Name = y.Name
                         
                         }).ToList()
                     }
                 }).ToList(),
            }).AsNoTracking()
              .ToListAsync();
        }

        public async Task<DogQuriesDto.DogDetails> GetSingleDogDetails(Guid dogId)
        {
            return await _context.Dogs.Select(x => new DogQuriesDto.DogDetails
            {
                DogId = x.DogId,
                HomelitterId=x.HomeLitterId,
                Name = x.Name,
                UserinformationId = x.UserinformationId.ToString(),
                IsDeleted = x.IsDeleted,

                DiseaseDetails = x.HealthRecord.Diseases.Select(x => new DiseaseQuriesDto.DiseaseDetails
                {
                    DiseaseId = x.Id.Value,
                    HealthRecordId = x.HealthRecordId,
                    Date = x.Date,
                    Name = x.Name,
                    Note = x.Note,
                    Probability = x.Probability,
                    IsHereditary = x.IsHereditary
                }).ToList(),

                HomeLitter=_context.Litters.Select(hl=>new LitterQuriesDto.LitterDetails
                {
                    LitterId=hl.LitterId,
                    Name=hl.Name,
                   Date=hl.Date,
                   IsDeleted=hl.IsDeleted,

                    ParentingDetails = hl.Parentings.Select(z => new ParentingQuriesDto.ParentingDetails
                    {
                        ParentingId = z.Id.Value,
                        DogId = z.DogId,
                        LitterId = z.LitterId,
                        
                        DogDetail = new DogQuriesDto.DogDetails
                        {
                            DogId = z.Dog.DogId,
                            Name = z.Dog.Name,
                            
                            DiseaseDetails = z.Dog.HealthRecord.Diseases.Select(y => new DiseaseQuriesDto.DiseaseDetails
                            {
                                DiseaseId = y.Id.Value,
                                Date = y.Date,
                                Name = y.Name,
                                Note = y.Note,
                                Probability = y.Probability,
                                IsHereditary = y.IsHereditary
                            }).ToList(),
                        }
                    }).ToList(),
                }
                ).Where(hl => hl.LitterId==x.HomeLitterId)
                .FirstOrDefault(),


              
            }).AsNoTracking()
            .FirstOrDefaultAsync(p => p.DogId == dogId);
        }

        public async Task<List<DogQuriesDto.DogDetails>> GetDogDetailsFromOwnerId(Guid ownerId)
        {
            return await _context.Dogs
                .AsNoTracking()
                .Where(x=>x.UserinformationId==ownerId)
                .Select(x => new DogQuriesDto.DogDetails


            {
                DogId = x.DogId,
                    Name = x.Name,
                Gender=x.Gender,
                UserinformationId=x.UserinformationId.ToString()
                
                   })
              .ToListAsync();

        }

        public async Task<List<DogQuriesDto.DogDetails>> GetAllDogDetailsForMatingCalculation()
        {
            return await _context.Dogs.Select(x => new DogQuriesDto.DogDetails
            {
                DogId = x.DogId,
                Name = x.Name,
                Gender = x.Gender
            }).AsNoTracking()
              .ToListAsync();
        }

       
    }
}
