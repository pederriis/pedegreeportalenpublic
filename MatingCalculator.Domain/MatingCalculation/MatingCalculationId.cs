using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.MatingCalculation
{
    public class MatingCalculationId : Value<MatingCalculationId>
    {
        public MatingCalculationId(Guid value) => Value = value;

        public Guid Value { get; internal set; }

        protected MatingCalculationId() { }

        public static implicit operator Guid(MatingCalculationId self) => self.Value;

        public static implicit operator MatingCalculationId(string value) => new MatingCalculationId(Guid.Parse(value));

        public override string ToString() => Value.ToString();
    }
}
