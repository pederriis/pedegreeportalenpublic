using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.MatingCalculation
{
    public class InbreedingPercent : Value<InbreedingPercent>
    {
        public double Value { get; internal set; }

        public InbreedingPercent(double value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements 
        protected InbreedingPercent() { }

        public static implicit operator double(InbreedingPercent weightInKg) => weightInKg.Value;

        public static InbreedingPercent FromDouble(double value)
        {
            return new InbreedingPercent(Convert.ToDouble(value));
        }
    }
}
