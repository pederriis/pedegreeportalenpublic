using PedigreePortalen.Shared.HealthRecordMicroservice.Queries;
using PedigreePortalen.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedigreePortalen.UI.Mapper.HealthRecordMicroserviceMapper
{
    public class HealthRecordMapper
    {
        public static HealthRecordViewModel.HelthRecordDetails Map(HealthRecordQueriesDTO.HealthRecordDetails dto)
        {
            if (dto == null)
            { return null; }
            return new HealthRecordViewModel.HelthRecordDetails
            {
                HealthRecordId = dto.HealthRecordID,
                AnimalId=dto.AnimalId,
                IsDeleted = dto.IsDeleted

            };
        }

        public static IEnumerable<HealthRecordViewModel.HelthRecordDetails> Map(IEnumerable<HealthRecordQueriesDTO.HealthRecordDetails> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static IEnumerable<HealthRecordQueriesDTO.HealthRecordDetails> Map(IEnumerable<HealthRecordViewModel.HelthRecordDetails> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }

        public static HealthRecordQueriesDTO.HealthRecordDetails Map(HealthRecordViewModel.HelthRecordDetails model)
        {
            if (model == null)
            { return null; }
            return new HealthRecordQueriesDTO.HealthRecordDetails
            {
                HealthRecordID = model.HealthRecordId,
                AnimalId = model.AnimalId,
                IsDeleted = model.IsDeleted


            };
        }
    }
}

