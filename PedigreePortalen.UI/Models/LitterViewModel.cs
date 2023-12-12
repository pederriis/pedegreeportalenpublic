using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedigreePortalen.UI.Models
{
    public static class LitterViewModel
    {
        public class CreateLitter
        {
            public Guid LitterId { get; set; }
            public Guid BreedById { get; set; }
            public string LitterName { get; set; }
            public DateTime LitterBirthDate { get; set; }
            public DateTime MatingDate { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class LitterDetails
        {
            public Guid? LitterId { get; set; }
            public Guid? BreedById { get; set; }
            public string? LitterName { get; set; }
            public DateTime? LitterBirthDate { get; set; }
            public DateTime? MatingDate { get; set; }
            public bool? IsDeleted { get; set; }

            // List
            public List<ParentingViewModel.ParentingDetails> Parentings { get; set; }
            public List<AnimalViewModel.DetailsAnimal> Animals { get; set; }
        }

        public class DeleteLitter
        {
            public Guid LitterId { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}
