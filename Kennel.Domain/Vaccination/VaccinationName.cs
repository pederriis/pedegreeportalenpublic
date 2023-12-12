using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Vaccination
{
    public class VaccinationName : Value<VaccinationName>
    {
        public string Value { get; internal set; }

        public VaccinationName(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected VaccinationName() { }

        public static implicit operator string(VaccinationName name) => name.Value;

        public static VaccinationName FromString(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value));

            return new VaccinationName(value);
        }
    }
}
