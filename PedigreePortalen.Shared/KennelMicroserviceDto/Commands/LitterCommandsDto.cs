using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.KennelMicroserviceDto.Commands
{
    public class LitterCommandsDto
    {
        public static class V1
        {
            public class CreateLitter
            {
                public Guid LitterId { get; set; }
                public string LitterName { get; set; }
                public DateTime LitterBirthDate { get; set; }
                public bool IsDeleted { get; set; } = false;
            }

            public class UpdateLitter
            {
                public Guid LitterId { get; set; }
                public string LitterName { get; set; }
                public DateTime LitterBirthDate { get; set; }
            }

            public class DeleteLitter
            {
                public Guid LitterId { get; set; }
                public bool IsDeleted { get; set; } = true;
            }
        }
    }
}
