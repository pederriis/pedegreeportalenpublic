using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Animal
{
    public class Gender : Value<Gender>
    {
        public bool Value { get; internal set; }

        public Gender(bool value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements 
        protected Gender() { }

        public static implicit operator bool(Gender gender) => gender.Value;

        public static Gender FromBool(bool value)
        {
            return new Gender(Convert.ToBoolean(value));
        }
    }
}
