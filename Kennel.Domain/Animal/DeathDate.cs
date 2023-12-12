using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Kennel.Domain.Animal
{
    public class DeathDate : Value<DeathDate>
    {
        public DateTime Value { get; internal set; }

        protected DeathDate() { }

        public DeathDate(DateTime value) => Value = value;

        public static implicit operator DateTime(DeathDate deathDate) => deathDate.Value;

        public static DeathDate NoDate => new DeathDate();

        public static DeathDate FromDateTime(DateTime value)
        {
            CheckValidity(value.ToString());
            return new DeathDate(value);
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
