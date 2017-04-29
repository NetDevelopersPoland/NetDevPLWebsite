using System.Collections.Generic;
using Nancy.Security;
using NetDevPL.Features.UserManagement;

namespace NetDevPLWeb.Infrastructure
{
    public class AuthUserIdentity : IUserIdentity
    {
        public string UserName { get; set; }
        public IEnumerable<string> Claims { get; set; }

        public static IUserIdentity Create(User user)
        {
            if (user == null)
                return null;

            return new AuthUserIdentity
            {
                UserName = user.Name,
                Claims = new List<string> { "user" }
            };
        }
    }
}