using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.HealthRecord
{
    public class HealthRecordId : Value<HealthRecordId>
    {
        public HealthRecordId(Guid value) => Value = value;

        public Guid Value { get; internal set; }

        protected HealthRecordId() { }

        public static implicit operator Guid(HealthRecordId self) => self.Value;

        public static implicit operator HealthRecordId(string value) => new HealthRecordId(Guid.Parse(value));

        public override string ToString() => Value.ToString();
    }
}
