namespace PropertyInvestAuction.Server.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;

    using PropertyInvestAuction.Data.Models;
    using PropertyInvestAuction.Server.Infrastructure;
    using PropertyInvestAuction.Server.Models.Identity;
    using PropertyInvestAuction.Services.Data;

    using static PropertyInvestAuction.Common.GlobalConstants;
    using static PropertyInvestAuction.Common.ErrorMessages;
    using Microsoft.AspNetCore.Authorization;

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
                return this.BadRequest(PasswordsDoNotMatch);
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

            await this.userManager.AddToRoleAsync(user, ClientRoleName);

            return Ok();
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginInputModel input)
        {
            var user = await this.userManager.FindByNameAsync(input.UserName);

            var passwordValid = await this.userManager.CheckPasswordAsync(user, input.Password);
            if (user == null || !passwordValid)
            {
                return BadRequest(InvalidUsernameOrPassword);
            }

            var roles = await this.userManager.GetRolesAsync(user);
            var token = this.identityService.GetJwtToken(user.Id, user.UserName, roles, this.appSettings.Secret);

            var model = new LoginResponseModel
            {
                Token = token
            };


            return this.Ok(model);
        }

        [HttpGet]
        [Authorize(Roles = AdministratorRoleName)]
        public async Task<int> UsersCount()
        {
            return await this.identityService.GetUsersCount();
        }

        [HttpGet]
        [Route(nameof(GetPage))]
        [Authorize(Roles = AdministratorRoleName)]
        public async Task<ActionResult<IEnumerable<UserResponseModel>>> GetPage([FromQuery]PageRequestModel pageRequest)
        {
            if (!this.ModelState.IsValid)
            {
                return ValidationProblem(this.ModelState);
            }

            var users = (await this.identityService
                .GetAll(pageRequest.Page, pageRequest.PageSize, pageRequest.Query ?? string.Empty))
                .Select(u => new UserResponseModel { 
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email,
                    Roles = u.Roles,
                    IsAdministrator = u.Roles.Any(x => x == AdministratorRoleName)
                });
            
            return Ok(users);
        }

        [HttpPost]
        [Route(nameof(AddToAdmin))]
        [Authorize(Roles = AdministratorRoleName)]
        public async Task<ActionResult> AddToAdmin(ChangeRoleRequestModel requestModel)
        {
            var user = await this.userManager.FindByIdAsync(requestModel.Id);
            if (user == null)
            {
                return BadRequest(UserNotFound);
            }

            await this.userManager.AddToRoleAsync(user, AdministratorRoleName);

            return Ok();
        }

        [HttpPost]
        [Route(nameof(RemoveFromAdmin))]
        [Authorize(Roles = AdministratorRoleName)]
        public async Task<ActionResult> RemoveFromAdmin(ChangeRoleRequestModel requestModel)
        {
            var user = await this.userManager.FindByIdAsync(requestModel.Id);
            if (user == null)
            {
                return this.BadRequest(UserNotFound);
            }

            await this.userManager.RemoveFromRoleAsync(user, AdministratorRoleName);
            return Ok();
        }
    }
}
