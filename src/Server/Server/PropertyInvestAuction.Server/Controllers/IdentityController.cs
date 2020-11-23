namespace PropertyInvestAuction.Server.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;

    using PropertyInvestAuction.Server.Infrastructure;
    using PropertyInvestAuction.Server.Models.Identity;
    using PropertyInvestAuction.Services.Data;

    public class IdentityController : BaseApiController
    {
        private readonly IIdentityService identityService;
        private readonly AppSettings appSettings;

        public IdentityController(
            IIdentityService identityService,
            IOptions<AppSettings> appSettings)
        {
            this.identityService = identityService;
            this.appSettings = appSettings.Value;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterInputModel input)
        {
            if (input.Password != input.ConfirmPassword)
            {
                return this.BadRequest("Passwords do not match.");
            }

            var result = await this.identityService.RegisterAsync<string>(input.UserName, input.Email, input.Password);

            if (result.Succeeded)
            {
                return this.Ok();
            }

            return this.BadRequest(result.Errors);
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginInputModel input)
        {
            var secret = this.appSettings.Secret;

            var result = await this.identityService.LoginAsync<LoginResponseModel>(input.UserName, input.Password, secret);

            if (result.Failure)
            {
                return this.BadRequest(result.Errors);
            }

            return this.Ok(result.Model);
        }
    }
}
