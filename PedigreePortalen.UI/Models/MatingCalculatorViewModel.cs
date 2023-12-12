using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedigreePortalen.UI.Models
{
    public class MatingCalculatorViewModel
    {
        public class MatingCalculatorDetails
        {
            public Guid MatingCalculationid { get; set; }

            public double InbreedingPercent { get; set; }

            public bool IsLegal { get; set; }

            public int ExpectedChildren { get; set; }

            public int LitterAmount { get; set; }

            public bool IsDeleted { get; set; }

            public List<CalculatedDiseaseViewModel.CalculatedDiseaseDetails> CalculatedDiseaseDetails { get; set; }
        }

        public class MatingCalculatorCreate
        {
            public Guid MatingCalculationid { get; set; }

            public double InbreedingPercent { get; set; }

            public bool IsLegal { get; set; }

            public int ExpectedChildren { get; set; }

            public int LitterAmount { get; set; }

            public bool IsDeleted { get; set; }

            //public List<CalculatedDiseaseViewModel.CalculatedDiseaseDetails> CalculatedDiseaseDetails { get; set; }
        }
    }
}
