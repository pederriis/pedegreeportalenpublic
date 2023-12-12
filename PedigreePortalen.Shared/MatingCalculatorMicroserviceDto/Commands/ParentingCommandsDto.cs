using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands
{
   public class ParentingCommandsDto
    {
        public static class V1
        {
            public class CreateParenting
            {
                public Guid ParentingId { get; set; }
                public Guid DogId { get; set; }
                public Guid LitterId { get; set; }

                public bool Gender { get; set; }
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
