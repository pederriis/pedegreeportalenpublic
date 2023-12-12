﻿using System;

namespace Kennel.Domain
{
    public class DomainExceptions
    {
        public class InvalidEntityState :Exception
        {
            public InvalidEntityState(object entity, string message) : base($"Entity {entity.GetType().Name} state change rejected, {message}")
            {

            }
        }
    }
}
