using System;
namespace PedigreePortalen.Shared.AnimalMicroserviceDto.Commands
{
    public class LitterCommandsDto
    {
        public static class V1
        {
            public class CreateLitter
            {
                public Guid LitterId { get; set; }
                public Guid BreedById { get; set; }
                public string LitterName { get; set; }
                public DateTime LitterBirthDate { get; set; }
                public DateTime MatingDate { get; set; }
                public bool IsDeleted { get; set; } = false;
            }

            public class UpdateLitter
            {
                public Guid LitterId { get; set; }
                public string LitterName { get; set; }
                public DateTime LitterBirthDate { get; set; }
                public DateTime MatingDate { get; set; }
            }

            public class DeleteLitter
            {
                public Guid LitterId { get; set; }
                public bool IsDeleted { get; set; } = true;
            }
        }
    }
}
