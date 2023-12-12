using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.Dog
{
    public class ChildAmount : Value<ChildAmount>
    {
        public int Value { get; internal set; }

        public ChildAmount(int value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements 
        protected ChildAmount() { }

        public static implicit operator int(ChildAmount childAmount) => childAmount.Value;

        public static ChildAmount FromInt(int value)
        {
            return new ChildAmount(Convert.ToInt32(value));
        }
    }
}
