using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.UserMicroserviceDto.Commands
{
    public class AnimalCommandsDto
    {
        public static class V1
        {
            public class CreateAnimal
            {
                public Guid AnimalId { get; set; }
                public Guid UserId { get; set; }
                public string Name { get; set; }
                public bool IsDeleted { get; set; } = false;
            }

            public class UpdateAnimal
            {
                public Guid AnimalId { get; set; }
                public Guid UserId { get; set; }
                public string Name { get; set; }
                public bool IsDeleted { get; set; } = false;
            }

            public class DeleteAnimal
            {
                public Guid AnimalId { get; set; }
                public bool IsDeleted { get; set; } = false;
            }
        }
    }
}
