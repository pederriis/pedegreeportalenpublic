using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.Events
{
    public class ContractEvents
    {
        public class CreateContract
        {
            public Guid ContractId { get; set; }
            public Guid MatingCalculationId { get; set; }
            public string MaleDogName { get; set; }
            public string FemaleDogName { get; set; }
            public string MaleDogOwnerName { get; set; }
            public string FemaleDogOwnerName { get; set; }
            public DateTime CreationDate { get; set; }
            public DateTime MatingDate { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class UpdateContract
        {
            public Guid ContractId { get; set; }
            public Guid MatingRulesID { get; set; }
            public string MaleDogName { get; set; }
            public string FemaleDogName { get; set; }
            public string MaleDogOwnerName { get; set; }
            public string FemaleDogOwnerName { get; set; }
            public DateTime CreationDate { get; set; }
            public DateTime MatingDate { get; set; }
        }

        public class DeleteContract
        {
            public Guid ContractId { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}
