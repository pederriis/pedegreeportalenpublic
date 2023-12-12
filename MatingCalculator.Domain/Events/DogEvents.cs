using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.Events
{
    public class DogEvents
    {
        public class CreateDog
        {
            public Guid DogId { get; set; }

           // public string RaceId { get; set; }
            public string SubRaceId { get; set; }

            public Guid UserinformationId { get; set; }
            public Guid? HomeLitterId { get; set; }
            public int ChildAmount { get; set; }
            public string Name { get; set; }
            public bool Gender { get; set; }
            public bool IsDeleted { get; set; }
            
        }

        public class UpdateDog
        {
            public Guid DogId { get; set; }
            //public string RaceId { get; set; }
            public string SubRaceId { get; set; }
            public Guid UserinformationId { get; set; }
            public Guid HomeLitterId { get; set; }
            public int ChildAmount { get; set; }
            public string Name { get; set; }
            public bool Gender { get; set; }

            public bool IsDeleted { get; set; }
        }

        public class DeleteDog
        {
            public Guid DogId { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class AddDogToLitter
        {
            public Guid DogId { get; set; }
            public Guid LitterId { get; set; }
        }
    }
}
