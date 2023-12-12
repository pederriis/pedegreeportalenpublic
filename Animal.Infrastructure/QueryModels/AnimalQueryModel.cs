using System;
using System.Collections.Generic;
using System.Text;

namespace Animal.Infrastructure.QueryModels
{
    public static class AnimalQueryModel
    {
        public class GetAnimalByAnimalId
        {
            public Guid AnimalId { get; set; }
        }

        public class GetAllAnimalByOwnerId
        {
            public Guid OwnerId { get; set; }
        }

        public class GetAllAnimalByLitterId
        {
            public Guid LitterId { get; set; }
        }
    }
}
