using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.Domain.User
{
    public class Zipcode : Value<Zipcode>
    {
        public string Value { get; internal set; }

        public Zipcode(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected Zipcode() { }

        public static implicit operator string(Zipcode zipcode) => zipcode.Value;

        public static Zipcode FromString(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value));

            return new Zipcode(value);
        }
    }
}
