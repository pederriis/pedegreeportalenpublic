using System;
using System.Collections.Generic;
using System.Text;

namespace User.Domain
{
    public class DomainExceptions
    {
        public class InvalidEntityState : Exception
        {
            public InvalidEntityState(object entity, string message) : base($"Entity {entity.GetType().Name} state change rejected, {message}")
            {

            }
        }

    }
}
