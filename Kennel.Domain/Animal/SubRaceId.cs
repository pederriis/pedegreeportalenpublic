using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Animal
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
    }
}
