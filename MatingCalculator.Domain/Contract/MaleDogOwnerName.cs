using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.Contract
{
    public class MaleDogOwnerName : Value<MaleDogOwnerName>
    {
        public string Value { get; internal set; }

        public MaleDogOwnerName(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected MaleDogOwnerName() { }

        public static implicit operator string(MaleDogOwnerName maleDogOwnerName) => maleDogOwnerName.Value;

        public static MaleDogOwnerName FromString(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value));

            return new MaleDogOwnerName(value);
        }
    }
}
