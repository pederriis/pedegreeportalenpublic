using PedigreePortalen.Framework;
using System;

namespace Animal.Domain.Animal
{
    public class ShortName :Value<ShortName>
    {
        public string Value { get; internal set; }

        public ShortName(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected ShortName() { }

        public static implicit operator string(ShortName shortName) => shortName.Value;

        public static ShortName FromString(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value));

            return new ShortName(value);
        }
    }
}
