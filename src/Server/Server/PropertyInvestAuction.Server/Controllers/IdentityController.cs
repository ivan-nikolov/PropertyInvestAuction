namespace PropertyInvestAuction.Server.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;

    using PropertyInvestAuction.Data.Models;
    using PropertyInvestAuction.Server.Infrastructure;
    using PropertyInvestAuction.Server.Models.Identity;
    using PropertyInvestAuction.Services.Data;

    public class IdentityController : BaseApiController
    {
        private readonly IIdentityService identityService;
        private readonly UserManager<AppUser> userManager;
        private readonly AppSettings appSettings;

        public IdentityController(
            IIdentityService identityService,
            IOptions<AppSettings> appSettings,
            UserManager<AppUser> userManager)
        {
            this.identityService = identityService;
            this.appSettings = appSettings.Value;
            this.userManager = userManager;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterInputModel input)
        {
            if (input.Password != input.ConfirmPassword)
            {
                return this.BadRequest("Passwords do not match.");
            }

            var user = new AppUser()
            {
                UserName = input.UserName,
                Email = input.Email,
            };
            var result = await this.userManager.CreateAsync(user, input.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginInputModel input)
        {
            var user = await this.userManager.FindByNameAsync(input.UserName);
            if (user == null)
            {
                return Unauthorized();
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, input.Password);
            if (!passwordValid)
            {
                return Unauthorized();
            }

            var token = this.identityService.GetJwtToken(user.Id, user.UserName, this.appSettings.Secret);
            var roles = await this.userManager.GetRolesAsync(user) as List<string>;

            var model = new LoginResponseModel
            {
                Token = token,
                Roles = roles
            };


            return this.Ok(model);
        }
    }
}
