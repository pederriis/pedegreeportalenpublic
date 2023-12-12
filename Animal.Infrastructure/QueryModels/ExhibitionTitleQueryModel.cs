using System;
using System.Collections.Generic;
using System.Text;

namespace Animal.Infrastructure.QueryModels
{
    public static class ExhibitionTitleQueryModel
    {
        public class GetExhibitionTitleByExhibitionTitleId
        {
            public Guid ExhibitionTitleId { get; set; }
        }
    }
}
