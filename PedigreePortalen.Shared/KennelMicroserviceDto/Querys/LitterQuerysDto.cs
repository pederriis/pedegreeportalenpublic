using System;
using System.Collections.Generic;
using System.Text;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Querys.ParrentQuerysDto;

namespace PedigreePortalen.Shared.KennelMicroserviceDto.Querys
{
    public class LitterQuerysDto
    {
        public class LitterDetails
        {
            public Guid LitterId { get; set; }
            public string LitterName { get; set; }
            public DateTime LitterBirthDate { get; set; }
            public bool IsDeleted { get; set; }

            public List<ParrentDetails> Parrents { get; set; }
        }
    }
}
