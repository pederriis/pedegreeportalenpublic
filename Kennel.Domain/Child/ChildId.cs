using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Child
{
    public class ChildId : Value<ChildId>
    {
        public Guid Value { get; internal set; }

        protected ChildId() { }

        public ChildId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Character Id cannot be empty");

            Value = value;
        }

        public static implicit operator Guid(ChildId childId) => childId.Value;

        public static implicit operator ChildId(string value)
        {
            return new ChildId(Guid.Parse(value));
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
