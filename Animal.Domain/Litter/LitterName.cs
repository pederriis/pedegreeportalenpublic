using PedigreePortalen.Framework;
using System;

namespace Animal.Domain.Litter
{
    public class LitterName :Value<LitterName>
    {
        public string Value { get; internal set; }

        public LitterName(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected LitterName() { }

        public static implicit operator string(LitterName name) => name.Value;

        public static LitterName FromString(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value));

            return new LitterName(value);
        }
    }
}
