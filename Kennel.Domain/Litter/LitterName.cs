using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Litter
{
    public class LitterName : Value<LitterName>
    {
        public string Value { get; internal set; }

        public LitterName(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected LitterName() { }

        public static implicit operator string(LitterName litterName) => litterName.Value;

        public static LitterName FromString(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value));

            return new LitterName(value);
        }
    }
}
