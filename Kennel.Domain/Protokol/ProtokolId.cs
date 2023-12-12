using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Protokol
{
    public class ProtokolId :Value<ProtokolId>
    {
        public Guid Value { get; internal set; }

        protected ProtokolId() { }

        public ProtokolId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "Character Id cannot be empty");

            Value = value;
        }

        public static implicit operator Guid(ProtokolId protokolId) => protokolId.Value;

        public static implicit operator ProtokolId(string value)
        {
            return new ProtokolId(Guid.Parse(value));
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
} 
