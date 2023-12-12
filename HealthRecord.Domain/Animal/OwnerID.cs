using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthRecord.Domain.Animal
{



    public class OwnerId : Value<OwnerId>
    {
        public string Value { get; internal set; }

        public OwnerId(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected OwnerId() { }

        public static implicit operator string(OwnerId name) => name.Value;

        public static OwnerId FromString(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value));

            return new OwnerId(value);
        }
    }
}
