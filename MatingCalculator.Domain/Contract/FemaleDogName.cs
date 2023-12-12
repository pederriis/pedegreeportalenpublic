using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.Contract
{
  public  class FemaleDogName : Value<FemaleDogName>
    {
        public string Value { get; internal set; }

        public FemaleDogName(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected FemaleDogName() { }

        public static implicit operator string(FemaleDogName femaleDogName) => femaleDogName.Value;

        public static FemaleDogName FromString(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value));

            return new FemaleDogName(value);
        }
    }
}
