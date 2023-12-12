using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Queries
{
    public class CalculatedDiseaseQueriesDto
    {
        public class CalculatedDiseaseDetails
        {
            public Guid CalculatedDiseaseId { get; set; }

            public Guid MatingCalculationId { get; set; }

            public string Name { get; set; }
            public double Probability { get; set; }

            public bool IsDeleted { get; set; }
        }
    }
}
