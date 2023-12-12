using PedigreePortalen.Shared.HealthRecordMicroservice.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthRecord.Infrastructure.Mappers
{
  
    public static class HealthCertificateMapper
    {
        public class HealthCertificateDtoMapper
        {
            public static HealthCertificateQueriesDTO.HealthCertificateDetails Map(Domain.HealthCertificate.HealthCertificate dto)
            {
                if (dto == null)
                { return null; }
                return new HealthCertificateQueriesDTO.HealthCertificateDetails
                {
                   HealthCertificateId=dto.HealthCertificateId,
                   Name=dto.Name,
                   Date=dto.Date,
                   IsDeleted=dto.IsDeleted
                };
            }

            public static IEnumerable<HealthCertificateQueriesDTO.HealthCertificateDetails> Map(IEnumerable<Domain.HealthCertificate.HealthCertificate> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

        }
    }
}


