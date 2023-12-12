using System;
using System.Collections.Generic;
using System.Text;

namespace Animal.Infrastructure.QueryModels
{
    public static class LitterQueryModel
    {
        public class GetLitterByLitterId
        {
            public Guid LitterId { get; set; }
        }

        public class GetLitterByOwnerId
        {
            public Guid BreedById { get; set; }
        }

        public class GetParentingsByLitterId
        {
            public Guid LitterId { get; set; }
        }

        public class GetLitterAnimalsByLitterId 
        {
            public Guid LitterId { get; set; }
        }

        public class GetAllParentingsByLitterId 
        {
            public Guid LitterId { get; set; }
        }
    }
}
