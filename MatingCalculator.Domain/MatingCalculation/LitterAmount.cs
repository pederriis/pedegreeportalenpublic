using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.MatingCalculation
{
  public  class LitterAmount : Value<LitterAmount>
    {
        public int Value { get; internal set; }

        public LitterAmount(int value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements 
        protected LitterAmount() { }

        public static implicit operator int(LitterAmount litterAmount) => litterAmount.Value;

        public static LitterAmount FromInt(int value)
        {
            return new LitterAmount(Convert.ToInt32(value));
        }
    }
}
