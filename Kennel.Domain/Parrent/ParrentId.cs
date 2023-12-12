using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Parrent
{
    public class ParrentId : Value<ParrentId>
    {
        public Guid Value { get; internal set; }

        protected ParrentId() { }

        public ParrentId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Character Id cannot be empty");

            Value = value;
        }

        public static implicit operator Guid(ParrentId animalLitterId) => animalLitterId.Value;

        public static implicit operator ParrentId(string value)
        {
            return new ParrentId(Guid.Parse(value));
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
