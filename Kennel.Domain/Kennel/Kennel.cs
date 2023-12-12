using Kennel.Domain.Owner;
using Kennel.Domain.Protokol;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Kennel
{
    public class Kennel : AggregateRoot<KennelId>
    {
        // Properties to handle the persistence
        public Guid KennelId { get; private set; }
        public Guid OwnerId { get; private set; }

        // Satisfy the serialization requirements
        public Kennel() { }

        // Aggregate state properties
        public KennelName KennelName { get; private set; }
        public KennelSmiley KennelSmiley { get; private set; }
        public IsDeleted IsDeleted { get; private set; }

        // one to one conn
        public Owner.Owner Owner { get; }
        public Protokol.Protokol Protokol { get; }

        public Kennel(KennelId kennelId, OwnerId ownerId, KennelName kennelName, KennelSmiley kennelSmiley, IsDeleted isDeleted)
        {
            //Owner = new Owner.Owner();

            Apply(new Events.KennelEvents.CreateKennel
            {
                KennelId = kennelId,
                OwnerId = ownerId,
                KennelName = kennelName,
                KennelSmiley = kennelSmiley,
                IsDeleted = isDeleted
            });
        }

        public void UpdateKennel(KennelName kennelName, KennelSmiley kennelSmiley)
        {
            Apply(new Events.KennelEvents.UpdateKennel
            {
                KennelId = KennelId,
                KennelName = kennelName,
                KennelSmiley = kennelSmiley
            });
        }

        public void DeleteKennel(IsDeleted isDeleted)
        {
            Apply(new Events.KennelEvents.DeleteKennel
            {
                KennelId = KennelId,
                IsDeleted = isDeleted
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.KennelEvents.CreateKennel e:
                    Id = new KennelId(e.KennelId);
                    OwnerId = new OwnerId(e.OwnerId);
                    KennelName = new KennelName(e.KennelName);
                    KennelSmiley = new KennelSmiley(e.KennelSmiley);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    KennelId = e.KennelId;
                    break;

                case Events.KennelEvents.UpdateKennel e:
                    KennelName = new KennelName(e.KennelName);
                    KennelSmiley = new KennelSmiley(e.KennelSmiley);                    
                    break;

                case Events.KennelEvents.DeleteKennel e:
                    Id = new KennelId(e.KennelId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    KennelId = e.KennelId;
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
