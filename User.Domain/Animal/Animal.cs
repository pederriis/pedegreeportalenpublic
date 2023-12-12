using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using User.Domain.User;

namespace User.Domain.Animal
{
    public class Animal : Entity<AnimalId>
    {
        // Properties to handle the persistence
        public Guid AnimalId { get; private set; }
        public Guid UserId { get; set; }

        protected Animal() { }

        // Entity state properties
        public Name Name { get; private set; }
        public IsDeleted IsDeleted { get; set; }

        // Obj to handle the persistence
        public User.User User { get; private set; }

        public Animal(AnimalId animalId, Guid userId, Name name, IsDeleted isDeleted)
        {
            Apply(new Events.AnimalEvents.CreatedAnimal
            {
                AnimalId = animalId,
                UserId=userId,
                Name = name,
                IsDeleted = isDeleted
            });
        }

        public void UpdateAnimal(Name name, Guid userId, IsDeleted isDeleted)
        {
            Apply(new Events.AnimalEvents.UpdatedAnimal
            {
                AnimalId = AnimalId,
                UserID=userId,
                Name = name,
                IsDeleted = isDeleted
            });
        }

        public void DeletedAnimal(IsDeleted isDeleted)
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
                    UserId = new UserId(e.UserId);
                    Name = new Name(e.Name);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    AnimalId = e.AnimalId;
                    break;

                case Events.AnimalEvents.UpdatedAnimal e:

                    Id = new AnimalId(e.AnimalId);
                    UserId = new UserId(e.UserID);
                    Name = new Name(e.Name);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    AnimalId = e.AnimalId;
                    break;

                case Events.AnimalEvents.DeletedAnimal e:
                    Id = new AnimalId(e.AnimalId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    AnimalId = e.AnimalId;
                    break;
            }
        }
    }
}
