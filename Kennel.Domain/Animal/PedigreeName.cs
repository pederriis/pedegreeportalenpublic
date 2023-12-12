using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Animal
{
    public class PedigreeName : Value<PedigreeName>
    {
        public string Value { get; internal set; }

        public PedigreeName(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected PedigreeName() { }

        public static implicit operator string(PedigreeName pedigreeName) => pedigreeName.Value;

        public static PedigreeName FromString(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value));

            return new PedigreeName(value);
        }
    }
}
