using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.KennelMicroserviceDto.Commands
{
    public class AnimalCommandsDto
    {
        public static class V1 
        {
            public class CreateAnimal
            {
                public Guid AnimalId { get; set; }
                public Guid? ProtokolId { get; set; }
                public string SubRaceId { get; set; }
                public int RegNo { get; set; }
                public string PedigreeName { get; set; }
                public DateTime BirthDate { get; set; }
                public DateTime DeathDate { get; set; }
                public bool Gender { get; set; }
                public string Color { get; set; }
                public bool IsBreedable { get; set; }
                public bool IsDeleted { get; set; } = false;
            }

            public class UpdateAnimal
            {
                public Guid AnimalId { get; set; }
                public int RegNo { get; set; }
                public string PedigreeName { get; set; }
                public DateTime BirthDate { get; set; }
                public DateTime DeathDate { get; set; }
                public bool Gender { get; set; }
                public string Color { get; set; }
                public bool IsBreedable { get; set; }
            }

            public class DeleteAnimal
            {
                public Guid AnimalId { get; set; }
                public bool IsDeleted { get; set; } = true;
            }

            public class AddAnimalToProtokol 
            {
                public Guid AnimalId { get; set; }
                public Guid ProtokolId { get; set; }
            }
        }
    }
}
