using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.HealthRecordMicroservice.Commands
{
   public class AnimalCommandsDTO
    {
        public static class V1
        {
            public class CreateAnimal
            {
                public Guid AnimalId { get; set; }

                public string Name { get; set; }

                public string OwnerId { get; set; }

                public bool IsDeleted { get; set; } = false;

            }

            public class UpdateAnimal
            {
                public Guid AnimalId { get; set; }

                public string Name { get; set; }

                public string OwnerId { get; set; }
                public bool IsDeleted { get; set; }
            }

            public class DeleteAnimal
            {
                public Guid AnimalId { get; set; }

              //  public string Name { get; set; }

                public bool IsDeleted { get; set; }
            }
        }
    }
}
