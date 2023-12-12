using MatingCalculator.Domain.MatingCalculation;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.MatingRules
{
    public class MatingRules:Entity<MatingRulesId>
    {
        public Guid MatingRulesId { get; private set; }

        public MatingRules() { }
        public InbreedingPercent InbreedingPercent { get; private set; }

        public LitterAmount LitterAmount { get; private set; }

        public IsDeleted IsDeleted { get; private set; }

        public List<MatingCalculation.MatingCalculation> MatingCalculations { get; }

        public MatingRules(

           MatingRulesId matingRulesId

           , InbreedingPercent inbreedingPercent
           , LitterAmount litterAmount
           , IsDeleted isDeleted
           )
        {
            MatingCalculations = new List<MatingCalculation.MatingCalculation>();

            Apply(new Events.MatingRulesEvents.CreateMatingRules
            {
                 MatingRulesId = matingRulesId
                ,InbreedingPercent=inbreedingPercent
                ,LitterAmount=litterAmount
                ,IsDeleted = isDeleted
            });
        }

        public void UpdateMatingRules(

           
            InbreedingPercent inbreedingPercent
           , LitterAmount litterAmount
            )
        {
            Apply(new Events.MatingRulesEvents.UpdateMatingRules
            {
               
                InbreedingPercent = inbreedingPercent
                ,LitterAmount = litterAmount
            });
        }

        public void DeleteDisease(IsDeleted isDeleted)
        {
            Apply(new Events.MatingRulesEvents.DeleteMatingRules
            {
                MatingRulesId = MatingRulesId,
                IsDeleted = isDeleted
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.MatingRulesEvents.CreateMatingRules e:
                    Id = new MatingRulesId(e.MatingRulesId);

                    MatingRulesId = new MatingRulesId(e.MatingRulesId);
                    InbreedingPercent = new InbreedingPercent(e.InbreedingPercent);
                    LitterAmount = new LitterAmount(e.LitterAmount);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    MatingRulesId = e.MatingRulesId;
                    break;

                case Events.MatingRulesEvents.UpdateMatingRules e:
                    InbreedingPercent = new InbreedingPercent(e.InbreedingPercent);
                    LitterAmount = new LitterAmount(e.LitterAmount);

                    break;
                case Events.MatingRulesEvents.DeleteMatingRules e:
                    Id = new MatingRulesId(e.MatingRulesId);

                    IsDeleted = new IsDeleted(e.IsDeleted);

                    MatingRulesId = e.MatingRulesId;
                    break;
            }
        }



    }
}
