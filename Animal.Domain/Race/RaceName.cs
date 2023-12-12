using PedigreePortalen.Framework;
using System;

namespace Animal.Domain.Race
{
    public class RaceName :Value<RaceName>
    {
        public string Value { get; internal set; }

        public RaceName(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected RaceName() { }

        public static implicit operator string(RaceName raceName) => raceName.Value;

        public static RaceName FromString(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value));

            return new RaceName(value);
        }
    }
}
