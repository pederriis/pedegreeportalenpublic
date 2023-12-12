using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MatingCalculator.Domain.Contract
{
    public class MatingDate : Value<MatingDate>
    {
        public DateTime Value { get; internal set; }

        protected MatingDate() { }

        public MatingDate(DateTime value) => Value = value;

        public static implicit operator DateTime(MatingDate matingDate) => matingDate.Value;

        public static MatingDate NoDate => new MatingDate();

        public static MatingDate FromDateTime(DateTime value)
        {
            CheckValidity(value.ToString());
            return new MatingDate(value);
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

