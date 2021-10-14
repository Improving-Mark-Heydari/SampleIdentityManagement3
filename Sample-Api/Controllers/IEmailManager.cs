using GB.IdentityServer.Models;

namespace GB.IdentityServer.Controllers
{
    internal interface IEmailManager
    {
        void SendWelcomeEmail(ApplicationUser user, string callbackUrl);
    }
}