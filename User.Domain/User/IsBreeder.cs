using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.Domain.User
{
    public class IsBreeder :Value<IsBreeder>
    {
        public bool Value { get; internal set; }

        public IsBreeder(bool value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements 
        protected IsBreeder() { }

        public static implicit operator bool(IsBreeder isBreeder) => isBreeder.Value;

        public static IsBreeder FromBool(bool value)
        {
            return new IsBreeder(Convert.ToBoolean(value));
        }
    }
}
