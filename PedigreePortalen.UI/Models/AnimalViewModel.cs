using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PedigreePortalen.UI.Models
{
    public static class AnimalViewModel
    {
        public class CreateAnimal
        {
            public Guid AnimalId { get; set; }
            public Guid OwnerId { get; set; }
            public Guid SubRaceId { get; set; }
            public Guid RaceId { get; set; }

            [Required(ErrorMessage = "Navn mangler.")]
            public int RegNo { get; set; }

            [Required(ErrorMessage = "Navn mangler.")]
            public string PedigreeName { get; set; }

            public string ShortName { get; set; }

            [Required(ErrorMessage = "Navn mangler.")]
            public DateTime BirthDate { get; set; }

            [Required(ErrorMessage = "Navn mangler.")]
            public DateTime DeathDate { get; set; }

            [Required(ErrorMessage = "Navn mangler.")]
            public bool Gender { get; set; }

            [Required(ErrorMessage = "Navn mangler.")]
            public string Color { get; set; }

            [Required(ErrorMessage = "Navn mangler.")]
            public double WeightInKg { get; set; }

            [Required(ErrorMessage = "Navn mangler.")]
            public bool IsBreedable { get; set; }

            [Required(ErrorMessage = "Navn mangler.")]
            public string ProfileText { get; set; }

            public List<RaceViewModel.RaceDetails> RaceDetails { get; set; }
            public List<SubRaceViewModel.SubRaceDetails> SubRaceDetails { get; set; }
        }

        public class DetailsAnimal
        {
            public Guid AnimalId { get; set; }
            public Guid OwnerId { get; set; }
            public Guid SubRaceId { get; set; }
            public int RegNo { get; set; }
            public string PedigreeName { get; set; }
            public string ShortName { get; set; }
            public DateTime BirthDate { get; set; }
            public DateTime DeathDate { get; set; }
            public bool Gender { get; set; }
            public string Color { get; set; }
            public double WeightInKg { get; set; }
            public bool IsBreedable { get; set; }
            public string ProfileText { get; set; }
            public bool IsDeleted { get; set; }

            public List<ParentingViewModel.ParentingDetails> Parentings { get; set; }
            public LitterViewModel.LitterDetails Litter { get; set; }
            //public List<ExhibitionTitleDetails> ExhibitionTitles { get; set; }
            //public HealthRecordDetails HealthRecord { get; set; }
        }

        public class DeleteAnimal
        {
            public Guid AnimalId { get; set; }
        }

        public class AddLitterToAnimal
        {
            public Guid AnimalId { get; set; }
            public Guid OwnerId { get; set; }
            public Guid SubRaceId { get; set; }
            public int RegNo { get; set; }
            public string PedigreeName { get; set; }
            public string ShortName { get; set; }
            public DateTime BirthDate { get; set; }
            public DateTime DeathDate { get; set; }
            public bool Gender { get; set; }
            public string Color { get; set; }
            public double WeightInKg { get; set; }
            public bool IsBreedable { get; set; }
            public string ProfileText { get; set; }
            public bool IsDeleted { get; set; }

            public Guid LitterId { get; set; }

            public List<LitterViewModel.LitterDetails> Litters { get; set; }
        }

        public class AddAnimalToLitter
        {
            public Guid AnimalId { get; set; }
            public Guid OwnerId { get; set; }
            public Guid SubRaceId { get; set; }
            public int RegNo { get; set; }
            public string PedigreeName { get; set; }
            public string ShortName { get; set; }
            public DateTime BirthDate { get; set; }
            public DateTime DeathDate { get; set; }
            public bool Gender { get; set; }
            public string Color { get; set; }
            public double WeightInKg { get; set; }
            public bool IsBreedable { get; set; }
            public string ProfileText { get; set; }
            public bool IsDeleted { get; set; }

            public Guid LitterId { get; set; }

            public List<DetailsAnimal> Animals { get; set; }
        }
    }
}
