using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.CalculatedDisease
{
    public class CalculatedDiseaseId : Value<CalculatedDiseaseId>
    {
        public CalculatedDiseaseId(Guid value) => Value = value;

        public Guid Value { get; internal set; }

        protected CalculatedDiseaseId() { }

        public static implicit operator Guid(CalculatedDiseaseId self) => self.Value;

        public static implicit operator CalculatedDiseaseId(string value) => new CalculatedDiseaseId(Guid.Parse(value));

        public override string ToString() => Value.ToString();
    }
}
