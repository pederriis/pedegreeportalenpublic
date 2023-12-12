using PedigreePortalen.Framework;
using System;

namespace Animal.Domain.HealthRecord
{
    public class HealthRecordId :Value<HealthRecordId>
    {
        public Guid Value { get; internal set; }

        protected HealthRecordId() { }

        public HealthRecordId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Character Id cannot be empty");

            Value = value;
        }

        public static implicit operator Guid(HealthRecordId healthRecordId) => healthRecordId.Value;

        public static implicit operator HealthRecordId(string value)
        {
            return new HealthRecordId(Guid.Parse(value));
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
