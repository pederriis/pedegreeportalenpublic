using PedigreePortalen.Framework;
using System;
using System.Globalization;

namespace Animal.Domain.Animal
{
    public class BirthDate :Value<BirthDate>
    {
        public DateTime Value { get; internal set; }

        protected BirthDate() { }

        public BirthDate(DateTime value) => Value = value;

        public static implicit operator DateTime(BirthDate birthDate) => birthDate.Value;

        public static BirthDate NoDate => new BirthDate();

        public static BirthDate FromDateTime(DateTime value)
        {
            CheckValidity(value.ToString());
            return new BirthDate(value);
        }

        private static bool CheckValidity(string dateFormat)
        {
            try
            {
                string dts = DateTime.Now.ToString(dateFormat, CultureInfo.InvariantCulture);
                DateTime.ParseExact(dts, dateFormat, CultureInfo.InvariantCulture);
                return true;

            }
            catch (Exception)
            {
                throw new ArgumentOutOfRangeException("DateTime is in another format", nameof(dateFormat));
            }
        }
    }
}
