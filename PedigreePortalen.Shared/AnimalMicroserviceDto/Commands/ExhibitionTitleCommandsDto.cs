using System;

namespace PedigreePortalen.Shared.AnimalMicroserviceDto.Commands
{
    public class ExhibitionTitleCommandsDto
    {
        public static class V1
        {
            public class CreateExhibitionTitle
            {
                public Guid ExhibitionTitleId { get; set; }
                public Guid AnimalId { get; set; }
                public string Name { get; set; }
                public DateTime Date { get; set; }
                public bool IsDeleted { get; set; } = false;
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
                public bool IsDeleted { get; set; } = true;
            }
        }
    }
}
