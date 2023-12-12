using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands
{
    public class LitterCommandsDto
    {
        public static class V1
        {
            public class CreateLitter
            {
                public Guid LitterId { get; set; }
                public string Name { get; set; }
                public DateTime Date { get; set; }
                public bool IsDeleted { get; set; } = false;
            }

            public class UpdateLitter
            {
                public Guid LitterId { get; set; }
                public string Name { get; set; }
                public DateTime Date { get; set; }
            }

            public class DeleteLitter
            {
                public Guid LitterId { get; set; }
                public bool IsDeleted { get; set; } = true;
            }
        }
    }
}
