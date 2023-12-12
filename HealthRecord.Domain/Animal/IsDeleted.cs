using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthRecord.Domain.Animal
{
   
    public class IsDeleted : Value<IsDeleted>
    {
        public bool Value { get; internal set; }

        public IsDeleted(bool value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements 
        protected IsDeleted() { }

        public static implicit operator bool(IsDeleted isDeleted) => isDeleted.Value;

        public static IsDeleted FromBool(bool value)
        {
            return new IsDeleted(Convert.ToBoolean(value));
        }
    }
}
