using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace HealthRecord.Domain.HealthCertificate
{
    public class Date : Value<Date>
    {
        public DateTime Value { get; internal set; }

        protected Date() { }

        public Date(DateTime value) => Value = value;

        public static implicit operator DateTime(Date date) => date.Value;

        public static Date NoDate => new Date();

        public static Date FromDateTime(DateTime value)
        {
            CheckValidity(value.ToString());
            return new Date(value);
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
