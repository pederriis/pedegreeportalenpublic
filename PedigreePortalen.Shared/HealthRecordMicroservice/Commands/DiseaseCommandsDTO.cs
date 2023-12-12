using Animal.Domain.HealthRecord;
using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.HealthRecordMicroservice.Commands
{
    public class DiseaseCommandsDTO
    {
        public static class V1
        {
            public class CreateDisease
            {
                public Guid DiseaseId { get; set; }

                public Guid HealthRecordId { get; set; }

                public string Name { get; set; }

                public DateTime Date { get; set; }

                public string Note { get; set; } = "";

                public double Probabilty { get; set; }
                public bool IsHereditary { get; set; }

                public bool IsDeleted { get; set; } = false;

            }

            public class UpdateDisease
            {
                public Guid DiseaseId { get; set; }

                public string Name { get; set; }

                public DateTime Date { get; set; }

                public string Note { get; set; } = "";

                public double Probabilty { get; set; }
                public bool IsHereditary { get; set; }

                public bool IsDeleted { get; set; } = false;

            }

            public class DeleteDisease
            {
                public Guid DiseaseId { get; set; }

                public bool IsDeleted { get; set; } = true;
            }
        }
    }
}
