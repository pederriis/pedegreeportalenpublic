using PedigreePortalen.Framework;
using System;

namespace Animal.Domain.Race
{
    public class RaceId :Value<RaceId>
    {
        public Guid Value { get; internal set; }

        protected RaceId() { }

        public RaceId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Character Id cannot be empty");

            Value = value;
        }

        public static implicit operator Guid(RaceId raceId) => raceId.Value;

        public static implicit operator RaceId(string value)
        {
            return new RaceId(Guid.Parse(value));
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
