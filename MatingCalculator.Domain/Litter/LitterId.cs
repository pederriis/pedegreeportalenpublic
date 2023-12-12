using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.Litter
{
   public class LitterId : Value<LitterId>
    {
        public LitterId(Guid value) => Value = value;

        public Guid Value { get; internal set; }

        protected LitterId() { }

        public static implicit operator Guid(LitterId self) => self.Value;

        public static implicit operator LitterId(string value) => new LitterId(Guid.Parse(value));

        public override string ToString() => Value.ToString();
    }
}
