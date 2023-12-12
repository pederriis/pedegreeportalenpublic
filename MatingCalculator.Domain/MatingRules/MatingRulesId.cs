using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.MatingRules
{
   public class MatingRulesId : Value<MatingRulesId>
    {
        public MatingRulesId(Guid value) => Value = value;

        public Guid Value { get; internal set; }

        protected MatingRulesId() { }

        public static implicit operator Guid(MatingRulesId self) => self.Value;

        public static implicit operator MatingRulesId(string value) => new MatingRulesId(Guid.Parse(value));

        public override string ToString() => Value.ToString();
    }
}
