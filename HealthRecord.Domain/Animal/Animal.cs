using HealthRecord.Domain.HealthRecord;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;



namespace HealthRecord.Domain.Animal
{
    public class Animal : Entity<AnimalId>
    {
        // Properties to handle the persistence
        public Guid AnimalId { get; private set; }

        protected Animal() { }
        // Entity state properties
        public Name Name { get; private set; }

        public OwnerId OwnerId { get; private set; }

        public IsDeleted IsDeleted { get; private set; }
        public HealthRecord.HealthRecord HealthRecord { get; }

        public Animal(AnimalId animalId, Name name, string ownerId, IsDeleted isDeleted)
        {
            Apply(new Events.AnimalEvents.CreatedAnimal
            {
                AnimalId = animalId,
                Name = name,
                OwnerId = ownerId,
                IsDeleted=isDeleted


            });
        }

        public void UpdateAnimal( Name name, OwnerId ownerId, IsDeleted isDeleted)
        {
            Apply(new Events.AnimalEvents.UpdatedAnimal
            {

                AnimalId = AnimalId,
                Name = name,
                OwnerId = ownerId,
                IsDeleted = isDeleted
            }) ;
        }

        public void DeleteAnimal( IsDeleted isDeleted)
        {
            Apply(new Events.AnimalEvents.DeletedAnimal
            {
                AnimalId = AnimalId,
                IsDeleted = isDeleted
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.AnimalEvents.CreatedAnimal e:
                    Id = new AnimalId(e.AnimalId);
                    Name = new Name(e.Name);
                    OwnerId = new OwnerId(e.OwnerId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    AnimalId = e.AnimalId;
                    break;

                case Events.AnimalEvents.UpdatedAnimal e:
                    Name = new Name(e.Name);
                    OwnerId = new OwnerId(e.OwnerId);
                    IsDeleted = new IsDeleted(e.IsDeleted);
                    break;

                    
                case Events.AnimalEvents.DeletedAnimal e:
                    Id = new AnimalId(e.AnimalId);
                    IsDeleted = new IsDeleted(e.IsDeleted);
                   // OwnerId = new OwnerId(e.OwnerId);
                    AnimalId = e.AnimalId;
                    break;
                
            }
        }

       
    }
}
