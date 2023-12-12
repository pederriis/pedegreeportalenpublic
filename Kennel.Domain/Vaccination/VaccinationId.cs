using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Vaccination
{
    public class VaccinationId : Value<VaccinationId>
    {
        public VaccinationId(Guid value) => Value = value;

        public Guid Value { get; internal set; }

        protected VaccinationId() { }

        public static implicit operator Guid(VaccinationId self) => self.Value;

        public static implicit operator VaccinationId(string value) => new VaccinationId(Guid.Parse(value));

        public override string ToString() => Value.ToString();
    }
}
