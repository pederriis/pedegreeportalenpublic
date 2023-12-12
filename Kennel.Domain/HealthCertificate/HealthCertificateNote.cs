using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.HealthCertificate
{
    public class HealthCertificateNote :Value<HealthCertificateNote>
    {
        public string Value { get; internal set; }

        public HealthCertificateNote(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected HealthCertificateNote() { }

        public static implicit operator string(HealthCertificateNote note) => note.Value;

        public static HealthCertificateNote FromString(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value));

            return new HealthCertificateNote(value);
        }
    }
}
