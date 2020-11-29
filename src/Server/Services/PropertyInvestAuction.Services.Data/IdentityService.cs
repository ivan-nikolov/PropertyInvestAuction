namespace PropertyInvestAuction.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;

    using PropertyInvestAuction.Data;
    using PropertyInvestAuction.Data.Common.Repositories;
    using PropertyInvestAuction.Data.Models;
    using PropertyInvestAuction.Services.Models.Identity;

    public class IdentityService : IIdentityService
    {
        private readonly IDeletableEntityRepository<AppUser> userRepo;
        private readonly AppDbContext context;

        public IdentityService(IDeletableEntityRepository<AppUser> userRepo, AppDbContext context)
        {
            this.userRepo = userRepo;
            this.context = context;
        }

        public async Task<IEnumerable<UserServiceModel>> GetAll(int page, int pageSize, string query)
        {
            var users = await this.userRepo.AllAsNoTracking()
            .Include(u => u.Roles)
            .Where(u => u.UserName.Contains(query))
            .Skip(page * pageSize)
            .Take(pageSize)
            .OrderBy(u => u.UserName)
            .ToListAsync();

            var roles = this.context.Roles.Select(r => new
            {
                r.Id,
                r.Name
            });

            var result = users
                .Select(u => new UserServiceModel
                {
                    Id = u.Id,
                    Username = u.UserName,
                    Email = u.Email,
                    Roles = roles
                    .Where(r => u.Roles
                                .Select(ur => ur.RoleId).Contains(r.Id))
                                .Select(r => r.Name)
                                .ToHashSet()
                });

            return result;
        }

        public async Task<int> GetUsersCount()
            => await this.userRepo
            .AllAsNoTracking()
            .CountAsync();

        //TODO: Implement Refresh Token

        public string GetJwtToken(string id, string username, IEnumerable<string> roles, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, id),
                    new Claim(ClaimTypes.Name, username),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Claims = new Dictionary<string, object>
                {
                    {"roles", roles }
                }
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);
            return encryptedToken;
        }
    }
}
