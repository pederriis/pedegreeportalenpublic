using HealthRecord.Domain.Animal;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthRecord.Domain.Events
{
    public class AnimalEvents
    {
        public class CreatedAnimal
        {
            public Guid AnimalId { get; set; }
            public string Name { get; set; }
            public string OwnerId { get; set; }
            public bool IsDeleted {get;set;}
        }

        public class UpdatedAnimal
        {
            public Guid AnimalId { get; set; }
            public string Name { get; set; }
            public string OwnerId { get; set; }
            public bool IsDeleted { get; set; }
        }


        public class DeletedAnimal
        {
            public Guid AnimalId { get; set; }
            //public string OwnerId { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}
