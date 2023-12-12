using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.HealthCertificate
{
    public class HealthCertificateName : Value<HealthCertificateName>
    {
        public string Value { get; internal set; }

        public HealthCertificateName(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected HealthCertificateName() { }

        public static implicit operator string(HealthCertificateName name) => name.Value;

        public static HealthCertificateName FromString(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value));

            return new HealthCertificateName(value);
        }
    }
}
