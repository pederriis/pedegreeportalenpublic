using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.Domain.User
{
    public class LastName : Value<LastName>
    {
        public string Value { get; internal set; }

        public LastName(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected LastName() { }

        public static implicit operator string(LastName lastName) => lastName.Value;

        public static LastName FromString(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value));

            return new LastName(value);
        }
    }
}
