using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.KennelMicroserviceDto.Commands
{
    public class ChildCommandsDto
    {
        public static class V1
        {
            public class CreateChild
            {
                public Guid ChildId { get; set; }
                public Guid AnimalId { get; set; }
                public Guid LitterId { get; set; }
                public bool IsDeleted { get; set; } = false;
            }

            public class DeleteChild
            {
                public Guid ChildId { get; set; }
                public bool IsDeleted { get; set; } = true;
            }

            public class AddChildToLitter
            {
                public Guid ChildId { get; set; }
                public Guid LitterId { get; set; }
            }
        }
    }
}
