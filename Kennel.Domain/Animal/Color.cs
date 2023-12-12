using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Animal
{
    public class Color : Value<Color>
    {
        public string Value { get; internal set; }

        public Color(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected Color() { }

        public static implicit operator string(Color color) => color.Value;

        public static Color FromString(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value));

            return new Color(value);
        }
    }
}
