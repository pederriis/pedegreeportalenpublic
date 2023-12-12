using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Kennel
{
    public class KennelId : Value<KennelId>
    {
        public Guid Value { get; internal set; }

        protected KennelId() { }

        public KennelId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Character Id cannot be empty");

            Value = value;
        }

        public static implicit operator Guid(KennelId kennelId) => kennelId.Value;

        public static implicit operator KennelId(string value)
        {
            return new KennelId(Guid.Parse(value));
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
