using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedigreePortalen.UI.Models
{
    public class CalculatedDiseaseViewModel
    {
        public class CalculatedDiseaseDetails
        {

            public Guid CalculatedDiseaseId { get; set; }

            public Guid MatingCalculationId { get; set; }


            public string Name { get; set; }

            public double Probabilaty { get; set; }

            public bool IsDeleted { get; set; }
        }
    }
}
