using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Events
{
    public class AnimalEvents
    {
        public class CreateAnimal
        {
            public Guid AnimalId { get; set; }
            public Guid ProtokolId { get; set; }
            public string SubRaceId { get; set; }
            public int RegNo { get; set; }
            public string PedigreeName { get; set; }
            public DateTime BirthDate { get; set; }
            public DateTime DeathDate { get; set; }
            public bool Gender { get; set; }
            public string Color { get; set; }
            public bool IsBreedable { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class UpdateAnimal
        {
            public Guid AnimalId { get; set; }
            public Guid ProtokolId { get; set; }
            public string SubRaceId { get; set; }
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
            public bool IsDeleted { get; set; }
        }

        public class AddAnimalToProtokol 
        {
            public Guid AnimalId { get; set; }
            public Guid ProtokolId { get; set; }
        }
    }
}
