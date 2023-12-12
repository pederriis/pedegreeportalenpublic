using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PedigreePortalen.UI.Models
{
    public class DiseaseViewModel
    {
        public class DiseaseDetails
        {

            public Guid DiseaseId { get; set; }
            public Guid HealthRecordId { get; set; }
            public string Name { get; set; }

            public DateTime Date { get; set; }

            public string Note { get; set; }

            public double Probabilty { get; set; }
            public bool IsHereditary { get; set; }

            public bool IsDeleted { get; set; }
        }

        public class CreateDisease
        {

            public Guid DiseaseId { get; set; }
            public Guid HealthRecordId { get; set; }

            [Required(ErrorMessage = "Navn mangler.")]
            public string Name { get; set; }

            public DateTime Date { get; set; }

            public string Note { get; set; }

            public double Probabilty { get; set; } = 100;
            public bool IsHereditary { get; set; }

            public bool IsDeleted { get; set; }
        }
    }
}
