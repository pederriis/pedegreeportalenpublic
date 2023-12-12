using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Disease
{
    public class DiseaseName : Value<DiseaseName>
    {
        public string Value { get; internal set; }

        public DiseaseName(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected DiseaseName() { }

        public static implicit operator string(DiseaseName name) => name.Value;

        public static DiseaseName FromString(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value));

            return new DiseaseName(value);
        }
    }
}
