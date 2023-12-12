using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.DogMatingCalculation
{
    public class DogMatingCalculationId : Value<DogMatingCalculationId>
    {
        public DogMatingCalculationId(Guid value) => Value = value;

        public Guid Value { get; internal set; }

        protected DogMatingCalculationId() { }

        public static implicit operator Guid(DogMatingCalculationId self) => self.Value;

        public static implicit operator DogMatingCalculationId(string value) => new DogMatingCalculationId(Guid.Parse(value));

        public override string ToString() => Value.ToString();
    }
}
