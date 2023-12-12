using System;
using System.Collections.Generic;
using System.Text;


namespace PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Queries
{
    public class DogQuriesDto
    {
        public class DogDetails
        {
            public Guid DogId { get; set; }
            public Guid? HomelitterId { get; set; }
            public string SubRaceId { get; set; }
            public string UserinformationId { get; set; }
            public string Name { get; set; }
            public bool Gender { get; set; }
            public int ChildAmount { get; set; }
            public bool IsDeleted { get; set; }

            public LitterQuriesDto.LitterDetails HomeLitter { get; set; }
            public List<DiseaseQuriesDto.DiseaseDetails> DiseaseDetails { get; set; }
           public HealthRecordQuriesDto.HealthRecordDetails HealthRecord { get; set; }
            public List<ParentingQuriesDto.ParentingDetails> ParentingDetails { get; set; }

            public DogDetails MotherDog { get; set; }
            public DogDetails FatherDog { get; set; }
        }

        public class FamilyTreeDetails
        {
            public Guid Dog0Id { get; set; }
            public string Dog0Name { get; set; }

           

            public DogDetails ThisDog { get; set; }

            public DogDetails m1Dog { get; set; }
            public DogDetails f1Dog { get; set; }
            public DogDetails mm2Dog { get; set; }
            public DogDetails mf2Dog { get; set; }
            public DogDetails fm2Dog { get; set; }
            public DogDetails ff2Dog { get; set; }
        }
     
    }
}
