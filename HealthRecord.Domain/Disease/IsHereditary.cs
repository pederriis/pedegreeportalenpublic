using System;
using System.Collections.Generic;
using System.Text;
using PedigreePortalen.Framework;

namespace HealthRecord.Domain.Disease
{
    public class IsHereditary: Value<IsHereditary>
    {
        public bool Value { get; internal set; }

        public IsHereditary(bool value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements 
        protected IsHereditary() { }

        public static implicit operator bool(IsHereditary isHereditary) => isHereditary.Value;

        public static IsHereditary FromBool(bool value)
        {
            return new IsHereditary(Convert.ToBoolean(value));
        }
    }
}
