using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.Disease
{
   public class Probability : Value<Probability>
    {
        public double Value { get; internal set; }

        public Probability(double value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements 
        protected Probability() { }

        public static implicit operator double(Probability Probability) => Probability.Value;

        public static Probability FromDouble(double value)
        {
            return new Probability(Convert.ToDouble(value));
        }
    }
}
