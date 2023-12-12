using PedigreePortalen.Framework;
using System;

namespace Animal.Domain.Human
{
    public class HumanId :Value<HumanId>
    {
        public Guid Value { get; internal set; }

        protected HumanId() { }

        public HumanId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Character Id cannot be empty");

            Value = value;
        }

        public static implicit operator Guid(HumanId humanId) => humanId.Value;

        public static implicit operator HumanId(string value)
        {
            return new HumanId(Guid.Parse(value));
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
