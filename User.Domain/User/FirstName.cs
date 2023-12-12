using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.Domain.User
{
    public class FirstName : Value<FirstName>
    {
        public string Value { get; internal set; }

        public FirstName(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected FirstName() { }

        public static implicit operator string(FirstName firstName) => firstName.Value;

        public static FirstName FromString(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value));

            return new FirstName(value);
        }
    }
}
