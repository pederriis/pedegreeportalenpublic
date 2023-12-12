using System;
using System.Collections.Generic;
using System.Text;

namespace Animal.Infrastructure.QueryModels
{
    public static class HealthRecordQueryModel
    {
        public class GetHealthRecordByHealthRecordId
        {
            public Guid HealthRecordId { get; set; }
        }
    }
}
