namespace PropertyInvestAuction.Server.Models.Identity
{
    using System.ComponentModel.DataAnnotations;

    using PropertyInvestAuction.Services.Mapping;
    using PropertyInvestAuction.Services.Models.Identity;

    public class LoginInputModel
    {
        [Required]
        [MaxLength(30)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
