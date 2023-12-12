using System;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Querys.ProtokolQuerysDto;

namespace PedigreePortalen.Shared.KennelMicroserviceDto.Querys
{
    public class KennelQuerysDto
    {
        public class KennelDetails
        {
            public Guid? KennelId { get; set; }
            public Guid? OwnerId { get; set; }
            public string KennelName { get; set; }
            public string KennelSmiley { get; set; }
            public bool? IsDeleted { get; set; }

            public ProtokolDetails Protokol { get; set; }
        }
    }
}
