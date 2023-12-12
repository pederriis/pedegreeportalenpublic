using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Kennel.Domain.HealthCertificate
{
    public class HealthCertificateDate : Value<HealthCertificateDate>
    {
        public DateTime Value { get; internal set; }

        protected HealthCertificateDate() { }

        public HealthCertificateDate(DateTime value) => Value = value;

        public static implicit operator DateTime(HealthCertificateDate date) => date.Value;

        public static HealthCertificateDate NoDate => new HealthCertificateDate();

        public static HealthCertificateDate FromDateTime(DateTime value)
        {
            CheckValidity(value.ToString());
            return new HealthCertificateDate(value);
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
