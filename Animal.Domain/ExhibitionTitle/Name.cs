using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Animal.Domain.ExhibitionTitle
{
    public class Name : Value<Name>
    {
        public string Value { get; internal set; }

        public Name(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected Name() { }

        public static implicit operator string(Name name) => name.Value;

        public static Name FromString(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value));

            return new Name(value);
        }
    }
}
