using PedigreePortalen.Framework;
using System;

namespace Animal.Domain.SubRace
{
    public class SubRaceId :Value<SubRaceId>
    {
        public Guid Value { get; internal set; }

        protected SubRaceId() { }

        public SubRaceId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Character Id cannot be empty");

            Value = value;
        }

        public static implicit operator Guid(SubRaceId subRaceId) => subRaceId.Value;

        public static implicit operator SubRaceId(string value)
        {
            return new SubRaceId(Guid.Parse(value));
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
