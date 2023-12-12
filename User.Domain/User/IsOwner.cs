using System;
using System.Collections.Generic;
using System.Text;

namespace User.Domain.User
{
    public class IsOwner
    {
        public bool Value { get; internal set; }

        public IsOwner(bool value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements 
        protected IsOwner() { }

        public static implicit operator bool(IsOwner isOwner) => isOwner.Value;

        public static IsOwner FromBool(bool value)
        {
            return new IsOwner(Convert.ToBoolean(value));
        }
    }
}
