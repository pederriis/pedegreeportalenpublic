using HealthRecord.Domain.HealthRecord;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthRecord.Domain.Events
{
    public class DiseaseEvents
    {

        public class CreatedDisease {
            public Guid DiseaseId { get; set; }

            public HealthRecordId HealthRecordId {get;set;}
            public string Name { get; set; }

            public DateTime Date { get; set; }

            public string Note { get; set; }

            public double Probability { get; set; }

            public bool IsHereditary  { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class UpdatedDisease
        {
            public Guid DiseaseId { get; set; }
            public string Name { get; set; }

            public DateTime Date { get; set; }

            public string Note { get; set; }

            public double Probability { get; set; }
            public bool IsHereditary { get; set; }
            public bool IsDeleted { get; set; }

        }
        public class DeletedDisease
        {
            public Guid DiseaseId { get; set; }
            public bool IsDeleted { get; set; }

        }
    }
}

