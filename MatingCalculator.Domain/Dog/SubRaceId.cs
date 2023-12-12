using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.Dog
{
    public class SubRaceId : Value<SubRaceId>
    {
        public string Value { get; internal set; }

        public SubRaceId(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected SubRaceId() { }

        public static implicit operator string(SubRaceId subRaceId) => subRaceId.Value;

        public static SubRaceId FromString(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value));

            return new SubRaceId(value);
        }
        //public SubRaceId(Guid value) => Value = value;

        //public Guid Value { get; internal set; }

        //protected SubRaceId() { }

        //public static implicit operator Guid(SubRaceId self) => self.Value;

        //public static implicit operator SubRaceId(string value) => new SubRaceId(Guid.Parse(value));

        //public override string ToString() => Value.ToString();


    }
}
