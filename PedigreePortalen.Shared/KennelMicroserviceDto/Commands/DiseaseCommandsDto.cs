using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.KennelMicroserviceDto.Commands
{
    public class DiseaseCommandsDto
    {
        public static class V1 
        {
            public class CreateDisease
            {
                public Guid DiseaseId { get; set; }
                public Guid HealthRecordId { get; set; }
                public string DiseaseName { get; set; }
                public DateTime DiseaseDate { get; set; }
                public string? DiseaseNote { get; set; }
                public bool IsHereditary { get; set; } = false;
                public bool IsDeleted { get; set; } = false;
            }

            public class UpdateDisease
            {
                public Guid DiseaseId { get; set; }
                public string DiseaseName { get; set; }
                public DateTime DiseaseDate { get; set; }
                public string? DiseaseNote { get; set; }
                public bool IsHereditary { get; set; }
            }

            public class DeleteDisease
            {
                public Guid DiseaseId { get; set; }
                public bool IsDeleted { get; set; } = true;
            }

        }
    }
}
