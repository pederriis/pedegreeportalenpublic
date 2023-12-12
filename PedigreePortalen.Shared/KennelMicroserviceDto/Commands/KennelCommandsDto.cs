using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.KennelMicroserviceDto.Commands
{
    public class KennelCommandsDto
    {
        public static class V1
        {
            public class CreateKennel
            {
                public Guid KennelId { get; set; }
                //public Guid ProtokolId { get; set; }
                public Guid OwnerId { get; set; }
                public string KennelName { get; set; }
                public string KennelSmiley { get; set; }
                public bool IsDeleted { get; set; } = false;
            }

            public class UpdateKennel
            {
                public Guid KennelId { get; set; }
                public string KennelName { get; set; }
                public string KennelSmiley { get; set; }
            }

            public class DeleteKennel
            {
                public Guid KennelId { get; set; }
                public bool IsDeleted { get; set; } = true;
            }
        }
    }
}
