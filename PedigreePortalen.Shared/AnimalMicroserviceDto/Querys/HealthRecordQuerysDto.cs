using System;

namespace PedigreePortalen.Shared.AnimalMicroserviceDto.Querys
{
    public static class HealthRecordQuerysDto
    {
        public class HealthRecordDetails 
        {
            public Guid? HealthRecordId { get; set; }
            public Guid? AnimalId { get; set; }
            public bool IsDeleted { get; set; }
         
        }
    }
}
