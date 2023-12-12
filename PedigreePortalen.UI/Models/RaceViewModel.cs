using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PedigreePortalen.UI.Models.SubRaceViewModel;

namespace PedigreePortalen.UI.Models
{
    public static class RaceViewModel
    {
        public class RaceDetails
        {
            public Guid RaceId { get; set; }
            public string RaceName { get; set; }
            public bool IsDeleted { get; set; }

            public List<SubRaceDetails> SubRaces { get; set; }
        }
    }
}
