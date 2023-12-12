using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands
{
    public class ChildCommandsDto
    {
        public static class V1
        {
            public class CreateChild
            {
                public Guid ChildId { get; set; }
                public Guid DogId { get; set; }
                public Guid LitterId { get; set; }
                public bool IsDeleted { get; set; } = false;
            }

            public class DeleteChild
            {
                public Guid ChildId { get; set; }
                public bool IsDeleted { get; set; } = true;
            }
        }
    }
}
