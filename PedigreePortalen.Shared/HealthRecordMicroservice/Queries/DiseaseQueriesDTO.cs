using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.HealthRecordMicroservice.Queries
{
    public static class DiseaseQuerysDto
    {
        public class DiseaseDetails
        {
            public Guid DiseaseId { get; set; }

            public Guid HealthRecordId { get; set; }

            public string Name { get; set; }

            public DateTime Date { get; set; }

            public string Note { get; set; }
            public double Probabilty { get; set; }

            public bool IsHereditary { get; set; }

            public bool IsDeleted { get; set; }

            
        }
    }
}
