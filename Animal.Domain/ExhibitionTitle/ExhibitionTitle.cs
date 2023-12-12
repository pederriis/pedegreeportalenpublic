using Animal.Domain.Animal;
using PedigreePortalen.Framework;
using System;

namespace Animal.Domain.ExhibitionTitle
{
    public class ExhibitionTitle :Entity<ExhibitionTitleId>
    {
        // Properties to handle the persistence
        public Guid ExhibitionTitleId { get; private set; }
        public Guid AnimalId { get; private set; }

        // Satisfy the serialization requirements
        protected ExhibitionTitle() { }

        // Entity state properties
        public Name Name { get; private set; }
        public Date Date { get; private set; }
        public IsDeleted  IsDeleted { get; private set; }

        // Obj to handle the persistence
        public Animal.Animal Animal { get; private set; }

        public ExhibitionTitle(ExhibitionTitleId exhibitionTitleId, AnimalId animalId, Name name, Date date, IsDeleted isDeleted)
        {
            Apply(new Events.ExhibitionTitleEvents.CreateExhibitionTitle
            {
                ExhibitionTitleId = exhibitionTitleId,
                AnimalId = animalId,
                Name = name,
                Date = date,
                IsDeleted = isDeleted
            });
        }

        public void UpdateExhibitionTitle(Name name, Date date)
        {
            Apply(new Events.ExhibitionTitleEvents.UpdateExhibitionTitle
            {
                ExhibitionTitleId = ExhibitionTitleId,
                Name = name,
                Date = date
            });
        }

        public void DeleteExhibitionTitle(IsDeleted isDeleted)
        {
            Apply(new Events.ExhibitionTitleEvents.DeleteExhibitionTitle
            {
                ExhibitionTitleId = ExhibitionTitleId,
                IsDeleted = isDeleted
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {

                case Events.ExhibitionTitleEvents.CreateExhibitionTitle e:

                    Id = new ExhibitionTitleId(e.ExhibitionTitleId);
                    AnimalId = new AnimalId(e.AnimalId);
                    Name = new Name(e.Name);
                    Date = new Date(e.Date);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    ExhibitionTitleId = e.ExhibitionTitleId;
                    break;

                case Events.ExhibitionTitleEvents.UpdateExhibitionTitle e:
                    Name = new Name(e.Name);
                    Date = new Date(e.Date);
                    break;

                case Events.ExhibitionTitleEvents.DeleteExhibitionTitle e:
                    Id = new ExhibitionTitleId(e.ExhibitionTitleId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    ExhibitionTitleId = e.ExhibitionTitleId;
                    break;
            }
        }
    }
}
