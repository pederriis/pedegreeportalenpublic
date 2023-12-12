using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Owner
{
    public class Email : Value<Email>
    {
        public string Value { get; internal set; }

        public Email(string value)
        {
            if (!value.Contains('@') || !value.Contains('.'))
                throw new ArgumentNullException(
               nameof(value), "Email most be valid.");

            Value = value;
        }

        // Satisfy the serialization requirements 
        protected Email() { }

        public static implicit operator string(Email email) => email.Value;

        public static Email FromString(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value));

            return new Email(value);
        }
    }
}
