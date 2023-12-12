using Kennel.Domain.Protokol;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Animal
{
    public class Animal : Entity<AnimalId>
    {
        // Properties to handle the persistence
        public Guid AnimalId { get; private set; }
        public Guid? ProtokolId { get; private set; }
        
        // Satisfy the serialization requirements
        protected Animal() { }

        // Aggregate state properties
        public SubRaceId SubRaceId {get; private set;}
        public RegNo RegNo { get; private set; }
        public PedigreeName PedigreeName { get; private set; }
        public BirthDate BirthDate { get; private set; }
        public DeathDate DeathDate { get; private set; }
        public Gender Gender { get; private set; }
        public Color Color { get; private set; }
        public IsBreedable IsBreedable { get; private set; }
        public IsDeleted IsDeleted { get; private set; }

        // Obj to handle the persistence
        public Protokol.Protokol Protokol { get; set; }
        // one to one conn
        public HealthRecord.HealthRecord HealthRecord { get; }

        // List
        public List<Parrent.Parrent> Parrents { get; }
        public List<Child.Child> Children { get; }

        public Animal(AnimalId animalId
            , SubRaceId subRaceId
            , RegNo regNo
            , PedigreeName pedigreeName
            , BirthDate birthDate
            , DeathDate deathDate
            , Gender gender
            , Color color
            , IsBreedable isBreedable
            , IsDeleted isDeleted
            )
        {
            Parrents = new List<Parrent.Parrent>();
            Children = new List<Child.Child>();
            Apply(new Events.AnimalEvents.CreateAnimal
            {
                AnimalId = animalId,
                SubRaceId = subRaceId,
                RegNo = regNo,
                PedigreeName = pedigreeName,
                BirthDate = birthDate,
                DeathDate = deathDate,
                Gender = gender,
                Color = color,
                IsBreedable = isBreedable,
                IsDeleted = isDeleted
            });
        }

        public void UpdateAnimal(
              RegNo regNo
            , PedigreeName pedigreeName
            , BirthDate birthDate
            , DeathDate deathDate
            , Gender gender
            , Color color
            , IsBreedable isBreedable
            )
        {
            Apply(new Events.AnimalEvents.UpdateAnimal
            {
                AnimalId = AnimalId,
                RegNo = regNo,
                PedigreeName = pedigreeName,
                BirthDate = birthDate,
                DeathDate = deathDate,
                Gender = gender,
                Color = color,
                IsBreedable = isBreedable,
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

        public void AddAnimalToProtokol(ProtokolId protokolId) 
        {
            Apply(new Events.AnimalEvents.AddAnimalToProtokol
            {
                AnimalId = AnimalId,
                ProtokolId = protokolId
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.AnimalEvents.CreateAnimal e:
                    Id = new AnimalId(e.AnimalId);
                    SubRaceId = new SubRaceId(e.SubRaceId);
                    RegNo = new RegNo(e.RegNo);
                    PedigreeName = new PedigreeName(e.PedigreeName);
                    BirthDate = new BirthDate(e.BirthDate);
                    DeathDate = new DeathDate(e.DeathDate);
                    Gender = new Gender(e.Gender);
                    Color = new Color(e.Color);
                    IsBreedable = new IsBreedable(e.IsBreedable);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    AnimalId = e.AnimalId;
                    break;

                case Events.AnimalEvents.UpdateAnimal e:
                    RegNo = new RegNo(e.RegNo);
                    PedigreeName = new PedigreeName(e.PedigreeName);
                    BirthDate = new BirthDate(e.BirthDate);
                    DeathDate = new DeathDate(e.DeathDate);
                    Gender = new Gender(e.Gender);
                    Color = new Color(e.Color);
                    IsBreedable = new IsBreedable(e.IsBreedable);

                    break;

                case Events.AnimalEvents.DeleteAnimal e:
                    Id = new AnimalId(e.AnimalId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    AnimalId = e.AnimalId;
                    break;

                case Events.AnimalEvents.AddAnimalToProtokol e:
                    ProtokolId = new ProtokolId(e.ProtokolId);
                    break;
            }
        }
    }
}
