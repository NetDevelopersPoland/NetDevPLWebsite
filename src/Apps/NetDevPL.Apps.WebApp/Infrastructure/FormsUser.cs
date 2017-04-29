using System;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Security;
using NetDevPL.Features.UserManagement;

namespace NetDevPLWeb.Infrastructure
{
    public class FormsUser : IUserMapper
    {
        public IUserIdentity GetUserFromIdentifier(Guid identifier, NancyContext context)
        {
            Repository repo = new Repository();
            return AuthUserIdentity.Create(repo.GetById(identifier));
        }
    }
}