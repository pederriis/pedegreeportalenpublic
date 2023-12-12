using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.KennelMicroserviceDto.Querys
{
    public class DiseaseQuerysDto
    {
        public class DiseaseDetails
        {
            public Guid DiseaseId { get; set; }
            public Guid HealthRecordId { get; set; }
            public string DiseaseName { get; set; }
            public DateTime DiseaseDate { get; set; }
            public string DiseaseNote { get; set; }
            public bool IsHereditary { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}
