using PedigreePortalen.Framework;
using System;

namespace Animal.Domain.Animal
{
    public class RegNo :Value<RegNo>
    {
        public int Value { get; internal set; }

        public RegNo(int value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements 
        protected RegNo() { }

        public static implicit operator int(RegNo regNo) => regNo.Value;

        public static RegNo FromInt(int value)
        {
            return new RegNo(Convert.ToInt32(value));
        }
    }
}
