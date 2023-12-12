using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MatingCalculator.Domain.Contract
{
  public  class CreationDate : Value<CreationDate>
    {
        public DateTime Value { get; internal set; }

    protected CreationDate() { }

    public CreationDate(DateTime value) => Value = value;

    public static implicit operator DateTime(CreationDate creationDate) => creationDate.Value;

    public static CreationDate NoDate => new CreationDate();

    public static CreationDate FromDateTime(DateTime value)
    {
        CheckValidity(value.ToString());
        return new CreationDate(value);
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
