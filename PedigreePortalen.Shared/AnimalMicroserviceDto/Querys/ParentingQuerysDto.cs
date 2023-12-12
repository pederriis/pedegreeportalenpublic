using System;

namespace PedigreePortalen.Shared.AnimalMicroserviceDto.Querys
{
    public static class ParentingQuerysDto
    {
        public class ParentingDetails
        {
            public Guid ParentingId { get; set; }
            public Guid AnimalId { get; set; }
            public Guid? LitterId { get; set; }
            public bool IsDeleted { get; set; }

            public LitterQuerysDto.LitterDetails Litter { get; set; }
            public AnimalQuerysDto.AnimalDetails Animal { get; set; }
        }
    }
}
