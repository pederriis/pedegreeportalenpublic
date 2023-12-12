using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.MatingCalculation
{
    public class IsLegal : Value<IsLegal>
    {
        public bool Value { get; internal set; }

        public IsLegal(bool value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements 
        protected IsLegal() { }

        public static implicit operator bool(IsLegal isLegal) => isLegal.Value;

        public static IsLegal FromBool(bool value)
        {
            return new IsLegal(Convert.ToBoolean(value));
        }
    }
}
