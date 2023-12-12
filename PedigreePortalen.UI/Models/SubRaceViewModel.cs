using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedigreePortalen.UI.Models
{
    public static class SubRaceViewModel
    {
        public class SubRaceDetails
        {
            public Guid SubRaceId { get; set; }
            public Guid RaceId { get; set; }
            public string SubRaceName { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}
