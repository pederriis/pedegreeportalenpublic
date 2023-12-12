using System;
using System.Collections.Generic;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Querys.AnimalQuerysDto;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Querys.LitterQuerysDto;

namespace PedigreePortalen.Shared.AnimalMicroserviceDto.Querys
{
    public static class HumanQuerysDto
    {
        public class HumanDetails 
        {
            public Guid HumanId { get; set; }
            public bool IsDeleted { get; set; }

            // List
            public List<AnimalDetails> Animals { get; set; }
            public List<LitterDetails> Litters { get; set; }
        }
    }
}
