using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Animal.Domain.ExhibitionTitle
{
    public class ExhibitionTitleId : Value<ExhibitionTitleId>
    {
        public Guid Value { get; internal set; }

        protected ExhibitionTitleId() { }

        public ExhibitionTitleId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Character Id cannot be empty");

            Value = value;
        }

        public static implicit operator Guid(ExhibitionTitleId exhibitionTitleId) => exhibitionTitleId.Value;

        public static implicit operator ExhibitionTitleId(string value)
        {
            return new ExhibitionTitleId(Guid.Parse(value));
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
