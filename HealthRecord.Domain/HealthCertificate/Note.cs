using System;
using System.Collections.Generic;
using System.Text;
using PedigreePortalen.Framework;

namespace HealthRecord.Domain.HealthCertificate
{
    public class Note : Value<Note>
    {
        public string Value { get; internal set; }

        public Note(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected Note() { }

        public static implicit operator string(Note note) => note.Value;

        public static Note FromString(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value));

            return new Note(value);
        }
    }
}
