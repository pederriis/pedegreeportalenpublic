using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.Contract
{
    public class MaleDogName : Value<MaleDogName>
    {
        public string Value { get; internal set; }

        public MaleDogName(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected MaleDogName() { }

        public static implicit operator string(MaleDogName maleDogName) => maleDogName.Value;

        public static MaleDogName FromString(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value));

            return new MaleDogName(value);
        }
    }
}
