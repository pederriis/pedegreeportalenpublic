using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands
{
    public class DogCommandsDto
    {
        public static class V1
        {
            public class CreateDog
            {
                public Guid DogId { get; set; }
                public string SubRaceId { get; set; }
                public Guid UserinformationId { get; set; }

              //  public Guid HomeLitterId { get; set; } 
                public int ChildAmount { get; set; }
                public bool Gender { get; set; }
                public string Name { get; set; } 
               
               
                public bool IsDeleted { get; set; } = false;
            }

            public class UpdateDog
            {
                public Guid DogId { get; set; }
                public string SubRaceId { get; set; }
                public Guid UserinformationId { get; set; }
                public Guid HomeLitterId { get; set; } 
                public int ChildAmount { get; set; }
                public bool Gender { get; set; }
                public string Name { get; set; }

                public bool IsDeleted { get; set; } = false;
            }

            public class DeleteDog
            {
                public Guid DogId { get; set; }
                public bool IsDeleted { get; set; } = true;
            }
            public class AddDogToLitter
            {
                public Guid DogId { get; set; }
                public Guid LitterId { get; set; }
            }

        }
    }
}
