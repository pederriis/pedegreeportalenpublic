using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.KennelMicroserviceDto.Commands
{
    public class ParrentCommandsDto
    {
        public static class V1
        {
            public class CreateParrent
            {
                public Guid ParrentId { get; set; }
                public Guid AnimalId { get; set; }
                public Guid LitterId { get; set; }
                public bool IsDeleted { get; set; } = false;
            }

            public class DeleteParrent
            {
                public Guid ParrentId { get; set; }
                public bool IsDeleted { get; set; } = true;
            }

            public class AddParrentToLitter
            {
                public Guid ParrentId { get; set; }
                public Guid LitterId { get; set; }
            }
        }
    }
}
