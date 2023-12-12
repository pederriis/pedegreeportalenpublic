using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.Contract
{
    public class FemaleDogOwnerName : Value<FemaleDogOwnerName>
    {
        public string Value { get; internal set; }

        public FemaleDogOwnerName(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected FemaleDogOwnerName() { }

        public static implicit operator string(FemaleDogOwnerName femaleDogOwnerName) => femaleDogOwnerName.Value;

        public static FemaleDogOwnerName FromString(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value));

            return new FemaleDogOwnerName(value);
        }
    }
}
