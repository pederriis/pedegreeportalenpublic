using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Kennel.Domain.Disease
{
    public class DiseaseDate : Value<DiseaseDate>
    {
        public DateTime Value { get; internal set; }

        protected DiseaseDate() { }

        public DiseaseDate(DateTime value) => Value = value;

        public static implicit operator DateTime(DiseaseDate date) => date.Value;

        public static DiseaseDate NoDate => new DiseaseDate();

        public static DiseaseDate FromDateTime(DateTime value)
        {
            CheckValidity(value.ToString());
            return new DiseaseDate(value);
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
