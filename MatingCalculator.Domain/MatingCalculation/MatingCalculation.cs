using MatingCalculator.Domain.MatingRules;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.MatingCalculation
{
    public class MatingCalculation :AggregateRoot<MatingCalculationId>
    {
        public Guid MatingCalculationId { get; private set; }

        public Guid MatingRulesId { get; private set; }

        public MatingCalculation() { }

        public ExpectedChildren ExpectedChildren { get; private set; }
        public InbreedingPercent InbreedingPercent { get; private set; }
        public IsLegal IsLegal { get; private set; }
        public IsDeleted IsDeleted {get; private set;}
        public LitterAmount LitterAmount { get; private set; }

        //One to one
        public Contract.Contract Contract { get;  }

        public MatingRules.MatingRules MatingRules { get;  set; }

        public List<DogMatingCalculation.DogMatingCalculation> DogMatingCalculations { get; }
        public List<CalculatedDisease.CalculatedDisease> CalculatedDiseases { get; }


        public MatingCalculation(MatingCalculationId matingCalculationId
            ,MatingRulesId matingRulesId
            , ExpectedChildren expectedChildren
            , InbreedingPercent inbreedingPercent
            , IsLegal isLegal
            ,LitterAmount litterAmount
            , IsDeleted isDeleted

            )
        {
                DogMatingCalculations = new List<DogMatingCalculation.DogMatingCalculation>();
                CalculatedDiseases = new List<CalculatedDisease.CalculatedDisease>();


            Apply(new Events.MatingCalculationEvents.CreateMatingCalculation
            {
                MatingCalculationId = matingCalculationId,
                MatingRulesId=matingRulesId,
                ExpectedChildren = expectedChildren,
                InbreedingPercent = inbreedingPercent,
                IsLegal = isLegal,
                LitterAmount=litterAmount,
                IsDeleted=isDeleted
            });
        }

        public void UpdateMatingCalculation(
            MatingRulesId matingRulesId
             ,ExpectedChildren expectedChildren
            , InbreedingPercent inbreedingPercent
            , IsLegal isLegal
            ,LitterAmount litterAmount
            , IsDeleted isDeleted
            )
        {
            Apply(new Events.MatingCalculationEvents.UpdateMatingCalculation
            {
                MatingCalculationId = MatingCalculationId,
                MatingRulesId=matingRulesId,
                ExpectedChildren = expectedChildren,
                InbreedingPercent = inbreedingPercent,
                LitterAmount=litterAmount,
                IsLegal = isLegal
            });

        }
        public void DeleteMatingCalculation(IsDeleted isDeleted)
        {
            Apply(new Events.MatingCalculationEvents.DeleteMatingCalculation
            {
                MatingCalculationId = MatingCalculationId,
                IsDeleted = isDeleted
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.MatingCalculationEvents.CreateMatingCalculation e:
                    Id = new MatingCalculationId(e.MatingCalculationId);
                    MatingRulesId = new MatingRulesId(e.MatingRulesId);
                    ExpectedChildren = new ExpectedChildren(e.ExpectedChildren);
                    InbreedingPercent = new InbreedingPercent(e.InbreedingPercent);
                    IsLegal = new IsLegal(e.IsLegal);
                    LitterAmount = new LitterAmount(e.LitterAmount);
                    
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    MatingCalculationId = e.MatingCalculationId;
                    break;

                case Events.MatingCalculationEvents.UpdateMatingCalculation e:
                    MatingRulesId = new MatingRulesId(e.MatingRulesId);
                    ExpectedChildren = new ExpectedChildren(e.ExpectedChildren);
                    InbreedingPercent = new InbreedingPercent(e.InbreedingPercent);
                    IsLegal = new IsLegal(e.IsLegal);
                    LitterAmount = new LitterAmount(e.LitterAmount);

                    break;

                case Events.MatingCalculationEvents.DeleteMatingCalculation e:
                    Id = new MatingCalculationId(e.MatingCalculationId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    MatingCalculationId = e.MatingCalculationId;

                    break;
            }
        }

        protected override void EnsureValidState()
        {
            var valid = Id != null;
            if (!valid)
            {
                throw new DomainExceptions.InvalidEntityState(this, $"Post-checks failed.");
            }
        }
    }
}
