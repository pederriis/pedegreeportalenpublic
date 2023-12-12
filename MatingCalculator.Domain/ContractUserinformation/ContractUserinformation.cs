using MatingCalculator.Domain.Contract;
using MatingCalculator.Domain.Userinformation;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.ContractUserinformation
{
   public class ContractUserinformation : Entity<ContractUserinformationId>
    {
        // Properties to handle the persistence
        public Guid ContractUserinformationId { get; private set; }
        public Guid? ContractId { get; private set; }
        public Guid? UserinformationId { get; private set; }

        // Satisfy the serialization requirements
        protected ContractUserinformation() { }

        // Entity state properties
        public IsDeleted IsDeleted { get; private set; }

        // Obj to handle the persistence
        public Contract.Contract Contract { get; private set; }
        public Userinformation.Userinformation Userinformation { get; private set; }


        public ContractUserinformation(ContractUserinformationId contractUserinformationId, ContractId contractId, UserinformationId userinformationId, IsDeleted isDeleted)
        {
            Apply(new Events.ContractUserinformationEvents.CreateContractUserinformation
            {
                ContractUserinformationId = contractUserinformationId,
                ContractId = contractId,
                UserinformationId = userinformationId,
                IsDeleted = isDeleted
            });
        }

        public void DeleteContractUserinformation(Domain.ContractUserinformation.IsDeleted isDeleted)
        {
            Apply(new Events.ContractUserinformationEvents.DeleteContractUserinformation
            {
                ContractUserinformationId = ContractUserinformationId,
                IsDeleted = isDeleted
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.ContractUserinformationEvents.CreateContractUserinformation e:
                    Id = new ContractUserinformationId(e.ContractUserinformationId);
                    ContractId = new ContractId(e.ContractId);
                    UserinformationId = new UserinformationId(e.UserinformationId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    ContractUserinformationId = e.ContractUserinformationId;
                    break;

                case Events.ContractUserinformationEvents.DeleteContractUserinformation e:
                    Id = new ContractUserinformationId(e.ContractUserinformationId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    ContractUserinformationId = e.ContractUserinformationId;
                    break;
            }
        }
    }
}
