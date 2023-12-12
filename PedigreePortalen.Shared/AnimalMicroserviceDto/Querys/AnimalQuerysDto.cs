using System;
using System.Collections.Generic;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Querys.ParentingQuerysDto;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Querys.ExhibitionTitleQuerysDto;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Querys.HealthRecordQuerysDto;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Querys.LitterQuerysDto;

namespace PedigreePortalen.Shared.AnimalMicroserviceDto.Querys
{
    public static class AnimalQuerysDto
    {
        public class AnimalDetails
        {
            public Guid AnimalId { get; set; }
            public Guid OwnerId { get; set; }
            public Guid SubRaceId { get; set; }
            public Guid? LitterId { get; set; }
            public int RegNo { get; set; }
            public string PedigreeName { get; set; }
            public string ShortName { get; set; }
            public DateTime BirthDate { get; set; }
            public DateTime DeathDate { get; set; }
            public bool Gender { get; set; }
            public string Color { get; set; }
            public double WeightInKg { get; set; }
            public bool IsBreedable { get; set; }
            public string ProfileText { get; set; }
            public bool IsDeleted { get; set; }

            public LitterDetails Litter { get; set; }

            // List
            public List<ExhibitionTitleDetails> ExhibitionTitles { get; set; }
            public HealthRecordDetails HealthRecord { get; set; }
            public List<ParentingDetails> Parentings { get; set; }
        }
    }
}
