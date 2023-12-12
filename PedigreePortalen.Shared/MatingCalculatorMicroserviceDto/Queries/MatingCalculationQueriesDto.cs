using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Text;

namespace PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Queries
{
    public class MatingCalculationQueriesDto
    {
        public class MatingCalculationDetails
        {
            public Guid MatingCalculationId { get; set; }

            public int ExpectedChildren { get; set; }
            public double InbreedingPercent { get; set; }
            public bool IsLegal { get; set; }
            
            public int LitterAmount { get; set; }
            public bool IsDeleted { get; set; }

            public List<CalculatedDiseaseQueriesDto.CalculatedDiseaseDetails> CalculatedDiseaseDetails { get; set; }

        }

    }
}
