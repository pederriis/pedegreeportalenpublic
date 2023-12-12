using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.AnimalMicroserviceDto.Commands
{
    public class ParentingCommandsDto
    {
        public static class V1
        {
            public class CreateParenting
            {
                public Guid ParentingId { get; set; }
                public Guid AnimalId { get; set; }
                public Guid LitterId { get; set; }
                public bool IsDeleted { get; set; } = false;
            }

            public class DeleteParenting
            {
                public Guid ParentingId { get; set; }
                public bool IsDeleted { get; set; } = true;
            }
        }
    }
}
