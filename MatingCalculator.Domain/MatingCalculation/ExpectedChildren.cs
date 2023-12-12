using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.MatingCalculation
{
    public class ExpectedChildren : Value<ExpectedChildren>
    {
        public int Value { get; internal set; }

        public ExpectedChildren(int value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements 
        protected ExpectedChildren() { }

        public static implicit operator int(ExpectedChildren expectedChildren) => expectedChildren.Value;

        public static ExpectedChildren FromInt(int value)
        {
            return new ExpectedChildren(Convert.ToInt32(value));
        }
    }
}
