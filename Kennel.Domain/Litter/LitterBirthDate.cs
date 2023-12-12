using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Kennel.Domain.Litter
{
    public class LitterBirthDate : Value<LitterBirthDate>
    {
        public DateTime Value { get; internal set; }

        protected LitterBirthDate() { }

        public LitterBirthDate(DateTime value) => Value = value;

        public static implicit operator DateTime(LitterBirthDate litterBirthDate) => litterBirthDate.Value;

        public static LitterBirthDate NoDate => new LitterBirthDate();

        public static LitterBirthDate FromDateTime(DateTime value)
        {
            CheckValidity(value.ToString());
            return new LitterBirthDate(value);
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
