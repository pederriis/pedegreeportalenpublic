using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands
{
   public class ContractCommandsDto
    {
        public static class V1
        {
            public class CreateContract
            {
                public Guid ContractId { get; set; }

                public Guid MatingCalculationId { get; set; }
                public string MaleDogName { get; set; }
                public string FemaleDogName { get; set; }
                public string MaleDogOwnerName { get; set; }

                public string FemaleDogWOnerName { get; set; }

                public DateTime CreationDate { get; set; }

                public DateTime MatingDate { get; set; }
                public bool IsDeleted { get; set; } = false;
            }

            public class UpdateContract
            {
                public Guid ContractId { get; set; }
                public string MaleDogName { get; set; }
                public string FemaleDogName { get; set; }
                public string MaleDogOwnerName { get; set; }

                public string FemaleDogOwnerName { get; set; }

                public DateTime CreationDate { get; set; }

                public DateTime MatingDate { get; set; }

            }

            public class DeleteContract
            {
                public Guid ContracteId { get; set; }
                public bool IsDeleted { get; set; } = true;
            }

        }
    }
}
