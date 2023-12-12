using PedigreePortalen.Shared.HealthRecordMicroservice.Commands;
using PedigreePortalen.Shared.HealthRecordMicroservice.Queries;
using PedigreePortalen.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedigreePortalen.UI.Mapper.HealthRecordMicroserviceMapper
{
    

        public class DiseaseDetialsMapper
        {
            public static DiseaseViewModel.DiseaseDetails Map(DiseaseQuerysDto.DiseaseDetails dto)
            {
                if (dto == null)
                { return null; }
                return new DiseaseViewModel.DiseaseDetails
                {
                    DiseaseId = dto.DiseaseId,
                   HealthRecordId=dto.HealthRecordId,
                   Name = dto.Name,
                   Date =dto.Date,
                   Note=dto.Note,
                   Probabilty = dto.Probabilty,
                   IsHereditary=dto.IsHereditary,
                   IsDeleted = dto.IsDeleted

                };
            }

            public static IEnumerable<DiseaseViewModel.DiseaseDetails> Map(IEnumerable<DiseaseQuerysDto.DiseaseDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static IEnumerable<DiseaseQuerysDto.DiseaseDetails> Map(IEnumerable<DiseaseViewModel.DiseaseDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static DiseaseQuerysDto.DiseaseDetails Map(DiseaseViewModel.DiseaseDetails model)
            {
                if (model == null)
                { return null; }
                return new DiseaseQuerysDto.DiseaseDetails
                {
                    DiseaseId = model.DiseaseId,
                    HealthRecordId = model.HealthRecordId,
                    Name = model.Name,
                    Date = model.Date,
                    Note = model.Note,
                    Probabilty = model.Probabilty,
                    IsHereditary=model.IsHereditary,
                    IsDeleted = model.IsDeleted


                };
            }
        }


    public class DiseaseCreateMapper
    {
        public static DiseaseViewModel.CreateDisease Map(DiseaseCommandsDTO.V1.CreateDisease dto)
        {
            if (dto == null)
            { return null; }
            return new DiseaseViewModel.CreateDisease
            {
                DiseaseId = dto.DiseaseId,
                HealthRecordId = dto.HealthRecordId,
                Name = dto.Name,
                Date = dto.Date,
                Note = dto.Note,
                Probabilty = dto.Probabilty,
                IsHereditary=dto.IsHereditary,
                IsDeleted = dto.IsDeleted

            };
        }

        public static IEnumerable<DiseaseViewModel.CreateDisease> Map(IEnumerable<DiseaseCommandsDTO.V1.CreateDisease> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static IEnumerable<DiseaseCommandsDTO.V1.CreateDisease> Map(IEnumerable<DiseaseViewModel.CreateDisease> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static DiseaseCommandsDTO.V1.CreateDisease Map(DiseaseViewModel.CreateDisease model)
        {
            if (model == null)
            { return null; }
            return new DiseaseCommandsDTO.V1.CreateDisease
            {
                DiseaseId = model.DiseaseId,
                HealthRecordId = model.HealthRecordId,
                Name = model.Name,
                Date = model.Date,
                Note = model.Note,
                Probabilty = model.Probabilty,
                IsHereditary=model.IsHereditary,
                IsDeleted = model.IsDeleted


            };
        }
    }

}
