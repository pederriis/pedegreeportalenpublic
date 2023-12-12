using System;

namespace PedigreePortalen.Shared.AnimalMicroserviceDto.Querys
{
    public static class ExhibitionTitleQuerysDto
    {
        public class ExhibitionTitleDetails 
        {
            public Guid ExhibitionTitleId { get; set; }
            public Guid AnimalId { get; set; }
            public string Name { get; set; }
            public DateTime Date { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}
