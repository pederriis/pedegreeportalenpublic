using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Kennel
{
    public class KennelSmiley : Value<KennelSmiley>
    {
        public string Value { get; internal set; }

        public KennelSmiley(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected KennelSmiley() { }

        public static implicit operator string(KennelSmiley kennelSmiley) => kennelSmiley.Value;

        public static KennelSmiley FromString(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value));

            return new KennelSmiley(value);
        }
    }
}
