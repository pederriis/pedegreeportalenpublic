using System;
using System.Collections.Generic;
using System.Text;
using static PedigreePortalen.Shared.HealthRecordMicroservice.Queries.DiseaseQuerysDto;

namespace PedigreePortalen.Shared.HealthRecordMicroservice.Queries
{
    public class HealthCertificateQueriesDTO
    {
        public class HealthCertificateDetails
        {
            public Guid HealthCertificateId { get; set; }

            public string Name { get; set; }

            public DateTime Date { get; set; }
            public string Note { get; set; }

            public bool IsDeleted { get; set; }

        }
    }
}
