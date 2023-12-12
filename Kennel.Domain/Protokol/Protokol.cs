using Kennel.Domain.Kennel;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Protokol
{
    public class Protokol : Entity<ProtokolId>
    {
        public Guid ProtokolId { get; private set; }
        public Guid KennelId { get; private set; }

        // Satisfy the serialization requirements
        public Protokol() { }

        // Aggregate state properties
        public IsDeleted IsDeleted { get; set; }

        // one to one conn
        public Kennel.Kennel Kennel { get; }

        // List
        public List<Animal.Animal> Animals { get; }
        

        public Protokol(ProtokolId protokolId, KennelId kennelId, IsDeleted isDeleted)
        {
            Animals = new List<Animal.Animal>();
            Apply(new Events.ProtokolEvents.CreateProtokol
            {
                ProtokolId = protokolId,
                KennelId = kennelId,
                IsDeleted = isDeleted
            });
        }

        public void DeleteProtokol(IsDeleted isDeleted)
        {
            Apply(new Events.ProtokolEvents.DeleteProtokol
            {
                ProtokolId = ProtokolId,
                IsDeleted = isDeleted
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.ProtokolEvents.CreateProtokol e:
                    Id = new ProtokolId(e.ProtokolId);
                    KennelId = new KennelId(e.KennelId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    ProtokolId = e.ProtokolId;
                    break;

                case Events.ProtokolEvents.DeleteProtokol e:
                    Id = new ProtokolId(e.ProtokolId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    ProtokolId = e.ProtokolId;
                    break;
            }
        }
    }
}
