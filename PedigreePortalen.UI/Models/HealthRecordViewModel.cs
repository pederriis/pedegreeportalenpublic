using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedigreePortalen.UI.Models
{
    public class HealthRecordViewModel
    {
        public class HelthRecordDetails
        {
            public Guid HealthRecordId { get; set; }

            public Guid AnimalId { get; set; }

            public bool IsDeleted { get; set; }

            public List<DiseaseViewModel.DiseaseDetails> Diseases { get; set; }
        }
    }
}
