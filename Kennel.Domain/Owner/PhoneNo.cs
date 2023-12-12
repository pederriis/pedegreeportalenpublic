using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Owner
{
    public class PhoneNo : Value<PhoneNo>
    {
        public string Value { get; internal set; }

        public PhoneNo(string phone)
        {
            Value = phone;
        }

        // Satisfy the serialization requirements
        protected PhoneNo() { }

        public static implicit operator string(PhoneNo phoneNo) => phoneNo.Value;

        public static PhoneNo FromString(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value));

            return new PhoneNo(value);
        }
    }
}
