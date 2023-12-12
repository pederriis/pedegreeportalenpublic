using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Queries
{
    public class ContractQueriesDto
    {
        public class ContractDetails
        {
            public Guid ContractId { get; set; }

            public DateTime CreationDate { get; set; }

            public DateTime MatingDate { get; set; }
            public string FemaleDogName { get; set; }

            public string MaleDogName { get; set; }

            public string FemaleDogOwnerName { get; set; }

            public string MaleDogOwnerName { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}
