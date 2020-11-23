namespace PropertyInvestAuction.Services.Data
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.IdentityModel.Tokens;

    using PropertyInvestAuction.Data.Models;
    using PropertyInvestAuction.Services.Models;

    using PropertyInvestAuction.Services.Mapping;

    using System.Collections.Generic;
    using PropertyInvestAuction.Services.Models.Identity;

    public class IdentityService : IIdentityService
    {
        private readonly UserManager<AppUser> userManager;

        public IdentityService(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<Result<T>> LoginAsync<T>(string userName, string password, string secret)
        {
            var user = await this.userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return new string[] { "Invalid UserName" };
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, password);
            if (!passwordValid)
            {
                return new string[] { "Invalid Password" };
            }

            var token = this.GetJwtToken(user.Id, user.UserName, secret);
            var roles = await this.userManager.GetRolesAsync(user) as List<string>;

            var model = new LoginModel
            {
                Token = token,
                Roles = roles
            };

            return model.To<T>();
        }

        public async Task<Result<T>> RegisterAsync<T>(string userName, string email, string password)
        {
            var user = new AppUser()
            {
                UserName = userName,
                Email = email
            };
            var result = await this.userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                return result.Errors.Select(x => x.Description).ToArray();
            }

            return result.Succeeded;
        }

        private string GetJwtToken(string userId, string userName, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Name, userName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return encryptedToken;
        }
    }
}
