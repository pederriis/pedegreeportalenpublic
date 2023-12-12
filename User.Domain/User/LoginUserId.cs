using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.Domain.User
{
    public class LoginUserId : Value<LoginUserId>
    {
        public string Value { get; internal set; }

        public LoginUserId(string value)
        {
            Value = value;
        }

        // Satisfy the serialization requirements
        protected LoginUserId() { }

        public static implicit operator string(LoginUserId loginUserId) => loginUserId.Value;

        public static LoginUserId FromString(string value)
        {
            if (value.IsEmpty())
                throw new ArgumentNullException(nameof(value));

            return new LoginUserId(value);
        }
    }
}
