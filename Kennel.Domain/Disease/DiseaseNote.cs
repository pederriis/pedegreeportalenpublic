using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Disease
{
    public class DiseaseNote : Value<DiseaseNote>
    {
        public string Value { get; internal set; }

        public DiseaseNote(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected DiseaseNote() { }

        public static implicit operator string(DiseaseNote note) => note.Value;

        public static DiseaseNote FromString(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value));

            return new DiseaseNote(value);
        }
    }
}
