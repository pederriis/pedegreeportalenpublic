using System;
using System.Collections.Generic;
using System.Text;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Querys.AnimalQuerysDto;

namespace PedigreePortalen.Shared.KennelMicroserviceDto.Querys
{
    public class ProtokolQuerysDto
    {
        public class ProtokolDetails
        {
            public Guid? ProtokolId { get; set; }
            public Guid? KennelId { get; set; }
            public bool IsDeleted { get; set; }

            public List<AnimalDetails> Animals { get; set; }
        }
    }
}
