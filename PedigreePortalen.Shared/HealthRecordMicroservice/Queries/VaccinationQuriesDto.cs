using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.HealthRecordMicroservice.Queries
{
    public class VaccinationQuriesDto
    {
        public class VacciantionDetails
        {
            public Guid VaccinationId { get; set; }

            public string Name { get; set; }

            public DateTime Date { get; set; }

            public bool IsDeleted { get; set; }
        }
    }
}
