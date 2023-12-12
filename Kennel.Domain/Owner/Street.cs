using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Owner
{
    public class Street : Value<Street>
    {
        public string Value { get; internal set; }

        public Street(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected Street() { }

        public static implicit operator string(Street street) => street.Value;

        public static Street FromString(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value));

            return new Street(value);
        }
    }
}
