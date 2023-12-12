using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Kennel.Domain.Vaccination
{
    public class VaccinationDate : Value<VaccinationDate>
    {
        public DateTime Value { get; internal set; }

        protected VaccinationDate() { }

        public VaccinationDate(DateTime value) => Value = value;

        public static implicit operator DateTime(VaccinationDate date) => date.Value;

        public static VaccinationDate NoDate => new VaccinationDate();

        public static VaccinationDate FromDateTime(DateTime value)
        {
            CheckValidity(value.ToString());
            return new VaccinationDate(value);
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
