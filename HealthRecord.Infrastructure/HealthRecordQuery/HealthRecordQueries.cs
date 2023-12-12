using HealthRecord.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.HealthRecordMicroservice.Queries.HealthRecordQueriesDTO;
using PedigreePortalen.Shared.HealthRecordMicroservice.Queries;
using System.Collections.Immutable;
using HealthRecord.Infrastructure.Mappers;

namespace HealthRecord.Infrastructure.HealthRecordQuery
{
    public class HealthRecordQueries
    {
        private readonly HealthRecordDbContext _context;

        public HealthRecordQueries(HealthRecordDbContext healthRecordDbContext)
        {
            _context = healthRecordDbContext;
        }
        public async Task<List<HealthRecordDetails>> GetAllHealRecordDetails()
        {
            var healthRecords = await _context.HealthRecord
                .Include(x=>x.Diseases)
                .Include(x=>x.HealthCertificates)
                .Include(x=>x.Vaccinations)

                .AsNoTracking()
                .ToListAsync();


            return HealthRecordMapper.HealthRecordDtoMapper.Map(healthRecords).ToList();
        }

        //public async Task <List<HealthRecordDetails>>GetAllHealRecordDetails()
        //{
        //    return await _context.HealthRecord.Select(x => new HealthRecordDetails


        //    {
        //        HealthRecordID = x.Id.Value,
        //        AnimalId = x.AnimalId,
        //        DiseaseDetails = x.Diseases.Select(x => new DiseaseQuerysDto.DiseaseDetails
        //        {
        //            DiseaseId = x.Id.Value,
        //            Date = x.Date,
        //            Name = x.Name,
        //            Note = x.Note,
        //            Probabilty = x.Probability,
        //            IsHereditary = x.IsHereditary


        //        }) .ToList(),

        //        VaccinationDetails = x.Vaccinations.Select(x => new VaccinationQuriesDto.VacciantionDetails
        //        {
        //            VaccinationId = x.Id.Value,
        //            Date = x.Date,
        //            Name = x.Name,



        //        }).ToList(),

        //        HealthCertificateDetails = x.HealthCertificates.Select(x => new HealthCertificateQueriesDTO.HealthCertificateDetails
        //        {
        //            HealthCertificateId = x.Id.Value,
        //            Date = x.Date,
        //            Note = x.Note,
        //            Name = x.Name,



        //        }).ToList(),



        //    }).AsNoTracking().ToListAsync();

        //}

        public async Task<HealthRecordDetails> GetSingleHealRecordDetails(Guid healthRecordId)
        {
            return await _context.HealthRecord.Select(x => new HealthRecordDetails


            {
                HealthRecordID = x.Id.Value,
                AnimalId=x.AnimalId,
                DiseaseDetails = x.Diseases.Select(x => new DiseaseQuerysDto.DiseaseDetails
                {
                    DiseaseId = x.Id.Value,
                    Date = x.Date,
                    Name = x.Name,
                    Note = x.Note,
                    Probabilty=x.Probability,
                    IsHereditary = x.IsHereditary


                }).ToList(),

                VaccinationDetails = x.Vaccinations.Select(x => new VaccinationQuriesDto.VacciantionDetails
                {
                    VaccinationId = x.Id.Value,
                    Date = x.Date,
                    Name = x.Name,



                }).ToList(),

                HealthCertificateDetails = x.HealthCertificates.Select(x => new HealthCertificateQueriesDTO.HealthCertificateDetails
                {
                    HealthCertificateId = x.Id.Value,
                    Date = x.Date,
                    Note = x.Note,
                    Name = x.Name,



                }).ToList(),

            }).AsNoTracking()
            .FirstOrDefaultAsync(x=>x.HealthRecordID==healthRecordId);

        }

        public async Task<HealthRecordDetails> GetSingleHealRecordDetailsFromAnimalId(Guid animalId)
        {
            return await _context.HealthRecord.Select(x => new HealthRecordDetails


            {
                HealthRecordID = x.Id.Value,
                AnimalId=x.AnimalId,
                DiseaseDetails = x.Diseases.Select(x => new DiseaseQuerysDto.DiseaseDetails
                {
                    DiseaseId = x.Id.Value,
                    Date = x.Date,
                    Name = x.Name,
                    Note = x.Note,
                    Probabilty = x.Probability,
                    IsHereditary = x.IsHereditary


                }).ToList(),

                VaccinationDetails = x.Vaccinations.Select(x => new VaccinationQuriesDto.VacciantionDetails
                {
                    VaccinationId = x.Id.Value,
                    Date = x.Date,
                    Name = x.Name,



                }).ToList(),

                HealthCertificateDetails = x.HealthCertificates.Select(x => new HealthCertificateQueriesDTO.HealthCertificateDetails
                {
                    HealthCertificateId = x.Id.Value,
                    Date = x.Date,
                    Note = x.Note,
                    Name = x.Name,



                }).ToList(),

            }).AsNoTracking()
            .FirstOrDefaultAsync(x => x.AnimalId == animalId);

        }
    }
}
