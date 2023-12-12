using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.Domain.User
{
    public class ProfileText : Value<ProfileText>
    {
        public string Value { get; internal set; }

        public ProfileText(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected ProfileText() { }

        public static implicit operator string(ProfileText profileText) => profileText.Value;

        public static ProfileText FromString(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value));

            return new ProfileText(value);
        }
    }
}
