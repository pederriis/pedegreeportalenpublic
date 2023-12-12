using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.Events
{
    public class DiseaseEvents
    {
        public class CreateDisease
        {
            public Guid DiseaseId { get; set; }
            public Guid HealthRecordId { get; set; }
            public string Name { get; set; }
            public DateTime Date { get; set; }
            public string Note { get; set; }
            public bool IsHereditary { get; set; }

            public double Probability { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class UpdateDisease
        {
            public Guid DiseaseId { get; set; }
            public Guid HealthRecordId { get; set; }
            public string Name { get; set; }
            public DateTime Date { get; set; }
            public string Note { get; set; }
            public double Probability { get; set; }
            public bool IsHereditary { get; set; }
        }

        public class DeleteDisease
        {
            public Guid DiseaseId { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}
