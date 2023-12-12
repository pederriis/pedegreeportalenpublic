using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Queries
{
    public class DiseaseQuriesDto
    {
        public class DiseaseDetails
        {
            public Guid DiseaseId { get; set; }

            public Guid HealthRecordId { get; set; }

            public DateTime Date { get; set; }

            public string Name { get; set; }

            public string Note { get; set; }

            public bool  IsHereditary { get; set; }

            public double Probability { get; set; }

            public bool IsDeleted { get; set; }
        }
    }
}
