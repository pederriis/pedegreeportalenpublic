using System;
using System.Collections.Generic;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Querys.AnimalQuerysDto;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Querys.ParentingQuerysDto;

namespace PedigreePortalen.Shared.AnimalMicroserviceDto.Querys
{
    public static class LitterQuerysDto
    {
        public class LitterDetails
        {
            public Guid? LitterId { get; set; }
            public Guid? BreedById { get; set; }
            public string? LitterName { get; set; }
            public DateTime? LitterBirthDate { get; set; }
            public DateTime? MatingDate { get; set; }
            public bool? IsDeleted { get; set; }

            // List
            public List<ParentingDetails> Parentings { get; set; }
            public List<AnimalDetails> Animals { get; set; }
        }
    }
}
