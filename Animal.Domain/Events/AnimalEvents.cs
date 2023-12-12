using System;

namespace Animal.Domain.Events
{
    public class AnimalEvents
    {
        public class CreateAnimal
        {
            public Guid AnimalId { get; set; }
            public Guid OwnerId { get; set; }
            public Guid SubRaceId { get; set; }
            public Guid LitterId { get; set; }
            public int RegNo { get;  set; }
            public string PedigreeName { get;  set; }
            public string ShortName { get;  set; }
            public DateTime BirthDate { get;  set; }
            public DateTime DeathDate { get;  set; }
            public bool Gender { get;  set; }
            public string Color { get;  set; }
            public double WeightInKg { get;  set; }
            public bool IsBreedable { get;  set; }
            public string ProfileText { get;  set; }
            public bool IsDeleted { get;  set; }
        }

        public class UpdateAnimal
        {
            public Guid AnimalId { get; set; }
            public Guid HumanId { get; set; }
            public int RegNo { get;  set; }
            public string PedigreeName { get; set; }
            public string ShortName { get; set; }
            public DateTime BirthDate { get; set; }
            public DateTime DeathDate { get; set; }
            public bool Gender { get; set; }
            public string Color { get; set; }
            public double WeightInKg { get; set; }
            public bool IsBreedable { get; set; }
            public string ProfileText { get; set; }
        }

        public class DeleteAnimal
        {
            public Guid AnimalId { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class AddAnimalToLitter
        {
            public Guid AnimalId { get; set; }
            public Guid LitterId { get; set; }
        }
    }
}
