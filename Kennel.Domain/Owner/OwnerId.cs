using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Owner
{
    public class OwnerId : Value<OwnerId>
    {
        public Guid Value { get; internal set; }

        protected OwnerId() { }

        public OwnerId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Character Id cannot be empty");

            Value = value;
        }

        public static implicit operator Guid(OwnerId ownerId) => ownerId.Value;

        public static implicit operator OwnerId(string value)
        {
            return new OwnerId(Guid.Parse(value));
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
