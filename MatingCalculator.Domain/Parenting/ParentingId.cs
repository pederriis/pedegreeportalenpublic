using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.Parenting
{
    public class ParentingId : Value<ParentingId>
    {
        public Guid Value { get; internal set; }

        protected ParentingId() { }

        public ParentingId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Character Id cannot be empty");

            Value = value;
        }

        public static implicit operator Guid(ParentingId parentId) => parentId.Value;

        public static implicit operator ParentingId(string value)
        {
            return new ParentingId(Guid.Parse(value));
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
