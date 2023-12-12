using System;

namespace Animal.Domain.Events
{
    public class ExhibitionTitleEvents
    {
        public class CreateExhibitionTitle
        {
            public Guid ExhibitionTitleId { get; set; }
            public Guid AnimalId { get; set; }
            public string Name { get;  set; }
            public DateTime Date { get;  set; }
            public bool IsDeleted { get; set; }
        }

        public class UpdateExhibitionTitle
        {
            public Guid ExhibitionTitleId { get; set; }
            public string Name { get; set; }
            public DateTime Date { get; set; }
        }

        public class DeleteExhibitionTitle
        {
            public Guid ExhibitionTitleId { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}
