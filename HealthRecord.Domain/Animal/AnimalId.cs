using System;
using System.Collections.Generic;
using System.Text;
using PedigreePortalen.Framework;

namespace HealthRecord.Domain.Animal
{
    public class AnimalId : Value<AnimalId>
    {
        public AnimalId(Guid value) => Value = value;

        public Guid Value { get; internal set; }

        protected AnimalId() { }

        public static implicit operator Guid(AnimalId self) => self.Value;

        public static implicit operator AnimalId(string value) => new AnimalId(Guid.Parse(value));

        public override string ToString() => Value.ToString();
    }
}
