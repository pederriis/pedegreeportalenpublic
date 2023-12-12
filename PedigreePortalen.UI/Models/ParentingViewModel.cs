using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedigreePortalen.UI.Models
{
    public static class ParentingViewModel
    {
        public class AddParentingToLitter
        {
            public Guid ParentingId { get; set; }
            public Guid AnimalId { get; set; }
            public Guid LitterId { get; set; }
            public bool IsDeleted { get; set; }

            public List<LitterViewModel.LitterDetails> Litters { get; set; }
        }

        public class ParentingDetails
        {
            public Guid ParentingId { get; set; }
            public Guid AnimalId { get; set; }
            public Guid? LitterId { get; set; }
            public bool IsDeleted { get; set; }

            public LitterViewModel.LitterDetails Litter { get; set; }
            public AnimalViewModel.DetailsAnimal Animal { get; set; }
        }

        public class CreateParenting
        {
            public Guid ParentingId { get; set; }
            public Guid AnimalId { get; set; }
            public Guid LitterId { get; set; }
            public bool IsDeleted { get; set; }

            public List<AnimalViewModel.DetailsAnimal> Animals { get; set; }
            public LitterViewModel.LitterDetails Litter { get; set; }
        }
    }
}
