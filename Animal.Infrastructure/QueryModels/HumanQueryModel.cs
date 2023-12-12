using System;
using System.Collections.Generic;
using System.Text;

namespace Animal.Infrastructure.QueryModels
{
    public static class HumanQueryModel
    {
        public class GetHumanByHumanId
        {
            public Guid HumanId { get; set; }
        }
    }
}
