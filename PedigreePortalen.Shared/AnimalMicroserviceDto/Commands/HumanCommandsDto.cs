using System;

namespace PedigreePortalen.Shared.AnimalMicroserviceDto.Commands
{
    public class HumanCommandsDto
    {
        public static class V1
        {
            public class CreateHuman
            {
                public Guid HumanId { get; set; }
                public bool IsDeleted { get; set; } = false;
            }

            public class DeleteHuman
            {
                public Guid HumanId { get; set; }
                public bool IsDeleted { get; set; } = true;
            }
        }
    }
}
