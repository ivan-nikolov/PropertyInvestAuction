﻿namespace PropertyInvestAuction.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using PropertyInvestAuction.Data.Models;

    public class AppDbContext : IdentityDbContext <AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) {}

    }
}
