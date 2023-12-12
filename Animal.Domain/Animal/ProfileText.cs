using PedigreePortalen.Framework;

namespace Animal.Domain.Animal
{
    public class ProfileText :Value<ProfileText>
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
            return new ProfileText(value);
        }
    }
}
