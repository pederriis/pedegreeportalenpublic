using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.Userinformation
{
    public class UserinformationId : Value<UserinformationId>
    {
        public UserinformationId(Guid value) => Value = value;

        public Guid Value { get; internal set; }

        protected UserinformationId() { }

        public static implicit operator Guid(UserinformationId self) => self.Value;

        public static implicit operator UserinformationId(string value) => new UserinformationId(Guid.Parse(value));

        public override string ToString() => Value.ToString();
    }
}
