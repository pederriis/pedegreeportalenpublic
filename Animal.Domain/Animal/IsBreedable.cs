using PedigreePortalen.Framework;
using System;

namespace Animal.Domain.Animal
{
    public class IsBreedable :Value<IsBreedable>
    {
        public bool Value { get; internal set; }

        public IsBreedable(bool value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements 
        protected IsBreedable() { }

        public static implicit operator bool(IsBreedable isBreedable) => isBreedable.Value;

        public static IsBreedable FromBool(bool value)
        {
            return new IsBreedable(Convert.ToBoolean(value));
        }
    }
}
