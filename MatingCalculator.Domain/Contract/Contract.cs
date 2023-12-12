using MatingCalculator.Domain.MatingCalculation;
using MatingCalculator.Domain.MatingRules;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.Contract
{
    public class Contract: Entity<ContractId>
    {
        public Guid ContractId { get; private set; }
        public Guid MatingCalculationId { get; private set; }

        public MaleDogName MaleDogName { get; private set; }
        public FemaleDogName FemaleDogName { get; private set; }
        public MaleDogOwnerName MaleDogOwnerName { get; private set; }
        public FemaleDogOwnerName FemaleDogOwnerName { get; private set; }
        public CreationDate CreationDate { get; private set; }
        public MatingDate MatingDate { get; private set; }
        public IsDeleted IsDeleted { get; private set; }

        public Contract() { }

        public MatingCalculation.MatingCalculation MatingCalculation { get; set; }

        public List<ContractUserinformation.ContractUserinformation> ContractUserinformations { get;  }

        public Contract(ContractId contractId
            , MatingCalculationId matingCalculationId
            , MaleDogName maleDogName
            , FemaleDogName femaleDogName
            , MaleDogOwnerName maleDogOwnerName
            , FemaleDogOwnerName femaleDogOwnerName
            , CreationDate creationDate
            , MatingDate matingDate
            , IsDeleted isDeleted
            )
        {
            ContractUserinformations = new List<ContractUserinformation.ContractUserinformation>();
            
            Apply(new Events.ContractEvents.CreateContract
            {
                ContractId = contractId
                ,MatingCalculationId = matingCalculationId
                ,MaleDogName = maleDogName
                ,FemaleDogName = femaleDogName
                ,MaleDogOwnerName = maleDogOwnerName
                ,FemaleDogOwnerName = femaleDogOwnerName
                ,CreationDate = creationDate
                ,MatingDate = matingDate
                ,IsDeleted = isDeleted
            });
        }

        public void UpdateContract(
             MaleDogName maleDogName
            , FemaleDogName femaleDogName
            , MaleDogOwnerName maleDogOwnerName
            , FemaleDogOwnerName femaleDogOwnerName
            , CreationDate creationDate
            , MatingDate matingDate
            )
        {
            Apply(new Events.ContractEvents.UpdateContract
            {
                ContractId = ContractId
                ,MaleDogName = maleDogName
                ,FemaleDogName = femaleDogName
                ,MaleDogOwnerName = maleDogOwnerName
                ,FemaleDogOwnerName = femaleDogOwnerName
                ,CreationDate = creationDate
                , MatingDate = matingDate
               
            }) ;

        }
        public void DeleteContract(IsDeleted isDeleted)
        {
            Apply(new Events.ContractEvents.DeleteContract
            {
                ContractId = ContractId,
                IsDeleted = isDeleted
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.ContractEvents.CreateContract e:
                    Id = new ContractId(e.ContractId);
                    MatingCalculationId = new MatingCalculationId(e.MatingCalculationId);
                    MaleDogName = new MaleDogName(e.MaleDogName);
                    FemaleDogName = new FemaleDogName(e.FemaleDogName);
                    MaleDogOwnerName = new MaleDogOwnerName(e.MaleDogOwnerName);
                    FemaleDogOwnerName = new FemaleDogOwnerName(e.FemaleDogOwnerName);
                    CreationDate = new CreationDate(e.CreationDate);
                    MatingDate = new MatingDate(e.MatingDate);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    ContractId = e.ContractId;
                    break;

                case Events.ContractEvents.UpdateContract e:
                    MaleDogName = new MaleDogName(e.MaleDogName);
                    FemaleDogName = new FemaleDogName(e.FemaleDogName);
                    MaleDogOwnerName = new MaleDogOwnerName(e.MaleDogOwnerName);
                    FemaleDogOwnerName = new FemaleDogOwnerName(e.FemaleDogOwnerName);
                    CreationDate = new CreationDate(e.CreationDate);
                    MatingDate = new MatingDate(e.MatingDate);

                    break;

                case Events.ContractEvents.DeleteContract e:
                    Id = new ContractId(e.ContractId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    ContractId = e.ContractId;
                    break;
            }
        }
    }
}
