using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Litter
{
    public class LitterId : Value<LitterId>
    {
        public Guid Value { get; internal set; }

        protected LitterId() { }

        public LitterId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Character Id cannot be empty");

            Value = value;
        }

        public static implicit operator Guid(LitterId litterId) => litterId.Value;

        public static implicit operator LitterId(string value)
        {
            return new LitterId(Guid.Parse(value));
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
