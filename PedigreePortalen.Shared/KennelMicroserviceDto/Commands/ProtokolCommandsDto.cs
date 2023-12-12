using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.KennelMicroserviceDto.Commands
{
    public class ProtokolCommandsDto
    {
        public static class V1
        {
            public class CreateProtokol
            {
                public Guid ProtokolId { get; set; }
                public Guid KennelId { get; set; }
                public bool IsDeleted { get; set; } = false;
            }

            public class DeleteProtokol
            {
                public Guid ProtokolId { get; set; }
                public bool IsDeleted { get; set; } = true;
            }
        }
    }
}
