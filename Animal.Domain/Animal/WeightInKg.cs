using PedigreePortalen.Framework;
using System;

namespace Animal.Domain.Animal
{
    public class WeightInKg :Value<WeightInKg>
    {
        public double Value { get; internal set; }

        public WeightInKg(double value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements 
        protected WeightInKg() { }

        public static implicit operator double(WeightInKg weightInKg) => weightInKg.Value;

        public static WeightInKg FromDouble(double value)
        {
            return new WeightInKg(Convert.ToDouble(value));
        }
    }
}
