using HealthRecord.Domain.Animal;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthRecord.Domain.Events
{
   public class HealthRecordEvents
     
    {
        public class CreatedHealthRecord
        {
            public Guid HealthRecordId { get; set; }
            public Animal.Animal Animal { get;  set; }
            public IEnumerable<Disease.Disease> Diseases { get;  set; }
            public IEnumerable<HealthCertificate.HealthCertificate> HealthCertificates { get;  set; }
            public IEnumerable<Vaccination.Vaccination> Vaccinations { get;  set; }

            public Guid AnimalId { get; set; }
        }


        public class UpdatedHealthRecord
        {

            public Guid HealthRecordId { get; set; }
            public Animal.Animal Animal { get; set; }
            public IEnumerable<Disease.Disease> Diseases { get; set; }
            public IEnumerable<HealthCertificate.HealthCertificate> HealthCertificates { get; set; }
            public IEnumerable<Vaccination.Vaccination> Vaccinations { get; set; }



        }
    }

    

    
}
