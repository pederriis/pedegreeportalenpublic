using PedigreePortalen.Framework;
using System;

namespace Animal.Domain.SubRace
{
    public class SubRaceName :Value<SubRaceName>
    {
        public string Value { get; internal set; }

        public SubRaceName(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected SubRaceName() { }

        public static implicit operator string(SubRaceName rubRaceName) => rubRaceName.Value;

        public static SubRaceName FromString(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value));

            return new SubRaceName(value);
        }
    }
}
