using PedigreePortalen.Framework;
using System;

namespace Animal.Domain.Animal
{
    public class AnimalId :Value<AnimalId>
    {
        public Guid Value { get; internal set; }

        protected AnimalId() { }

        public AnimalId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Character Id cannot be empty");

            Value = value;
        }

        public static implicit operator Guid(AnimalId animalId) => animalId.Value;

        public static implicit operator AnimalId(string value)
        {
            return new AnimalId(Guid.Parse(value));
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
