using System;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.SimpleAuthentication;
using NetDevPL.Features.UserManagement;
using NetDevPL.Infrastructure.SharedKernel;

namespace NetDevPLWeb
{
    public class SampleAuthenticationCallbackProvider : IAuthenticationCallbackProvider
    {
        public dynamic Process(NancyModule nancyModule, AuthenticateCallbackData model)
        {
            try
            {
                if (model.Exception != null)
                {
                    Logger.Fatal(model.Exception);
                    return ReturnLoginErrorResponse();
                }
                else
                {
                    //TODO handle exception from model.Exception
                    Repository repo = new Repository();

                    User user = repo.GetByMail(model.AuthenticatedClient.UserInformation.Email);

                    if (user == null)
                    {
                        user = new User
                        {
                            Id = Guid.NewGuid(),
                            CreateDate = DateTime.UtcNow,
                            Email = model.AuthenticatedClient.UserInformation.Email,
                            Name = model.AuthenticatedClient.UserInformation.Name,
                            Picture = model.AuthenticatedClient.UserInformation.Picture,
                            Provider = model.AuthenticatedClient.ProviderName,
                            ProviderExternalId = model.AuthenticatedClient.UserInformation.Id
                        };

                        repo.Add(user);
                    }

                    return nancyModule.LoginAndRedirect(user.Id);
                }
            }
            catch (Exception exc)
            {
                Logger.Fatal(exc);
                return ReturnLoginErrorResponse();
            }
        }

        public dynamic OnRedirectToAuthenticationProviderError(NancyModule nancyModule, string errorMessage)
        {
            return null;
        }

        private dynamic ReturnLoginErrorResponse()
        {
            var r = (Response)"Could not authenticate. Notify administrator, please :)";
            r.StatusCode = HttpStatusCode.InternalServerError;

            return r;
        }
    }
}