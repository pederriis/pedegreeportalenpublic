using Animal.Domain.Human;
using Animal.Domain.Litter;
using Animal.Domain.SubRace;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;

namespace Animal.Domain.Animal
{
    public class Animal :AggregateRoot<AnimalId>
    {
        // Properties to handle the persistence
        public Guid AnimalId { get; private set; }
        public Guid OwnerId { get; private set; }
        public Guid SubRaceId { get; private set; }
        public Guid? LitterId { get; private set; }

        // Satisfy the serialization requirements
        protected Animal() { }

        // Aggregate state properties
        public RegNo RegNo { get; private set; }
        public PedigreeName PedigreeName { get; private set; }
        public ShortName ShortName { get; private set; }
        public BirthDate BirthDate { get; private set; }
        public DeathDate DeathDate { get; private set; }
        public Gender Gender { get; private set; }
        public Color Color { get; private set; }
        public WeightInKg WeightInKg { get; private set; }
        public IsBreedable IsBreedable { get; private set; }
        public ProfileText ProfileText { get; private set; }
        public IsDeleted IsDeleted { get; private set; }

        // Obj to handle the persistence
        public Human.Human Owner { get; private set; }
        public SubRace.SubRace SubRace { get; private set; }
        public Litter.Litter Litter { get; private set; }

        // one to one conn
        public HealthRecord.HealthRecord HealthRecord { get; }

        // List
        public List<ExhibitionTitle.ExhibitionTitle> ExhibitionTitles { get; }
        public List<Parenting.Parenting> Parentings { get; }
        
        public Animal(AnimalId animalId
            , HumanId ownerId
            , SubRaceId subRaceId
            , RegNo regNo
            , PedigreeName pedigreeName
            , ShortName shortName
            , BirthDate birthDate
            , DeathDate deathDate
            , Gender gender
            , Color color
            , WeightInKg weightInKg
            , IsBreedable isBreedable
            , ProfileText profileText
            , IsDeleted isDeleted
            )
        {
            ExhibitionTitles = new List<ExhibitionTitle.ExhibitionTitle>();
            Parentings = new List<Parenting.Parenting>();
            Apply(new Events.AnimalEvents.CreateAnimal
            {
                AnimalId = animalId,
                OwnerId = ownerId,
                SubRaceId = subRaceId,
                RegNo = regNo,
                PedigreeName = pedigreeName,
                ShortName = shortName,
                BirthDate = birthDate,
                DeathDate = deathDate,
                Gender = gender,
                Color = color,
                WeightInKg = weightInKg,
                IsBreedable = isBreedable,
                ProfileText = profileText,
                IsDeleted = isDeleted
            });
        }

        public void UpdateAnimal(
            HumanId humanId
            , RegNo regNo
            , PedigreeName pedigreeName
            , ShortName shortName
            , BirthDate birthDate
            , DeathDate deathDate
            , Gender gender
            , Color color
            , WeightInKg weightInKg
            , IsBreedable isBreedable
            , ProfileText profileText
            )
        {
            Apply(new Events.AnimalEvents.UpdateAnimal
            {
                AnimalId = AnimalId,
                HumanId = humanId,
                RegNo = regNo,
                PedigreeName = pedigreeName,
                ShortName = shortName,
                BirthDate = birthDate,
                DeathDate = deathDate,
                Gender = gender,
                Color = color,
                WeightInKg = weightInKg,
                IsBreedable = isBreedable,
                ProfileText = profileText
            });
        }

        public void DeleteAnimal(IsDeleted isDeleted)
        {
            Apply(new Events.AnimalEvents.DeleteAnimal
            {
                AnimalId = AnimalId,
                IsDeleted = isDeleted
            });
        }

        public void AddAnimalToLitter(LitterId litterId)
        {
            Apply(new Events.AnimalEvents.AddAnimalToLitter
            {
                AnimalId = AnimalId,
                LitterId = litterId
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.AnimalEvents.CreateAnimal e:
                    Id = new AnimalId(e.AnimalId);
                    OwnerId = new HumanId(e.OwnerId);
                    SubRaceId = new SubRaceId(e.SubRaceId);
                    RegNo = new RegNo(e.RegNo);
                    PedigreeName = new PedigreeName(e.PedigreeName);
                    ShortName = new ShortName(e.ShortName);
                    BirthDate = new BirthDate(e.BirthDate);
                    DeathDate = new DeathDate(e.DeathDate);
                    Gender = new Gender(e.Gender);
                    Color = new Color(e.Color);
                    WeightInKg = new WeightInKg(e.WeightInKg);
                    IsBreedable = new IsBreedable(e.IsBreedable);
                    ProfileText = new ProfileText(e.ProfileText);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    AnimalId = e.AnimalId;
                    break;

                case Events.AnimalEvents.UpdateAnimal e:
                    RegNo = new RegNo(e.RegNo);
                    PedigreeName = new PedigreeName(e.PedigreeName);
                    ShortName = new ShortName(e.ShortName);
                    BirthDate = new BirthDate(e.BirthDate);
                    DeathDate = new DeathDate(e.DeathDate);
                    Gender = new Gender(e.Gender);
                    Color = new Color(e.Color);
                    WeightInKg = new WeightInKg(e.WeightInKg);
                    IsBreedable = new IsBreedable(e.IsBreedable);
                    ProfileText = new ProfileText(e.ProfileText);
                    break;

                case Events.AnimalEvents.DeleteAnimal e:
                    Id = new AnimalId(e.AnimalId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    AnimalId = e.AnimalId;
                    break;

                case Events.AnimalEvents.AddAnimalToLitter e:
                    Id = new AnimalId(e.AnimalId);
                    LitterId = new LitterId(e.LitterId);

                    AnimalId = e.AnimalId;
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

