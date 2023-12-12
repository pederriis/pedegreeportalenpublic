using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Kennel
{
    public class KennelName :Value<KennelName>
    {
        public string Value { get; internal set; }

        public KennelName(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected KennelName() { }

        public static implicit operator string(KennelName kennelName) => kennelName.Value;

        public static KennelName FromString(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value));

            return new KennelName(value);
        }
    }
}
