using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.ContractUserinformation
{
    public class ContractUserinformationId : Value<ContractUserinformationId>
    {
        public Guid Value { get; internal set; }

        protected ContractUserinformationId() { }

        public ContractUserinformationId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Character Id cannot be empty");

            Value = value;
        }

        public static implicit operator Guid(ContractUserinformationId contractUserinformationId) => contractUserinformationId.Value;

        public static implicit operator ContractUserinformationId(string value)
        {
            return new ContractUserinformationId(Guid.Parse(value));
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
