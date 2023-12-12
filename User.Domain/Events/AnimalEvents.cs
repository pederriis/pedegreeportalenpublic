using System;
using System.Collections.Generic;
using System.Text;

namespace User.Domain.Events
{
    public class AnimalEvents
    {
        public class CreatedAnimal
        {
            public Guid AnimalId { get; set; }

            public Guid UserId { get; set; }
            public string Name { get; set; }

            public bool IsDeleted { get; set; }
        }

        public class UpdatedAnimal
        {
            public Guid AnimalId { get; set; }

            public Guid UserID { get; set; }
            public string Name { get; set; }

            public bool IsDeleted { get; set; }

        }
        public class DeletedAnimal
        {
            public Guid AnimalId { get; set; }

            public bool IsDeleted { get; set; }
        }
    }
}
