using System;
using System.Collections.Generic;
using System.Text;
using PedigreePortalen.Framework;

namespace HealthRecord.Domain.HealthCertificate
{
    public class HealthCertificateId : Value<HealthCertificateId>
    {

        public HealthCertificateId(Guid value) => Value = value;

        public Guid Value { get; internal set; }

        protected HealthCertificateId() { }

        public static implicit operator Guid(HealthCertificateId self) => self.Value;

        public static implicit operator HealthCertificateId(string value) => new HealthCertificateId(Guid.Parse(value));

        public override string ToString() => Value.ToString();
    }
}

