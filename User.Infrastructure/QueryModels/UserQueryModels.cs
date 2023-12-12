using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.Infrastructure.QueryModels
{
    public static class UserQueryModels
    {
        public class GetUserByUserId
        {
            public Guid UserId { get; set; }
        }

        public class GetUserByLoginUserId
        {
            public string LoginUserId { get; set; }
        }
    }
}
