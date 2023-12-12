using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.Dog
{
    public class DogId : Value<DogId>
    {
        public DogId(Guid value) => Value = value;

        public Guid Value { get; internal set; }

        protected DogId() { }

        public static implicit operator Guid(DogId self) => self.Value;

        public static implicit operator DogId(string value) => new DogId(Guid.Parse(value));

        public override string ToString() => Value.ToString();
    }
}
