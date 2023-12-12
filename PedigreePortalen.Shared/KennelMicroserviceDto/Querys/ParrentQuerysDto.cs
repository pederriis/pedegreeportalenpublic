using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.KennelMicroserviceDto.Querys
{
    public static class ParrentQuerysDto
    {
        public class ParrentDetails
        {
            public Guid ParrentId { get; set; }
            public Guid? AnimalId { get; set; }
            public Guid? LitterId { get; set; }

            public bool IsDeleted { get; set; }
        }
    }
}
