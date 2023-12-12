using MatingCalculator.Domain.Litter;
using MatingCalculator.Domain.Userinformation;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.Dog
{
    public class Dog : Entity<DogId>
    {
        public Guid DogId { get; private set; }

        public Guid UserinformationId { get; private set; }

        public Guid? HomeLitterId { get; private set; }

        // public Guid? MatingCalculationId { get; private set; }

        public Dog() { }

        //public RaceId RaceId { get; private set; }

        public SubRaceId SubRaceId { get; private set; }

        public ChildAmount ChildAmount { get; private set; }

        public Gender Gender { get; private set; }

        public Name Name { get; private set; }

        public IsDeleted IsDeleted { get; private set; }


        public Userinformation.Userinformation Userinformation { get; private set; }

        public HealthRecord.HealthRecord HealthRecord { get; }
        public Litter.Litter HomeLitter { get; private set; }
        public List<Parenting.Parenting> Parentings { get; }

        public List<DogMatingCalculation.DogMatingCalculation> DogMatingCalculations { get; }


        public Dog(DogId dogId
          // , RaceId raceId
           , SubRaceId subRaceId
            ,UserinformationId userinformationId
           // ,LitterId homeLitterId
           , ChildAmount childAmount
           , Name name
           , Gender gender
           , IsDeleted isDeleted
           )
        {
            //Childs = new List<Child.Child>();
            Parentings = new List<Parenting.Parenting>();
            Apply(new Events.DogEvents.CreateDog
            {
                DogId = dogId
               // ,RaceId=raceId
                ,SubRaceId = subRaceId
                ,UserinformationId=userinformationId
               // ,HomeLitterId=homeLitterId
                ,ChildAmount=childAmount
                ,Name = name
                ,Gender = gender
                ,IsDeleted = isDeleted
            });
        }

        public void UpdateDog(

            SubRaceId subRaceId
          // , RaceId raceId
            ,UserinformationId userinformationId
           // ,LitterId homelitterId
           , ChildAmount childAmount
           , Gender gender
            , Name name
            ,IsDeleted isDeleted

            )
        {
            Apply(new Events.DogEvents.UpdateDog
            {
                DogId = DogId
               // ,RaceId = raceId
                ,SubRaceId = subRaceId
                ,UserinformationId=userinformationId
              //  ,HomeLitterId=homelitterId
                ,ChildAmount = childAmount
                ,Name = name
                ,Gender = gender
                ,IsDeleted=isDeleted
                
            });
        }

        public void DeleteDog(IsDeleted isDeleted)
        {
            Apply(new Events.DogEvents.DeleteDog
            {
                DogId = DogId,
                IsDeleted = isDeleted
            });
        }
        public void AddDogToLitter(LitterId litterId)
        {
            Apply(new Events.DogEvents.AddDogToLitter
            {
                DogId = DogId,
                LitterId = litterId
            });
        }



        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.DogEvents.CreateDog e:

                    Id = new DogId(e.DogId);
                    //RaceId = new RaceId(e.RaceId.ToString());
                    SubRaceId = new SubRaceId(e.SubRaceId.ToString());
                    UserinformationId = new UserinformationId(e.UserinformationId);
                   // HomeLitterId = new LitterId(e.HomeLitterId);
                    ChildAmount = new ChildAmount(e.ChildAmount);
                    Gender = new Gender(e.Gender);
                    Name = new Name(e.Name);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    DogId = e.DogId;
                    break;

                case Events.DogEvents.UpdateDog e:
                    Id = new DogId(e.DogId);
                    SubRaceId = new SubRaceId(e.SubRaceId.ToString());
                    //RaceId = new RaceId(e.RaceId.ToString());
                    UserinformationId = new UserinformationId(e.UserinformationId);
                    //HomeLitterId = new LitterId(e.HomeLitterId);
                    ChildAmount = new ChildAmount(e.ChildAmount);
                    Gender = new Gender(e.Gender);
                    Name = new Name(e.Name);
                    
                    
                    break;

                case Events.DogEvents.DeleteDog e:
                    Id = new DogId(e.DogId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    DogId = e.DogId;
                    break;

                case Events.DogEvents.AddDogToLitter e:
                    Id = new DogId(e.DogId);
                    HomeLitterId = new LitterId(e.LitterId);

                    DogId = e.DogId;
                    break;

            }
        }
    }
}
