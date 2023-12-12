using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.Contract
{
    public class ContractId : Value<ContractId>
    {
        public Guid Value { get; internal set; }

        protected ContractId() { }

        public ContractId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Character Id cannot be empty");

            Value = value;
        }

        public static implicit operator Guid(ContractId contractId) => contractId.Value;

        public static implicit operator ContractId(string value)
        {
            return new ContractId(Guid.Parse(value));
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
