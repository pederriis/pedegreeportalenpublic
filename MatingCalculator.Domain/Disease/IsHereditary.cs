using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.Disease
{
    public class IsHereditary : Value<IsHereditary>
    {
        public bool Value { get; internal set; }

        public IsHereditary(bool value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements 
        protected IsHereditary() { }

        public static implicit operator bool(IsHereditary isDeleted) => isDeleted.Value;

        public static IsHereditary FromBool(bool value)
        {
            return new IsHereditary(Convert.ToBoolean(value));
        }
    }
}
