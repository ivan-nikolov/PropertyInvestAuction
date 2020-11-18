namespace PropertyInvestAuction.Server.Models.Identity
{
    using System.ComponentModel.DataAnnotations;

    public class LoginInputModel
    {
        [Required]
        [MaxLength(30)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
