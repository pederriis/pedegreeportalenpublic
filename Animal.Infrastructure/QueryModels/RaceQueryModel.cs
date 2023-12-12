using System;
using System.Collections.Generic;
using System.Text;

namespace Animal.Infrastructure.QueryModels
{
    public static class RaceQueryModel
    {
        public class GetRaceByRaceId
        {
            public Guid RaceId { get; set; }
        }
    }
}
