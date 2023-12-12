using System;
using System.Collections.Generic;
using System.Text;

namespace Animal.Infrastructure.QueryModels
{
    public static class SubRaceQueryModel
    {
        public class GetAllSubRaceByRaceId 
        {
            public Guid RaceId { get; set; }
        }
    }
}
