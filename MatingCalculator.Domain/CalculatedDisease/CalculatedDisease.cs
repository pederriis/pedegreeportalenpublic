using MatingCalculator.Domain.MatingCalculation;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.CalculatedDisease
{
   public class CalculatedDisease : Entity<CalculatedDiseaseId>
    {

        public Guid CalculatedDiseaseId { get; private set; }
        public Guid MatingCalculationId { get; set; }

        public CalculatedDisease() { }



        public Name Name { get; private set; }

        public Probability Probability { get; set; }

        public IsDeleted IsDeleted { get; private set; }


        public MatingCalculation.MatingCalculation MatingCalculation { get; private set; }

        public CalculatedDisease(
            CalculatedDiseaseId calculatedDiseaseId
           , MatingCalculationId matingCalculationId
           , Name name
           , Probability probability
           , IsDeleted isDeleted
           )
        {
            Apply(new Events.CalculatedDiseaseEvents.CreateCalculatedDisease
            {
               CalculatedDiseaseId = calculatedDiseaseId,
                MatingCalculationId = matingCalculationId,
                Name = name,
                Probability = probability,
                IsDeleted = isDeleted

            });
        }

        public void UpdateCalculatedDisease(
            Name name
            , Probability probability

            )
        {
            Apply(new Events.CalculatedDiseaseEvents.UpdateCalculatedDisease
            {
                CalculatedDiseaseId = CalculatedDiseaseId,
                Name = name,
                Probability = probability,

            });
        }

        public void DeleteCalculatedDisease(IsDeleted isDeleted)
        {
            Apply(new Events.CalculatedDiseaseEvents.DeleteCalculatedDisease
            {
                CalculatedDiseaseId = CalculatedDiseaseId,
                IsDeleted = isDeleted
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.CalculatedDiseaseEvents.CreateCalculatedDisease e:
                    Id = new CalculatedDiseaseId(e.CalculatedDiseaseId);
                    MatingCalculationId = new MatingCalculationId(e.MatingCalculationId);
                    Name = new Name(e.Name);
                    Probability = new Probability(e.Probability);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    CalculatedDiseaseId = e.CalculatedDiseaseId;
                    break;

                case Events.CalculatedDiseaseEvents.UpdateCalculatedDisease e:
                    Name = new Name(e.Name);
                    Probability = new Probability(e.Probability);

                    break;
                case Events.CalculatedDiseaseEvents.DeleteCalculatedDisease e:
                    Id = new CalculatedDiseaseId(e.CalculatedDiseaseId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    CalculatedDiseaseId = e.CalculatedDiseaseId;
                    break;
            }
        }


    }
}
