using System;
using System.Collections.Generic;
using System.Text;

namespace Animal.Infrastructure.QueryModels
{
    public class ParentingQueryModel
    {
        public class GetAnimalPedegreeByAnimalId
        {
            public Guid AnimalId { get; set; }
        }
    }
}
