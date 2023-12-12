using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.Domain.User
{
    public class City :Value<City>
    {
        public string Value { get; internal set; }

        public City(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected City() { }

        public static implicit operator string(City city) => city.Value;

        public static City FromString(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value));

            return new City(value);
        }
    }
}
