using System;
using System.Collections.Generic;
using System.Text;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Querys.ParrentQuerysDto;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Querys.HealthRecordQuerysDto;

namespace PedigreePortalen.Shared.KennelMicroserviceDto.Querys
{
    public class AnimalQuerysDto
    {
        public class AnimalDetails
        {
            public Guid AnimalId { get; set; }
            public Guid? ProtokolId { get; set; }
            public string SubRaceId { get; set; }
            public int RegNo { get; set; }
            public string PedigreeName { get; set; }
            public DateTime BirthDate { get; set; }
            public DateTime DeathDate { get; set; }
            public bool Gender { get; set; }
            public string Color { get; set; }
            public bool IsBreedable { get; set; }
            public bool IsDeleted { get; set; }

            public List<ParrentDetails> Parrents { get; set; }
            public HealthRecordDetails HealthRecord { get; set; }
        }
    }
}
