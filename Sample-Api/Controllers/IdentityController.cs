using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IdentityModel;

namespace Sample_Api.Controllers
{
    [Route("identity")]
    [Authorize]
    public class IdentityController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }
    }

    //[HttpPost]
    //[Authorize(LocalApi.PolicyName)]
    //public async Task<IActionResult> CreateUser([FromBody] ApplicationUser user)
    //{
    //    bool userIsInDb = true;
    //    var dbUser = await this._userManager.FindByEmailAsync(user.Email);
    //    if (dbUser == null)
    //    {
    //        var result = await _userManager.CreateAsync(user);
    //        userIsInDb = result.Succeeded;
    //    }
    //    else
    //    {
    //        user = dbUser;
    //    }

    //    if (userIsInDb)
    //    {
    //        string clientName = GetRequestClientName();

    //        if (string.IsNullOrEmpty(clientName))
    //        {
    //            return BadRequest();
    //        }

    //        await _userManager.AddClaimAsync(user, new Claim(clientName, true.ToString().ToLower()));

    //        var t = await _userManager.GeneratePasswordResetTokenAsync(user);
    //        var callbackUrl = Url.Action("ResetPassword", "Account", new { email = user.Email, token = t }, protocol: "https");

    //        //send a link for the user to set their password.
    //        this._emailManager.SendWelcomeEmail(user, callbackUrl);

    //        return Ok(user.Email);
    //    }
    //    else
    //    {
    //        return BadRequest();
    //    }
    //}

}